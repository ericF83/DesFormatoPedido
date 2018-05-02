using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesFormatoPedido
{
    public partial class FRM_tallas : Form
    {
        string Modelo, Estilo, Color;
        List<ListaEstilos> listaEstilos = new List<ListaEstilos>();
        List<string> listaEstilos1 = new List<string>();
        List<string> Tallas = new List<string>();
        FRM_FormatoP FP = new FRM_FormatoP();
        int cont = 0;
        int x = 10, y = 15;
        List<ListaEstilos> lstTC = new List<ListaEstilos>();
        string tipoS = "";
        string tipo = "";
        int posicion = 3;

        public string tipos ()
        {
            string ret = "";
            var dValue1 = from row in FP.Uni.AsEnumerable()
                          where row.Field<string>("Modelo") == Modelo
                          && row.Field<string>("Familia") == Estilo
                          //&& row.Field<int>("C") == 3
                          select row.Field<string>("tipoS");

            List<string> er1 = dValue1.Distinct().ToList();
            ret = er1[0];
            return ret;
        }

        private void btnEnviar_Click_1(object sender, EventArgs e)
        {
            FP.txtColor.Text = String.Empty;
            foreach (object obj in pnlTalla.Controls)
            {
                if (obj.GetType() == typeof(obj_SelecCantidad))
                {
                    ListaEstilos l = new ListaEstilos();
                    obj_SelecCantidad x = obj as obj_SelecCantidad;
                    if (x.txtNo.Text != "")
                    {
                        if (this.Modelo == "ARTIC")
                            x.pocision += 1;
                        l.talla = x.lbltalla.Text;
                        l.cantidad = Convert.ToInt32(x.txtNo.Text);
                        l.posicion = x.pocision;
                        l.tipoS = tipos();
                        l.tipo = this.tipo;                       
                    }
                    lstTC.Add(l);
                }
            }
            
                FP.lst = lstTC;
                FP.AddGrid(this.Modelo, this.Estilo, this.Color, "", 0);            
            this.Close();
        }

        public FRM_tallas(string mod, string est, string color, List<string> lst, FRM_FormatoP fp,string tipo)
        {
            InitializeComponent();
            this.Modelo = mod;
            this.Estilo = est;
            this.Color = color;
            this.Tallas = lst;
            this.tipo = tipo;
            //this.Tallas = tall;
            this.FP = fp;
        }

        private void FRM_tallas_Load(object sender, EventArgs e)
        {
            int widhtF = this.Width;            
            int widhtP = this.pnlTalla.Width;
            int xBtn = this.btnEnviar.Location.X;
            
            foreach (string t in this.Tallas)
            {
                        cont++;
                        controlesAdd(t, x, y, posicion);
                        posicion++;
                        x = x + 40;
                if (cont > 2)
                {
                    widhtF = widhtF + 35;                    
                    widhtP = widhtP + 35;
                    xBtn = xBtn + 35;                    
                }
            }
            this.Size = new Size(widhtF, 190);
            this.pnlTalla.Size = new Size(widhtP, 132);
            this.btnEnviar.Location = new Point(xBtn, 85);
        }

        private void controlesAdd(string talla, int x, int y, int cont, string tipo = "")
        {
            

            obj_SelecCantidad selec = new obj_SelecCantidad();
            if (talla == "UNITALLA")
                selec.move();
            selec.lbltalla.Text = talla;
            selec.txtNo.Text = "";
            selec.pocision = cont;
            selec.Location = new System.Drawing.Point(x, y);
            selec.Enabled = habilitar(talla);
            //selec.Size = new Size(70, 27);
            //selec.txtNo.Location = new Point(37, 3);
                     
            pnlTalla.Controls.Add(selec);
        }

        public bool habilitar(string talla)
        {
            bool ret = true;
            List<string> excluirM = new List<string>() {  "EURO", "IO", "LYON", "THYONE" };
            List<string> St = new List<string>() { "CL","DLP","CC"};
            List<string> Clr = new List<string>() { "AZUL REY", "KHAKI" , "NARANJA", "AMARILLO", "VERDE", "TINTO", "AZUL FRANCIA", "GRIS ACERO", "LAGO", "UVA" };
            List<string> T = new List<string>() { "3XL", "4XL" };

            if (excluirM.Contains(Modelo) && St.Contains(Estilo) && Clr.Contains(Color) && T.Contains(talla))
                ret = false;

            //if (Modelo == "SUPER POP" && SuperPopSt.Contains(Estilo) && SuperPopClr.Contains(Color) && SuperPopT.Contains(talla))
            //    ret = false;

            List<string> ArticSt = new List<string>() { "DC" };
            List<string> ArticClr = new List<string>() { "ROJO", "NEGRO" , "GRIS" };
            List<string> ArticT = new List<string>() { "2XL" };
            if (Modelo == "ARTIC" && ArticSt.Contains(Estilo) && ArticClr.Contains(Color) && ArticT.Contains(talla))
                ret = false;

            //List<string> IoSt = new List<string>() { "CL", "DLP" };
            //List<string> IoClr = new List<string>() { "AMARILLO" };
            //List<string> IoT = new List<string>() { "3XL", "4XL" };
            //if (Modelo == "IO" && IoSt.Contains(Estilo) && IoClr.Contains(Color) && IoT.Contains(talla))
            //    ret = false;

            //List<string> LyonSt = new List<string>() { "CL", "DLP" };
            //List<string> LyonClr = new List<string>() { "LAGO", "UVA" };
            //List<string> LyonT = new List<string>() { "3XL", "4XL" };
            //if (Modelo == "LYON" && LyonSt.Contains(Estilo) && LyonClr.Contains(Color) && LyonT.Contains(talla))
            //    ret = false;

            //List<string> ThyoneSt = new List<string>() { "CL", "DLP" };
            //List<string> ThyoneClr = new List<string>() { "AZUL FRANCIA", "GRIS ACERO" };
            //List<string> ThyoneT = new List<string>() { "3XL", "4XL" };
            //if (Modelo == "THYONE" && ThyoneSt.Contains(Estilo) && LyonClr.Contains(Color) && LyonT.Contains(talla))
            //    ret = false;

            return ret;

        }
    }
}
