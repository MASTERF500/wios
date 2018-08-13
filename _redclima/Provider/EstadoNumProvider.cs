using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//clases agregadas:
using System.Runtime.Remoting; 
using System.Configuration;
using SistemaAlertas.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SistemaAlertas.Provider
{
    public abstract class EstadoNumProvider:DataAccess
    {
        private static ObjectHandle obj;

        private static EstadoNumProvider _Intance = null;

        public static EstadoNumProvider Intance
        {
            get
            {
                if (_Intance == null)
                {
                    obj = Activator.CreateInstance(
                        ConfigurationManager.AppSettings["EstadoNumDll"],
                        ConfigurationManager.AppSettings["EstadoNumClass"]);
                    _Intance = (EstadoNumProvider)obj.Unwrap();
                }
                return _Intance;
            }
        }
        public EstadoNumProvider() { }
        public abstract List<EstadoNumEntity> GetEstadosNumByIdEstacion(int Idedo, int IdEstacion, string inicio, string fin);
        public abstract List<EstadoNumEntity> GetEstadosNumUltimateDate(int Idedo, int IEstacion);
        public virtual EstadoNumEntity GetEstadosNumFromReader(IDataReader reader) {
            EstadoNumEntity entity = null;
            try
            {
                entity = new EstadoNumEntity();
                entity.Numero = reader["numero"] == System.DBNull.Value ? 0 : (int)reader["numero"];
                DateTime InParse = reader["fecha"] == System.DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["fecha"]);
                entity.Fecha = Convert.ToDateTime(InParse.Year + "/" + InParse.Month + "/" + InParse.Day + " " + InParse.Hour + ":" + InParse.Minute);
                entity.FechaParseo = InParse.Year + "/" + InParse.Month + "/" + InParse.Day + " " + InParse.Hour + ":" + InParse.Minute;
                entity.Prec= reader["prec"]==System.DBNull.Value ? 0 : (decimal)reader["prec"];
                entity.Temt=reader["temt"]==System.DBNull.Value ? 0 : (decimal)reader["temt"];
                entity.Dirv=reader["dirv"]==System.DBNull.Value ? 0 : (decimal)reader["dirv"];
                entity.Velv = reader["velv"] == System.DBNull.Value ? 0 : (decimal)reader["velv"];
                entity.Radg = reader["radg"] == System.DBNull.Value ? 0 : (decimal)reader["radg"];
                entity.Humr = reader["humr"] == System.DBNull.Value ? 0 : (decimal)reader["humr"];
                entity.Humh = reader["humh"] == System.DBNull.Value ? 0 : (decimal)reader["humh"];
                entity.Eto = reader["eto"] == System.DBNull.Value ? 0 : (decimal)reader["eto"];
            }
            catch(Exception ex) {
                throw new Exception("Error converting data of EstadoNum...", ex);
            }
            return entity;
        }




    }
}
