﻿namespace Trapid
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
            this.label_IP = new System.Windows.Forms.Label();
            this.Numero_puerto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton_SSH = new System.Windows.Forms.RadioButton();
            this.textBox_Puerto = new System.Windows.Forms.TextBox();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.groupBox_Configuracion_comunicacion = new System.Windows.Forms.GroupBox();
            this.button1_txt = new System.Windows.Forms.Button();
            this.button_dds = new System.Windows.Forms.Button();
            this.textBox_archivotxt = new System.Windows.Forms.TextBox();
            this.label_ruta_archivo = new System.Windows.Forms.Label();
            this.textBox_ruta_de_carpeta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_velocidad = new System.Windows.Forms.Label();
            this.label_serial = new System.Windows.Forms.Label();
            this.textBox_Comando = new System.Windows.Forms.TextBox();
            this.groupBox_Botonesdecontrol = new System.Windows.Forms.GroupBox();
            this.button_actualizar = new System.Windows.Forms.Button();
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
            this.button1 = new System.Windows.Forms.Button();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.textBox_Respuesta = new System.Windows.Forms.TextBox();
            this.openFileDialog_dds = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog_txt = new System.Windows.Forms.OpenFileDialog();
            this.label_matriz = new System.Windows.Forms.Label();
            this.label_altura = new System.Windows.Forms.Label();
            this.label_Modoimpresion = new System.Windows.Forms.Label();
            this.label_anchofuente = new System.Windows.Forms.Label();
            this.textBox_matriz = new System.Windows.Forms.TextBox();
            this.textBox_altura = new System.Windows.Forms.TextBox();
            this.textBox_modoPG = new System.Windows.Forms.TextBox();
            this.textBox_ANCHOFUENTE = new System.Windows.Forms.TextBox();
            this.label_espejo = new System.Windows.Forms.Label();
            this.label_orientacion = new System.Windows.Forms.Label();
            this.label_resolucion = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_signal = new System.Windows.Forms.ComboBox();
            this.comboBox_espejo = new System.Windows.Forms.ComboBox();
            this.comboBox_orientacion = new System.Windows.Forms.ComboBox();
            this.textBox_resolucion = new System.Windows.Forms.TextBox();
            this.textBox_orientacion = new System.Windows.Forms.TextBox();
            this.textBox_espejo = new System.Windows.Forms.TextBox();
            this.groupBox_Configuracion_comunicacion.SuspendLayout();
            this.groupBox_Botonesdecontrol.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.radioButton_SSH.Location = new System.Drawing.Point(229, 50);
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
            this.textBox_Puerto.Size = new System.Drawing.Size(222, 30);
            this.textBox_Puerto.TabIndex = 7;
            this.textBox_Puerto.TextChanged += new System.EventHandler(this.textBox_Puerto_TextChanged);
            // 
            // textBox_IP
            // 
            this.textBox_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_IP.Location = new System.Drawing.Point(238, 107);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(222, 30);
            this.textBox_IP.TabIndex = 8;
            this.textBox_IP.TextChanged += new System.EventHandler(this.textBox_IP_TextChanged);
            // 
            // groupBox_Configuracion_comunicacion
            // 
            this.groupBox_Configuracion_comunicacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.button1_txt);
            this.groupBox_Configuracion_comunicacion.Controls.Add(this.button_dds);
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
            this.groupBox_Configuracion_comunicacion.Location = new System.Drawing.Point(30, 37);
            this.groupBox_Configuracion_comunicacion.Name = "groupBox_Configuracion_comunicacion";
            this.groupBox_Configuracion_comunicacion.Size = new System.Drawing.Size(483, 264);
            this.groupBox_Configuracion_comunicacion.TabIndex = 10;
            this.groupBox_Configuracion_comunicacion.TabStop = false;
            this.groupBox_Configuracion_comunicacion.Text = "Configuracion de la cominicación";
            // 
            // button1_txt
            // 
            this.button1_txt.Location = new System.Drawing.Point(429, 265);
            this.button1_txt.Name = "button1_txt";
            this.button1_txt.Size = new System.Drawing.Size(58, 32);
            this.button1_txt.TabIndex = 16;
            this.button1_txt.Text = "...";
            this.button1_txt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1_txt.UseVisualStyleBackColor = true;
            this.button1_txt.Click += new System.EventHandler(this.button1_txt_Click);
            // 
            // button_dds
            // 
            this.button_dds.Location = new System.Drawing.Point(400, 209);
            this.button_dds.Name = "button_dds";
            this.button_dds.Size = new System.Drawing.Size(58, 32);
            this.button_dds.TabIndex = 15;
            this.button_dds.Text = "....";
            this.button_dds.UseVisualStyleBackColor = true;
            this.button_dds.Click += new System.EventHandler(this.button_dds_Click);
            // 
            // textBox_archivotxt
            // 
            this.textBox_archivotxt.Location = new System.Drawing.Point(237, 265);
            this.textBox_archivotxt.Name = "textBox_archivotxt";
            this.textBox_archivotxt.Size = new System.Drawing.Size(185, 32);
            this.textBox_archivotxt.TabIndex = 14;
            // 
            // label_ruta_archivo
            // 
            this.label_ruta_archivo.AutoSize = true;
            this.label_ruta_archivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ruta_archivo.Location = new System.Drawing.Point(16, 263);
            this.label_ruta_archivo.Name = "label_ruta_archivo";
            this.label_ruta_archivo.Size = new System.Drawing.Size(175, 26);
            this.label_ruta_archivo.TabIndex = 13;
            this.label_ruta_archivo.Text = "Ruta archivo.txt :";
            // 
            // textBox_ruta_de_carpeta
            // 
            this.textBox_ruta_de_carpeta.Location = new System.Drawing.Point(237, 209);
            this.textBox_ruta_de_carpeta.Name = "textBox_ruta_de_carpeta";
            this.textBox_ruta_de_carpeta.Size = new System.Drawing.Size(158, 32);
            this.textBox_ruta_de_carpeta.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Archivo dds :";
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
            this.textBox_Comando.Size = new System.Drawing.Size(315, 187);
            this.textBox_Comando.TabIndex = 16;
            this.textBox_Comando.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Comando_KeyDown);
            // 
            // groupBox_Botonesdecontrol
            // 
            this.groupBox_Botonesdecontrol.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_actualizar);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_leer);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_descarga);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_paro);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_inicio);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_Cierre);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_apertura);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_apagar);
            this.groupBox_Botonesdecontrol.Controls.Add(this.button_Encender);
            this.groupBox_Botonesdecontrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Botonesdecontrol.Location = new System.Drawing.Point(530, 37);
            this.groupBox_Botonesdecontrol.Name = "groupBox_Botonesdecontrol";
            this.groupBox_Botonesdecontrol.Size = new System.Drawing.Size(537, 264);
            this.groupBox_Botonesdecontrol.TabIndex = 20;
            this.groupBox_Botonesdecontrol.TabStop = false;
            this.groupBox_Botonesdecontrol.Text = "Control ";
            // 
            // button_actualizar
            // 
            this.button_actualizar.Location = new System.Drawing.Point(362, 195);
            this.button_actualizar.Name = "button_actualizar";
            this.button_actualizar.Size = new System.Drawing.Size(149, 40);
            this.button_actualizar.TabIndex = 8;
            this.button_actualizar.Text = "Actualizar";
            this.button_actualizar.UseVisualStyleBackColor = true;
            this.button_actualizar.Click += new System.EventHandler(this.button_actualizar_Click);
            // 
            // button_leer
            // 
            this.button_leer.Location = new System.Drawing.Point(362, 122);
            this.button_leer.Name = "button_leer";
            this.button_leer.Size = new System.Drawing.Size(149, 41);
            this.button_leer.TabIndex = 7;
            this.button_leer.Text = "Leer";
            this.button_leer.UseVisualStyleBackColor = true;
            this.button_leer.Click += new System.EventHandler(this.button_leer_Click);
            // 
            // button_descarga
            // 
            this.button_descarga.Location = new System.Drawing.Point(362, 55);
            this.button_descarga.Name = "button_descarga";
            this.button_descarga.Size = new System.Drawing.Size(149, 41);
            this.button_descarga.TabIndex = 6;
            this.button_descarga.Text = "Descarga";
            this.button_descarga.UseVisualStyleBackColor = true;
            this.button_descarga.Click += new System.EventHandler(this.button_descarga_Click);
            // 
            // button_paro
            // 
            this.button_paro.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_paro.Location = new System.Drawing.Point(198, 195);
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
            this.button_inicio.Location = new System.Drawing.Point(198, 122);
            this.button_inicio.Name = "button_inicio";
            this.button_inicio.Size = new System.Drawing.Size(132, 41);
            this.button_inicio.TabIndex = 4;
            this.button_inicio.Text = "Inicio";
            this.button_inicio.UseVisualStyleBackColor = true;
            this.button_inicio.Click += new System.EventHandler(this.button_inicio_Click);
            // 
            // button_Cierre
            // 
            this.button_Cierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cierre.Location = new System.Drawing.Point(198, 54);
            this.button_Cierre.Name = "button_Cierre";
            this.button_Cierre.Size = new System.Drawing.Size(132, 42);
            this.button_Cierre.TabIndex = 3;
            this.button_Cierre.Text = "Cierre";
            this.button_Cierre.UseVisualStyleBackColor = true;
            this.button_Cierre.Click += new System.EventHandler(this.button_Cierre_Click);
            // 
            // button_apertura
            // 
            this.button_apertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_apertura.Location = new System.Drawing.Point(19, 195);
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
            this.button_apagar.Location = new System.Drawing.Point(19, 122);
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
            this.button_Encender.Location = new System.Drawing.Point(18, 55);
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
            this.groupBox1.Location = new System.Drawing.Point(1088, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 261);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consola de comandos";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button_Limpiar);
            this.groupBox2.Controls.Add(this.textBox_Respuesta);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(30, 340);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1413, 399);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consola de Respuesta";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1234, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Location = new System.Drawing.Point(671, 15);
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
            this.textBox_Respuesta.Location = new System.Drawing.Point(30, 58);
            this.textBox_Respuesta.Multiline = true;
            this.textBox_Respuesta.Name = "textBox_Respuesta";
            this.textBox_Respuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Respuesta.Size = new System.Drawing.Size(1362, 320);
            this.textBox_Respuesta.TabIndex = 0;
            // 
            // openFileDialog_dds
            // 
            this.openFileDialog_dds.FileName = "openFileDialog1";
            // 
            // openFileDialog_txt
            // 
            this.openFileDialog_txt.FileName = "openFileDialog1";
            // 
            // label_matriz
            // 
            this.label_matriz.AutoSize = true;
            this.label_matriz.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_matriz.Location = new System.Drawing.Point(25, 47);
            this.label_matriz.Name = "label_matriz";
            this.label_matriz.Size = new System.Drawing.Size(83, 26);
            this.label_matriz.TabIndex = 0;
            this.label_matriz.Text = "Matriz :";
            // 
            // label_altura
            // 
            this.label_altura.AutoSize = true;
            this.label_altura.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_altura.Location = new System.Drawing.Point(23, 100);
            this.label_altura.Name = "label_altura";
            this.label_altura.Size = new System.Drawing.Size(206, 26);
            this.label_altura.TabIndex = 1;
            this.label_altura.Text = "Altura de impresión:";
            // 
            // label_Modoimpresion
            // 
            this.label_Modoimpresion.AutoSize = true;
            this.label_Modoimpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Modoimpresion.Location = new System.Drawing.Point(24, 159);
            this.label_Modoimpresion.Name = "label_Modoimpresion";
            this.label_Modoimpresion.Size = new System.Drawing.Size(203, 26);
            this.label_Modoimpresion.TabIndex = 2;
            this.label_Modoimpresion.Text = "Modo de impresión:";
            // 
            // label_anchofuente
            // 
            this.label_anchofuente.AutoSize = true;
            this.label_anchofuente.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_anchofuente.Location = new System.Drawing.Point(28, 211);
            this.label_anchofuente.Name = "label_anchofuente";
            this.label_anchofuente.Size = new System.Drawing.Size(176, 26);
            this.label_anchofuente.TabIndex = 3;
            this.label_anchofuente.Text = "Ancho de fuente:";
            // 
            // textBox_matriz
            // 
            this.textBox_matriz.Location = new System.Drawing.Point(255, 50);
            this.textBox_matriz.Name = "textBox_matriz";
            this.textBox_matriz.Size = new System.Drawing.Size(147, 32);
            this.textBox_matriz.TabIndex = 4;
            this.textBox_matriz.TextChanged += new System.EventHandler(this.textBox_matriz_TextChanged);
            // 
            // textBox_altura
            // 
            this.textBox_altura.Location = new System.Drawing.Point(256, 100);
            this.textBox_altura.Name = "textBox_altura";
            this.textBox_altura.Size = new System.Drawing.Size(146, 32);
            this.textBox_altura.TabIndex = 5;
            this.textBox_altura.TextChanged += new System.EventHandler(this.textBox_altura_TextChanged);
            // 
            // textBox_modoPG
            // 
            this.textBox_modoPG.Location = new System.Drawing.Point(258, 156);
            this.textBox_modoPG.Name = "textBox_modoPG";
            this.textBox_modoPG.Size = new System.Drawing.Size(144, 32);
            this.textBox_modoPG.TabIndex = 6;
            this.textBox_modoPG.TextChanged += new System.EventHandler(this.textBox_modoPG_TextChanged);
            // 
            // textBox_ANCHOFUENTE
            // 
            this.textBox_ANCHOFUENTE.Location = new System.Drawing.Point(258, 208);
            this.textBox_ANCHOFUENTE.Name = "textBox_ANCHOFUENTE";
            this.textBox_ANCHOFUENTE.Size = new System.Drawing.Size(144, 32);
            this.textBox_ANCHOFUENTE.TabIndex = 7;
            this.textBox_ANCHOFUENTE.TextChanged += new System.EventHandler(this.textBox_ANCHOFUENTE_TextChanged);
            // 
            // label_espejo
            // 
            this.label_espejo.AutoSize = true;
            this.label_espejo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_espejo.Location = new System.Drawing.Point(31, 395);
            this.label_espejo.Name = "label_espejo";
            this.label_espejo.Size = new System.Drawing.Size(91, 26);
            this.label_espejo.TabIndex = 8;
            this.label_espejo.Text = "Espejo :";
            // 
            // label_orientacion
            // 
            this.label_orientacion.AutoSize = true;
            this.label_orientacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_orientacion.Location = new System.Drawing.Point(27, 329);
            this.label_orientacion.Name = "label_orientacion";
            this.label_orientacion.Size = new System.Drawing.Size(135, 26);
            this.label_orientacion.TabIndex = 9;
            this.label_orientacion.Text = "Orientación :";
            // 
            // label_resolucion
            // 
            this.label_resolucion.AutoSize = true;
            this.label_resolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_resolucion.Location = new System.Drawing.Point(27, 268);
            this.label_resolucion.Name = "label_resolucion";
            this.label_resolucion.Size = new System.Drawing.Size(132, 26);
            this.label_resolucion.TabIndex = 10;
            this.label_resolucion.Text = "Resolución :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.comboBox_signal);
            this.groupBox3.Controls.Add(this.comboBox_espejo);
            this.groupBox3.Controls.Add(this.comboBox_orientacion);
            this.groupBox3.Controls.Add(this.textBox_resolucion);
            this.groupBox3.Controls.Add(this.textBox_orientacion);
            this.groupBox3.Controls.Add(this.textBox_espejo);
            this.groupBox3.Controls.Add(this.label_resolucion);
            this.groupBox3.Controls.Add(this.label_orientacion);
            this.groupBox3.Controls.Add(this.label_espejo);
            this.groupBox3.Controls.Add(this.textBox_ANCHOFUENTE);
            this.groupBox3.Controls.Add(this.textBox_modoPG);
            this.groupBox3.Controls.Add(this.textBox_altura);
            this.groupBox3.Controls.Add(this.textBox_matriz);
            this.groupBox3.Controls.Add(this.label_anchofuente);
            this.groupBox3.Controls.Add(this.label_Modoimpresion);
            this.groupBox3.Controls.Add(this.label_altura);
            this.groupBox3.Controls.Add(this.label_matriz);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(1467, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(426, 699);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configuración de parametros ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 26);
            this.label2.TabIndex = 30;
            this.label2.Text = "Señal PRINT-GO:";
            // 
            // comboBox_signal
            // 
            this.comboBox_signal.FormattingEnabled = true;
            this.comboBox_signal.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.comboBox_signal.Location = new System.Drawing.Point(258, 471);
            this.comboBox_signal.Name = "comboBox_signal";
            this.comboBox_signal.Size = new System.Drawing.Size(144, 34);
            this.comboBox_signal.TabIndex = 29;
            this.comboBox_signal.SelectedIndexChanged += new System.EventHandler(this.comboBox_signal_SelectedIndexChanged);
            // 
            // comboBox_espejo
            // 
            this.comboBox_espejo.FormattingEnabled = true;
            this.comboBox_espejo.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_espejo.Location = new System.Drawing.Point(258, 396);
            this.comboBox_espejo.Name = "comboBox_espejo";
            this.comboBox_espejo.Size = new System.Drawing.Size(145, 34);
            this.comboBox_espejo.TabIndex = 28;
            this.comboBox_espejo.SelectedIndexChanged += new System.EventHandler(this.comboBox_espejo_SelectedIndexChanged);
            // 
            // comboBox_orientacion
            // 
            this.comboBox_orientacion.FormattingEnabled = true;
            this.comboBox_orientacion.Items.AddRange(new object[] {
            "0",
            "180"});
            this.comboBox_orientacion.Location = new System.Drawing.Point(258, 329);
            this.comboBox_orientacion.Name = "comboBox_orientacion";
            this.comboBox_orientacion.Size = new System.Drawing.Size(139, 34);
            this.comboBox_orientacion.TabIndex = 27;
            this.comboBox_orientacion.SelectedIndexChanged += new System.EventHandler(this.comboBox_orientacion_SelectedIndexChanged);
            // 
            // textBox_resolucion
            // 
            this.textBox_resolucion.Location = new System.Drawing.Point(258, 268);
            this.textBox_resolucion.Name = "textBox_resolucion";
            this.textBox_resolucion.Size = new System.Drawing.Size(139, 32);
            this.textBox_resolucion.TabIndex = 26;
            this.textBox_resolucion.TextChanged += new System.EventHandler(this.textBox_resolucion_TextChanged);
            // 
            // textBox_orientacion
            // 
            this.textBox_orientacion.Location = new System.Drawing.Point(29, 540);
            this.textBox_orientacion.Name = "textBox_orientacion";
            this.textBox_orientacion.Size = new System.Drawing.Size(141, 32);
            this.textBox_orientacion.TabIndex = 25;
            this.textBox_orientacion.TextChanged += new System.EventHandler(this.textBox_orientacion_TextChanged);
            // 
            // textBox_espejo
            // 
            this.textBox_espejo.Location = new System.Drawing.Point(255, 540);
            this.textBox_espejo.Name = "textBox_espejo";
            this.textBox_espejo.Size = new System.Drawing.Size(142, 32);
            this.textBox_espejo.TabIndex = 24;
            this.textBox_espejo.TextChanged += new System.EventHandler(this.textBox_espejo_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 781);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_Botonesdecontrol);
            this.Controls.Add(this.groupBox_Configuracion_comunicacion);
            this.Name = "Form1";
            this.Text = "Trapid";
            this.groupBox_Configuracion_comunicacion.ResumeLayout(false);
            this.groupBox_Configuracion_comunicacion.PerformLayout();
            this.groupBox_Botonesdecontrol.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Label Numero_puerto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton_SSH;
        private System.Windows.Forms.TextBox textBox_Puerto;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.GroupBox groupBox_Configuracion_comunicacion;
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
        private System.Windows.Forms.Button button1_txt;
        private System.Windows.Forms.Button button_dds;
        private System.Windows.Forms.OpenFileDialog openFileDialog_dds;
        private System.Windows.Forms.OpenFileDialog openFileDialog_txt;
        private System.Windows.Forms.Label label_velocidad;
        private System.Windows.Forms.Label label_serial;
        private System.Windows.Forms.Label label_matriz;
        private System.Windows.Forms.Label label_altura;
        private System.Windows.Forms.Label label_Modoimpresion;
        private System.Windows.Forms.Label label_anchofuente;
        private System.Windows.Forms.TextBox textBox_matriz;
        private System.Windows.Forms.TextBox textBox_altura;
        private System.Windows.Forms.TextBox textBox_modoPG;
        private System.Windows.Forms.TextBox textBox_ANCHOFUENTE;
        private System.Windows.Forms.Label label_espejo;
        private System.Windows.Forms.Label label_orientacion;
        private System.Windows.Forms.Label label_resolucion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_espejo;
        private System.Windows.Forms.TextBox textBox_resolucion;
        private System.Windows.Forms.TextBox textBox_orientacion;
        private System.Windows.Forms.Button button_actualizar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_espejo;
        private System.Windows.Forms.ComboBox comboBox_orientacion;
        private System.Windows.Forms.ComboBox comboBox_signal;
        private System.Windows.Forms.Label label2;
    }
}

