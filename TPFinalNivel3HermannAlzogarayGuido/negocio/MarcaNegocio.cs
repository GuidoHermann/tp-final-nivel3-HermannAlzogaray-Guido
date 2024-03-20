using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listarMarca()
        {
            List<Marca> listaMarca = new List<Marca>();
            AccesoDb datos = new AccesoDb();

            try
            {
                datos.establecerConsulta("Select Id, Descripcion from MARCAS");
                datos.ejectuarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    listaMarca.Add(aux);
                }
                return listaMarca;
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
