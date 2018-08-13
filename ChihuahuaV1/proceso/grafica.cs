using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Add
using SistemaAlertas.Business;

namespace ChihuahuaV1.proceso
{
    public class grafica
    {
        private DateTime _Fecha;
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        private decimal _HorasDia;
        public decimal HorasDia
        {
            get { return _HorasDia; }
            set { _HorasDia = value; }
        }
        grafica() { }
        grafica(DateTime Fecha, decimal HorasDia) {
            this._Fecha = Fecha;
            this._HorasDia = HorasDia;
        }
        public static List<grafica> toGridView(int numero, string fch1, string fhc2, int tipo, out string chart, out string calenda, out string strpLns)
        {
            #region list_&_call_method
            List<grafica> lstReturn = new List<grafica>();
            List<EstadoNumDiario> lstDatos = new List<EstadoNumDiario>();
            lstDatos = EstadoNumDiario.GetEstadoNumDiarioByEstacion(8, numero, fch1, fhc2);
            #endregion
            #region vars_&_switch
            //unidades calor - numero division - num base - ovip - huevesillo - Larva - Pupa
            decimal uc = 0, v = 2, b = 0, O = 0, H = 0, L = 0, P = 0;
            strpLns = "";
            switch (tipo)
            {
                case 1:
                    //Nuez
                    b = 3.3m; O = 55; H = 155; L = 694; P = 907;
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
            #endregion
            #region chart_&_grid
            chart = "";
            bool fl1, fl2, fl3, fl4;
            fl1 = fl2 = fl3 = fl4 = false;
                foreach (EstadoNumDiario row in lstDatos)
                {
                    //FillStringToChart
                    DateTime date = Convert.ToDateTime(row.FechaParseo);
                    decimal tm = row.Tmax + row.Tmin;
                    uc += tm / v - b;
                    if (uc >= O && fl1 == false) { strpLns += "{value:new Date(" + date.Year + "," + (date.Month - 1) + "," + date.Day + "),showOnTop: true,lineDashType: 'dot',Label: 'Ovip Limite: 55 UC'}"; fl1 = true; }
                    if (uc >= H && fl2 == false) { strpLns += ",{value:new Date(" + date.Year + "," + (date.Month - 1) + "," + date.Day + "),showOnTop: true,lineDashType: 'dot',Label: 'Huevesillo Limite: 155 UC'}"; fl2 = true; }
                    if (uc >= L && fl3 == false) { strpLns += ",{value:new Date(" + date.Year + "," + (date.Month - 1) + "," + date.Day + "),showOnTop: true,lineDashType: 'dot',Label: 'Larva: 694 UC'},"; fl3=true;}
                    if (uc >= P && fl4 == false) { strpLns += ",{value:new Date(" + date.Year + "," + (date.Month - 1) + "," + date.Day + "),showOnTop: true,lineDashType: 'dot',Label: 'Pupa Limite: 907 UC'},"; fl4 = true; }
                    chart += "{x:new Date(" + date.Year + "," + (date.Month - 1) + "," + date.Day + "), y: " + (uc < 0 ? 0 : uc) + "},";
                    //FillLstToGrid
                    grafica lstEstructura = new grafica(Convert.ToDateTime(row.FechaParseo),uc);
                    lstReturn.Add(lstEstructura);
                }
            #endregion
            #region calenda
            calenda = "";
            uc = 0;
            foreach (EstadoNumDiario row in lstDatos)
            {
                //FillStringToCalendar
                DateTime date = Convert.ToDateTime(row.FechaParseo);
                decimal tm = row.Tmax + row.Tmin;
                uc += tm / v - b;
                calenda += "[new Date(" + date.Year + "," + (date.Month - 1) + "," + date.Day + "), " + (uc < 0 ? 0 : uc) + "],";
            }
            #endregion
            return lstReturn;
        }
        #region code
        //public static string graficar(int numero, string fch1, string fhc2,int tipo) {
        //    List<EstadoNumDiario> lst = new List<EstadoNumDiario>();
        //    lst = EstadoNumDiario.GetEstadoNumDiarioByEstacion(8,numero,fch1,fhc2);
        //    decimal uc = 0, v = 2, b=0;
        //    string acumulador = "";
        //    foreach (EstadoNumDiario row in lst) {
        //        DateTime date = Convert.ToDateTime(row.FechaParseo);
        //        decimal tm=row.Tmax + row.Tmin;
        //        uc += tm / v - b;
        //        acumulador += "{x:new Date(" + date.Year + "," + (date.Month - 1) + "," + date.Day + "), y: " + (uc < 0 ? 0 : uc) + "},";
        //    }
        //    return acumulador;
        //}
        //public static string calenda(int numero, string fch1, string fhc2) {
        //    List<EstadoNumDiario> lst = new List<EstadoNumDiario>();
        //    lst = EstadoNumDiario.GetEstadoNumDiarioByEstacion(8, numero, fch1, fhc2);
        //    decimal uc = 0, v = 2, b = 0;
        //    string acumulador = "";
        //    foreach (EstadoNumDiario row in lst)
        //    {
        //        DateTime date = Convert.ToDateTime(row.FechaParseo);
        //        decimal tm = row.Tmax + row.Tmin;
        //        uc += tm / v - b;
        //        acumulador += "[new Date(" + date.Year + "," + (date.Month - 1) + "," + date.Day + "), " + (uc < 0 ? 0 : uc) + "],";
        //    }
        //    return acumulador;
        //}
        #endregion

    }
}