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
    public class Estado
    {
        #region propiedades
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
        #endregion

        #region constructores
        public Estado() { }

        public Estado(int Indice, string Nombre)
        {
            this._Indice = Indice;
            this._Nombre = Nombre;
        }
        #endregion

        #region metodos estaticos

        public static List<Estado> GetEstados()
        {
            List<Estado> ListaEdo = new List<Estado>();
            List<EstadoEntity> Estados = new List<EstadoEntity>();
            //Referencia en archivo SisAletas/Provider
            Estados = Provider.Provider.Estado.GetEstados();
            foreach (EstadoEntity get in Estados)
            {
                Estado esTrucEstado = new Estado(get.Indice, get.Nombre);
                ListaEdo.Add(esTrucEstado);
            }
            return ListaEdo;
        }

        #endregion
    }
}
