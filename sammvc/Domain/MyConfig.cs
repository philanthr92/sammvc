using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MyConfig : Entities
    {
        public System.Data.Entity.DbContext db { get; private set; }

        public MyConfig() {
            db = new Entities();
        }

        #region connect database configure

        public static string DefaultConnectionString = "";

        public static IDbConnection DefaultConnection
        {
            get
            {
                IDbConnection defaultConn = null;
                string action = ConfigurationManager.AppSettings["daoType"];
                switch(action)
                {
                    case "mssql":
                        defaultConn = new System.Data.SqlClient.SqlConnection();
                        DefaultConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                        break;
                    default: break;
                }

                return defaultConn;
            }
        }

        public static string DatabaseConnectionString(string entityName)
        {
            IDbConnection con = DefaultConnection;
            return EFConnectionStringModle(entityName, DefaultConnectionString);
        }

        private static string EFConnectionStringModle(string entityName,string dbSource)
        {
            return string.Concat("metadata=res://*/",
                 entityName, ".csdl|res://*/",
                 entityName, ".ssdl|res://*/",
                 entityName, ".msl;provider=System.Data.SqlClient;provider connection string='",
                 dbSource, "'");
            
        }
        #endregion

    }
}
