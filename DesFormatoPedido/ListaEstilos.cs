using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesFormatoPedido.Service1;

namespace DesFormatoPedido
{
    public class ListaEstilos
    {
        MetodosClient met = new MetodosClient();
        public string estilo { get; set; }
        public string descripcion { get; set; }

        public string tipo { get; set; }

        public string tipoS { get; set; }

        ////////////////////////////////////////

        public string talla { get; set; }

        public int cantidad { get; set; }

        public int posicion { get; set; }

        public string articulo { get; set; }

        public string color { get; set; }

        string Color = "";
        public string Ncolor { get { return this.Color; } set { this.Color = AsignaColor(value); } }

        private string AsignaColor( string value)
        {
            string ret="";
            ret = met.Ncolor(value);
            return ret;
        }
    }
}
