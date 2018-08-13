using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaAlertas.Provider
{
    public class Provider
    {
        public static EstadoProvider Estado
        {
            get { return EstadoProvider.Intance; }
        }

        public static MunicipioProvider Municipio 
        {
            get { return MunicipioProvider.Intance; }
        }

        public static EstacionProvider Estacion
        {
            get { return EstacionProvider.Intance; }
        }

        public static EstadoNumProvider EstadoNum
        {
            get { return EstadoNumProvider.Intance; }
        }

        public static EstadoNumDiarioProvider EstadoNumDiario
        {
            get { return EstadoNumDiarioProvider.Intance; }
        }

    }
}
