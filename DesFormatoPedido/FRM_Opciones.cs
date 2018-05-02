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
    public partial class FRM_Opciones : Form
    {
        private FRM_FormatoP f;
        private int mandar;
        
        /* toma como parametro del construcor la forma primcipal para hacer uso de sus propiedades publicas, 
         el parametro int es para saber que tipo de lista va a desplegar los radioButtoms son dinamicos */
        public FRM_Opciones( FRM_FormatoP p, int mandaTxt)
        {
            InitializeComponent();
            f = p;
            this.mandar = mandaTxt;
        }

        /* mandar, indica que texto de encabezado se pone al formulario*/
        private void FRM_Opciones_Load(object sender, EventArgs e)
        {
            if (mandar == 2) 
                this.Text = "ESTILOS";
            else if (mandar == 3)
                this.Text = "COLORES";
        }

        /*evento para saber cual radioButtom fue cickiado y con el parametro f que es una referencia del formulario principal
         manda al textbox ya sea modelo o estilo la eleccion junto con la descripcion, este evento se hereda a todos la radioButtom 
         que se generaron*/
        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;
                if (mandar == 1)
                    f.txtMod.Text = rb.Text;
                else if (mandar == 2)
                {
                    f.txtEstilo.Text = rb.Text;
                    var dValue1 = from row in f.Uni.AsEnumerable()
                                  where row.Field<string>("Modelo") == f.txtMod.Text
                                  && row.Field<string>("Familia") == rb.Text
                                  //&& row.Field<int>("C") == 3
                                  select row.Field<string>("Descripcion");

                    List<string> er1 = dValue1.Distinct().ToList();
                    f.lblDescrip.Text = "Descripcion: " + er1[0];                    
                }
                else if (mandar == 3)
                    f.txtColor.Text = rb.Text;

                this.Close();
            }
        }

        private void FRM_Opciones_Click(object sender, EventArgs e)
        {
           
        }
        /* este metos es utilizado para generar dinamicamente los radioButtoms segun la lista string que se le envie (colores)*/
        public void generaB(List<string> lst)
        {
            this.Size = new Size(153, 211);
            agregar(lst);
        }
        /**/
        public void generaM(List<string> lst)
        {
            this.Size = new Size(153, 211);
            agregar(lst);
        }

        public void generaBestilos(List<string> listaF)
        {
            this.Size = new Size(153, 211);
            agregar(listaF);
        }

        public void agregar(List<string> lst)
        {
            int x = 10, y = 25, cont = 0;
            int sizeWidth = this.Size.Width;

            foreach (string s in lst)
            {
                if (cont == 5)
                {
                    x = x + 125;
                    y = 25;
                    cont = 0;
                    sizeWidth = sizeWidth + 127;
                    this.Size = new Size(sizeWidth, 211);
                }

                RadioButton radio = new RadioButton();
                radio.Text = s.ToString();
                radio.Size = new Size(125, 20);
                radio.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
                radio.Location = new Point(x, y);
                this.Controls.Add(radio);
                y += 25;
                cont++;
            }
        }
    }
}
