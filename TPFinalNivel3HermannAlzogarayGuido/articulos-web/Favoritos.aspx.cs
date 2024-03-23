using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace articulos_web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Usuario usuario = (Usuario)Session["usuario"];
                        FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                        List<Articulo> favoritos = favoritoNegocio.ListarFavorito(usuario);
                        repFavoritos.DataSource = favoritos;
                        repFavoritos.DataBind();
                    }
                    else
                    {
                        Response.Redirect("Login.aspx", false);
                    }

                }
            }
            catch (Exception ex)
            {

                ManejoError.Agrego(HttpContext.Current, ex);
            }
        }

        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnEliminarFavorito = (Button)sender;
                int idArticulo = int.Parse(btnEliminarFavorito.CommandArgument);
                Usuario usuario = (Usuario)Session["usuario"];
                if (Seguridad.sesionActiva(usuario))
                {
                    FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                    favoritoNegocio.EliminarFavorito(usuario, idArticulo);
                    Response.Redirect(Request.RawUrl, false);
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {

                ManejoError.Agrego(HttpContext.Current, ex);
            }

        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            string idArticulo = ((LinkButton)sender).CommandArgument;
            Response.Redirect("DetalleArticulo.aspx?idArticulo=" + idArticulo);
        }
    }
}