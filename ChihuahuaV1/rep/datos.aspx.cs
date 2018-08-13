using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Add
using SistemaAlertas.Business;
using ChihuahuaV1.proceso;
using System.Data;
using System.Data.SqlClient;

namespace ChihuahuaV1.rep
{
    public partial class datos : System.Web.UI.Page
    {
        protected List<EstadoNumDiario> lst;
        protected string calenda1, striplines;
        protected string chart1;
        protected int estacion,nom,lat,lon;
        protected void Page_Load(object sender, EventArgs e)
        {
            estacion = Convert.ToInt32(Request.QueryString["id"]);
            nameLabel.Text = "Estación: "+Request.QueryString["nom"];
            LatLabel.Text ="Latitud: "+ Request.QueryString["lat"];
            LongLabel.Text ="Longitud: "+ Request.QueryString["lon"];
            int type =  Convert.ToInt32(Session["typeOf"]);
            Labeltype.Text = "" + typep(type);
        }
        protected string calendas(int numEstacion, string fch1, string fch2, int tipo) {
            lst = EstadoNumDiario.GetEstadoNumDiarioByEstacion(8,numEstacion,fch1,fch2);
            string acumulador="";
            switch (tipo){
                case 1:
                    foreach (EstadoNumDiario row in lst)
                    {
                        DateTime date = Convert.ToDateTime(row.FechaParseo);
                        acumulador += "[new Date(" + date.Year + "," + date.Month + "," + date.Day + "),"+row.Tmax+" ],";
                    }
                    break;
                case 2:
                    foreach (EstadoNumDiario row in lst)
                    {
                        DateTime date = Convert.ToDateTime(row.FechaParseo);
                        acumulador += "[new Date(" + date.Year + "," + date.Month + "," + date.Day + "), "+row.Tmin+"],";
                    }
                    break;
            }
            
            return acumulador;
        }
        private string typep(int tp)
        {
            string info="NONE";
            switch (tp)
            {
                case 1:
                    info = "NUÉZ";
                    break;
                case 2:
                    info = "RUEZNO";
                    break;
                case 3:
                    info = "MAIZ";
                    break;
                case 4:
                    info = "DURAZNO";
                    break;
            }
            return info;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            List<grafica> lst= new List<grafica>();
            lst = grafica.toGridView(estacion, TextBoxFch1.Text, TextBoxFch2.Text, Convert.ToInt32(Session["typeOf"]), out chart1, out calenda1, out striplines);
        }
    }
}