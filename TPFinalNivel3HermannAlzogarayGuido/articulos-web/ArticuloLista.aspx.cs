using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace articulos_web
{
    public partial class ArticuloLista : System.Web.UI.Page

    {
        public bool FiltroAvazando { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //valido al usuario, si es admin le doy permiso, si no redirigo a error
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    if (!Seguridad.esAdmin(Session["usuario"]))
                    {
                        Session.Add("error", "Para acceder a esta pagina debes ser administrador");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }

                FiltroAvazando = chkAvanzado.Checked;
                if (!IsPostBack)
                {
                    //Carga del griw view en el load de la pagina
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Session.Add("listaArticulo", negocio.listar());
                    dgvArticulo.DataSource = Session["listaArticulo"];
                    dgvArticulo.DataBind();

                }
            }
            catch (Exception ex)
            {

                ManejoError.Agrego(HttpContext.Current, ex);
            }


        }
        protected void dgvArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //para modificar un articulo
            string id = dgvArticulo.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void dgvArticulo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                //para cambiar entre las paginas de grillas
                dgvArticulo.PageIndex = e.NewPageIndex;
                cargoDatos();
            }
            catch (Exception ex)
            {

                ManejoError.Agrego(HttpContext.Current, ex);
            }


        }
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //cargo la lista previamente guardada en la sesion para hacer la busqueda rapida
                List<Articulo> lista = (List<Articulo>)Session["listaArticulo"];
                List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                dgvArticulo.DataSource = listaFiltrada;
                dgvArticulo.DataBind();
            }
            catch (Exception ex)
            {
                ManejoError.Agrego(HttpContext.Current, ex);
            }
        }
        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            //cambio la propiedad del filtro para que solo se pueda buscar por el avanzado
            FiltroAvazando = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvazando;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargo los desplegas y los configuro con los parametros para filtrar
            string ddlCampoSeleccionado = ddlCampo.SelectedItem.ToString();
            if (ddlCampoSeleccionado == "Codigo" || ddlCampoSeleccionado == "Nombre" || ddlCampoSeleccionado == "Descripcion")
            {

                ddlCriterio.DataSource = null;
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");

            }
            else if (ddlCampoSeleccionado == "Precio")
            {
                ddlCriterio.DataSource = null;
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //valido los campos al filtrar cuando le doy click a guardar
                Page.Validate();
                if (!Page.IsValid)
                    return;
                if (ddlCampo.SelectedItem.Text == "Precio")
                {
                    if (!int.TryParse(txtFiltroAvanzado.Text, out int result))
                    {

                        lblMensajeFiltroError.Text = "Por favor, ingrese solo números en el campo Precio.";
                        return;
                    }
                }

                lblMensajeFiltroError.Text = "";
                //hago la busqueda
                cargoDatos();

                lblMensajeFiltroError.Text = "Busqueda realizada";
            }
            catch (Exception ex)
            {

                ManejoError.Agrego(HttpContext.Current, ex);
            }
        }

        protected void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioArticulo.aspx", false);
        }
        private void cargoDatos()
        {
            //encapsulamiento de la busqueda del filtro y del a carga de articulos
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                if (FiltroAvazando)
                {
                    dgvArticulo.DataSource = negocio.filtrar(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text);
                    dgvArticulo.DataBind();
                }
                else
                {
                    dgvArticulo.DataSource = negocio.listar();
                    dgvArticulo.DataBind();
                }

            }
            catch (Exception ex)
            {

                ManejoError.Agrego(HttpContext.Current, ex);
            }
        }


    }
}