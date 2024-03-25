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
    public partial class Default : System.Web.UI.Page
    {

        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                //cargo el load de la pagina default con las cartas desde la DB
                ArticuloNegocio negocio = new ArticuloNegocio();
                ListaArticulos = negocio.listar();
                if (!IsPostBack)
                {
                    repCartas.DataSource = ListaArticulos;
                    repCartas.DataBind();
                }
            }
            catch (Exception ex)
            {
                ManejoError.Agrego(HttpContext.Current, ex);
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            //redigiro a la pagila de detalle utilizando el id del boton
            string idArticulo = ((LinkButton)sender).CommandArgument;
            Response.Redirect("DetalleArticulo.aspx?idArticulo=" + idArticulo);
        }

        protected void btnAgregarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                //agrego el id para buscar el articulo
                string idArticulo = ((LinkButton)sender).CommandArgument;
                //pregunto si hay un usuario en sesion
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    //busco el articulo en la lista
                    Articulo articulo = ListaArticulos.FirstOrDefault(a => a.IdArticulo == int.Parse(idArticulo));
                    FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                    favoritoNegocio.AgregarFavorito(usuario, articulo);
                    Label lblFavorito = (Label)((Control)sender).Parent.FindControl("lblFavoritoAgregado");
                    lblFavorito.Visible = true;

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