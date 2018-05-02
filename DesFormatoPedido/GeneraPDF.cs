using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;


namespace DesFormatoPedido
{
    public class GeneraPDF
    {
        FRM_FormatoP FP = new FRM_FormatoP();
        bool guardar = false;
        public string rutaPDF = ""; 
        public GeneraPDF ( FRM_FormatoP fp, bool Guardar)
        {
            this.FP = fp;
            this.guardar = Guardar;
        }

        internal static string CrearEtiqueta()
        {

            string etiqueta = null;
            DateTime fecha = DateTime.Now;
            etiqueta = fecha.ToShortDateString().Replace("/", "");
            etiqueta += "_" + fecha.ToShortTimeString().Replace(":", "");
            etiqueta = etiqueta.Replace(".", "");
            return etiqueta;

        }

        public void To_pdf()
        {
            Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
            
            if (!Directory.Exists(@"C:\PedidosBingBang"))
                Directory.CreateDirectory(@"C:\PedidosBingBang");

            if (!Directory.Exists(@"C:\reptemp"))
                Directory.CreateDirectory(@"C:\reptemp");

            foreach (string fichero in Directory.GetFiles(@"C:\reptemp", "*.pdf"))
                File.Delete(fichero);

            string filename = "PEDIDO_" + CrearEtiqueta() + ".pdf";
            
            if (filename.Trim() != "")
            {
                
                PdfWriter.GetInstance(doc, new FileStream(@"C:\reptemp\" + filename, FileMode.Create));
                doc.Open();

                iTextSharp.text.Image imagenlogo;
                string dirLOgo = Application.StartupPath + @"\logo big uniformes1.png";
                imagenlogo = iTextSharp.text.Image.GetInstance(dirLOgo);
                //Properties.Resources.logo_big_uniformes;//Dirreccion a la imagen que se hace referencia
                imagenlogo.SetAbsolutePosition(30, doc.PageSize.Height - 100); //Posicion en el eje cartesiano
                imagenlogo.ScaleAbsoluteWidth(200); //Ancho de la imagen
                imagenlogo.ScaleAbsoluteHeight(70); //Altura de la imagen
                doc.Add(imagenlogo); //Agrega la imagen al documento
                //////////////////////// TABLA ENCABEZADO//////////////////////////////////////////////////////
                iTextSharp.text.Font tipoFont = FontFactory.GetFont("arial", 6, 3, BaseColor.BLACK);
                iTextSharp.text.Font tipoFontCont = FontFactory.GetFont("arial", 6, BaseColor.BLUE);
                iTextSharp.text.Font coloraviso = FontFactory.GetFont("arial", 12, BaseColor.RED);
                DateTime fechaHoy = DateTime.Today;
                float[] widths = new float[] { 2f, 1f, 1f, 2f };
                PdfPTable table = new PdfPTable(4);
                table.TotalWidth = 300f;
                table.LockedWidth = true;
                table.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.SetWidths(widths);
                var backCell = System.Drawing.Color.LightGray;
                var backCellDatos = System.Drawing.Color.WhiteSmoke;
                var colorBorde = System.Drawing.Color.Gray;

                /////// CELDAS ENCABEZADO
                PdfPCell fecha = new PdfPCell(new Phrase("FECHA:", tipoFont));
                fecha.Border = 0;
                fecha.HorizontalAlignment = 2;
                fecha.BackgroundColor = new BaseColor(backCell);
                fecha.BorderColor = new BaseColor(colorBorde);
                fecha.BorderWidthBottom = 1f;
                table.AddCell(fecha);

                PdfPCell DATOfecha = new PdfPCell(new Phrase("   " + fechaHoy.ToString("dd-MM-yyyy"), tipoFontCont));
                DATOfecha.BackgroundColor = new BaseColor(backCellDatos);
                DATOfecha.Border = 0;
                DATOfecha.Colspan = 3;
                DATOfecha.BorderColor = new BaseColor(colorBorde);
                DATOfecha.BorderWidthBottom = 1f;
                table.AddCell(DATOfecha);

                //table.AddCell("Cell 2");
                PdfPCell CTE = new PdfPCell(new Phrase("CLIENTE:", tipoFont));
                CTE.Border = 0;
                CTE.HorizontalAlignment = 2;
                CTE.BackgroundColor = new BaseColor(backCell);
                //CTE.Colspan = 4;
                CTE.BorderColor = new BaseColor(colorBorde);
                CTE.BorderWidthBottom = 1f;
                table.AddCell(CTE);

                PdfPCell NomCTE = new PdfPCell(new Phrase("   " + FP.txtNombre.Text, tipoFontCont));
                NomCTE.BackgroundColor = new BaseColor(backCellDatos);
                NomCTE.Border = 0;
                NomCTE.Colspan = 3;
                NomCTE.BorderColor = new BaseColor(colorBorde);
                NomCTE.BorderWidthBottom = 1f;
                table.AddCell(NomCTE);

                PdfPCell FACT = new PdfPCell(new Phrase("FACTURA A:", tipoFont));
                FACT.Border = 0;
                FACT.HorizontalAlignment = 2;
                FACT.BackgroundColor = new BaseColor(backCell);
                //FACT.Colspan = 4;
                FACT.BorderColor = new BaseColor(colorBorde);
                FACT.BorderWidthBottom = 1f;
                table.AddCell(FACT);

                PdfPCell Nomfact = new PdfPCell(new Phrase("   " + FP.txtFact.Text, tipoFontCont));
                Nomfact.BackgroundColor = new BaseColor(backCellDatos);
                Nomfact.Border = 0;
                Nomfact.Colspan = 3;
                Nomfact.BorderColor = new BaseColor(colorBorde);
                Nomfact.BorderWidthBottom = 1f;
                table.AddCell(Nomfact);

                PdfPCell cOLONIA = new PdfPCell(new Phrase("CALLE, NUMERO Y COLONIA:", tipoFont));
                cOLONIA.Border = 0;
                cOLONIA.HorizontalAlignment = 2;
                cOLONIA.BackgroundColor = new BaseColor(backCell);
                //cOLONIA.Colspan = 2;
                cOLONIA.BorderColor = new BaseColor(colorBorde);
                cOLONIA.BorderWidthBottom = 1f;
                table.AddCell(cOLONIA);

                PdfPCell dATOcolonia = new PdfPCell(new Phrase("   " + FP.txtCalle.Text, tipoFontCont));
                dATOcolonia.BackgroundColor = new BaseColor(backCellDatos);
                dATOcolonia.Border = 0;
                dATOcolonia.Colspan = 3;
                dATOcolonia.BorderColor = new BaseColor(colorBorde);
                dATOcolonia.BorderWidthBottom = 1f;
                table.AddCell(dATOcolonia);

                PdfPCell CP = new PdfPCell(new Phrase("CP:", tipoFont));
                CP.Border = 0;
                CP.HorizontalAlignment = 2;
                CP.BackgroundColor = new BaseColor(backCell);
                CP.BorderColor = new BaseColor(colorBorde);
                CP.BorderWidthBottom = 1f;
                table.AddCell(CP);

                PdfPCell DATOCP = new PdfPCell(new Phrase("   " + FP.txtCP.Text, tipoFontCont));
                DATOCP.BackgroundColor = new BaseColor(backCellDatos);
                DATOCP.Border = 0;
                DATOCP.Colspan = 3;
                DATOCP.BorderColor = new BaseColor(colorBorde);
                DATOCP.BorderWidthBottom = 1f;
                table.AddCell(DATOCP);

                PdfPCell MPIO = new PdfPCell(new Phrase("MUNICIPIO:", tipoFont));
                MPIO.Border = 0;
                MPIO.HorizontalAlignment = 2;
                MPIO.BackgroundColor = new BaseColor(backCell);
                MPIO.BorderColor = new BaseColor(colorBorde);
                MPIO.BorderWidthBottom = 1f;
                table.AddCell(MPIO);

                PdfPCell DATOMPIO = new PdfPCell(new Phrase("   " + FP.txtMuni.Text, tipoFontCont));
                DATOMPIO.BackgroundColor = new BaseColor(backCellDatos);
                DATOMPIO.Border = 0;
                DATOMPIO.Colspan = 3;
                DATOMPIO.BorderColor = new BaseColor(colorBorde);
                DATOMPIO.BorderWidthBottom = 1f;
                table.AddCell(DATOMPIO);

                PdfPCell CD = new PdfPCell(new Phrase("CUIDAD:", tipoFont));
                CD.Border = 0;
                CD.HorizontalAlignment = 2;
                CD.BackgroundColor = new BaseColor(backCell);
                CD.BorderColor = new BaseColor(colorBorde);
                CD.BorderWidthBottom = 1f;
                table.AddCell(CD);

                PdfPCell DATOCD = new PdfPCell(new Phrase("   " + FP.txtCiud.Text, tipoFontCont));
                DATOCD.BackgroundColor = new BaseColor(backCellDatos);
                DATOCD.Border = 0;
                DATOCD.Colspan = 3;
                DATOCD.BorderColor = new BaseColor(colorBorde);
                DATOCD.BorderWidthBottom = 1f;
                table.AddCell(DATOCD);

                PdfPCell EDO = new PdfPCell(new Phrase("ESTADO:", tipoFont));
                EDO.Border = 0;
                EDO.HorizontalAlignment = 2;
                EDO.BackgroundColor = new BaseColor(backCell);
                EDO.BorderColor = new BaseColor(colorBorde);
                EDO.BorderWidthBottom = 1f;
                table.AddCell(EDO);

                PdfPCell DATOEDO = new PdfPCell(new Phrase("   " + FP.txtEdo.Text, tipoFontCont));
                DATOEDO.BackgroundColor = new BaseColor(backCellDatos);
                DATOEDO.Border = 0;
                DATOEDO.Colspan = 3;
                DATOEDO.BorderColor = new BaseColor(colorBorde);
                DATOEDO.BorderWidthBottom = 1f;
                table.AddCell(DATOEDO);
                
                PdfPCell TRASP = new PdfPCell(new Phrase("TRASPORTE:", tipoFont));
                TRASP.Border = 0;
                TRASP.HorizontalAlignment = 2;
                TRASP.BackgroundColor = new BaseColor(backCell);
                TRASP.BorderColor = new BaseColor(colorBorde);
                TRASP.BorderWidthBottom = 1f;
                table.AddCell(TRASP);

                PdfPCell DATOTRASP = new PdfPCell(new Phrase("   " + FP.txtTrasp.Text, tipoFontCont));
                DATOTRASP.BackgroundColor = new BaseColor(backCellDatos);
                DATOTRASP.Border = 0;
                DATOTRASP.Colspan = 3;
                DATOTRASP.BorderColor = new BaseColor(colorBorde);
                DATOTRASP.BorderWidthBottom = 1f;
                table.AddCell(DATOTRASP);

                PdfPCell USO = new PdfPCell(new Phrase("USO CFDI:", tipoFont));
                USO.Border = 0;
                USO.HorizontalAlignment = 2;
                USO.BackgroundColor = new BaseColor(backCell);
                USO.BorderColor = new BaseColor(colorBorde);
                USO.BorderWidthBottom = 1f;
                table.AddCell(USO);

                PdfPCell DATOUSO = new PdfPCell(new Phrase("   " + FP.cmbUso.Text, tipoFontCont));
                DATOUSO.BackgroundColor = new BaseColor(backCellDatos);
                DATOUSO.Border = 0;
                DATOUSO.Colspan = 3;
                DATOUSO.BorderColor = new BaseColor(colorBorde);
                DATOUSO.BorderWidthBottom = 1f;
                table.AddCell(DATOUSO);

                doc.Add(table);
                ////////////////////////////////////////////////////////7
                iTextSharp.text.Font ARIAL = FontFactory.GetFont("ARIAL", 10, 3);
                ARIAL.Color = new iTextSharp.text.BaseColor(255, 0, 0);
                // Chunk begin = new Chunk("IMPORTANTE", ARIAL);
                Chunk chunk = new Chunk("IMPORTANTE", ARIAL);
                doc.Add(new Paragraph(chunk));
                doc.Add(new Paragraph("Una vez realizado el pedido y además siendo verificado y aceptado por el cliente, se les informa que no se aceptan devoluciones."));
                doc.Add(new Paragraph("    "));
                GenerarDocumento(doc);                
                doc.Close();
                
                
                if (!this.guardar)
                {
                    //FRMvisor visor = new FRMvisor(Application.StartupPath + @"\repPDF\" + filename);
                    //visor.cargarPDF();
                    //visor.ShowDialog();
                    Process.Start(@"C:\reptemp\" + filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
                }
                else
                {
                    File.Copy(@"C:\reptemp\" + filename, @"C:\PedidosBingBang\" + filename, true);
                    rutaPDF = @"C:\PedidosBingBang\" + filename;
                }
                    
            }

        }
        public void GenerarDocumento(Document document)
        {
            int i, j;
            int contRows = 0;
            System.Drawing.Color back;
            bool bandMas40 = false;
            iTextSharp.text.Font tipoheader = FontFactory.GetFont("arial", 6, 3, BaseColor.BLACK);
            iTextSharp.text.Font tipoFontCell = FontFactory.GetFont("arial", 5, BaseColor.BLUE);
            iTextSharp.text.Font tipoTotal = FontFactory.GetFont("arial", 5, BaseColor.BLUE);
            var colorBorde = System.Drawing.Color.Gray;
            PdfPTable datatable = new PdfPTable(FP.dgvBottC.ColumnCount - 3);
            datatable.DefaultCell.Padding = 3;
            float[] headerwidths = GetTamañoColumnas(FP.dgvBottC);
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            //datatable.DefaultCell.BorderWidth = 1;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPTable table2 = new PdfPTable(FP.dgvBottC.ColumnCount - 3);
            table2.DefaultCell.Padding = 3;
            table2.SetWidths(headerwidths);
            table2.WidthPercentage = 100;
            table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER; 


            for (int z = 0; z < FP.dgvBC.ColumnCount; z++)
            {
                PdfPCell BC = new PdfPCell(new Phrase(FP.dgvBC.Columns[z].HeaderText, tipoheader));
                BC.BorderColor = new BaseColor(colorBorde);
                BC.BackgroundColor = new BaseColor(System.Drawing.Color.FromName("LightBlue"));
                if (z == 0)
                    BC.Colspan = 3;
                datatable.AddCell(BC);
                table2.AddCell(BC);
            }

            for (int y = 0; y < FP.dgvBD.ColumnCount; y++)
            {
                PdfPCell BD = new PdfPCell(new Phrase(FP.dgvBD.Columns[y].HeaderText, tipoheader));
                BD.BorderColor = new BaseColor(colorBorde);
                BD.BackgroundColor = new BaseColor(System.Drawing.Color.LightPink);
                if (y == 0)
                    BD.Colspan = 3;
                datatable.AddCell(BD);
                table2.AddCell(BD);
            }

            for (int e = 0; e < FP.dgvTops.ColumnCount; e++)
            {
                PdfPCell tops = new PdfPCell(new Phrase(FP.dgvTops.Columns[e].HeaderText, tipoheader));
                tops.BorderColor = new BaseColor(colorBorde);
                tops.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);
                if (e == 0)
                    tops.Colspan = 3;
                datatable.AddCell(tops);
                table2.AddCell(tops);
            }

            for (int x = 0; x < FP.dgvUni.ColumnCount; x++)
            {
                PdfPCell uni = new PdfPCell(new Phrase(FP.dgvUni.Columns[x].HeaderText, tipoheader));
                uni.BorderColor = new BaseColor(colorBorde);
                uni.BackgroundColor = new BaseColor(System.Drawing.Color.Yellow);
                if (x==0)
                    uni.Colspan = 3;
                datatable.AddCell(uni);
                table2.AddCell(uni);
            }
            for (i = 0; i < FP.dgvBottC.ColumnCount - 3; i++)
            {
                PdfPCell column = new PdfPCell(new Phrase(FP.dgvBottC.Columns[i].HeaderText, tipoheader));
                column.BorderColor = new BaseColor(colorBorde);
                datatable.AddCell(column);
                table2.AddCell(column);
            }
            datatable.HeaderRows = 1;
            table2.HeaderRows = 1;
            
            //datatable.DefaultCell.BorderWidth = 1;
            string frase = "";
            for (i = 0; i < FP.dgvBottC.Rows.Count; i++)
            {
                contRows++;
                for (j = 0; j < FP.dgvBottC.Columns.Count - 3; j++)
                {
                    if (FP.dgvBottC[j, i].Value == null)
                        frase = "";
                    else
                        frase = FP.dgvBottC[j, i].Value.ToString();

                    PdfPCell cell = new PdfPCell(new Phrase(frase, tipoFontCell));
                    var color = FP.dgvBottC[j, i].Style.BackColor;
                    if( color.Name == "LightBlue")
                        cell.BackgroundColor = new BaseColor(System.Drawing.Color.LightBlue);
                    else if (color.Name == "LightPink")
                        cell.BackgroundColor = new BaseColor(System.Drawing.Color.LightPink);
                    else if (color.Name == "Yellow")
                        cell.BackgroundColor = new BaseColor(System.Drawing.Color.Yellow);
                    else if (color.Name == "WhiteSmoke")
                        cell.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);
                    else
                    {
                        if(i % 2 == 0)
                            cell.BackgroundColor = new BaseColor(System.Drawing.Color.LightGray);
                        
                    }
                    cell.Border = Rectangle.BOX;
                    cell.BorderColor = new BaseColor(colorBorde);
                    if(contRows < 40)
                        datatable.AddCell(cell);//En esta parte, se esta agregando un renglon por cada registro en el datagrid
                    if (contRows >= 40 && contRows < 80)
                    {
                       table2.AddCell(cell);
                        bandMas40 = true;
                    }
                    //else if( i >= 80 && i < 120)
                    //{

                    //}
                    //else if( i >= 120 && i < 160)
                    //{

                    //}

                }
                
            }
            PdfPCell total = new PdfPCell(new Phrase("TOTAL ARTICULOS:",tipoFontCell));
            total.Colspan = 18;
            total.BorderColor = new BaseColor(colorBorde);
            total.BorderWidthBottom = 0;
            total.BorderWidthLeft = 0;
            total.BorderWidthTop = 0;
            total.HorizontalAlignment = 2;
            
            PdfPCell Ntotal = new PdfPCell(new Phrase(FP.txtTotal.Text, tipoFontCell));
            Ntotal.BorderColor = new BaseColor(colorBorde);
            if (!bandMas40)
            {
                datatable.AddCell(total);
                datatable.AddCell(Ntotal);
            }
                


            datatable.CompleteRow();
            document.Add(datatable);
            if(bandMas40)
            {
                document.NewPage();
                table2.AddCell(total);
                table2.AddCell(Ntotal);
                table2.CompleteRow();
                document.Add(table2);
            }
                      
                
        }

        public PdfPCell generaCellHeadaer( DataGridView dt , iTextSharp.text.Font fnt, string color)
        {
            PdfPCell BC = new PdfPCell();
            for (int z = 0; z < dt.ColumnCount; z++)
            {
                BC = new PdfPCell(new Phrase(dt.Columns[z].HeaderText, fnt));
                BC.BorderColor = new BaseColor(System.Drawing.Color.Gray);
                BC.BackgroundColor = new BaseColor(System.Drawing.Color.FromName(color));
                if (z == 0)
                    BC.Colspan = 3;
            }
            return BC;
        }
        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount - 3];
            for (int i = 0; i < dg.ColumnCount - 3; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;

        }
    }
}
