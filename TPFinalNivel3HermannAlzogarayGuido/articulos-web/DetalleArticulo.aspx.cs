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
    public partial class DetalleArticulo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //cargo los datos del detalle del articulo que me llegan en sesion
                    string id = Request.QueryString["idArticulo"];
                    //valido si el id no llega vacio desde la sesion
                    if (string.IsNullOrEmpty(id))
                    {
                        Session.Add("error", "El ID del articulo es invalido, no existe");
                        Response.Redirect("Error.aspx", false);
                        return;
                    }
                    //validar si existe el ID del articulo
                    ArticuloNegocio aNegocio = new ArticuloNegocio();
                    List<Articulo> listaArticulos = aNegocio.listar();

                    //recorro la lista preguntando por el id que me llego en sesion
                    Articulo detallado = listaArticulos.FirstOrDefault(a => a.IdArticulo == int.Parse(id));

                    //si el id del articulo que me llego en la sesion no existe, redirigo a error
                    if (detallado == null)
                    {
                        Session.Add("error", "El articulo no existe en la base de datos");
                        Response.Redirect("Error.aspx", false);
                        return;
                    }
                    //cargo los datos del articulo
                    lblCodigoArticulo.Text = detallado.CodigoArticulo;
                    lblNombreArticulo.Text = detallado.Nombre;
                    lblDescripcion.Text = detallado.Descripcion;
                    lblMarca.Text = detallado.Marca.Descripcion;
                    imgDetalle.ImageUrl = detallado.Imagen;
                    imgDetalle.DataBind();
                    lblCategoria.Text = detallado.Categoria.Descripcion;
                    lblPrecio.Text = detallado.Precio.ToString("F2");
                }
            }
            catch (Exception ex)
            {
                ManejoError.Agrego(HttpContext.Current, ex);
            }
        }

        protected void btnAgregarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                //recibo el id por sesion
                string idArticulo = Request.QueryString["idArticulo"];

                //asigno el usuario que me llego en sesion
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario != null)
                {
                    //agrego el articulo a favoritos
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    Articulo articulo = articuloNegocio.listar(idArticulo)[0];
                    FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                    favoritoNegocio.AgregarFavorito(usuario, articulo);
                    lblFavorito.Text = "Tu articulo ha sido añadido a favoritos";
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
    }
}
