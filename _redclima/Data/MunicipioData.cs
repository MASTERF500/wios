using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Agregados
using SistemaAlertas.Provider;
using SistemaAlertas.Entity;
using System.Data.SqlClient;
using System.Data;

namespace SistemaAlertas.Data
{
    public class MunicipioData:MunicipioProvider
    {
        public override List<MunicipioEntity> GetMunicipios(int idedo)
        {
            MunicipioEntity entityMunicipio = null;
            List<MunicipioEntity> List = new List<MunicipioEntity>();

            SqlConnection connection = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand command = new SqlCommand("select distinct m.indice,m.idedo,m.nombre from municipios m,estaciones es where m.idedo=" + idedo + " and m.indice=es.municipioid", connection);
            
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = null;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entityMunicipio = new MunicipioEntity();
                    entityMunicipio = GetMunicipiosFromReader(reader);
                    List.Add(entityMunicipio);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Estados..." + ex.Message, ex);
            }
            finally
            {
                connection.Close();
                reader.Close();
                connection.Dispose();
            }
            return List;
        }

    }
}
