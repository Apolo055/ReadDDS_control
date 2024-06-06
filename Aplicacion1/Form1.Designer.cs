namespace Aplicacion1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_IP = new System.Windows.Forms.Label();
            this.Numero_puerto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton_SSH = new System.Windows.Forms.RadioButton();
            this.textBox_Puerto = new System.Windows.Forms.TextBox();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.groupBox_Configuracion_comunicacion = new System.Windows.Forms.GroupBox();
            this.textBox_ruta_de_carpeta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_velocidad = new System.Windows.Forms.Label();
            this.label_serial = new System.Windows.Forms.Label();
            this.textBox_Comando = new System.Windows.Forms.TextBox();
            this.Servidor = new System.Windows.Forms.PictureBox();
            this.Cliente = new System.Windows.Forms.PictureBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label_conexion = new System.Windows.Forms.Label();
            this.pictureBox_cable = new System.Windows.Forms.PictureBox();
            this.groupBox_Botonesdecontrol = new System.Windows.Forms.GroupBox();
            this.button_leer = new System.Windows.Forms.Button();
            this.button_descarga = new System.Windows.Forms.Button();
            this.button_paro = new System.Windows.Forms.Button();
            this.button_inicio = new System.Windows.Forms.Button();
            this.button_Cierre = new System.Windows.Forms.Button();
            this.button_apertura = new System.Windows.Forms.Button();
            this.button_apagar = new System.Windows.Forms.Button();
            this.button_Encender = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.textBox_Respuesta = new System.Windows.Forms.TextBox();
            this.label_ruta_archivo = new System.Windows.Forms.Label();
            this.textBox_archivotxt = new System.Windows.Forms.TextBox();
            this.groupBox_Configuracion_comunicacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Servidor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cable)).BeginInit();
            this.groupBox_Botonesdecontrol.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_IP.Location = new System.Drawing.Point(7, 111);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(145, 26);
            this.label_IP.TabIndex = 0;
            this.label_IP.Text = "Anfitrión (IP) :";
            // 
            // Numero_puerto
            // 
            this.Numero_puerto.AutoSize = true;
            this.Numero_puerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Numero_puerto.Location = new System.Drawing.Point(6, 157);
            this.Numero_puerto.Name = "Numero_puerto";
            this.Numero_puerto.Size = new System.Drawing.Size(199, 26);
            this.Numero_puerto.TabIndex = 1;
            this.Numero_puerto.Text = " Número de puerto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de conexión:";
            // 
            // radioButton_SSH
            // 
            this.radioButton_SSH.AutoSize = true;
            this.radioButton_SSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_SSH.Location = new System.Drawing.Point(238, 50);
            this.radioButton_SSH.Name = "radioButton_SSH";
            this.radioButton_SSH.Size = new System.Drawing.Size(222, 30);
            this.radioButton_SSH.TabIndex = 3;
            this.radioButton_SSH.TabStop = true;
            this.radioButton_SSH.Text = "TCP/IP (Winsock)";
            this.radioButton_SSH.UseVisualStyleBackColor = true;
            this.radioButton_SSH.CheckedChanged += new System.EventHandler(this.radioButton_SSH_CheckedChanged);
            // 
            // textBox_Puerto
            // 
            this.textBox_Puerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Puerto.Location = new System.Drawing.Point(238, 158);
            this.textBox_Puerto.Name = "textBox_Puerto";
            this.textBox_Puerto.Size = new System.Drawing.Size(249, 30);
            this.textBox_Puerto.TabIndex = 7;
            // 
            // textBox_IP
            // 
            this.textBox_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_IP.Location = new System.Drawing.Point(238, 107);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(249, 30);
            this.textBox_IP.TabIndex = 8;
            // 
            // groupBox_Configuracion_comunicacion
            // 
            this.groupBox_Configuracion_comunicacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.textBox_archivotxt);
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.label_ruta_archivo);
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.textBox_ruta_de_carpeta);
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.label1);
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.label_velocidad);
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.label_serial);
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.label_IP);
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.Numero_puerto);
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.textBox_IP);
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.label3);
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.textBox_Puerto);
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.radioButton_SSH);
            this.groupBox_Configuracion_comunicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Configuracion_comunicacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox_Configuracion_comunicacion.Location = new System.Drawing.Point(33, 21);
            this.groupBox_Configuracion_comunicacion.Name = "groupBox_Configuracion_comunicacion";
            this.groupBox_Configuracion_comunicacion.Size = new System.Drawing.Size(512, 328);
            this.groupBox_Configuracion_comunicacion.TabIndex = 10;
            this.groupBox_Configuracion_comunicacion.TabStop = false;
            this.groupBox_Configuracion_comunicacion.Text = "Configuracion de la cominicación";
            // 
            // textBox_ruta_de_carpeta
            // 
            this.textBox_ruta_de_carpeta.Location = new System.Drawing.Point(237, 209);
            this.textBox_ruta_de_carpeta.Name = "textBox_ruta_de_carpeta";
            this.textBox_ruta_de_carpeta.Size = new System.Drawing.Size(250, 32);
            this.textBox_ruta_de_carpeta.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ruta del archivo .dds :";
            // 
            // label_velocidad
            // 
            this.label_velocidad.AutoSize = true;
            this.label_velocidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_velocidad.Location = new System.Drawing.Point(11, 159);
            this.label_velocidad.Name = "label_velocidad";
            this.label_velocidad.Size = new System.Drawing.Size(204, 26);
            this.label_velocidad.TabIndex = 10;
            this.label_velocidad.Text = "Velocidad (baudios)";
            // 
            // label_serial
            // 
            this.label_serial.AutoSize = true;
            this.label_serial.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_serial.Location = new System.Drawing.Point(12, 109);
            this.label_serial.Name = "label_serial";
            this.label_serial.Size = new System.Drawing.Size(129, 26);
            this.label_serial.TabIndex = 9;
            this.label_serial.Text = "Linea serial:";
            // 
            // textBox_Comando
            // 
            this.textBox_Comando.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox_Comando.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Comando.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_Comando.Location = new System.Drawing.Point(19, 46);
            this.textBox_Comando.Multiline = true;
            this.textBox_Comando.Name = "textBox_Comando";
            this.textBox_Comando.Size = new System.Drawing.Size(499, 248);
            this.textBox_Comando.TabIndex = 16;
            this.textBox_Comando.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Comando_KeyDown);
            // 
            // Servidor
            // 
            this.Servidor.Location = new System.Drawing.Point(108, 365);
            this.Servidor.Name = "Servidor";
            this.Servidor.Size = new System.Drawing.Size(49, 27);
            this.Servidor.TabIndex = 11;
            this.Servidor.TabStop = false;
            // 
            // Cliente
            // 
            this.Cliente.Location = new System.Drawing.Point(373, 365);
            this.Cliente.Name = "Cliente";
            this.Cliente.Size = new System.Drawing.Size(82, 23);
            this.Cliente.TabIndex = 12;
            this.Cliente.TabStop = false;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label_conexion
            // 
            this.label_conexion.AutoSize = true;
            this.label_conexion.Font = new System.Drawing.Font("Nirmala UI", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_conexion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_conexion.Location = new System.Drawing.Point(434, 375);
            this.label_conexion.Name = "label_conexion";
            this.label_conexion.Size = new System.Drawing.Size(291, 17);
            this.label_conexion.TabIndex = 14;
            this.label_conexion.Text = "Verifica la conexion fisica y presiona Conectar";
            // 
            // pictureBox_cable
            // 
            this.pictureBox_cable.Location = new System.Drawing.Point(218, 375);
            this.pictureBox_cable.Name = "pictureBox_cable";
            this.pictureBox_cable.Size = new System.Drawing.Size(149, 23);
            this.pictureBox_cable.TabIndex = 15;
            this.pictureBox_cable.TabStop = false;
            // 
            // groupBox_Botonesdecontrol
            // 
            this.groupBox_Botonesdecontrol.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_leer);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_descarga);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_paro);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_inicio);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_Cierre);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_apertura);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_apagar);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_Encender);
            this.groupBox_Botonesdecontrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Botonesdecontrol.Location = new System.Drawing.Point(574, 19);
            this.groupBox_Botonesdecontrol.Name = "groupBox_Botonesdecontrol";
            this.groupBox_Botonesdecontrol.Size = new System.Drawing.Size(358, 330);
            this.groupBox_Botonesdecontrol.TabIndex = 20;
            this.groupBox_Botonesdecontrol.TabStop = false;
            this.groupBox_Botonesdecontrol.Text = "Control ";
            // 
            // button_leer
            // 
            this.button_leer.Location = new System.Drawing.Point(202, 260);
            this.button_leer.Name = "button_leer";
            this.button_leer.Size = new System.Drawing.Size(133, 39);
            this.button_leer.TabIndex = 7;
            this.button_leer.Text = "Leer";
            this.button_leer.UseVisualStyleBackColor = true;
            this.button_leer.Click += new System.EventHandler(this.button_leer_Click);
            // 
            // button_descarga
            // 
            this.button_descarga.Location = new System.Drawing.Point(35, 260);
            this.button_descarga.Name = "button_descarga";
            this.button_descarga.Size = new System.Drawing.Size(140, 39);
            this.button_descarga.TabIndex = 6;
            this.button_descarga.Text = "Descarga";
            this.button_descarga.UseVisualStyleBackColor = true;
            this.button_descarga.Click += new System.EventHandler(this.button_descarga_Click);
            // 
            // button_paro
            // 
            this.button_paro.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_paro.Location = new System.Drawing.Point(203, 185);
            this.button_paro.Name = "button_paro";
            this.button_paro.Size = new System.Drawing.Size(133, 40);
            this.button_paro.TabIndex = 5;
            this.button_paro.Text = "Paro";
            this.button_paro.UseVisualStyleBackColor = true;
            this.button_paro.Click += new System.EventHandler(this.button_paro_Click);
            // 
            // button_inicio
            // 
            this.button_inicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_inicio.Location = new System.Drawing.Point(203, 107);
            this.button_inicio.Name = "button_inicio";
            this.button_inicio.Size = new System.Drawing.Size(132, 39);
            this.button_inicio.TabIndex = 4;
            this.button_inicio.Text = "Inicio";
            this.button_inicio.UseVisualStyleBackColor = true;
            this.button_inicio.Click += new System.EventHandler(this.button_inicio_Click);
            // 
            // button_Cierre
            // 
            this.button_Cierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cierre.Location = new System.Drawing.Point(203, 31);
            this.button_Cierre.Name = "button_Cierre";
            this.button_Cierre.Size = new System.Drawing.Size(132, 41);
            this.button_Cierre.TabIndex = 3;
            this.button_Cierre.Text = "Cierre";
            this.button_Cierre.UseVisualStyleBackColor = true;
            this.button_Cierre.Click += new System.EventHandler(this.button_Cierre_Click);
            // 
            // button_apertura
            // 
            this.button_apertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_apertura.Location = new System.Drawing.Point(35, 186);
            this.button_apertura.Name = "button_apertura";
            this.button_apertura.Size = new System.Drawing.Size(140, 40);
            this.button_apertura.TabIndex = 2;
            this.button_apertura.Text = "Apertura";
            this.button_apertura.UseVisualStyleBackColor = true;
            this.button_apertura.Click += new System.EventHandler(this.button_apertura_Click);
            // 
            // button_apagar
            // 
            this.button_apagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_apagar.Location = new System.Drawing.Point(35, 106);
            this.button_apagar.Name = "button_apagar";
            this.button_apagar.Size = new System.Drawing.Size(140, 39);
            this.button_apagar.TabIndex = 1;
            this.button_apagar.Text = "Apagar";
            this.button_apagar.UseVisualStyleBackColor = true;
            this.button_apagar.Click += new System.EventHandler(this.button_apagar_Click);
            // 
            // button_Encender
            // 
            this.button_Encender.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Encender.Location = new System.Drawing.Point(34, 33);
            this.button_Encender.Name = "button_Encender";
            this.button_Encender.Size = new System.Drawing.Size(141, 41);
            this.button_Encender.TabIndex = 0;
            this.button_Encender.Text = "Encender";
            this.button_Encender.UseVisualStyleBackColor = true;
            this.button_Encender.Click += new System.EventHandler(this.button_Encender_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.textBox_Comando);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(963, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 328);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consola de comandos";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.button_Limpiar);
            this.groupBox2.Controls.Add(this.textBox_Respuesta);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(33, 375);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1468, 381);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consola de Respuesta";
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Location = new System.Drawing.Point(716, 13);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(125, 39);
            this.button_Limpiar.TabIndex = 7;
            this.button_Limpiar.Text = "Limpiar";
            this.button_Limpiar.UseVisualStyleBackColor = true;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click);
            // 
            // textBox_Respuesta
            // 
            this.textBox_Respuesta.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox_Respuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Respuesta.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_Respuesta.Location = new System.Drawing.Point(12, 56);
            this.textBox_Respuesta.Multiline = true;
            this.textBox_Respuesta.Name = "textBox_Respuesta";
            this.textBox_Respuesta.Size = new System.Drawing.Size(1432, 309);
            this.textBox_Respuesta.TabIndex = 0;
            // 
            // label_ruta_archivo
            // 
            this.label_ruta_archivo.AutoSize = true;
            this.label_ruta_archivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ruta_archivo.Location = new System.Drawing.Point(16, 263);
            this.label_ruta_archivo.Name = "label_ruta_archivo";
            this.label_ruta_archivo.Size = new System.Drawing.Size(186, 29);
            this.label_ruta_archivo.TabIndex = 13;
            this.label_ruta_archivo.Text = "Ruta archivo.txt :";
            // 
            // textBox_archivotxt
            // 
            this.textBox_archivotxt.Location = new System.Drawing.Point(237, 265);
            this.textBox_archivotxt.Name = "textBox_archivotxt";
            this.textBox_archivotxt.Size = new System.Drawing.Size(250, 32);
            this.textBox_archivotxt.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1532, 781);
            this.Controls.Add(this.Servidor);
            this.Controls.Add(this.label_conexion);
            this.Controls.Add(this.pictureBox_cable);
            this.Controls.Add(this.Cliente);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_Botonesdecontrol);
            this.Controls.Add(this.groupBox_Configuracion_comunicacion);
            this.Name = "Form1";
            this.Text = "Aplicacion de conexion ADP";
            this.groupBox_Configuracion_comunicacion.ResumeLayout(false);
            this.groupBox_Configuracion_comunicacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Servidor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cable)).EndInit();
            this.groupBox_Botonesdecontrol.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Label Numero_puerto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton_SSH;
        private System.Windows.Forms.TextBox textBox_Puerto;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.GroupBox groupBox_Configuracion_comunicacion;
        private System.Windows.Forms.PictureBox Servidor;
        private System.Windows.Forms.PictureBox Cliente;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label_serial;
        private System.Windows.Forms.Label label_velocidad;
        private System.Windows.Forms.Label label_conexion;
        private System.Windows.Forms.PictureBox pictureBox_cable;
        private System.Windows.Forms.TextBox textBox_Comando;
        private System.Windows.Forms.GroupBox groupBox_Botonesdecontrol;
        private System.Windows.Forms.Button button_Encender;
        private System.Windows.Forms.Button button_apagar;
        private System.Windows.Forms.Button button_apertura;
        private System.Windows.Forms.Button button_paro;
        private System.Windows.Forms.Button button_inicio;
        private System.Windows.Forms.Button button_Cierre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_descarga;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.TextBox textBox_Respuesta;
        private System.Windows.Forms.Button button_leer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ruta_de_carpeta;
        private System.Windows.Forms.TextBox textBox_archivotxt;
        private System.Windows.Forms.Label label_ruta_archivo;
    }
}

