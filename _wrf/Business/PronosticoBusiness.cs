using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WRF.Provider;
using WRF.Entity;
using WRF.Data;

namespace WRF.Business
{
    public class PronosticoBusiness
    {
        #region business
        private int _Estacion;
        public int Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private string _Fecha;
        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private int _Dia;
        public int Dia
        {
            get { return _Dia; }
            set { _Dia = value; }
        }

                private decimal _Prec;
                public decimal Prec
        {
            get { return _Prec; }
            set { _Prec = value; }
        }
                private decimal _Tmax;

                public decimal Tmax
                {
                    get { return _Tmax; }
                    set { _Tmax = value; }
                }

                private decimal _Tmin;
                public decimal Tmin
                {
                    get { return _Tmin; }
                    set { _Tmin = value; }
                }
                
                private decimal _Temp;
                public decimal Temp
                {
                    get { return _Temp; }
                    set { _Temp = value; }
                }
                
                private decimal _Eto;
                public decimal Eto
                {
                    get { return _Eto; }
                    set { _Eto = value; }
                }
                public PronosticoBusiness() { }
                public PronosticoBusiness(int Estacion, string Fecha, int Dia, decimal Prec, decimal Tmax, decimal Tmin, decimal Temp, decimal Eto) 
                {
                    this._Estacion = Estacion;
                    this._Dia=Dia;
                    this._Fecha=Fecha;
                    this._Prec = Prec;
                    this._Tmax = Tmax;
                    this._Tmin = Tmin;
                    this._Temp = Temp;
                    this._Eto = Eto;
                }
        #endregion
        public static List<PronosticoBusiness> GetPronosticoByRangeId(int Id, string fch1, string fch2) {
            List<PronosticoBusiness> ListReturn = new List<PronosticoBusiness>();
            List<PronosticoEntity> Datos = new List<PronosticoEntity>();
            Datos = Provider.Provider.Pronostico.GetPronosticoByRangeId(Id, fch1, fch2);
            foreach (PronosticoEntity get in Datos) {
                PronosticoBusiness contenedor = new PronosticoBusiness(get.Estacion,get.Fecha,get.Dia,get.Prec,get.Tmax,get.Tmin,get.Temp,get.Eto);
                ListReturn.Add(contenedor);
            }
            return ListReturn;
        }
        public static List<PronosticoBusiness> GetPronostricoUltimateDate(int Id){
            List<PronosticoBusiness> ListReturn = new List<PronosticoBusiness>();
            List<PronosticoEntity> Datos = new List<PronosticoEntity>();
            Datos = Provider.Provider.Pronostico.GetPronostricoUltimateDate(Id);
            foreach (PronosticoEntity get in Datos)
            {
                PronosticoBusiness contenedor = new PronosticoBusiness(get.Estacion, get.Fecha, get.Dia, get.Prec, get.Tmax, get.Tmin, get.Temp, get.Eto);
                ListReturn.Add(contenedor);
            }
            return ListReturn;
        }
        public static List<PronosticoBusiness> GetPronosticoById(int Id, string fch) {
            List<PronosticoBusiness> ListReturn = new List<PronosticoBusiness>();
            List<PronosticoEntity> Datos = new List<PronosticoEntity>();
            Datos = Provider.Provider.Pronostico.GetPronosticoById(Id, fch);
            foreach (PronosticoEntity get in Datos)
            {
                PronosticoBusiness contenedor = new PronosticoBusiness(get.Estacion, get.Fecha, get.Dia, get.Prec, get.Tmax, get.Tmin, get.Temp, get.Eto);
                ListReturn.Add(contenedor);
            }
            return ListReturn;
        }
        public static List<PronosticoBusiness> GetPronosticoByRangeFecha(string fch1, string fch2) {
            List<PronosticoBusiness> ListReturn = new List<PronosticoBusiness>();
            List<PronosticoEntity> Datos = new List<PronosticoEntity>();
            Datos = Provider.Provider.Pronostico.GetPronosticoByRangeFecha(fch1,fch1);
            foreach (PronosticoEntity get in Datos)
            {
                PronosticoBusiness contenedor = new PronosticoBusiness(get.Estacion, get.Fecha, get.Dia, get.Prec, get.Tmax, get.Tmin, get.Temp, get.Eto);
                ListReturn.Add(contenedor);
            }
            return ListReturn;
        }
        public static List<PronosticoBusiness> GetPronosticoByFecha(string fch) {
            List<PronosticoBusiness> ListReturn = new List<PronosticoBusiness>();
            List<PronosticoEntity> Datos = new List<PronosticoEntity>();
            Datos = Provider.Provider.Pronostico.GetPronosticoByFecha(fch);
            foreach (PronosticoEntity get in Datos)
            {
                PronosticoBusiness contenedor = new PronosticoBusiness(get.Estacion, get.Fecha, get.Dia, get.Prec, get.Tmax, get.Tmin, get.Temp, get.Eto);
                ListReturn.Add(contenedor);
            }
            return ListReturn;
        }
         

    }
}
