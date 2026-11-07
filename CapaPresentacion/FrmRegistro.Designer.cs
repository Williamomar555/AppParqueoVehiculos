namespace CapaPresentacion
{
    partial class FrmRegistro
    {
        // Variable requerida para el diseñador de Windows Forms
        private System.ComponentModel.IContainer components = null;

        // Limpia los recursos que se estén utilizando
        protected override void Dispose(bool disposing)
        {
            // Verifica si se deben eliminar los componentes y si el contenedor no es nulo
            if (disposing && (components != null))
            {
                // Libera los recursos del contenedor de componentes
                components.Dispose();
            }
            // Llama al método Dispose de la clase base Form
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        // Método privado que inicializa y posiciona todos los controles visuales del formulario
        private void InitializeComponent()
        {
            // Instancia el componente DataGridView para mostrar el listado de vehículos
            this.dgvRegistros = new System.Windows.Forms.DataGridView();

            // Instancia la etiqueta descriptiva para el campo de placa
            this.lblPlaca = new System.Windows.Forms.Label();

            // Instancia la caja de texto para capturar la placa del vehículo
            this.txtPlaca = new System.Windows.Forms.TextBox();

            // Instancia la etiqueta descriptiva para el tipo de vehículo
            this.lblTipo = new System.Windows.Forms.Label();

            // Instancia el ComboBox para seleccionar el tipo de vehículo
            this.cboTipoVehiculo = new System.Windows.Forms.ComboBox();

            // Instancia el botón para registrar la entrada
            this.btnRegistrarEntrada = new System.Windows.Forms.Button();

            // Instancia el botón para registrar la salida
            this.btnRegistrarSalida = new System.Windows.Forms.Button();

            // Instancia el botón para consultar el total recaudado del día
            this.btnTotalDia = new System.Windows.Forms.Button();

            // Suspende temporalmente el diseño del DataGridView mientras se configuran sus propiedades
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();

            // Suspende temporalmente el diseño del formulario principal
            this.SuspendLayout();

            // Configura el comportamiento de redimensionamiento de las columnas del DataGridView
            this.dgvRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Establece las coordenadas X e Y donde se ubicará el DataGridView en el formulario
            this.dgvRegistros.Location = new System.Drawing.Point(12, 130);

            // Asigna el nombre identificador del control
            this.dgvRegistros.Name = "dgvRegistros";

            // Configura la selección para que se seleccione la fila completa
            this.dgvRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // Define el tamaño (ancho y alto) del DataGridView en píxeles
            this.dgvRegistros.Size = new System.Drawing.Size(600, 300);

            // Asigna el índice de tabulación del control
            this.dgvRegistros.TabIndex = 0;

            // Configura la etiqueta de la placa para que ajuste su tamaño automáticamente al texto
            this.lblPlaca.AutoSize = true;

            // Define la posición en el formulario de la etiqueta Placa
            this.lblPlaca.Location = new System.Drawing.Point(12, 25);

            // Asigna el nombre del control etiqueta
            this.lblPlaca.Name = "lblPlaca";

            // Define el tamaño de la etiqueta
            this.lblPlaca.Size = new System.Drawing.Size(37, 13);

            // Define el texto visible que mostrará la etiqueta
            this.lblPlaca.Text = "Placa:";

            // Define la ubicación del TextBox para la placa
            this.txtPlaca.Location = new System.Drawing.Point(120, 22);

            // Asigna el nombre del TextBox
            this.txtPlaca.Name = "txtPlaca";

            // Define el ancho y alto de la caja de texto
            this.txtPlaca.Size = new System.Drawing.Size(150, 20);

            // Asigna el orden de tabulación
            this.txtPlaca.TabIndex = 1;

            // Configura la etiqueta del tipo de vehículo para ajustar su tamaño automáticamente
            this.lblTipo.AutoSize = true;

            // Define la posición en el formulario de la etiqueta del tipo
            this.lblTipo.Location = new System.Drawing.Point(12, 65);

            // Asigna el nombre de la etiqueta
            this.lblTipo.Name = "lblTipo";

            // Define el tamaño de la etiqueta
            this.lblTipo.Size = new System.Drawing.Size(88, 13);

            // Define el texto visible de la etiqueta
            this.lblTipo.Text = "Tipo de Vehículo:";

            // Configura el estilo del ComboBox para que sea una lista desplegable fija (sin opción de escritura libre)
            this.cboTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Define la posición del ComboBox en el formulario
            this.cboTipoVehiculo.Location = new System.Drawing.Point(120, 62);

            // Asigna el nombre del ComboBox
            this.cboTipoVehiculo.Name = "cboTipoVehiculo";

            // Define el tamaño del ComboBox
            this.cboTipoVehiculo.Size = new System.Drawing.Size(150, 21);

            // Asigna el orden de tabulación
            this.cboTipoVehiculo.TabIndex = 2;

            // Define la posición del botón Registrar Entrada
            this.btnRegistrarEntrada.Location = new System.Drawing.Point(300, 20);

            // Asigna el nombre del botón
            this.btnRegistrarEntrada.Name = "btnRegistrarEntrada";

            // Define las dimensiones del botón
            this.btnRegistrarEntrada.Size = new System.Drawing.Size(130, 30);

            // Asigna el orden de tabulación
            this.btnRegistrarEntrada.TabIndex = 3;

            // Define el texto que se muestra en el botón
            this.btnRegistrarEntrada.Text = "Registrar Entrada";

            // Habilita el color visual estándar del botón
            this.btnRegistrarEntrada.UseVisualStyleBackColor = true;

            // Conecta el evento Click del botón con el método manejador correspondiente en el código
            this.btnRegistrarEntrada.Click += new System.EventHandler(this.btnRegistrarEntrada_Click);

            // Define la posición del botón Registrar Salida
            this.btnRegistrarSalida.Location = new System.Drawing.Point(300, 60);

            // Asigna el nombre del botón de salida
            this.btnRegistrarSalida.Name = "btnRegistrarSalida";

            // Define las dimensiones del botón de salida
            this.btnRegistrarSalida.Size = new System.Drawing.Size(130, 30);

            // Asigna el orden de tabulación
            this.btnRegistrarSalida.TabIndex = 4;

            // Define el texto visible del botón de salida
            this.btnRegistrarSalida.Text = "Registrar Salida";

            // Habilita el color visual estándar
            this.btnRegistrarSalida.UseVisualStyleBackColor = true;

            // Conecta el evento Click del botón con su respectivo método
            this.btnRegistrarSalida.Click += new System.EventHandler(this.btnRegistrarSalida_Click);

            // Define la posición del botón para consultar el total del día
            this.btnTotalDia.Location = new System.Drawing.Point(450, 20);

            // Asigna el nombre del botón
            this.btnTotalDia.Name = "btnTotalDia";

            // Define el tamaño del botón
            this.btnTotalDia.Size = new System.Drawing.Size(130, 30);

            // Asigna el orden de tabulación
            this.btnTotalDia.TabIndex = 5;

            // Define el texto del botón
            this.btnTotalDia.Text = "Total Recaudado Día";

            // Habilita el color visual estándar
            this.btnTotalDia.UseVisualStyleBackColor = true;

            // Conecta el evento Click del botón con su método correspondiente
            this.btnTotalDia.Click += new System.EventHandler(this.btnTotalDia_Click);

            // Define las dimensiones de escala automática de fuentes
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);

            // Define el modo de escala automática
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            // Establece el tamaño total de la ventana del formulario
            this.ClientSize = new System.Drawing.Size(630, 450);

            // Agrega los controles creados a la colección de controles visuales del formulario
            this.Controls.Add(this.btnTotalDia);
            this.Controls.Add(this.btnRegistrarSalida);
            this.Controls.Add(this.btnRegistrarEntrada);
            this.Controls.Add(this.cboTipoVehiculo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.lblPlaca);
            this.Controls.Add(this.dgvRegistros);

            // Asigna el nombre interno del formulario
            this.Name = "FrmRegistro";

            // Define el título que aparecerá en la barra superior de la ventana
            this.Text = "Control de Parqueo de Vehículos";

            // Conecta el evento Load del formulario con su método inicializador
            this.Load += new System.EventHandler(this.FrmRegistro_Load);

            // Reanuda el diseño del DataGridView finalizando su inicialización
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();

            // Reanuda el diseño del formulario principal
            this.ResumeLayout(false);
            this.PerformLayout();
        }

#endregion

        // Declaración de los controles a nivel de clase para que estén accesibles en todo el formulario
        private System.Windows.Forms.DataGridView dgvRegistros;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipoVehiculo;
        private System.Windows.Forms.Button btnRegistrarEntrada;
        private System.Windows.Forms.Button btnRegistrarSalida;
        private System.Windows.Forms.Button btnTotalDia;
    }
}