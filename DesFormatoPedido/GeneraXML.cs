using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace DesFormatoPedido
{
    public class GeneraXML
    {
        public GeneraXML()
        {
            
        }

        public string xmlToString(string appid,string tabla, string tipo)
        {
            string cadena = "";
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", ""));
            
            XmlElement raiz = doc.CreateElement("Solicitud");
            doc.AppendChild(raiz);

            XmlElement nodo = doc.CreateElement("AppID");
            nodo.AppendChild(doc.CreateTextNode(appid));
            raiz.AppendChild(nodo);

            nodo = doc.CreateElement("Tabla");
            nodo.AppendChild(doc.CreateTextNode(tabla));
            raiz.AppendChild(nodo);

            nodo = doc.CreateElement("Tipo");
            nodo.AppendChild(doc.CreateTextNode("SP_Cat_FormatoPedido"));
            raiz.AppendChild(nodo);

            //cadena = doc;
            
            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter tx = new XmlTextWriter(sw))
                {
                    doc.WriteTo(tx);
                    cadena = sw.ToString();
                    
                }
            }
            return cadena;

        }

       
    }
}
