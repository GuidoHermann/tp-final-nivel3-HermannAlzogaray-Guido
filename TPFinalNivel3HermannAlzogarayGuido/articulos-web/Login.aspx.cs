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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                lblPassError.Visible = false;
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Usuario usuario = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPassword.Text;

                //pregunto si hay un usuario con esas caracteristicas y lo cargo en sesion
                if (negocio.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    lblPassError.Text = "&#128683; Usuario o contraseña incorrectos";
                    lblPassError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ManejoError.Agrego(HttpContext.Current, ex);
            }
        }
    }
}