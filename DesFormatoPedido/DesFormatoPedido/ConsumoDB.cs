using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Data.OleDb;
using static DesFormatoPedido.ClsConexionAcces;
using DesFormatoPedido.WebRef;
using System.Configuration;

namespace DesFormatoPedido
{
    public class ConsumoDB
    {
        private SqlConnection con = new SqlConnection();
        Conexion linea = new Conexion();

        public List<string> Modelo(string opcion)
        {
            List<string> lista = new List<string>();
            try
            {
                string sp = "SP_Cat_FormatoPedido";
                con = new SqlConnection(linea.LineaConexion());
                SqlCommand com = new SqlCommand(sp, con);
                con.Open();
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("@OP", SqlDbType.VarChar).Value = opcion;
                SqlDataReader dr;
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    if(!String.IsNullOrEmpty(dr.GetString(0)))
                        lista.Add(dr.GetString(0));
                }
                con.Close();
                dr.Close();

                
            }
            catch(Exception e)
            {
                if (e.Source != null)
                    throw new System.Exception(e.Message + ". error en modelos.");
            }

            return lista;
        }

        public List<ListaEstilos> estilo(string opcion)
        {
            List<ListaEstilos> lista = new List<ListaEstilos>();
            try
            {
                string sp = "SP_ExploradorLicencias";
                con = new SqlConnection(linea.LineaConexion());
                SqlCommand com = new SqlCommand(sp, con);
                con.Open();
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("@OP", SqlDbType.VarChar).Value = opcion;                
                SqlDataReader dr;
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    ListaEstilos l = new ListaEstilos();
                    if (!String.IsNullOrEmpty(dr.GetString(0)))
                    {
                        l.estilo = dr.GetString(0);
                        l.descripcion = dr.GetString(1);
                        l.tipo = dr.GetString(2);
                        l.tipoS = dr.GetString(3);
                        lista.Add(l);
                    }                       
                }
                con.Close();
                dr.Close();


            }
            catch (Exception e)
            {
                if (e.Source != null)
                    throw new System.Exception(e.Message + ". error en estilo.");
            }

            return lista;
        }

        public DataTable LModelo(string opcion)
        {
            DataTable dt = new DataTable();
            try
            {
                string sp = "SP_Cat_FormatoPedido";
                con = new SqlConnection(linea.LineaConexion());
                SqlCommand com = new SqlCommand(sp, con);
                con.Open();
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("@OP", SqlDbType.VarChar).Value = opcion;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);

            }
            catch (Exception e)
            {
                if (e.Source != null)
                    throw new System.Exception(e.Message + ". error en estilo.");
            }

            return dt;
        }

        public XmlDocument xml(string opcion)
        {
            String dt = "";
            XmlDocument document = new XmlDocument();
            
            try
            {
                string sp = "SP_Cat_FormatoPedido";
                con = new SqlConnection(linea.LineaConexion());
                SqlCommand com = new SqlCommand(sp, con);
                con.Open();
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("@OP", SqlDbType.VarChar).Value = opcion;
                //SqlDataAdapter da = new SqlDataAdapter(com);
                //da.Fill(dt);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                dt = dr.GetString(0);
                document.LoadXml(dr.GetString(0));
                con.Close();
                dr.Close();

            }
            catch (Exception e)
            {
                if (e.Source != null)
                    throw new System.Exception(e.Message + ". error en estilo.");
            }

            return document;
        }

        public DataTable DatosAcces()
        {
            OleDbCommand oleDbCommand = new OleDbCommand();
            DataTable dtr = new DataTable();
            string[] array = new string[50];
            int num = 0;
            try
            {
                oleDbCommand.CommandText = "select * from Universo";
                ClsConexion.ConexionActiva.Open();
                oleDbCommand.Connection = ClsConexion.ConexionActiva;
                //OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                OleDbDataAdapter da = new OleDbDataAdapter(oleDbCommand);
                da.Fill(dtr);                
                ClsConexion.ConexionActiva.Close();
            }
            catch (Exception ex)
            {
                ClsConexion.ConexionActiva.Close();
                throw new Exception("Falla al obtener los Tipos de Lectores\n" + ex.Message);
            }
            
            return dtr;
        }

        public XmlDocument xml_Response()
        {
            String dt = "";
            XmlDocument document = new XmlDocument();
            GeneraXML xml = new GeneraXML();

            try
            {
                Service sr = new Service();
                string pass = ConfigurationManager.AppSettings["PassServ"];
                string SolXml = xml.xmlToString("50011", "ART", "SP_Cat_FormatoPedido");
                document.LoadXml(sr.Solicitud(500, "1", CrypterPass.Crypt.Desencriptar(pass), 5002, SolXml));
            }
            catch (Exception e)
            {
                if (e.Source != null)
                    throw new System.Exception(e.Message + ". error en xml.");
            }

            return document;
        }

    }
}
