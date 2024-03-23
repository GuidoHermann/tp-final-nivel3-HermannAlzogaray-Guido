using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Collections.Specialized.BitVector32;


namespace articulos_web
{
    public class ManejoError
    {
        public static void Agrego(HttpContext context, Exception ex)
        {
            context.Session.Add("Error", ex.Message);
            context.Response.Redirect("Error.aspx", false);
        }
    }
}