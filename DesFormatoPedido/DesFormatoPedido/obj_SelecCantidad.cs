using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesFormatoPedido
{
    public struct obj_talla
    {
        public string tipo;
        public string talla;
        public int cantidad;
    }
    public partial class obj_SelecCantidad : UserControl
    {
        internal string tipo;
        internal string talla;
        internal int cantidad;
        internal int pocision = 0;
        obj_talla Tallas;
        internal int x, y;
        internal obj_SelecCantidad()
        {
            InitializeComponent();
            Tallas = new obj_talla();
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void SelecCantidad_Load(object sender, EventArgs e)
        {
           
        }

        public void move()
        {
            this.Size = new Size(100, 50);
            //txtNo.Location = new Point(66, 3);
        }
    }
}
