using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Referencias Agregadas:
using System.Configuration;
using System.Data.Common;
using System.Data;

namespace SistemaAlertas.Provider
{
    public abstract class DataAccess
    {
        #region Conexión
        private static string sqlGlobalConectionString;

        public static string SqlGlobalConectionString
        {
            get
            {
                if (sqlGlobalConectionString == null)
                {
                    sqlGlobalConectionString = ConfigurationManager.ConnectionStrings["BDredclima"].ConnectionString;
                }
                return DataAccess.sqlGlobalConectionString;
            }
            set { DataAccess.sqlGlobalConectionString = value; }
        }
        //Encapsulamiento (Clic derecho sobre variable, Factorizar/Encapsular Campo -Desmarcar casillas).
        #endregion

        //comando generico parametros, funciona con cualquier proveedor de datos.
        protected int ExecuteNonQuery(DbCommand cmd)
        {
            string systemUser = string.Empty;
            if (systemUser.Equals("Test"))
                return 1;
            else
                return cmd.ExecuteNonQuery();
        }
        //CommandBehavior: para diferentes modos de ejecución respecto a la conexión BD.
        protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            return cmd.ExecuteReader(behavior);
        }
        //Devuelve cualquier tipo de dato.
        protected Object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }
    }
}
