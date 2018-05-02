using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DesFormatoPedido
{
    class ClsConexionAcces
    {
        internal static class ClsConexion
        {
            private static OleDbConnection Conexion;

            private static string strProvider;

            private static string strDataBase;

            private static string strUser;

            private static string strPassword;


            public static string Provider
            {
                get
                {
                    return ClsConexion.strProvider = "Microsoft.Jet.OLEDB.4.0";
                }
            }

            public static string DataBase
            {
                get
                {
                    return ClsConexion.strDataBase = Application.StartupPath + "\\DB_Data.mdb";
                }
            }

            //public static string DataBase2
            //{
            //    get
            //    {
            //        return ClsConexion.strDataBase2 = ClsParametro.DirUsuariosDB;
            //    }
            //}

            public static string User
            {
                get
                {
                    return ClsConexion.strUser;
                }
                set
                {
                    ClsConexion.strUser = value;
                }
            }

            public static string Password
            {
                get
                {
                    return ClsConexion.strPassword = "DbBigbang*+";
                }
            }

            public static OleDbConnection ConexionActiva
            {
                get
                {
                    return ClsConexion.Conexion;
                }
            }           

            static ClsConexion()
            {
                string connectionString = string.Concat(new string[]
                {
                "Provider=",
                ClsConexion.Provider,
                "; Data Source= ",
                ClsConexion.DataBase,
                "; Jet OLEDB:Database Password=",
                ClsConexion.Password,
                ";"
                });
                ClsConexion.Conexion = new OleDbConnection(connectionString);
            }

            
        }
    }
}
