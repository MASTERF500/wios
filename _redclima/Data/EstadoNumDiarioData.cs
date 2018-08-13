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
    public class EstadoNumDiarioData:EstadoNumDiarioProvider
    {
        public override List<EstadoNumDiarioEntity> GetEstadoNumDiarioByEstacion(int Idedo, int IdEstacion, string inicio, string fin)
        {
            EstadoNumDiarioEntity entityNumEstadoDiario = null;
            List<EstadoNumDiarioEntity> List = new List<EstadoNumDiarioEntity>();

            SqlConnection connection = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand command = new SqlCommand("select numero,fecha,prec,tmax,tmin,tmed,velvmax,velv,dirvvmax,dirv,radg,humr,et,ep,porc from estado" + Idedo + "diarios where numero=" + IdEstacion + " and fecha>='" + inicio + "' and fecha<='" + fin + "' ", connection);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = null;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entityNumEstadoDiario = new EstadoNumDiarioEntity();
                    entityNumEstadoDiario = GetEstadosNumDiarioFromReader(reader);
                    List.Add(entityNumEstadoDiario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar EstadosNumDiario..." + ex.Message, ex);
            }
            finally
            {
                connection.Close();
                reader.Close();
                connection.Dispose();
            }
            return List;
        }
        public override List<EstadoNumDiarioEntity> GetEstadoNumDiarioUltimateDate(int Idedo, int IdEstacion)
        {
            EstadoNumDiarioEntity entityNumEstadoDiario = null;
            List<EstadoNumDiarioEntity> List = new List<EstadoNumDiarioEntity>();
            string query = @"select  numero,fecha,prec,tmax,tmin,tmed,velvmax,velv,dirvvmax,dirv,radg,humr,et,ep,porc 
                               from estado"+Idedo+"diarios "+
                               @"where numero=" + IdEstacion + " and fecha = (select max(fecha) from estado" + Idedo + "diarios where numero=" + IdEstacion + ")";
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
                    entityNumEstadoDiario = new EstadoNumDiarioEntity();
                    entityNumEstadoDiario = GetEstadosNumDiarioFromReader(reader);
                    List.Add(entityNumEstadoDiario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar EstadosNumDiario..." + ex.Message, ex);
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
