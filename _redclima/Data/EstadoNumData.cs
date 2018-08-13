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
    public class EstadoNumData:EstadoNumProvider
    {
        public override List<EstadoNumEntity> GetEstadosNumByIdEstacion(int Idedo, int IdEstacion, string inicio, string fin)
        {
            EstadoNumEntity entityNumEstado = null;
            List<EstadoNumEntity> List = new List<EstadoNumEntity>();

            SqlConnection connection = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand command = new SqlCommand("select numero,fecha, prec, temt, dirv, velv,radg,humr,humh,eto from estado" + Idedo + " where numero=" + IdEstacion + " and fecha>='" + inicio + "' and fecha<='" + fin + "'", connection);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = null;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entityNumEstado = new EstadoNumEntity();
                    entityNumEstado = GetEstadosNumFromReader(reader);
                    List.Add(entityNumEstado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar EstadosNum..." + ex.Message, ex);
            }
            finally
            {
                connection.Close();
                reader.Close();
                connection.Dispose();
            }
            return List;
        }

        public override List<EstadoNumEntity> GetEstadosNumUltimateDate(int Idedo, int IdEstacion)
        {
            EstadoNumEntity entityNumEstado = null;
            List<EstadoNumEntity> List = new List<EstadoNumEntity>();
            string query = @"select numero,fecha, prec, temt, dirv, velv,radg,humr,humh,eto 
            from estado" + Idedo + " where numero=" + IdEstacion + " and fecha=(select max(fecha) from estado" + Idedo + " where numero=" + IdEstacion + ")";
            SqlConnection connection = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = null;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entityNumEstado = new EstadoNumEntity();
                    entityNumEstado = GetEstadosNumFromReader(reader);
                    List.Add(entityNumEstado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar EstadosNum..." + ex.Message, ex);
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
