using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRF.Provider
{
    public class Provider
    {
        public static PronosticoProvider Pronostico {
            get { return PronosticoProvider.Instance;}
        }
    }
}
