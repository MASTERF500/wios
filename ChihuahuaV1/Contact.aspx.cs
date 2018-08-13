using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaAlertas.Business;
namespace ChihuahuaV1
{
    public partial class Contact : Page
    {
        protected string x;
        protected DateTime t1,t2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Request.QueryString["id"]) != 0 && TextBox1.Text == "")
            {
                TextBox1.Text = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
                //renderCharts(Convert.ToInt16(Request.QueryString["estacion"]), FechaTextBox.Text);
                //estacionDatos(Convert.ToInt16(Request.QueryString["estacion"]));
                t2=t1 = DateTime.Today;
            }
            
        }



        #region autopostback
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {


        }
        #endregion
    }
}