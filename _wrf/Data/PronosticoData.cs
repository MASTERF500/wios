using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WRF.Provider;
using WRF.Entity;
using System.Data;
using System.Data.SqlClient;
namespace WRF.Data
{
    public class PronosticoData:PronosticoProvider
    {

        public override List<PronosticoEntity> GetPronosticoByRangeId(int Id, string fch1, string fch2)
        {
            PronosticoEntity entityPronostico = null;
            List<PronosticoEntity> prnList = new List<PronosticoEntity>();
            
            SqlConnection conn = new SqlConnection(DataAccess.SqlGlobalConectionString);
            string query = @"select estacion, fecha, dia, prec, tmax, tmin, temp, eto from Valor_estaciones
                            where estacion="+Id+" and fecha between '"+fch1+"' and '"+fch2+"' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            try {
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        entityPronostico = new PronosticoEntity();
                        entityPronostico = GetPronosticoFromReader(reader);
                        prnList.Add(entityPronostico);
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Error: ", ex); }
            finally { conn.Close(); reader.Close(); conn.Dispose();}
            return prnList;
        }

        public override List<PronosticoEntity> GetPronostricoUltimateDate(int Id)
        {
            PronosticoEntity entityPronostico = null;
            List<PronosticoEntity> prnList = new List<PronosticoEntity>();
            string query = @"select estacion, fecha, dia, prec, tmax, tmin, temp, eto
                            from Valor_estaciones
                            where estacion=" + Id + " and fecha =(select max(fecha) from Valor_estaciones where estacion=" + Id + ")"; 
            SqlConnection conn = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        entityPronostico = new PronosticoEntity();
                        entityPronostico = GetPronosticoFromReader(reader);
                        prnList.Add(entityPronostico);
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Error: ", ex); }
            finally { conn.Close(); reader.Close(); conn.Dispose(); }
            return prnList;
        }

        public override List<PronosticoEntity> GetPronosticoById(int Id, string fch)
        {
            PronosticoEntity entityPronostico = null;
            List<PronosticoEntity> prnList = new List<PronosticoEntity>();
            string query = @"select estacion, fecha, dia, prec, tmax, tmin, temp, eto
                            from Valor_estaciones
                            where estacion="+Id+" and fecha ='"+fch+"' ";
            SqlConnection conn = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        entityPronostico = new PronosticoEntity();
                        entityPronostico = GetPronosticoFromReader(reader);
                        prnList.Add(entityPronostico);
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Error: ", ex); }
            finally { conn.Close(); reader.Close(); conn.Dispose(); }
            return prnList;
        }

        public override List<PronosticoEntity> GetPronosticoByRangeFecha(string fch1, string fch2)
        {
            PronosticoEntity entityPronostico = null;
            List<PronosticoEntity> prnList = new List<PronosticoEntity>();
            string query = @"select estacion, fecha, dia, prec, tmax, tmin, temp, eto
                            from Valor_estaciones
                            where fecha between '"+fch1+"' and '"+fch2+"'";
            SqlConnection conn = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        entityPronostico = new PronosticoEntity();
                        entityPronostico = GetPronosticoFromReader(reader);
                        prnList.Add(entityPronostico);
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Error: ", ex); }
            finally { conn.Close(); reader.Close(); conn.Dispose(); }
            return prnList;
        }

        public override List<PronosticoEntity> GetPronosticoByFecha(string fch)
        {
            PronosticoEntity entityPronostico = null;
            List<PronosticoEntity> prnList = new List<PronosticoEntity>();
            string query = @"select estacion, fecha, dia, prec, tmax, tmin, temp, eto
                             from Valor_estaciones
                             where fecha='"+fch+"' ";
            SqlConnection conn = new SqlConnection(DataAccess.SqlGlobalConectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        entityPronostico = new PronosticoEntity();
                        entityPronostico = GetPronosticoFromReader(reader);
                        prnList.Add(entityPronostico);
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Error: ", ex); }
            finally { conn.Close(); reader.Close(); conn.Dispose(); }
            return prnList;
        }
    }
}
