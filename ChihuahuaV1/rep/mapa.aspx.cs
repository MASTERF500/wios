using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//NameSpaces: Dll Connection N-Tier
using SistemaAlertas.Business;
//NameSpaces: Parsin to Json Format
using System.Web.Script.Serialization;

namespace ChihuahuaV1.rep
{
    public partial class mapa : System.Web.UI.Page
    {
        protected string estaciones;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Estacion> ls = Estacion.GetEstaciones(8);
            JavaScriptSerializer serializador = new JavaScriptSerializer();
            estaciones = serializador.Serialize(ls);
        }
    }
}