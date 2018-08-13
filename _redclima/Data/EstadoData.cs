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
    public class EstadoData:EstadoProvider
    {
        
        public override List<EstadoEntity> GetEstados()
        {
            EstadoEntity entityEstado = null;
            List<EstadoEntity> List = new List<EstadoEntity>();

            SqlConnection connection = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand command = new SqlCommand("ConsultaEdos", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entityEstado = new EstadoEntity();
                    entityEstado = GetEstadosFromReader(reader);
                    List.Add(entityEstado);
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
