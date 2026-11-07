using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        // Almacena la cadena de conexión centralizada para toda la capa de datos
        private static readonly string cadenaConexion = @"Server=.;Database=DBParqueo;Trusted_Connection=True;TrustServerCertificate=True;";

        // Método que crea y retorna una nueva instancia de la conexión SQL
        public static SqlConnection ObtenerConexion()
        {
            // Instancia el objeto SqlConnection con la cadena definida
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            // Retorna la conexión lista para ser abierta
            return conexion;
        }
    }
}