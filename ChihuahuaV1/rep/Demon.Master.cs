using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChihuahuaV1.rep
{
    public partial class Demon : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonNuez_Click(object sender, EventArgs e)
        {
            Session["typeOf"] = "1";
            Response.Redirect("mapa.aspx?type=1");
        }

        protected void ButtonRuezno_Click(object sender, EventArgs e)
        {
            Session["typeOf"] = "2";
            Response.Redirect("mapa.aspx?type=2");
        }

        protected void ButtonMaiz_Click(object sender, EventArgs e)
        {
            Session["typeOf"] = "3";
            Response.Redirect("mapa.aspx?type=3");
        }

        protected void ButtonDurazno_Click(object sender, EventArgs e)
        {
            Session["typeOf"] = "4";
            Response.Redirect("mapa.aspx?type=4");
        }
    }
}