using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DesFormatoPedido.Service1;
using ServiceBB.DataContract;

namespace DesFormatoPedido
{
    public partial class FRMloginCte : Form
    {
        MetodosClient met = new MetodosClient();
       
        DC_datosCte datCte = new DC_datosCte();
        public FRMloginCte()
        {
            InitializeComponent();
        }

        private void txtNombreCte_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                
                datCte =  met.datosCte(txtNombreCte.Text);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }


    }
}
