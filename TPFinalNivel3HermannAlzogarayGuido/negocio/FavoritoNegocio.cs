using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class FavoritoNegocio
    {
        
        public void AgregarFavorito(Usuario usuario, Articulo articulo)


        {
            AccesoDb datos = new AccesoDb();
            try
            {
                //pregunto si no existe un favorito ya con ese id
                if(!ExisteFavorito(usuario, articulo))
                {
                    datos.establecerConsulta("Insert INTO FAVORITOS (IdUser, IdArticulo) values(@IdUser,@IdArticulo)");
                    datos.establecerParametro("@IdUser", usuario.Id);
                    datos.establecerParametro("IdArticulo", articulo.IdArticulo);
                    datos.ejecutarAccion();
                }
                
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

        public void EliminarFavorito(Usuario usuario, int id)
        {
            AccesoDb datos = new AccesoDb();
            try
            {
                datos.establecerConsulta("DELETE FROM Favoritos WHERE IdUser = @IdUser AND IdArticulo = @IdArticulo");
                datos.establecerParametro("@IdUser", usuario.Id);
                datos.establecerParametro("@IdArticulo",id);
                datos.ejecutarAccion();
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

        public List<Articulo> ListarFavorito(Usuario usuario)
        {
            AccesoDb datos = new AccesoDb();
            List<Articulo> favoritos = new List<Articulo>();
            try
            {
                datos.establecerConsulta("SELECT IdArticulo FROM Favoritos WHERE IdUser = @IdUser");
                datos.establecerParametro("@IdUser", usuario.Id);
                datos.ejectuarLectura();

                while (datos.Lector.Read())
                {
                    int idArticulo = (int)datos.Lector["IdArticulo"];
                    
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo articulo = negocio.listar(idArticulo.ToString())[0];
                    favoritos.Add(articulo);
                }
                    return favoritos;
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

        private bool ExisteFavorito(Usuario usuario, Articulo articulo)
        {
            AccesoDb datos = new AccesoDb();
            try
            {
                datos.establecerConsulta("SELECT COUNT(*) FROM Favoritos WHERE IdUser = @IdUser AND IdArticulo = @IdArticulo");
                datos.establecerParametro("@IdUser", usuario.Id);
                datos.establecerParametro("@IdArticulo", articulo.IdArticulo);
                datos.ejectuarLectura();

                if (datos.Lector.Read())
                {
                    int count = Convert.ToInt32(datos.Lector[0]);
                    return count > 0; 
                }
                return false;
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
    }
}
