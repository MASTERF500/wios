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
    public abstract class EstadoNumDiarioProvider:DataAccess
    {
        private static ObjectHandle obj;

        private static EstadoNumDiarioProvider _Intance = null;

        public static EstadoNumDiarioProvider Intance {
            get
            {
                if (_Intance == null)
                {
                    obj = Activator.CreateInstance(
                        ConfigurationManager.AppSettings["EstadoNumDiarioDll"],
                        ConfigurationManager.AppSettings["EstadoNumDiarioClass"]);
                    _Intance = (EstadoNumDiarioProvider)obj.Unwrap();
                }
                return _Intance;
            }
        }
        public EstadoNumDiarioProvider() { }
        public abstract List<EstadoNumDiarioEntity> GetEstadoNumDiarioByEstacion(int Idedo, int IdEstacion, string inicio, string fin);
        public abstract List<EstadoNumDiarioEntity> GetEstadoNumDiarioUltimateDate(int Idedo, int IdEstacion);
        public virtual EstadoNumDiarioEntity GetEstadosNumDiarioFromReader(IDataReader reader) {
            EstadoNumDiarioEntity entity = null;
            try
            {
                entity = new EstadoNumDiarioEntity();
                entity.Numero = reader["numero"] == System.DBNull.Value ? 0 : (int)reader["numero"];
                entity.Fecha = reader["fecha"] == System.DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["fecha"]);
                DateTime InParse = reader["fecha"] == System.DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["fecha"]);
                entity.FechaParseo = InParse.Day + "/" + InParse.Month + "/" + InParse.Year;
                entity.Prec= reader["prec"]==System.DBNull.Value ? 0 : (decimal)reader["prec"];
                entity.Tmax = reader["tmax"] == System.DBNull.Value ? 0 : (decimal)reader["tmax"];
                entity.Tmin = reader["tmin"] == System.DBNull.Value ? 0 : (decimal)reader["tmin"];
                entity.Tmed = reader["tmed"] == System.DBNull.Value ? 0 : (decimal)reader["tmed"];
                entity.VelvMax = reader["velvmax"] == System.DBNull.Value ? 0 : (decimal)reader["velvmax"];
                entity.Velv = reader["velv"] == System.DBNull.Value ? 0 : (decimal)reader["velv"];
                entity.DirvVMax = reader["dirvvmax"] == System.DBNull.Value ? 0 : (decimal)reader["dirvvmax"];
                entity.Dirv=reader["dirv"]==System.DBNull.Value ? 0 : (decimal)reader["dirv"];
                entity.Radg = reader["radg"] == System.DBNull.Value ? 0 : (decimal)reader["radg"];
                entity.Humr = reader["humr"] == System.DBNull.Value ? 0 : (decimal)reader["humr"];
                entity.Et = reader["et"] == System.DBNull.Value ? 0 : (decimal)reader["et"];
                entity.Ep = reader["ep"] == System.DBNull.Value ? 0 : (decimal)reader["ep"];
                entity.Porc = reader["porc"] == System.DBNull.Value ? "0" : Convert.ToString(reader["porc"]);
            }
            catch(Exception ex) {
                throw new Exception("Error converting data of EstadoNumDiario...", ex);
            }
            return entity;
        }

    }
}
