using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChihuahuaV1.rep
{
    public partial class info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            int estacion = Convert.ToInt32(Request.QueryString["id"]);
            int type =  Convert.ToInt32(Session["type"]);
            if ( estacion != 0 && TextBoxFch1.Text == "" && TextBoxfch2.Text == "")
            {
              TextBoxFch1.Text=TextBoxfch2.Text= DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
            }
        }
        private string type(int tp) {
            string info;
            switch (tp) { 
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
            return "";        
        }

        protected void ImageButtonAccept_Click(object sender, ImageClickEventArgs e)
        {
            if (CompareValidatorFechas.IsValid == true)
            {
                //Session["fch1"] = TextBoxFch1.Text;
                //Session["fch2"] = TextBoxfch2.Text;
            }
        }

        protected void TextBoxFch1_TextChanged(object sender, EventArgs e)
        {
        }

        protected void TextBoxfch2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}