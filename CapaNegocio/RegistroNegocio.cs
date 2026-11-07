using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class RegistroNegocio
    {
        // Instancia de la capa de datos de registros
        private RegistroDatos datos = new RegistroDatos();

        // Método de negocio para registrar la entrada de un vehículo
        public bool RegistrarEntrada(string placa, int idTipo)
        {
            // Regla de negocio 3: La placa es obligatoria
            if (string.IsNullOrWhiteSpace(placa))
            {
                // Lanza una excepción si la placa está vacía
                throw new Exception("La placa del vehículo es obligatoria.");
            }

            // Regla de negocio 2: No se puede registrar la entrada de una placa que ya tiene un registro abierto
            if (datos.ExistePlacaAbierta(placa.Trim()))
            {
                // Lanza una excepción si el vehículo ya se encuentra dentro del parqueo
                throw new Exception("El vehículo con esta placa ya se encuentra dentro del parqueo.");
            }

            // Define la hora de entrada como el momento actual
            DateTime horaEntrada = DateTime.Now;

            // Llama a la capa de datos para insertar el registro y retorna el resultado
            return datos.RegistrarEntrada(placa.Trim().ToUpper(), idTipo, horaEntrada);
        }

        // Método para listar los vehículos que están dentro del parqueo
        public DataTable ListarVehiculosAdentro()
        {
            // Retorna los datos obtenidos desde la capa de datos
            return datos.ListarVehiculosAdentro();
        }

        // Método de negocio para registrar la salida y calcular el pago automáticamente
        public bool RegistrarSalida(int idRegistro)
        {
            // Define la hora de salida actual
            DateTime horaSalida = DateTime.Now;
            DateTime horaEntrada;
            decimal tarifaHora;

            // Obtiene los datos necesarios para el cálculo desde la capa de datos
            bool obtenido = datos.ObtenerDatosParaSalida(idRegistro, out horaEntrada, out tarifaHora);

            // Valida si el registro existe
            if (!obtenido)
            {
                // Lanza una excepción si no se encuentra el registro
                throw new Exception("No se encontró el registro especificado.");
            }

            // Calcula la diferencia de tiempo transcurrida
            TimeSpan tiempoEstadia = horaSalida - horaEntrada;

            // Obtiene el total de horas en formato decimal
            double horasTotales = tiempoEstadia.TotalHours;

            // Regla de negocio 1: Las horas se redondean hacia arriba (mínimo 1)
            int horasRedondeadas = (int)Math.Ceiling(horasTotales);
            if (horasRedondeadas < 1)
            {
                horasRedondeadas = 1;
            }
                        
            // Calcula el total a pagar multiplicando las horas redondeadas por la tarifa por hora
            decimal totalPagar = horasRedondeadas * tarifaHora;

            // Llama a la capa de datos para actualizar la salida y el total calculado
            return datos.RegistrarSalida(idRegistro, horaSalida, totalPagar);
        }

        // Método para consultar el total recaudado del día
        public decimal ObtenerTotalRecaudadoDia()
        {
            // Retorna el monto obtenido de la capa de datos
            return datos.ObtenerTotalRecaudadoDia();
        }
    }
}