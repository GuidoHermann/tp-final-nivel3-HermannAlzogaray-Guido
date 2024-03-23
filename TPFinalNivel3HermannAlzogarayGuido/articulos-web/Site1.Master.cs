using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace articulos_web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //pregunto a cuales paginas se puede acceder sin estar logeado

            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if (!string.IsNullOrEmpty(usuario.Nombre))
                    lblUser.Text = usuario.Nombre.ToUpper();
                else
                    lblUser.Text = usuario.Email;

                if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
                    imgAvatar.ImageUrl = "~/Images/" + usuario.ImagenPerfil;
                else
                    imgAvatar.ImageUrl = "https://previews.123rf.com/images/salamatik/salamatik1801/salamatik180100019/92979836-perfil-an%C3%B3nimo-icono-de-la-cara-persona-silueta-gris-avatar-masculino-por-defecto-foto-de.jpg";
            }
            else
            {
                
                imgAvatar.ImageUrl = "https://previews.123rf.com/images/salamatik/salamatik1801/salamatik180100019/92979836-perfil-an%C3%B3nimo-icono-de-la-cara-persona-silueta-gris-avatar-masculino-por-defecto-foto-de.jpg";
            }

            if (!(Page is Login || Page is Registro || Page is Default || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
                
            }







        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }

        
    }
}