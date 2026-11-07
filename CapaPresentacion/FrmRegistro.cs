using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmRegistro : Form
    {
        // Instancia de las clases de negocio necesarias
        private RegistroNegocio negocioRegistro = new RegistroNegocio();
        private TipoVehiculoNegocio negocioTipo = new TipoVehiculoNegocio();

        // Constructor del formulario
        public FrmRegistro()
        {
            // Inicializa los componentes visuales del formulario diseñados en Visual Studio
            InitializeComponent();
        }

        // Evento que se ejecuta al cargar el formulario
        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            // Carga inicial de datos al abrir la ventana utilizando un bloque try/catch obligatorio
            try
            {
                // Carga los tipos de vehículos en el ComboBox
                CargarTiposVehiculo();

                // Actualiza el listado de vehículos que se encuentran dentro del parqueo en el DataGridView
                ListarVehiculos();
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error claro mediante MessageBox si ocurre una excepción
                MessageBox.Show("Error al cargar la aplicación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método auxiliar para cargar el ComboBox de tipos de vehículos
        private void CargarTiposVehiculo()
        {
            // Asigna los datos obtenidos de la capa de negocio al origen de datos del ComboBox
            cboTipoVehiculo.DataSource = negocioTipo.Listar();

            // Define el campo que se mostrará al usuario
            cboTipoVehiculo.DisplayMember = "Nombre";

            // Define el valor interno que se seleccionará (el ID)
            cboTipoVehiculo.ValueMember = "IdTipo";
        }

        // Método auxiliar para listar los vehículos activos en el DataGridView
        private void ListarVehiculos()
        {
            // Asigna el DataTable con los vehículos adentro como origen de datos del DataGridView
            dgvRegistros.DataSource = negocioRegistro.ListarVehiculosAdentro();
        }

        // Evento del botón para registrar la entrada de un vehículo
        private void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            // Estructura try / catch obligatoria para controlar cualquier error en operaciones del formulario
            try
            {
                // Captura el valor de la placa desde el TextBox
                string placa = txtPlaca.Text;

                // Obtiene el ID del tipo de vehículo seleccionado en el ComboBox
                int idTipo = Convert.ToInt32(cboTipoVehiculo.SelectedValue);

                // Llama al método de la capa de negocio para procesar la entrada
                bool resultado = negocioRegistro.RegistrarEntrada(placa, idTipo);

                // Verifica si el registro fue exitoso
                if (resultado)
                {
                    // Muestra un mensaje de éxito al usuario
                    MessageBox.Show("Entrada registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpia la caja de texto de la placa después de guardar
                    txtPlaca.Clear();

                    // Actualiza la lista en el DataGridView
                    ListarVehiculos();
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje claro con el error de negocio o de base de datos
                MessageBox.Show(ex.Message, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento del botón para registrar la salida del vehículo seleccionado en la tabla
        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            // Estructura try / catch para control de excepciones
            try
            {
                // Valida que el usuario haya seleccionado una fila en el DataGridView
                if (dgvRegistros.SelectedRows.Count > 0)
                {
                    // Obtiene el IdRegistro de la fila seleccionada
                    int idRegistro = Convert.ToInt32(dgvRegistros.SelectedRows[0].Cells["IdRegistro"].Value);

                    // Llama a la capa de negocio para registrar la salida y calcular el total
                    bool resultado = negocioRegistro.RegistrarSalida(idRegistro);

                    // Si el proceso es exitoso
                    if (resultado)
                    {
                        // Muestra un mensaje informativo al usuario
                        MessageBox.Show("Salida registrada y total calculado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresca el listado del DataGridView
                        ListarVehiculos();
                    }
                }
                else
                {
                    // Advierte al usuario que debe seleccionar un elemento de la lista
                    MessageBox.Show("Por favor, seleccione un vehículo de la lista para registrar su salida.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Muestra el mensaje de error controlado
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón para consultar el total recaudado en el día
        private void btnTotalDia_Click(object sender, EventArgs e)
        {
            // Estructura try / catch para la consulta
            try
            {
                // Obtiene el monto total recaudado del día desde la capa de negocio
                decimal totalDia = negocioRegistro.ObtenerTotalRecaudadoDia();

                // Muestra el resultado en un cuadro de diálogo
                MessageBox.Show("Total recaudado el día de hoy: RD$ " + totalDia.ToString("N2"), "Reporte Diario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Maneja cualquier error inesperado
                MessageBox.Show("Error al calcular el total: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}