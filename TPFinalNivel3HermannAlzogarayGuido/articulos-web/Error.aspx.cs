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
            // Verificar si hay un error en la sesión
            if (Session["Error"] != null)
            {
                
                lblError.Text = Session["Error"] as string;
                
                Session.Remove("Error");
            }
            else
            {
                
                lblError.Text = "No se encontró ningún error.";
            }
        }
    }
}