using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Globalization;


namespace articulos_web
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool Confirmar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtId.Visible = false;
            try
            {
                //cargo los datos para los desplegables para agregar un articulo nuevo
                if (!IsPostBack)
                {
                    CategoriaNegocio categoria = new CategoriaNegocio();
                    MarcaNegocio marca = new MarcaNegocio();
                    List<Categoria> listaCategoria = categoria.listarCategoria();
                    List<Marca> listaMarca = marca.listarMarca();
                    ddlCategoria.DataSource = listaCategoria;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }
                //pregunto si trae un ID entonces es modificacion
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = (negocio.listar(id))[0];
                    //lo agrego a la sesion para usarlo
                    Session.Add("articuloSeleccionado", seleccionado);

                    //cargo los campos para la modificacion
                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.CodigoArticulo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagen.Text = seleccionado.Imagen;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    txtImagen_TextChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                ManejoError.Agrego(HttpContext.Current, ex);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                //asigno los datos de las textbox a un articulo para llevarlo a la base datos
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                nuevo.CodigoArticulo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Imagen = txtImagen.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text, CultureInfo.InvariantCulture);

                //pregunto si tiene un ID y si es asi lo modifico, si no agrego un nuevo articulo
                if (Request.QueryString["id"] != null)
                {
                    nuevo.IdArticulo = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                }
                else
                    negocio.añadir(nuevo);

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                ManejoError.Agrego(HttpContext.Current, ex);
            }
        }



        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtImagen.Text))
                imgArticulo.ImageUrl = Validar.imagenHolder();
            else
                imgArticulo.ImageUrl = txtImagen.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //pongo la propiedad en true para poder ver el otro boton
            Confirmar = true;
        }

        protected void btnConfirmoEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmo.Checked)
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(usuario,int.Parse(txtId.Text));
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {

                ManejoError.Agrego(HttpContext.Current, ex);
            }
        }
    }
}