using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public int nuevoUsuario(Usuario nuevo)
        {
            AccesoDb acceso = new AccesoDb();
            try
            {
                acceso.establecerConsulta("insert into USERS (email, pass) output inserted.id values (@email, @pass)");
                acceso.establecerParametro("@email", nuevo.Email);
                acceso.establecerParametro("@pass", nuevo.Pass);
                return acceso.ejecutarAccionScalar();
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

        public bool Login(Usuario usuario)
        {
            AccesoDb datos = new AccesoDb();
            try
            {
                datos.establecerConsulta("Select Id, email, pass, admin, urlImagenPerfil, nombre, apellido from USERS Where email = @email And pass = @pass");
                datos.establecerParametro("@email", usuario.Email);
                datos.establecerParametro("@pass", usuario.Pass);
                datos.ejectuarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Admin = (bool)datos.Lector["admin"];

                    //verifico si los datos no estan nullos en la DB
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];

                    return true;

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

        public void Actualizar(Usuario usuario)
        {
            AccesoDb datos = new AccesoDb();
            try
            {
                datos.establecerConsulta("Update USERS set urlImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido Where Id = @id");
                datos.establecerParametro("@imagen", (object)usuario.ImagenPerfil ?? DBNull.Value);
                datos.establecerParametro("@nombre", usuario.Nombre);
                datos.establecerParametro("@apellido", usuario.Apellido);
                datos.establecerParametro("id", usuario.Id);
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

        public bool ExisteUsuario(string email)
        {
                AccesoDb datos = new AccesoDb();
            try
            {
                datos.establecerConsulta("SELECT COUNT(*) FROM USERS WHERE email = @email");
                datos.establecerParametro("@email", email);
                return datos.ejecutarAccionScalar() > 0;

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
