using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaAlertas.Entity
{
    public class EstacionEntity
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

        public EstacionEntity() { }
        public EstacionEntity(
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
                this._InicioParseo=InicioParseo;
        }
    }
}
