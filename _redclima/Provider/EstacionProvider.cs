using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Agregadas
using System.Runtime.Remoting; //Agregar a referemcias directamente.
using System.Configuration;
using SistemaAlertas.Entity; //Agregar a referencias por medio de Proyectos.
using System.Data;
using System.Data.SqlClient;

namespace SistemaAlertas.Provider
{
    public abstract class EstacionProvider:DataAccess
    {
           private static ObjectHandle obj; //manejador de objeto.

        private static EstacionProvider _Intance = null;

        public static EstacionProvider Intance
        {
            get {
                if (_Intance == null){
                    obj = Activator.CreateInstance(
                        ConfigurationManager.AppSettings["EstacionDll"],
                        ConfigurationManager.AppSettings["EstacionClass"]);
                    _Intance = (EstacionProvider)obj.Unwrap();
                }  
                return _Intance; }
        }

        public EstacionProvider() { }
        public abstract List<EstacionEntity> GetEstaciones(int idedo);
        public abstract List<EstacionEntity> GetEstacionesByIdMunicipio(int idmun);
        public abstract List<EstacionEntity> GetEstacionesDesfase(int edo);
        public abstract List<EstacionEntity> GetEstacionesDesfaseByEstado(int edo, string fecha);
        public abstract List<EstacionEntity> GetEstacionesAll();
        //metodo auxiliar virtual=reescribible
        public virtual EstacionEntity GetEstacionesFromReader(IDataReader reader) {
            EstacionEntity entity = null;
            try
            {
                entity =new EstacionEntity();
                entity.Numero = reader["numero"] == System.DBNull.Value ? 0 : (int)reader["numero"];
                entity.Idred = reader["idred"] == System.DBNull.Value ? 0 : (int)reader["idred"];
                entity.Nombre = reader["nombre"] == System.DBNull.Value ? "Null" : (string)reader["nombre"];
                entity.EstadoId=reader["estadoid"]==System.DBNull.Value ? 0 : (int)reader["estadoid"];
                entity.MunicipioId=reader["municipioid"]==System.DBNull.Value ? 0:(int)reader["municipioid"];
                entity.Productor=reader["productor"]==System.DBNull.Value ? "Null": (string)reader["productor"];
                entity.Latitud = reader["latitud"] == System.DBNull.Value ? 0 : Convert.ToSingle( reader["latitud"]);
                entity.Longitud= reader["longitud"] == System.DBNull.Value ? 0 : Convert.ToSingle( reader["longitud"]);
                entity.Altitud=reader["altitud"]==System.DBNull.Value ? 0 : Convert.ToSingle( reader["altitud"]);
                entity.Inicio=reader["inicio"]==  System.DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["inicio"]);
                DateTime InParse=reader["inicio"] == System.DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["inicio"]);
                entity.InicioParseo = InParse.Day+"/"+InParse.Month+"/"+InParse.Year;


            }
            catch(Exception ex) {
                throw new Exception("Error converting data...", ex);
            }
            return entity;
        }
        public virtual EstacionEntity GetEstacionesFromReaderDesfase(IDataReader reader)
        {
            EstacionEntity entity = null;
            try
            {
                entity = new EstacionEntity();
                entity.Numero = reader["numero"] == System.DBNull.Value ? 0 : (int)reader["numero"];
                entity.Idred = 0;
                entity.Nombre = reader["nombre"] == System.DBNull.Value ? "Null" : (string)reader["nombre"];
                entity.EstadoId = reader["estadoid"] == System.DBNull.Value ? 0 : (int)reader["estadoid"];
                entity.MunicipioId = 0;
                entity.Productor = "";
                entity.Latitud = reader["latitud"] == System.DBNull.Value ? 0 : Convert.ToSingle(reader["latitud"]);
                entity.Longitud = reader["longitud"] == System.DBNull.Value ? 0 : Convert.ToSingle(reader["longitud"]);
                entity.Altitud = reader["h"]== System.DBNull.Value? 0 : Convert.ToSingle(reader["h"]);
                entity.Inicio = Convert.ToDateTime(null); 
                entity.InicioParseo = "";


            }
            catch (Exception ex)
            {
                throw new Exception("Error converting data...", ex);
            }
            return entity;
        }
    }
}
