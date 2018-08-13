using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespaces add
using System.Runtime.Remoting;
using System.Configuration;
using WRF.Entity;
using System.Data;
using System.Data.SqlClient;
namespace WRF.Provider
{
    public abstract class PronosticoProvider:DataAccess 
    {
        private static ObjectHandle obj;
        private static PronosticoProvider _Instance = null;

        public static PronosticoProvider Instance
        {
            get {
                if (_Instance == null) { 
                    obj=Activator.CreateInstance(
                        ConfigurationManager.AppSettings["PronosticoDLL"],
                        ConfigurationManager.AppSettings["PronosticoClass"]);
                    _Instance = (PronosticoProvider)obj.Unwrap();
                } return _Instance; }
        }
        public PronosticoProvider() { }
        public abstract List<PronosticoEntity> GetPronosticoByRangeId(int Id,string fch1, string fch2);
        public abstract List<PronosticoEntity> GetPronostricoUltimateDate(int Id);
        public abstract List<PronosticoEntity> GetPronosticoById(int Id, string fch);
        public abstract List<PronosticoEntity> GetPronosticoByRangeFecha(string fch1, string fch2);
        public abstract List<PronosticoEntity> GetPronosticoByFecha(string fch);
        public virtual PronosticoEntity GetPronosticoFromReader(IDataReader reader)
        {
            PronosticoEntity entity = null;
            try {
                entity = new PronosticoEntity();
                entity.Estacion = reader["estacion"] == System.DBNull.Value ? 0 : (int)reader["estacion"];
                entity.Fecha = reader["fecha"] == System.DBNull.Value ? "01/01/0001" : Convert.ToDateTime(reader["fecha"]).Day + "/" + Convert.ToDateTime(reader["fecha"]).Month + "/" + Convert.ToDateTime(reader["fecha"]).Year;
                entity.Dia = reader["dia"] == System.DBNull.Value ? 0 : Convert.ToInt16(reader["dia"]);
                entity.Prec = reader["prec"] == System.DBNull.Value ? 0 : (decimal)reader["prec"];
                entity.Tmax = reader["tmax"] == System.DBNull.Value ? 0 : (decimal)reader["tmax"];
                entity.Tmax = reader["tmin"] == System.DBNull.Value ? 0 : (decimal)reader["tmin"];
                entity.Tmax = reader["temp"] == System.DBNull.Value ? 0 : (decimal)reader["temp"];
                entity.Tmax = reader["eto"] == System.DBNull.Value ? 0 : (decimal)reader["eto"];
             }
            catch (Exception ex) { throw new Exception("Error: ", ex); } return entity;
            
        
        }



    }
}
