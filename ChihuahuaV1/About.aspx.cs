using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaAlertas.Business;
using System.Web.Script.Serialization;
namespace ChihuahuaV1
{
    public partial class About : Page
    {

        protected string x;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Estacion> ls = Estacion.GetEstaciones(8);
            JavaScriptSerializer serializador = new JavaScriptSerializer();
            x= serializador.Serialize(ls);

        }
    }
}