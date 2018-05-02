using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using CrypterPass;


namespace DesFormatoPedido
{
    class Conexion
    {
        
        public string LineaConexion()
        {
            string linea = "", server = "", db = "", user = "", pass = "";
            server = ConfigurationManager.AppSettings["server"];
            db = ConfigurationManager.AppSettings["database"];
            user = Crypt.Desencriptar(ConfigurationManager.AppSettings["username"]);
            pass = Crypt.Desencriptar(ConfigurationManager.AppSettings["PassServ"]);
            
            linea =  "Server=" + server + ";Database=" + db + ";User id=" + user + ";Password= "+ pass+" ;Connection Timeout=7";
            return linea;
        }
    }
}
