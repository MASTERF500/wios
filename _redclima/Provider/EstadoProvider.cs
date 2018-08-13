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
    public abstract class EstadoProvider:DataAccess
    {
         //Repositorio para instancia. Por medio de un activator, buscar en DLL una funcion.
        private static ObjectHandle obj; //manejador de objeto.

        private static EstadoProvider _Intance = null;

        public static EstadoProvider Intance
        {
            get {
                if (_Intance == null){
                    obj = Activator.CreateInstance(
                        ConfigurationManager.AppSettings["EstadoDll"],
                        ConfigurationManager.AppSettings["EstadoClass"]);
                    _Intance = (EstadoProvider)obj.Unwrap();
                }  
                return _Intance; }
        }

        public EstadoProvider() { }
        public abstract List<EstadoEntity> GetEstados();
        //metodo auxiliar virtual=reescribible
        public virtual EstadoEntity GetEstadosFromReader(IDataReader reader) {
            EstadoEntity entity = null;
            try
            {
                entity = new EstadoEntity();
                entity.Indice = reader["indice"] == System.DBNull.Value ? 0 : (int)reader["indice"];
                    entity.Nombre = reader["nombre"] == System.DBNull.Value ? null : (String)reader["nombre"];
            }
            catch(Exception ex) {
                throw new Exception("Error converting data...", ex);
            }
            return entity;
        }
    }

}
