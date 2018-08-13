using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRF.Entity
{
    public class PronosticoEntity
    {
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
                public PronosticoEntity() { }
                public PronosticoEntity(int Estacion, string Fecha, int Dia, decimal Prec, decimal Tmax, decimal Tmin, decimal Temp, decimal Eto) 
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

    }
}
