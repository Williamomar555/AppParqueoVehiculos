namespace CapaNegocio
{
    public class TipoVehiculo
    {
        // Propiedad que almacena el identificador único del tipo de vehículo
        public int IdTipo { get; set; }

        // Propiedad que almacena el nombre del tipo de vehículo
        public string Nombre { get; set; }

        // Propiedad que almacena la tarifa por hora
        public decimal TarifaHora { get; set; }
    }
}