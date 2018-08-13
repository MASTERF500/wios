using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaAlertas.Entity
{
    public class MunicipioEntity
    {
            private int _Indice;

            public int Indice
            {
                get { return _Indice; }
                set { _Indice = value; }
            }
            private int _Idedo;

            public int Idedo
            {
                get { return _Idedo; }
                set { _Idedo = value; }
            }
            private string _Nombre;

            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

         public MunicipioEntity() { }

            public MunicipioEntity(int Indice,int Idedo, string Nombre)
            {
                this._Indice = Indice;
                this._Idedo = Idedo;
                this._Nombre = Nombre;
            }

    }
}
