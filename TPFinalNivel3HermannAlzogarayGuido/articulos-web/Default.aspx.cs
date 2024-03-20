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
            //cargo el load de la pagina default con las cartas desde la DB
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listar();


            if (!IsPostBack)
            {
                repCartas.DataSource = ListaArticulos;
                repCartas.DataBind();
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {

            string idArticulo = ((LinkButton)sender).CommandArgument;
            Response.Redirect("DetalleArticulo.aspx?idArticulo=" + idArticulo);
        }

        protected void btnAgregarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                string idArticulo = ((LinkButton)sender).CommandArgument;

                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    //busco el articulo en la lista
                    Articulo articulo = ListaArticulos.FirstOrDefault(a => a.IdArticulo == int.Parse(idArticulo));
                    FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                    favoritoNegocio.AgregarFavorito(usuario, articulo);
                }
                else
                {
                    
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}