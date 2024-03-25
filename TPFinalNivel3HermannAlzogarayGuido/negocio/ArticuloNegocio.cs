using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;


namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> listadb = new List<Articulo>();
            AccesoDb datos = new AccesoDb();
            try
            {
                string consulta = "Select A.Id ArticuloId, Codigo , Nombre, A.Descripcion ArticuloDescripcion, ImagenUrl, Precio, A.IdMarca IdMarca, A.IdCategoria IdCategoria, C.Descripcion DescripcionCategoria, M.Descripcion DescripcionMarca From ARTICULOS A, CATEGORIAS C, MARCAS M Where C.Id = A.IdCategoria AND M.Id = A.IdMarca";
                //si se agrega un id lo uso como filtro
                if (id != "")
                    consulta += " and A.Id = " + id;
                datos.establecerConsulta(consulta);
                datos.ejectuarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();

                    //asigno los valores
                    aux.IdArticulo = (int)datos.Lector["ArticuloId"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["ArticuloDescripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Imagen = (string)datos.Lector["ImagenUrl"];

                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["DescripcionMarca"];

                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["DescripcionCategoria"];




                    listadb.Add(aux);
                }
               
                    return listadb;
               
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void añadir(Articulo nuevo)
        {
            AccesoDb acceso = new AccesoDb();
            try
            {
                acceso.establecerConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values( @codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio)");

                acceso.establecerParametro("@codigo", nuevo.CodigoArticulo);
                acceso.establecerParametro("@nombre", nuevo.Nombre);
                acceso.establecerParametro("@descripcion", nuevo.Descripcion);
                acceso.establecerParametro("@idMarca", nuevo.Marca.Id);
                acceso.establecerParametro("@idCategoria", nuevo.Categoria.Id);
                acceso.establecerParametro("@imagenUrl", nuevo.Imagen);
                acceso.establecerParametro("@precio", nuevo.Precio);

                acceso.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

        public void modificar(Articulo modificado)
        {
            AccesoDb acceso = new AccesoDb();
            try
            {
                acceso.establecerConsulta("Update ARTICULOS set Codigo = @codigo , Nombre = @nombre, Descripcion = @descripcion , IdMarca = @idMarca , IdCategoria = @idCategoria, ImagenUrl = @imageUrl, Precio = @precio Where id = @idArticulo");

                acceso.establecerParametro("@codigo", modificado.CodigoArticulo);
                acceso.establecerParametro("@nombre", modificado.Nombre);
                acceso.establecerParametro("@descripcion", modificado.Descripcion);
                acceso.establecerParametro("@idMarca", modificado.Marca.Id);
                acceso.establecerParametro("@idCategoria", modificado.Categoria.Id);
                acceso.establecerParametro("@imageUrl", modificado.Imagen);
                acceso.establecerParametro("@precio", modificado.Precio);
                acceso.establecerParametro("@idArticulo", modificado.IdArticulo);

                acceso.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

        public void eliminar(Usuario usuario,int id)
        {
            AccesoDb acceso = new AccesoDb();
            try
            {
                acceso.establecerConsulta("Delete from ARTICULOS where id = @id");
                acceso.establecerParametro("id", id);
                acceso.ejecutarAccion();
                //despues de eliminar el articulo, tambien lo elimino de favoritos
                acceso.establecerConsulta("DELETE FROM Favoritos WHERE IdUser = @IdUser AND IdArticulo = @IdArticulo");
                acceso.establecerParametro("@IdUser", usuario.Id);
                acceso.establecerParametro("@IdArticulo", id);
                acceso.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDb acceso = new AccesoDb();

            try
            {

                string consulta = "Select A.Id ArticuloId, Codigo , Nombre, A.Descripcion ArticuloDescripcion, ImagenUrl, Precio, A.IdMarca IdMarca, A.IdCategoria IdCategoria, C.Descripcion DescripcionCategoria, M.Descripcion DescripcionMarca From ARTICULOS A, CATEGORIAS C, MARCAS M Where C.Id = A.IdCategoria AND M.Id = A.IdMarca AND ";

                if (campo == "Codigo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Codigo like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Codigo like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Codigo like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Descripcion")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "A.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }
                acceso.establecerConsulta(consulta);
                acceso.ejectuarLectura();

                while (acceso.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();


                    aux.IdArticulo = (int)acceso.Lector["ArticuloId"];
                    aux.CodigoArticulo = (string)acceso.Lector["Codigo"];
                    aux.Nombre = (string)acceso.Lector["Nombre"];
                    aux.Descripcion = (string)acceso.Lector["ArticuloDescripcion"];

                    if (!(acceso.Lector["ImagenUrl"] is DBNull))
                        aux.Imagen = (string)acceso.Lector["ImagenUrl"];

                    aux.Precio = (decimal)acceso.Lector["Precio"];

                    aux.Marca.Id = (int)acceso.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)acceso.Lector["DescripcionMarca"];

                    aux.Categoria.Id = (int)acceso.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)acceso.Lector["DescripcionCategoria"];


                    lista.Add(aux);
                }
                return lista;


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }
    }
}
