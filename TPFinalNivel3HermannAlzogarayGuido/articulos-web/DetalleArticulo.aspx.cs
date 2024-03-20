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

                    //cargo los datos del detalle del articulo
                    string id = Request.QueryString["idArticulo"];





                    ArticuloNegocio aNegocio = new ArticuloNegocio();
                    Articulo detallado = (aNegocio.listar(id))[0];

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
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }

        protected void btnAgregarFavorito_Click(object sender, EventArgs e)
        {
            
            string idArticulo = Request.QueryString["idArticulo"];

            
            Usuario usuario = (Usuario)Session["usuario"];
            if (usuario != null)
            {
                
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
    }
}
