using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class TipoVehiculoNegocio
    {
        // Instancia de la clase de datos de tipo de vehículo
        private TipoVehiculoDatos tipoDatos = new TipoVehiculoDatos(); // (O simplemente new TipoVehiculoDatos())

        // Método para listar los tipos de vehículos llamando a la capa de datos
        public DataTable Listar()
        {
            TipoVehiculoDatos datos = new TipoVehiculoDatos();
            // Retorna el DataTable obtenido desde la capa de datos
            return datos.Listar();
        }
    }
}