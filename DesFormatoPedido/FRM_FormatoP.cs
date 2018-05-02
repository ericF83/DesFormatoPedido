using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Linq;
using DesFormatoPedido.Service1;
using ServiceBB;
using ServiceBB.DataContract;
//using ServiceBB;
//using ServiceBB.DataContract;

namespace DesFormatoPedido
{
    public partial class FRM_FormatoP : Form
    {
        ConsumoDB consumo = new ConsumoDB();
        
        //public List<string> listEstilo = new List<string>();
        // lista para cargar la informacoion de la base de datos primero se llenan las listas
        public List<ListaEstilos> listEstilosAres = new List<ListaEstilos>();
        public List<ListaEstilos> listEstilos = new List<ListaEstilos>();
        public List<string> listModelo = new List<string>();
        public List<string> listcolor = new List<string>();
        public List<string> listtalla = new List<string>();
        public List<string> listtallaD = new List<string>();
        public List<string> listtallaC = new List<string>();
        
        public DataTable Uni = new DataTable();
        MetodosClient met = new MetodosClient();
        
        public string bottomORtop;
        public List<ListaEstilos> lst = new List<ListaEstilos>(); //lista de estilos para agregar al grid con talla , posicion y cantidad
        public bool exist_inDatagrid = false;
        Detalle DetalleVta = new Detalle();
        List<Detalle> ListDetalleVta = new List<Detalle>();
        public FRM_FormatoP()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                GeneraXML g = new GeneraXML();
                string x = g.xmlToString("50011","ART", "SP_Cat_FormatoPedido");
                //Uni = consumo.LModelo("TOTAL");
                ////***** lineas para recibir la cadena XML directo sql***********//
                //document = consumo.xml("XML");
                //XmlReader rd = new XmlNodeReader(document);
                //DataSet dt = new DataSet();
                //dt.ReadXml(rd);
                //Uni = dt.Tables[0];
                ////***** lineas para recibir la cadena XML desde service***********//
                //document = consumo.xml_Response();
                //XmlReader rd = new XmlNodeReader(document);
                //DataSet dt = new DataSet();
                //dt.ReadXml(rd);
                //Uni = dt.Tables[0];
                ////***********lineas para recibir por acces **************//
                Uni = consumo.DatosAcces();

                var LM  = (from r in Uni.AsEnumerable()select r["Modelo"]).Distinct().ToList();
                listModelo = LM.Select(s => (string)s).ToList();
                
            }
            catch(Exception ee)
            {
                MessageBox.Show("" + ee.Message);
            }

            
        }

        void cargarLista()
        {

        }
        
        private void txtMod_TextChanged(object sender, EventArgs e)
        {

        }
        /* 
        cada que se hace click en el textbox manda llamar al forma para elegir modelo, en este caso se pasa como parametro
        a la clase FRM_Opciones, la forma principal con this para utilizar las propiedades publicas, y la lista de modelo a
        uno de sus metodos  
        */
        private void txtMod_Click(object sender, EventArgs e)
        {
            //aqui se trae los modelos a elejir
            lblClick1.Visible = false;
            lblDescrip.Text = ".";
            txtEstilo.Text = String.Empty;
            txtColor.Text = String.Empty;
            FRM_Opciones op = new FRM_Opciones(this,1);
            op.generaM(listModelo);
            op.ShowDialog(this);            
                      
        }

        private void txtEstilo_Click(object sender, EventArgs e)
        {
            //listModelo = consumo.Modelo("ESTILO",txtMod.Text);            
            FRM_Opciones op = new FRM_Opciones(this,2); // formulario donde se crean lo radioButtons de estilos
            var dValue = from row in Uni.AsEnumerable()
                         where row.Field<string>("Modelo") == txtMod.Text
                         select row.Field<string>("Familia");
            List<string> ESTI = dValue.Distinct().ToList();
            op.generaBestilos(ESTI);          
            op.ShowDialog(this);
            lblclick2.Visible = false;
            txtColor.Text = String.Empty;            
        }

        private void txtColor_Click(object sender, EventArgs e)
        {
            FRM_Opciones op = new FRM_Opciones(this, 3);
            string Tipo = "";
            try
            {
                var dValue2 = from row in Uni.AsEnumerable()
                              where row.Field<string>("Modelo") == txtMod.Text
                              && row.Field<string>("Familia") == txtEstilo.Text
                              && row.Field<string>("Opcion") == "C"
                              select row.Field<string>("ColorTalla");

                List<string> COLORES = dValue2.Distinct().ToList();
                var dValue3 = from row in Uni.AsEnumerable()
                              where row.Field<string>("Modelo") == txtMod.Text
                              && row.Field<string>("Familia") == txtEstilo.Text
                              && row.Field<string>("Opcion") == "T"
                              select row.Field<string>("ColorTalla");
                List<string> tallas = dValue3.Distinct().ToList();

                if(txtMod.Text != "" && txtEstilo.Text != "")
                {
                    var dValue4 = from row in Uni.AsEnumerable()
                                  where row.Field<string>("Modelo") == txtMod.Text
                                  && row.Field<string>("Familia") == txtEstilo.Text
                                  select row.Field<string>("Grupo");
                    Tipo = dValue4.Distinct().ToList().Single();
                }
                op.generaB(COLORES);
                lblclick3.Visible = false;
                op.ShowDialog(this);
                if (txtColor.Text != "")
                {
                    FRM_tallas t = new FRM_tallas(txtMod.Text, txtEstilo.Text, txtColor.Text, tallas, this, Tipo);
                    t.ShowDialog();
                }
                


            }
            catch(Exception er)
            {
                MessageBox.Show("error12" + er.Message);
                return;
            }
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dgvTops.Visible = false;
            if (!String.IsNullOrEmpty(txtNombre.Text) && dgvBottC.Rows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Desea guardar pedido?", "Envio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(confirm == DialogResult.Yes)
                {
                    try
                    {
                        genera_pedido();
                        GeneraPDF doPDF = new GeneraPDF(this, true);
                        doPDF.To_pdf();

                        DialogResult dr = MessageBox.Show(/*"Su pedido se a enviado," + Environment.NewLine + */" Se genero un formato PDF en al ruta: " + doPDF.rutaPDF + ", desea abrir el formato?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            //FRMvisor visor = new FRMvisor(doPDF.rutaPDF);
                            //visor.cargarPDF();
                            //visor.ShowDialog();
                            Process.Start(doPDF.rutaPDF);

                        }
                        clean();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al generar PDF, verifique que el pdf no este abierto!" + Environment.NewLine + "DETALLES: " + ex.Message,"Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }

                }
                
            }
            else
            {
                if (String.IsNullOrEmpty(txtNombre.Text))
                    MessageBox.Show("!El campo Nombre es obligatorio¡");
                else if (dgvBottC.Rows.Count == 0)
                    MessageBox.Show("!No a capturado ningun articulo¡");
            }

        }

        void genera_pedido()
        {
            DetalleList det = new DetalleList(this);
            ListDetalleVta = det.genera_pedid();
            List<VentaDstruct> d = new List<VentaDstruct>();            
            enviarPedido(ListDetalleVta);
            //MessageBox.Show("");
        }

        void enviarPedido(List<Detalle> detalle)
        {
            int cont = 1;
            MetodosClient met = new MetodosClient();
            List<VentaStruct> vnt = new List<VentaStruct>();
            List<VentaDstruct> vntd = new List<VentaDstruct>();

            DC_venta venta = new DC_venta();
            List<DC_ventaD> ventad = new List<DC_ventaD>();

            vnt.Add(new VentaStruct() {
                Empresa = "ALTAI",
                Mov = "Pedido",
                Concepto = "Ventas a distribuidores",
                Moneda = "Pesos",
                Usuario = "FMARTINEZ",
                Estatus = "SinAfectar",
                Prioridad = "Normal",
                Cliente = "HVENEGAS",
                TipoCambio = Convert.ToDecimal(1.00),
                Directo = 1,
                RenglonID = 1,
                ServicioSerie = cmbUso.Text
            });

            foreach (Detalle d in detalle)
            {
                //VentaDstruct det = new VentaDstruct();
                //det.ID = 0;
                //det.Renglon = 2048 * cont;
                //det.RenglonID = cont;
                //det.Cantidad = Convert.ToDecimal(d.Cantidad);
                //det.RenglonTipo = "N";
                //det.SubCuenta = d.Subcuenta;
                //det.Articulo = d.Articulo;
                //vntd.Add(det);
                vntd.Add(new VentaDstruct() {
                   ID = 0,
                    Renglon = 2048 * cont,
                    RenglonID = cont,
                    Cantidad = Convert.ToDecimal(d.Cantidad),
                    RenglonTipo = "N",
                    SubCuenta = d.Subcuenta,
                    Articulo = d.Articulo
            });
                cont = cont + 1;
            }
            venta.Venta = vnt;
            venta.Detalle = vntd; 

            met.DetalleVenta(venta);
            
        }

        public void AddGrid(string modelo , string estilo , string color, string talla, int cantidad)
        {
            //foreach(DataGridViewRow row in dgvBottC.Rows)
            //{

            //}
            exist_inDatagrid = dgvBottC.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["Modelo"].Value) == modelo && Convert.ToString(row.Cells["Estilo"].Value) == estilo && Convert.ToString(row.Cells["Color"].Value) == color);

            if (exist_inDatagrid)
            {
               foreach(DataGridViewRow row in dgvBottC.Rows)
                {
                   if(row.Cells["Modelo"].Value.ToString() == modelo && row.Cells["Estilo"].Value.ToString() == estilo && row.Cells["Color"].Value.ToString() == color)
                    {
                        if(lst != null)
                        foreach (ListaEstilos l in lst)
                        {
                                if (!String.IsNullOrEmpty(l.talla))
                                {
                                    row.Cells[l.posicion].Value = Convert.ToInt32(row.Cells[l.posicion].Value ?? 0) + l.cantidad;
                                    if (l.tipoS == "C" && l.tipo != "TOPS")
                                        row.Cells[l.posicion].Style.BackColor = System.Drawing.Color.LightBlue;
                                    else if (l.tipoS == "D" && l.tipo != "TOPS")
                                        row.Cells[l.posicion].Style.BackColor = System.Drawing.Color.LightPink;
                                    else if (l.tipoS == "U" && l.tipo != "TOPS" && l.talla == "UNITALLA")
                                        row.Cells[l.posicion].Style.BackColor = System.Drawing.Color.Gold;
                                    else
                                        row.Cells[l.posicion].Style.BackColor = System.Drawing.Color.WhiteSmoke;
                                }
                                    
                        }
                    }
                }
            }
            else
                dgvBottC.Rows.Add(modelo, estilo, color);
            //if (exist_inDatagrid)
            //{
            //    lst = null;
            //}


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNombre.Text) && dgvBottC.Rows.Count > 0 && cmbUso.Text != "")
            {
                try
                {
                    GeneraPDF doPDF = new GeneraPDF(this, false);
                    doPDF.To_pdf();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar PDF, verifique que el pdf no este abierto!" + Environment.NewLine + "DETALLES: " + ex.Message);
                }

            }
            else
            {
                if (String.IsNullOrEmpty(txtNombre.Text))
                    MessageBox.Show("!El campo Nombre es obligatorio¡");
                else if (dgvBottC.Rows.Count == 0)
                    MessageBox.Show("!No a capturado ningun articulo¡");
                else if (cmbUso.Text == "")
                    MessageBox.Show("Debe de capturar el uso de CFDI");
            }
            
        }

        
        private void dgvTops_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // dgvTops.Rows[e.RowIndex].Cells[]
            
        }

        private void ox (object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void dgvTops_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && dgvTops.Columns[e.ColumnIndex].Name.Equals("btnDel") && e.RowIndex != -1)
            {
                dgvTops.Rows.RemoveAt(e.RowIndex);
            }
        }

        
        private void dgvBottC_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            if(!exist_inDatagrid)
            foreach (ListaEstilos l in lst)
            {
                
             if (!String.IsNullOrEmpty(l.talla))
                 {                        
                     dgvBottC.Rows[e.RowIndex].Cells[l.posicion].Value = l.cantidad;
                     if(l.tipoS == "C" && l.tipo != "TOPS")
                        {
                            dgvBottC.Rows[e.RowIndex].Cells[l.posicion].Style.BackColor = System.Drawing.Color.LightBlue;
                            dgvBottC.Rows[e.RowIndex].Cells[dgvBottC.Columns.Count - 3].Value = l.Ncolor;
                            dgvBottC.Rows[e.RowIndex].Cells[dgvBottC.Columns.Count - 2].Value = l.articulo;
                            dgvBottC.Rows[e.RowIndex].Cells[dgvBottC.Columns.Count - 1].Value = l.tipo;
                        }                         
                     else if(l.tipoS == "D" && l.tipo != "TOPS")
                        {
                            dgvBottC.Rows[e.RowIndex].Cells[l.posicion].Style.BackColor = System.Drawing.Color.LightPink;
                            dgvBottC.Rows[e.RowIndex].Cells[dgvBottC.Columns.Count - 3].Value = l.Ncolor;
                            dgvBottC.Rows[e.RowIndex].Cells[dgvBottC.Columns.Count - 2].Value = l.articulo;
                            dgvBottC.Rows[e.RowIndex].Cells[dgvBottC.Columns.Count - 1].Value = l.tipo;
                        }                         
                     else if(l.tipoS == "U" && l.tipo != "TOPS" && l.talla == "UNITALLA")
                        {
                            dgvBottC.Rows[e.RowIndex].Cells[l.posicion].Style.BackColor = System.Drawing.Color.Gold;
                            dgvBottC.Rows[e.RowIndex].Cells[dgvBottC.Columns.Count - 3].Value = l.Ncolor;
                            dgvBottC.Rows[e.RowIndex].Cells[dgvBottC.Columns.Count - 2].Value = l.articulo;
                            dgvBottC.Rows[e.RowIndex].Cells[dgvBottC.Columns.Count - 1].Value = l.tipo;
                        }
                     else
                        {
                            dgvBottC.Rows[e.RowIndex].Cells[l.posicion].Style.BackColor = System.Drawing.Color.WhiteSmoke;
                            dgvBottC.Rows[e.RowIndex].Cells[dgvBottC.Columns.Count - 3].Value = l.Ncolor;
                            dgvBottC.Rows[e.RowIndex].Cells[dgvBottC.Columns.Count - 2].Value = l.articulo;
                            dgvBottC.Rows[e.RowIndex].Cells[dgvBottC.Columns.Count - 1].Value = l.tipo;
                        }
                         

                     if(l.tipo == "BOTTOMS" && l.tipoS == "D")
                        {
                            DataGridViewTextBoxCell cell = dgvBottC.Rows[e.RowIndex].Cells["Column14"] as DataGridViewTextBoxCell;
                            cell.ReadOnly = true;
                            DataGridViewTextBoxCell cell2 = dgvBottC.Rows[e.RowIndex].Cells["Column15"] as DataGridViewTextBoxCell;
                            cell2.ReadOnly = true;
                        }
                     if(l.tipo == "TOPS")
                        {
                            DataGridViewTextBoxCell cell14 = dgvBottC.Rows[e.RowIndex].Cells["Column14"] as DataGridViewTextBoxCell;
                            cell14.ReadOnly = true;
                            DataGridViewTextBoxCell cell15 = dgvBottC.Rows[e.RowIndex].Cells["Column15"] as DataGridViewTextBoxCell;
                            cell15.ReadOnly = true;
                            DataGridViewTextBoxCell cell13 = dgvBottC.Rows[e.RowIndex].Cells["Column13"] as DataGridViewTextBoxCell;
                            cell13.ReadOnly = true;
                            DataGridViewTextBoxCell cell12 = dgvBottC.Rows[e.RowIndex].Cells["Column12"] as DataGridViewTextBoxCell;
                            cell12.ReadOnly = true;
                            if (dgvBottC.Rows[e.RowIndex].Cells["Modelo"].Value.ToString() != "NARVI")
                            {
                                DataGridViewTextBoxCell cell11 = dgvBottC.Rows[e.RowIndex].Cells["Column11"] as DataGridViewTextBoxCell;
                                cell11.ReadOnly = true;
                                DataGridViewTextBoxCell cell1 = dgvBottC.Rows[e.RowIndex].Cells["Column1"] as DataGridViewTextBoxCell;
                                cell1.ReadOnly = true;
                            }
                            if (dgvBottC.Rows[e.RowIndex].Cells["Modelo"].Value.ToString() == "NARVI" && dgvBottC.Rows[e.RowIndex].Cells["Estilo"].Value.ToString() == "DC")
                            {
                                DataGridViewTextBoxCell cell11 = dgvBottC.Rows[e.RowIndex].Cells["Column11"] as DataGridViewTextBoxCell;
                                cell11.ReadOnly = true;                                
                            }

                            if (dgvBottC.Rows[e.RowIndex].Cells["Modelo"].Value.ToString() == "ARTIC" )
                            {
                                DataGridViewTextBoxCell cell1 = dgvBottC.Rows[e.RowIndex].Cells["Column1"] as DataGridViewTextBoxCell;
                                cell1.ReadOnly = true;
                                //DataGridViewTextBoxCell cell10 = dgvBottC.Rows[e.RowIndex].Cells["Column10"] as DataGridViewTextBoxCell;
                                //cell10.ReadOnly = true;
                                DataGridViewTextBoxCell cell9 = dgvBottC.Rows[e.RowIndex].Cells["Column9"] as DataGridViewTextBoxCell;
                                cell9.ReadOnly = true;
                                DataGridViewTextBoxCell cell8 = dgvBottC.Rows[e.RowIndex].Cells["Column8"] as DataGridViewTextBoxCell;
                                cell8.ReadOnly = true;
                                DataGridViewTextBoxCell cell11 = dgvBottC.Rows[e.RowIndex].Cells["Column11"] as DataGridViewTextBoxCell;
                                cell11.ReadOnly = true;
                                if (dgvBottC.Rows[e.RowIndex].Cells["Estilo"].Value.ToString() == "DC")
                                {
                                    DataGridViewTextBoxCell cell7 = dgvBottC.Rows[e.RowIndex].Cells["Column7"] as DataGridViewTextBoxCell;
                                    cell7.ReadOnly = true;
                                }                                
                            }
                            if (dgvBottC.Rows[e.RowIndex].Cells["Modelo"].Value.ToString() == "ZODIAC" && dgvBottC.Rows[e.RowIndex].Cells["Estilo"].Value.ToString() == "DLP")
                            {
                                //DataGridViewTextBoxCell cell10 = dgvBottC.Rows[e.RowIndex].Cells["Column10"] as DataGridViewTextBoxCell;
                                //cell10.ReadOnly = true;
                                DataGridViewTextBoxCell cell9 = dgvBottC.Rows[e.RowIndex].Cells["Column9"] as DataGridViewTextBoxCell;
                                cell9.ReadOnly = true;
                                DataGridViewTextBoxCell cell8 = dgvBottC.Rows[e.RowIndex].Cells["Column8"] as DataGridViewTextBoxCell;
                                cell8.ReadOnly = true;
                                DataGridViewTextBoxCell cell11 = dgvBottC.Rows[e.RowIndex].Cells["Column11"] as DataGridViewTextBoxCell;
                                cell11.ReadOnly = true;

                            }
                            if (dgvBottC.Rows[e.RowIndex].Cells["Modelo"].Value.ToString() == "ZODIAC" && dgvBottC.Rows[e.RowIndex].Cells["Estilo"].Value.ToString() == "CL")
                            {
                                DataGridViewTextBoxCell cell11 = dgvBottC.Rows[e.RowIndex].Cells["Column11"] as DataGridViewTextBoxCell;
                                cell11.ReadOnly = true;
                                //DataGridViewTextBoxCell cell10 = dgvBottC.Rows[e.RowIndex].Cells["Column10"] as DataGridViewTextBoxCell;
                                //cell10.ReadOnly = true;
                                DataGridViewTextBoxCell cell9 = dgvBottC.Rows[e.RowIndex].Cells["Column9"] as DataGridViewTextBoxCell;
                                cell9.ReadOnly = true;
                                DataGridViewTextBoxCell cell8 = dgvBottC.Rows[e.RowIndex].Cells["Column8"] as DataGridViewTextBoxCell;
                                cell8.ReadOnly = true;

                            }
                        }
                     if(l.tipo == "UNISEX" && l.talla == "UNITALLA")
                        {
                            dgvBottC.Rows[e.RowIndex].ReadOnly = true;
                            DataGridViewTextBoxCell cellU = dgvBottC.Rows[e.RowIndex].Cells["Column1"] as DataGridViewTextBoxCell;
                            cellU.ReadOnly = false;
                        }
                     if(l.tipo == "UNISEX" && l.talla != "UNITALLA")
                        {
                            DataGridViewTextBoxCell cell14 = dgvBottC.Rows[e.RowIndex].Cells["Column14"] as DataGridViewTextBoxCell;
                            cell14.ReadOnly = true;
                            DataGridViewTextBoxCell cell15 = dgvBottC.Rows[e.RowIndex].Cells["Column15"] as DataGridViewTextBoxCell;
                            cell15.ReadOnly = true;
                            DataGridViewTextBoxCell cell13 = dgvBottC.Rows[e.RowIndex].Cells["Column13"] as DataGridViewTextBoxCell;
                            cell13.ReadOnly = true;
                            DataGridViewTextBoxCell cell12 = dgvBottC.Rows[e.RowIndex].Cells["Column12"] as DataGridViewTextBoxCell;
                            cell12.ReadOnly = true;
                            DataGridViewTextBoxCell cell11 = dgvBottC.Rows[e.RowIndex].Cells["Column11"] as DataGridViewTextBoxCell;
                            cell11.ReadOnly = true;
                            DataGridViewTextBoxCell cell10 = dgvBottC.Rows[e.RowIndex].Cells["Column10"] as DataGridViewTextBoxCell;
                            cell10.ReadOnly = true;
                        }

                 }
                    
            }
            
                

            lst = null;
        }
        private void txtCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void dgvBottC_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DialogResult dr;
                dgvBottC.Rows[e.RowIndex].Selected = true;
                dr = MessageBox.Show("Desea eliminar este registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(DialogResult.Yes == dr)
                {
                    if (!String.IsNullOrEmpty(txtTotal.Text))
                        txtTotal.Text = Convert.ToString(Convert.ToInt32(txtTotal.Text) - Convert.ToInt32(dgvBottC.Rows[e.RowIndex].Cells["Total"].Value ?? 0));
                    dgvBottC.Rows.RemoveAt(e.RowIndex);                   
                }
                else
                    dgvBottC.Rows[e.RowIndex].Selected = false;
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;     
            
        }

        private void txtCiud_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void txtFact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void txtEdo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void txtCalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void txtTrasp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void txtCP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void txtMuni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void txtMod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void txtEstilo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void txtColor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void dgvBottC_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int total = 0;
            int totalF = 0;
            int numeroCell = 0;
            if (dgvBottC.Columns[e.ColumnIndex].Name != "Modelo" && dgvBottC.Columns[e.ColumnIndex].Name != "Color" && dgvBottC.Columns[e.ColumnIndex].Name != "Estilo" && dgvBottC.Columns[e.ColumnIndex].Name != "" && dgvBottC.Columns[e.ColumnIndex].Name != "Total")
            {
                int ValorCelda = 0;                
                    int valor = 0;
                    int totalfila = 0;
                    for (int x = 3; x <= 17; x++)
                    {
                        System.Drawing.Color clr = new System.Drawing.Color();
                        if (dgvBottC.Rows[e.RowIndex].Cells[x].Style.BackColor == System.Drawing.Color.LightBlue || dgvBottC.Rows[e.RowIndex].Cells[x].Style.BackColor == System.Drawing.Color.LightPink || dgvBottC.Rows[e.RowIndex].Cells[x].Style.BackColor == System.Drawing.Color.LightYellow )
                            clr = dgvBottC.Rows[e.RowIndex].Cells[x].Style.BackColor;
                        if (int.TryParse(Convert.ToString(dgvBottC.Rows[e.RowIndex].Cells[x].Value), out valor))
                        {                            
                            ValorCelda = Convert.ToInt32(dgvBottC.Rows[e.RowIndex].Cells[x].Value);
                            totalfila = totalfila + ValorCelda;
                            //total = total + ValorCelda;
                            dgvBottC.Rows[e.RowIndex].Cells[x].Style.BackColor = clr;
                            dgvBottC.Rows[e.RowIndex].Cells["Total"].Value = Convert.ToString(totalfila);
                        }
                          
                    }

                foreach (DataGridViewRow row in dgvBottC.Rows)
                {
                    int OUT_N = 0;
                    for (int x = 3; x <= 17; x++)
                    {
                        try
                        {
                            OUT_N = Convert.ToInt32(row.Cells[x].Value);
                        }
                        catch (Exception ex)
                        {
                            OUT_N = 0;
                        }              
                        totalF = totalF + OUT_N; 
                        total = total + ValorCelda;
                        txtTotal.Text = Convert.ToString(totalF);
                    }                  
                }

                
            }


        }

        private void dgvBottC_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            System.Drawing.Color clr = new System.Drawing.Color();
            if (dgvBottC.Columns[e.ColumnIndex].Name != "Modelo" && dgvBottC.Columns[e.ColumnIndex].Name != "Color" && dgvBottC.Columns[e.ColumnIndex].Name != "Estilo" && dgvBottC.Columns[e.ColumnIndex].Name != "" && e.ColumnIndex > 3)
            {
                foreach (DataGridViewRow row in dgvBottC.Rows)
                {
                    int valor = 0;
                    for (int x = 3; x <= 17; x++)
                    {
                        
                        if (dgvBottC.Rows[e.RowIndex].Cells[x].Style.BackColor == System.Drawing.Color.LightBlue || dgvBottC.Rows[e.RowIndex].Cells[x].Style.BackColor == System.Drawing.Color.LightPink || dgvBottC.Rows[e.RowIndex].Cells[x].Style.BackColor == System.Drawing.Color.Gold)               
                        {
                            clr = dgvBottC.Rows[e.RowIndex].Cells[x].Style.BackColor;
                            dgvBottC.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = System.Drawing.Color.FromName(clr.Name);
                        }
                        
                    }                    
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            txtMod_Click(sender, e);
            lblClick1.Visible = false;
        }

        private void lblclick2_Click(object sender, EventArgs e)
        {
            txtEstilo_Click(sender, e);
            lblclick2.Visible = false;
        }

        private void lblclick3_Click(object sender, EventArgs e)
        {
            txtColor_Click(sender, e);
            lblclick3.Visible = false;
        }

        private void txtMod_TextChanged_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMod.Text))
                lblClick1.Visible = true;
        }

        public void clean()
        {
            foreach (TextBox tx in this.Controls.OfType<TextBox>())
            {
                tx.Text = String.Empty;
            }

            dgvBottC.Rows.Clear();
            bottomORtop = "";
            exist_inDatagrid = false;
        }

        private void verFormatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEnviar.PerformClick();
        }

        private void verFormatoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFormato.PerformClick();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.ShowDialog();
        }

    }
}
