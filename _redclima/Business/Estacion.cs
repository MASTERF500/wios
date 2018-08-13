using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Agregados
using SistemaAlertas.Entity;
using SistemaAlertas.Provider;
using SistemaAlertas.Data;

namespace SistemaAlertas.Business
{
    public class Estacion
    {
        private int _Numero;
        public int Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        private int _Idred;
        public int Idred
        {
            get { return _Idred; }
            set { _Idred = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private int _EstadoId;
        public int EstadoId
        {
            get { return _EstadoId; }
            set { _EstadoId = value; }
        }

        private int _MunicipioId;
        public int MunicipioId
        {
            get { return _MunicipioId; }
            set { _MunicipioId = value; }
        }

        private string _Productor;
        public string Productor
        {
            get { return _Productor; }
            set { _Productor = value; }
        }

        private float _Latitud;
        public float Latitud
        {
            get { return _Latitud; }
            set { _Latitud = value; }
        }

        private float _Longitud;
        public float Longitud
        {
            get { return _Longitud; }
            set { _Longitud = value; }
        }

        private float _Altitud;
        public float Altitud
        {
            get { return _Altitud; }
            set { _Altitud = value; }
        }

        private DateTime _Inicio;
        public DateTime Inicio
        {
            get { return _Inicio; }
            set { _Inicio = value; }
        }

        private string _InicioParseo;
        public string InicioParseo
        {
            get { return _InicioParseo; }
            set { _InicioParseo = value; }
        }

        public Estacion() { }
        public Estacion(
            int Numero, int Idred, 
            string Nombre, int EstadoId, int MunicipioId, string Productor,
            float Latitud, float Longitud, float Altitud, DateTime Inicio, string InicioParseo) {
                this._Numero = Numero;
                this._Idred = Idred;
                this._Nombre = Nombre;
                this._EstadoId = EstadoId;
                this._MunicipioId = MunicipioId;
                this._Productor = Productor;
                this._Latitud = Latitud;
                this._Longitud = Longitud;
                this._Altitud = Altitud;
                this._Inicio = Inicio;
                this._InicioParseo = InicioParseo;
        }

        public static List<Estacion> GetEstaciones(int idedo) {
            List<Estacion> ListaEstn = new List<Estacion>();
            List<EstacionEntity> Estaciones = new List<EstacionEntity>();
            //Referencia en archivo SisAletas/Provider
            Estaciones = Provider.Provider.Estacion.GetEstaciones(idedo);
            foreach (EstacionEntity get in Estaciones)
            {
                Estacion esTrucEstacion = new Estacion(get.Numero,get.Idred,get.Nombre,get.EstadoId,get.MunicipioId,get.Productor,get.Latitud,get.Longitud,get.Altitud,get.Inicio, get.InicioParseo);
                ListaEstn.Add(esTrucEstacion);
            }
            return ListaEstn;
        }
        public static List<Estacion> GetEstacionesByIdMunicipio(int idmun)
        {
            List<Estacion> ListaEstn = new List<Estacion>();
            List<EstacionEntity> Estaciones = new List<EstacionEntity>();
            //Referencia en archivo SisAletas/Provider
            Estaciones = Provider.Provider.Estacion.GetEstacionesByIdMunicipio(idmun);
            foreach (EstacionEntity get in Estaciones)
            {
                Estacion esTrucEstacion = new Estacion(get.Numero, get.Idred, get.Nombre, get.EstadoId, get.MunicipioId, get.Productor, get.Latitud, get.Longitud, get.Altitud, get.Inicio,get.InicioParseo);
                ListaEstn.Add(esTrucEstacion);
            }
            return ListaEstn;
        }
        public static List<Estacion> GetEstacionesDesfase(int edo)
        {
            List<Estacion> ListaEstn = new List<Estacion>();
            List<EstacionEntity> Estaciones = new List<EstacionEntity>();
            Estaciones = Provider.Provider.Estacion.GetEstacionesDesfase(edo);

            foreach (EstacionEntity get in Estaciones)
            {
                Estacion esTrucEstacion = new Estacion(get.Numero, get.Idred, get.Nombre, get.EstadoId, get.MunicipioId, get.Productor, get.Latitud, get.Longitud, get.Altitud, get.Inicio, get.InicioParseo);
                ListaEstn.Add(esTrucEstacion);
            }

            return ListaEstn;
        }
        public static List<Estacion> GetEstacionesDesfaseByEstado(int edo, string fecha)
        {
            List<Estacion> ListaEstn = new List<Estacion>();
            List<EstacionEntity> Estaciones = new List<EstacionEntity>();
            Estaciones = Provider.Provider.Estacion.GetEstacionesDesfaseByEstado(edo, fecha);

                foreach (EstacionEntity get in Estaciones)
                {
                    Estacion esTrucEstacion = new Estacion(get.Numero, get.Idred, get.Nombre, get.EstadoId, get.MunicipioId, get.Productor, get.Latitud, get.Longitud, get.Altitud, get.Inicio, get.InicioParseo);
                    ListaEstn.Add(esTrucEstacion);
                }
            
            return ListaEstn;
        }
        public static List<Estacion> GetEstacionesAll(double latitud,double longitud) {
            List<Estacion> returnEST = new List<Estacion>();
            List<EstacionEntity> estaciones = Provider.Provider.Estacion.GetEstacionesAll();
            Estacion paquete = null;
            double flag=0;
            foreach (EstacionEntity get in estaciones) {
                double x = Math.Pow(longitud - Convert.ToDouble(get.Longitud),2);
                double y = Math.Pow(latitud - Convert.ToDouble(get.Latitud),2);
                double Result = Math.Sqrt(x+y);
                if (flag == 0) {
                    flag = Result;
                }
                if (Result < flag) {
                    flag = Result;
                   paquete = new Estacion(get.Numero, get.Idred, get.Nombre, get.EstadoId, get.MunicipioId, get.Productor, get.Latitud, get.Longitud, get.Altitud, get.Inicio, get.InicioParseo);
                }
                           
            }
            returnEST.Add(paquete);
            return returnEST;
        
        }
   
    }
}
