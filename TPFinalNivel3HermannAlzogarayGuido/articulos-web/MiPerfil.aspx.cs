using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        //cargo las textbox con los datos que llego el usuario
                        Usuario usuario = (Usuario)Session["usuario"];
                        txtEmail.Text = usuario.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;

                        if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images/" + usuario.ImagenPerfil;
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoError.Agrego(HttpContext.Current, ex);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //actualizo la base de datos con las text de la pantalla Perfil
            lblMsjInfo.Visible = false;
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = (Usuario)Session["usuario"];

                //valido si se cargo la imagen
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.ImagenPerfil = "perfil-" + usuario.Id + ".jpg";
                }
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                negocio.Actualizar(usuario);

                Label lblUser = (Label)Master.FindControl("lblUser");
                if (!string.IsNullOrWhiteSpace(usuario.Nombre))
                    lblUser.Text = usuario.Nombre.ToUpper();
                else
                    lblUser.Text = usuario.Email;

                Image img = (Image)Master.FindControl("imgAvatar");
                if (!string.IsNullOrWhiteSpace(usuario.ImagenPerfil))
                {
                    img.ImageUrl = "~/Images/" + usuario.ImagenPerfil;
                    imgNuevoPerfil.ImageUrl = "~/Images/" + usuario.ImagenPerfil;
                }
                else
                {
                    img.ImageUrl = "https://previews.123rf.com/images/salamatik/salamatik1801/salamatik180100019/92979836-perfil-an%C3%B3nimo-icono-de-la-cara-persona-silueta-gris-avatar-masculino-por-defecto-foto-de.jpg";
                    imgNuevoPerfil.ImageUrl = "https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg";
                }
                lblMsjInfo.Visible = true;
                lblMsjInfo.Text = "&#9989; Tu perfil ha sido actualizado.";
                
            }
            catch (Exception ex)
            {
                ManejoError.Agrego(HttpContext.Current, ex);
            }
        }
    }
}