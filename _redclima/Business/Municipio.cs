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
    public class Municipio
    {
        #region propiedades
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
        
        #endregion

        #region constructores
        public Municipio() { }

        public Municipio(int Indice,int idedo, string Nombre)
        {
            this._Indice = Indice;
            this._Idedo = Idedo;
            this._Nombre = Nombre;
        }
        #endregion

        #region metodos estaticos

        public static List<Municipio> GetMunicipios(int idedo)
        {
            List<Municipio> ListaMcp = new List<Municipio>();
            List<MunicipioEntity> Municipios = new List<MunicipioEntity>();
            //Referencia en archivo SisAletas/Provider
            Municipios = Provider.Provider.Municipio.GetMunicipios(idedo);
            foreach (MunicipioEntity get in Municipios)
            {
                Municipio esTrucMunicipio = new Municipio(get.Indice,get.Idedo,get.Nombre);
                ListaMcp.Add(esTrucMunicipio);
            }
            return ListaMcp;
        }

        #endregion
    }
}
