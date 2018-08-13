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
    public class EstacionData:EstacionProvider
    {

        public override List<EstacionEntity> GetEstaciones(int idedo)
        {
            EstacionEntity entityEstacion = null;
            List<EstacionEntity> List = new List<EstacionEntity>();

            SqlConnection connection = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand command = new SqlCommand("select numero,idred,nombre,estadoid,municipioid,productor,latitud,longitud,altitud,inicio  from estaciones where estadoid=" + idedo + " ", connection);

            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = null;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entityEstacion = new EstacionEntity();
                    entityEstacion = GetEstacionesFromReader(reader);
                    List.Add(entityEstacion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Estaciones..." + ex.Message, ex);
            }
            finally
            {
                connection.Close();
                reader.Close();
                connection.Dispose();
            }
            return List;
        }

        public override List<EstacionEntity> GetEstacionesByIdMunicipio(int idmun)
        {
            EstacionEntity entityEstacion = null;
            List<EstacionEntity> List = new List<EstacionEntity>();

            SqlConnection connection = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand command = new SqlCommand("select numero,idred,nombre,estadoid,municipioid,productor,latitud,longitud,altitud,inicio  from estaciones where municipioid=" + idmun + " ", connection);

            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = null;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entityEstacion = new EstacionEntity();
                    entityEstacion = GetEstacionesFromReader(reader);
                    List.Add(entityEstacion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Estaciones por Municipio..." + ex.Message, ex);
            }
            finally
            {
                connection.Close();
                reader.Close();
                connection.Dispose();
            }
            return List;
        }

        public override List<EstacionEntity> GetEstacionesDesfase(int edo)
        {
            EstacionEntity entityEstacion = null;
            List<EstacionEntity> List = new List<EstacionEntity>();

            SqlConnection connection = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand command = new SqlCommand("select S.numero,S.nombre,S.latitud,S.longitud,S.estadoid,datediff (hh,max(T.fecha),getdate()) as h from estado"+edo+" T,estaciones S where S.numero=T.numero and S.activa=1 group by S.numero,s.nombre,S.latitud,S.longitud,S.estadoid order by S.numero ", connection);

            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = null;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entityEstacion = new EstacionEntity();
                    entityEstacion = GetEstacionesFromReaderDesfase(reader);
                    List.Add(entityEstacion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Desfase por Estacion..." + ex.Message, ex);
            }
            finally
            {
                connection.Close();
                reader.Close();
                connection.Dispose();
            }
            return List;
        }

        public override List<EstacionEntity> GetEstacionesDesfaseByEstado(int edo, string fecha)
        {
            EstacionEntity entityEstacion = null;
            List<EstacionEntity> List = new List<EstacionEntity>();

            SqlConnection connection = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand command = new SqlCommand("select S.numero,S.nombre,S.latitud,S.longitud,S.estadoid,datediff (hh,max(T.fecha),getdate()) as h from estado" + edo + " T,estaciones S where S.numero=T.numero and S.activa=1 and T.fecha='"+fecha+"' group by S.numero,s.nombre,S.latitud,S.longitud,S.estadoid order by S.numero ", connection);

            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = null;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entityEstacion = new EstacionEntity();
                    entityEstacion = GetEstacionesFromReaderDesfase(reader);
                    List.Add(entityEstacion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Desfase Estacion por Estado..." + ex.Message, ex);
            }
            finally
            {
                connection.Close();
                reader.Close();
                connection.Dispose();
            }
            return List;
        }

        public override List<EstacionEntity> GetEstacionesAll()
        {

            EstacionEntity entityEstacion = null;
            List<EstacionEntity> List = new List<EstacionEntity>();

            SqlConnection connection = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand command = new SqlCommand("select numero,idred,nombre,estadoid,municipioid,productor,latitud,longitud,altitud,inicio  from estaciones", connection);

            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = null;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entityEstacion = new EstacionEntity();
                    entityEstacion = GetEstacionesFromReader(reader);
                    List.Add(entityEstacion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Estaciones..." + ex.Message, ex);
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
