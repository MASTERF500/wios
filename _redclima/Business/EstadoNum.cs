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
    public class EstadoNum
    {
        private int _Numero;
        public int Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        private DateTime _Fecha;
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private string _FechaParseo;
        public string FechaParseo
        {
            get { return _FechaParseo; }
            set { _FechaParseo = value; }
        }

        private decimal _Prec;
        public decimal Prec
        {
            get { return _Prec; }
            set { _Prec = value; }
        }

        private decimal _Temt;
        public decimal Temt
        {
            get { return _Temt; }
            set { _Temt = value; }
        }

        private decimal _Dirv;
        public decimal Dirv
        {
            get { return _Dirv; }
            set { _Dirv = value; }
        }

        private decimal _Velv;
        public decimal Velv
        {
            get { return _Velv; }
            set { _Velv = value; }
        }

        private decimal _Radg;
        public decimal Radg
        {
            get { return _Radg; }
            set { _Radg = value; }
        }

        private decimal _Humr;
        public decimal Humr
        {
            get { return _Humr; }
            set { _Humr = value; }
        }

        private decimal _Humh;
        public decimal Humh
        {
            get { return _Humh; }
            set { _Humh = value; }
        }

        private decimal _Eto;
        public decimal Eto
        {
            get { return _Eto; }
            set { _Eto = value; }
        }

        public EstadoNum() {}
        public EstadoNum(int Numero, DateTime Fecha,string FechaParseo, decimal Prec,
        decimal Temt, decimal Dirv, decimal Velv, decimal Radg, decimal Humr,
        decimal Humh, decimal Eto) {
            this._Numero = Numero;
            this._Fecha = Fecha;
            this._FechaParseo = FechaParseo;
            this._Prec = Prec;
            this._Temt = Temt;
            this._Dirv = Dirv;
            this._Velv = Velv;
            this._Radg = Radg;
            this._Humr = Humr;
            this._Humh = Humh;
            this._Eto = Eto;
        }

        public static List<EstadoNum> GetEstacionesByIdEstacion(int Idedo, int IdEstacion, string inicio, string fin)
        {
            List<EstadoNum> ListaEstn = new List<EstadoNum>();
            List<EstadoNumEntity> Info = new List<EstadoNumEntity>();
            Info =Provider.Provider.EstadoNum.GetEstadosNumByIdEstacion(Idedo,IdEstacion,inicio,fin);
            foreach (EstadoNumEntity get in Info)
            {
                EstadoNum  esTrucEstado = new EstadoNum(get.Numero,get.Fecha,get.FechaParseo,get.Prec,get.Temt, get.Dirv,get.Velv,get.Radg,get.Humr,get.Humh,get.Eto);
                ListaEstn.Add(esTrucEstado);
            }
            return ListaEstn;
        }
        public static List<EstadoNum> GetEstacionUltimateDate(int Idedo, int IdEstacion)
        {
            List<EstadoNum> ListaEstn = new List<EstadoNum>();
            List<EstadoNumEntity> Info = new List<EstadoNumEntity>();
            Info = Provider.Provider.EstadoNum.GetEstadosNumUltimateDate(Idedo,IdEstacion);
            foreach (EstadoNumEntity get in Info)
            {
                EstadoNum esTrucEstado = new EstadoNum(get.Numero, get.Fecha, get.FechaParseo, get.Prec, get.Temt, get.Dirv, get.Velv, get.Radg, get.Humr, get.Humh, get.Eto);
                ListaEstn.Add(esTrucEstado);
            }
            return ListaEstn;
        }

    }
}
