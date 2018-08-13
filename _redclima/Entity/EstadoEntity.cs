using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaAlertas.Entity
{
    public class EstadoEntity
    {
        private int _Indice;

        public int Indice
        {
            get { return _Indice; }
            set { _Indice = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public EstadoEntity() { }

        public EstadoEntity(int Indice, string Nombre)
        {
            this._Indice = Indice;
            this._Nombre = Nombre;
        }
    }

    
}
