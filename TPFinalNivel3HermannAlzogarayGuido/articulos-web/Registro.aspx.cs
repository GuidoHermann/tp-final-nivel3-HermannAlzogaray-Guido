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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            //creacion del usuario creando todos los datos
            try
            {
                lblMensajeMail.Visible = false;
                lblErrorPass.Visible = false;
                //validaciones
                Page.Validate();
                if (!Page.IsValid)
                    return;
                //CREAR VALIDACION DOBLE DE CONTRASEÑA
                //VALIDAR SI YA EXISTE UN USUARIO CON ESE MAIL

                string email = txtEmail.Text;
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                if (!usuarioNegocio.ExisteUsuario(email))
                {
                    if (txtPassword.Text == txtConfirmoPass.Text)
                    {
                        Usuario usuario = new Usuario();
                        usuario.Email = email;
                        usuario.Pass = txtPassword.Text;
                        usuario.Id = usuarioNegocio.nuevoUsuario(usuario);
                        Session.Add("usuario", usuario);
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        lblErrorPass.Visible = true;
                        lblErrorPass.Text = "&#128683 Las contraseñas no coinciden";
                    }
                }
                else
                {
                    lblMensajeMail.Visible = true;
                    lblMensajeMail.Text = "&#128267; Ya existe un usuario con ese correo, intenta loguearte";
                }
            }
            catch (Exception ex)
            {
                ManejoError.Agrego(HttpContext.Current, ex);
            }
        }




    }
}