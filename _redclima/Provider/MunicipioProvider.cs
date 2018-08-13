using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//clases agregadas:
using System.Runtime.Remoting; //Agregar a referemcias directamente.
using System.Configuration;
using SistemaAlertas.Entity; //Agregar a referencias por medio de Proyectos.
using System.Data;
using System.Data.SqlClient;

namespace SistemaAlertas.Provider
{
    public abstract class MunicipioProvider:DataAccess
    {
        private static ObjectHandle obj; //manejador de objeto.

        private static MunicipioProvider _Intance = null;

        public static MunicipioProvider Intance
        {
          get {
                if (_Intance == null){
                    obj = Activator.CreateInstance(
                        ConfigurationManager.AppSettings["MunicipioDll"],
                        ConfigurationManager.AppSettings["MunicipioClass"]);
                    _Intance = (MunicipioProvider)obj.Unwrap();
                }  
                return _Intance; }
        }

        public MunicipioProvider() { }
        public abstract List<MunicipioEntity> GetMunicipios(int idedo);
        public virtual MunicipioEntity GetMunicipiosFromReader(IDataReader reader) {
            MunicipioEntity entity = null;
            try
            {
                entity = new MunicipioEntity();
                entity.Indice = reader["indice"] == System.DBNull.Value ? 0 : (int)reader["indice"];
                entity.Idedo = reader["idedo"] == System.DBNull.Value ? 0 : (int)reader["idedo"];
                entity.Nombre = reader["nombre"] == System.DBNull.Value ? "Error" : (String)reader["nombre"];
            }
            catch(Exception ex) {
                throw new Exception("Error converting data...", ex);
            }
            return entity;
        }
    }
}
