using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                if (Session["error"] != null)
                {
                    lblError.Text = Session["error"].ToString();
                }
                else
                {
                    lblError.Text = "Si estas viendo esto es que no hay error ?....";
                  
                }
        }
    }
}