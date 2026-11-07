namespace CapaNegocio
{
    public class Registro
    {
        // Propiedad que almacena el identificador del registro
        public int IdRegistro { get; set; } 

        // Propiedad que almacena la placa del vehículo
        public string Placa { get; set; }

        // Propiedad que almacena el identificador del tipo de vehículo
        public int IdTipo { get; set; }

        // Propiedad que almacena la fecha y hora de entrada
        public DateTime HoraEntrada { get; set; }

        // Propiedad que almacena la fecha y hora de salida (puede ser nula)
        public DateTime? HoraSalida { get; set; }

        // Propiedad que almacena el total a pagar (puede ser nulo)
        public decimal? TotalPagar { get; set; }
    }
}