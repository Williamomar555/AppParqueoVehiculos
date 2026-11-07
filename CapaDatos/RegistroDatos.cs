using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class RegistroDatos
    {
        // Método para registrar la entrada de un vehículo
        public bool RegistrarEntrada(string placa, int idTipo, DateTime horaEntrada)
        {
            // Establece la conexión a la base de datos
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                // Define la consulta SQL de inserción usando parámetros para evitar inyecciones SQL
                string query = "INSERT INTO Registro (Placa, IdTipo, HoraEntrada, HoraSalida, TotalPagar) VALUES (@Placa, @IdTipo, @HoraEntrada, NULL, NULL)";

                // Crea el comando SQL
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    // Añade el parámetro de la placa
                    cmd.Parameters.AddWithValue("@Placa", placa);

                    // Añade el parámetro del tipo de vehículo
                    cmd.Parameters.AddWithValue("@IdTipo", idTipo);

                    // Añade el parámetro de la hora de entrada
                    cmd.Parameters.AddWithValue("@HoraEntrada", horaEntrada);

                    // Abre la conexión
                    conexion.Open();

                    // Ejecuta la consulta y verifica si se afectó al menos una fila
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // Retorna verdadero si la inserción fue exitosa
                    return filasAfectadas > 0;
                }
            }
        }

        // Método para listar los vehículos que se encuentran actualmente dentro del parqueo (HoraSalida es nula)
        public DataTable ListarVehiculosAdentro()
        {
            // Crea un DataTable para guardar los registros
            DataTable tabla = new DataTable();

            // Establece la conexión
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                // Consulta SQL para unir las tablas y filtrar los que no tienen hora de salida
                string query = @"SELECT r.IdRegistro, r.Placa, t.Nombre AS TipoVehiculo, r.HoraEntrada 
                                 FROM Registro r 
                                 INNER JOIN TipoVehiculo t ON r.IdTipo = t.IdTipo 
                                 WHERE r.HoraSalida IS NULL";

                // Crea el comando SQL
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    // Abre la conexión
                    conexion.Open();

                    // Carga el resultado en el DataTable
                    tabla.Load(cmd.ExecuteReader());
                }
            }
            // Retorna la tabla con los vehículos adentro
            return tabla;
        }

        // Método para verificar si una placa ya tiene un registro abierto (sin salida)
        public bool ExistePlacaAbierta(string placa)
        {
            // Inicializa la variable de conteo
            int count = 0;

            // Establece la conexión
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                // Consulta para contar registros abiertos con la misma placa
                string query = "SELECT COUNT(*) FROM Registro WHERE Placa = @Placa AND HoraSalida IS NULL";

                // Crea el comando SQL
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    // Agrega el parámetro de la placa
                    cmd.Parameters.AddWithValue("@Placa", placa);

                    // Abre la conexión
                    conexion.Open();

                    // Ejecuta la consulta escalar para obtener el número de filas encontradas
                    count = (int)cmd.ExecuteScalar();
                }
            }
            // Retorna verdadero si el conteo es mayor a 0 (la placa ya está adentro)
            return count > 0;
        }

        // Método para registrar la salida de un vehículo, actualizando la hora de salida y el total a pagar
        public bool RegistrarSalida(int idRegistro, DateTime horaSalida, decimal totalPagar)
        {
            // Establece la conexión
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                // Consulta SQL para actualizar la salida y el total
                string query = "UPDATE Registro SET HoraSalida = @HoraSalida, TotalPagar = @TotalPagar WHERE IdRegistro = @IdRegistro";

                // Crea el comando SQL
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    // Agrega el parámetro de la hora de salida
                    cmd.Parameters.AddWithValue("@HoraSalida", horaSalida);

                    // Agrega el parámetro del total a pagar calculado
                    cmd.Parameters.AddWithValue("@TotalPagar", totalPagar);

                    // Agrega el parámetro del identificador del registro
                    cmd.Parameters.AddWithValue("@IdRegistro", idRegistro);

                    // Abre la conexión
                    conexion.Open();

                    // Ejecuta la actualización
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // Retorna verdadero si se actualizó correctamente
                    return filasAfectadas > 0;
                }
            }
        }

        // Método para obtener la tarifa por hora y la hora de entrada de un registro específico
        public bool ObtenerDatosParaSalida(int idRegistro, out DateTime horaEntrada, out decimal tarifaHora)
        {
            // Inicializa las variables de salida
            horaEntrada = DateTime.MinValue;
            tarifaHora = 0;
            bool encontrado = false;

            // Establece la conexión
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                // Consulta para obtener la entrada del registro y la tarifa del tipo de vehículo asociado
                string query = @"SELECT r.HoraEntrada, t.TarifaHora 
                                 FROM Registro r 
                                 INNER JOIN TipoVehiculo t ON r.IdTipo = t.IdTipo 
                                 WHERE r.IdRegistro = @IdRegistro";

                // Crea el comando SQL
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    // Agrega el parámetro del id de registro
                    cmd.Parameters.AddWithValue("@IdRegistro", idRegistro);

                    // Abre la conexión
                    conexion.Open();

                    // Ejecuta el lector de datos
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Si encuentra el registro, extrae los valores
                        if (reader.Read())
                        {
                            horaEntrada = reader.GetDateTime(0);
                            tarifaHora = reader.GetDecimal(1);
                            encontrado = true;
                        }
                    }
                }
            }
            // Retorna el indicador de éxito
            return encontrado;
        }

        // Método para calcular el total recaudado del día actual
        public decimal ObtenerTotalRecaudadoDia()
        {
            // Inicializa la variable de total
            decimal total = 0;

            // Establece la conexión
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                // Consulta SQL para sumar los pagos cuya fecha de salida sea el día de hoy
                string query = "SELECT ISNULL(SUM(TotalPagar), 0) FROM Registro WHERE CAST(HoraSalida AS DATE) = CAST(GETDATE() AS DATE)";

                // Crea el comando SQL
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    // Abre la conexión
                    conexion.Open();

                    // Ejecuta la consulta escalar y convierte el resultado a decimal
                    total = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            // Retorna el monto total recaudado
            return total;
        }
    }
}