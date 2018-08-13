using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaAlertas.Entity
{
    public class EstadoNumDiarioEntity
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

        private decimal _Tmed;
        public decimal Tmed
        {
            get { return _Tmed; }
            set { _Tmed = value; }
        }

        private decimal _VelvMax;
        public decimal VelvMax
        {
            get { return _VelvMax; }
            set { _VelvMax = value; }
        }

        private decimal _Velv;
        public decimal Velv
        {
            get { return _Velv; }
            set { _Velv = value; }
        }

        private decimal _DirvVMax;
        public decimal DirvVMax
        {
            get { return _DirvVMax; }
            set { _DirvVMax = value; }
        }

        private decimal _Dirv;
        public decimal Dirv
        {
            get { return _Dirv; }
            set { _Dirv = value; }
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

        private decimal _Et;
        public decimal Et
        {
            get { return _Et; }
            set { _Et = value; }
        }

        private decimal _Ep;
        public decimal Ep
        {
            get { return _Ep; }
            set { _Ep = value; }
        }

        private string _Porc;

        public string Porc
        {
            get { return _Porc; }
            set { _Porc = value; }
        }

        public EstadoNumDiarioEntity() { }
        public EstadoNumDiarioEntity(int Numero, DateTime Fecha, string FechaParseo, decimal Prec,
        decimal Tmax, decimal Tmin, decimal Tmed, decimal VelvMax,decimal Velv, decimal DrivVMax,decimal Dirv, decimal Radg, decimal Humr,
        decimal Et, decimal Ep, string Porc)
        {
            this._Numero = Numero;
            this._Fecha = Fecha;
            this._FechaParseo = FechaParseo;
            this._Prec = Prec;
            this._Tmax = Tmax;
            this._Tmin = Tmin;
            this._Tmed = Tmed;
            this._VelvMax = VelvMax;
            this._Velv = Velv;
            this._DirvVMax = DrivVMax;
            this._Dirv = Dirv;
            this._Radg = Radg;
            this._Humr = Humr;
            this._Et = Et;
            this._Ep = Ep;
            this._Porc = Porc;
        
        }

    }
}
