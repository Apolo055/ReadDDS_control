//librerias utilizadas para el proyecto

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


// El namespace se utiliza para declarar un ámbito que contiene un conjunto de objetos relacionados. Puedes usar un espacio de nombres para organizar los elementos de código y crear tipos únicos globales
namespace Aplicacion1
{
    public partial class Form1 : Form // clase que contiene los metodos variables y eventos necesarios para el funcionamiento de la interfaz grafica de usuario
    {
        private SimpleTcpClient client; // palabra clave de la instancia
        bool serial = false, SSH = false; // variables utilizadas para funcionamiento de la aplicacion
        string command = "", response = ""; // variable para almacenar la respuesta y mensaje que se envia entre el usuario y la maquina

        string Encender = "^0!PO", Apagar = "^0!PF", Apertura = "^0!NO", Cierre = "^0!NC", Inicio = "^0!GO", Paro = "^0!ST", Descarga = "^0?JB";
        // valiables que almacenan comando especificos para mandar a la maquina atraves de botones de control
        string ruta =" ";
        public Form1() // metodo utilizado para inicalizar componentes y estados de los elementos que se utilizan
        {
            InitializeComponent();// inicializacion de la aplicacion

            // habilitar o desabilitar elementos de la aplicacion
            textBox_IP.Enabled = false;
            textBox_Puerto.Enabled = false;
            label_serial.Visible = false;
            label_velocidad.Visible = false;
            label_conexion.Visible = false;
            serialPort1.PortName = "COM4"; // Aquí puedes poner el número de puerto que desees
            serialPort1.BaudRate = 9600; // Aquí puedes poner la velocidad de transmisión que desees
            textBox_ruta_de_carpeta.Text = @"C:\Users\manue\OneDrive\Escritorio\programas_impresora\article.dds";
            textBox_archivotxt.Text = @"C:\Users\manue\OneDrive\Escritorio\Archivo\Archivo.txt";
            button_leer.Visible = true;
            


            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Path.GetDirectoryName(textBox_ruta_de_carpeta.Text.Trim()); // Observa el directorio del archivo
            watcher.Filter = Path.GetFileName(textBox_ruta_de_carpeta.Text.Trim()); // Observa específicamente este archivo
            watcher.Deleted += OnDeleted;
            watcher.Created += OnCreated;

            // Iniciar la observación
            watcher.EnableRaisingEvents = true;



        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
          /////  MessageBox.Show($"Archivo agregado: {e.FullPath}");
             // invocamos el evento click desde el hilo de la UI O hilo principal
            this.Invoke((MethodInvoker)delegate {
                button_leer_Click(this, EventArgs.Empty);
            });

        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            //mandamos mensaje de adevertencia utilizando otro hilo para advertir que se ha borrado el documento
            MessageBox.Show($"El archivo {e.Name} ha sido {e.ChangeType}");
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) //metodo para abrir el puerto serial
        {
            while (serialPort1.IsOpen && serialPort1.BytesToRead > 0)//verificamos si hay datos en el puerto serial
            {
                String linea1 = serialPort1.ReadLine();//leemos y guardamos los datos
            }

        }

        private void radioButton_SSH_CheckedChanged(object sender, EventArgs e) //evento para seleccionar el tipo de comunicacion
        {

            //inicializacion de las etiquetas y cuadro de texto visibilidad y habilitacion
            label_serial.Visible = false;
            label_velocidad.Visible = false;
            Numero_puerto.Visible = true;
            label_IP.Visible = true;
            textBox_IP.Enabled = true;
            textBox_Comando.Visible = true;
            textBox_Respuesta.Visible = true;
            textBox_Puerto.Enabled = true;
            textBox_Comando.Enabled = true;
            textBox_Respuesta.Enabled = true;
            label_conexion.Visible = false;
            pictureBox_cable.Visible = false;
            Servidor.Visible = false;
            Cliente.Visible = false;
            textBox_IP.Text = "172.16.23.97";
            textBox_Puerto.Text = "3000";
            textBox_ruta_de_carpeta.Text = @"C:\Users\manue\OneDrive\Escritorio\programas_impresora\article.dds";


            serial = false;
            SSH = true;
        }

        private async void button_leer_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(textBox_ruta_de_carpeta.Text.Trim()))
                {
                    string contenidoArchivo1 = File.ReadAllText(textBox_ruta_de_carpeta.Text.Trim());

                    Dictionary<string, string[]> valoresEncontrados1 = new Dictionary<string, string[]>();
                    foreach (string linea in contenidoArchivo1.Split('\n'))
                    {
                        string[] partes = linea.Split('=');
                        if (partes.Length > 1)
                        {
                            string clave = partes[0].Trim();
                            string valor = partes[1].Trim();
                            if (clave == "MarkingTextBegin" || clave == "MarkingTextEndless" || clave == "MarkingTextEnd")
                            {
                                if (valor.Contains(","))
                                {
                                    string[] valores = valor.Split(',');
                                    valores[0] = valores[0].Trim('"');
                                    valores[1] = valores[1].Trim('"');
                                    valoresEncontrados1[clave] = valores;
                                }
                            }
                            else if (clave == "Name")
                            {
                                valor = valor.Trim('"');
                                valoresEncontrados1[clave] = new string[] { valor };
                            }
                        }
                    }

                    string plantilla = @"
                    BEGINLJSCRIPT [(V01.06.00.31)]
                    JLPAR [70 1 0 3 10 180 0 12500 00:00 1 7000 0 0 1000 0 0]
                    VISION [ 0 1 0 55000 3 5 3 5 0 ]
                    BEGINJOB [ 0 (|_BEGINJOB_|) ]
                    JOBPAR [ |_JOBPAR1_| 2 40000 320 0 0 0 1 1 0 -1 ({09E0BA11-8ADB-1E0E-B02B-55C7F102F9EC}) 1 1 55000 1 2 0 1 0 0 0 1 0 0 ]
                    OBJ [1 0 0 0 (ISO1_7x5)  (|_OBJ1_|) 2 0 0 0 0 1 0 0 0 0 0 0 ()  () 0 0 () ]
                    JOBPAR [ |_JOBPAR2_| 2 40000 320 0 0 0 1 1 0 -1 ({09E0BA11-8ADB-1E0E-B02B-55C7F102F9EC}) 1 1 55000 1 2 0 1 0 0 0 1 0 0 ]
                    OBJ [1 0 0 0 (ISO1_7x5)  (|_OBJ2_|) 2 0 0 0 0 1 0 0 0 0 0 0 ()  () 0 0 () ]
                    JOBPAR [ |_JOBPAR3_| 2 40000 320 0 0 0 1 1 0 -1 ({09E0BA11-8ADB-1E0E-B02B-55C7F102F9EC}) 1 1 55000 1 2 0 1 0 0 0 1 0 0 ]
                    OBJ [1 0 0 0 (ISO1_7x5)  (|_OBJ3_|) 2 0 0 0 0 1 0 0 0 0 0 0 ()  () 0 0 () ]
                    ENDJOB []
                    ENDLJSCRIPT []     
                    ";

                    Dictionary<string, string> parametros = new Dictionary<string, string>();
                    parametros.Add("|_BEGINJOB_|", valoresEncontrados1["Name"][0]);
                    parametros.Add("|_JOBPAR1_|", valoresEncontrados1["MarkingTextBegin"][0]);
                    parametros.Add("|_OBJ1_|", valoresEncontrados1["MarkingTextBegin"][1]);
                    parametros.Add("|_JOBPAR2_|", valoresEncontrados1["MarkingTextEndless"][0]);
                    parametros.Add("|_OBJ2_|", valoresEncontrados1["MarkingTextEndless"][1]);
                    parametros.Add("|_JOBPAR3_|", valoresEncontrados1["MarkingTextEnd"][0]);
                    parametros.Add("|_OBJ3_|", valoresEncontrados1["MarkingTextEnd"][1]);

                    foreach (KeyValuePair<string, string> item in parametros)
                    {
                        plantilla = plantilla.Replace(item.Key, item.Value);
                    }

                    textBox_Comando.Text = plantilla;

                    command = textBox_Comando.Text.Trim();
                    await conectar();
                    imprimir();

                    textBox_Comando.Text = "El mensaje modificado ha sido enviado";
                }
                else
                {
                    textBox_Comando.Text = "El archivo1 no existe.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al leer el archivo: " + ex.Message);
                Console.WriteLine("El error ocurrió en la línea: " + new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber());
            }
        }


        private void imprimir() // metodo para imprimir respuesta y mensaje 
        {
            textBox_Respuesta.AppendText(">> "  + command + "\r\n" ); //impresion mensaje
            textBox_Respuesta.AppendText(">> " + response + "\r\n");//impresion respuesta
            textBox_Comando.Clear();//limpiamos la consola


            client.Disconnect();
            client = null;
        }

        private async Task conectar() // metodo utilizado para comenzar la conexion
        {
            if (client == null) //verificamos el estado de nuestra conexion
            {
                string serverIP = textBox_IP.Text.Trim(); // obtenemos la direccion ip de la text box y la almcenamos en la variable
                int port = int.Parse(textBox_Puerto.Text.Trim()); // obtenemos y convertimos a entero  el numero de puerto capturado en la caja de texto

                client = new SimpleTcpClient(); // creacion de una nueva conexion
                client.Connect(serverIP, port); // conexion establecia con el numero de puerto y direccion ip capturados
            }

            // Envía el comando a la impresora
            response = await client.SendCommand(command);
        }

        // evento para detectar cuando se presiona enter
        private async void textBox_Comando_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //verificamos que se presiones enter
            {
                e.SuppressKeyPress = true; // se presiona enter

                command = textBox_Comando.Text;// obtenemos y almacenamos el comando de la caja de texto
                response = ""; //damos el contenido de respuesta

                try
                {
                    await conectar();
                    response = await client.SendCommand(command);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar comando: " + ex.Message); // si no se envia mandamos un mensaje
                }

                imprimir(); // imprimimos el mensaje y la respuesta

            }
        }
      

        private async void button_Encender_Click(object sender, EventArgs e)
        {


            response = "";
            command = Encender; // el comando es igual al valor de la variable encender

            try
            {
               await conectar(); // nos conectamos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar comando: " + ex.Message);
            }

            imprimir(); // imprimimos el mensaje y cerramos conexion
        }

        // evento para limpiar la consola cuando se presiona el boton limpiar
        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Respuesta.Clear();// limpiamos la consola de respuesta
            textBox_Comando.Clear();// limpiamos la consola de comando
        }

        // evento para descargar codigo de la maquina cuando se presiona el boton descarga
        private async void button_descarga_Click(object sender, EventArgs e)
        {
            response = " ";
            command = Descarga; // comando igual al valor de descarga

            try
            {
               await conectar(); // nos conectamos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar comando: " + ex.Message);
            }

            imprimir(); // imprimimos mensaje y respuesta y cerramos conexion
        }

        // evento para apagar  la maquina cuando se presiona el boton apagar
        private async void button_apagar_Click(object sender, EventArgs e)
        {
            response = " ";
            command = Apagar;// comando igual al valor de apagar

            try
            {
                await conectar(); // nos conectamos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar comando: " + ex.Message);
            }

            imprimir(); // imprimimos la respuesta y el mensjae  y cerramos la conexion
        }

        //evento para abrir la boquilla del cabezal de la maquina

        private async void button_apertura_Click(object sender, EventArgs e)
        {
            response = " ";
            command = Apertura; // comando igual a apertura

            try
            {
               await conectar();// nos conectamos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar comando: " + ex.Message);
            }

            imprimir(); // imprimimos el mensaje y la respuesta y cerramos la conexion
        }

        //metodo para cerrar la boquilla del cabezal cuando se presione el boton cierre
        private async void button_Cierre_Click(object sender, EventArgs e)
        {
            response = " ";
            command = Cierre;// el comando es igual al cierre

            try
            {
               await conectar();// nos conectamos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar comando: " + ex.Message);
            }

            imprimir();// imprimimosel mensaje y la respuesta y cerramos la conexion
        }

        // evento para comenzar la impresion al presionar el boton inicio
        private async void button_inicio_Click(object sender, EventArgs e)
        {
            response = " ";
            command = Inicio; //comando es igual a inicio

            try
            {
                await conectar(); // nos conectamos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar comando: " + ex.Message);
            }

            imprimir(); // nos conectamos e imprimimos y cerramos conexion
        }


        //evento para detener la impresion al presionar el boton paro
        private async void button_paro_Click(object sender, EventArgs e)
        {
            response = " ";
            command = Paro; // comandpo igual a impresion

            try
            {
               await conectar(); // nos conectamos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar comando: " + ex.Message);
            }

            imprimir(); // imprimimos el mensja ey la respuesta y cerramos la conexion
        }



    }


    public class SimpleTcpClient // clase utilizada para crear un cliente, conectar y desconectarme a la impresora
    {
        private TcpClient client; // creamos el nombre para instanciar nuestra clase
        private NetworkStream stream; // linea de codigo para conexion

        public SimpleTcpClient() // metodo para inicializacion de variables
        {
        }

        public void Connect(string serverIP, int port) // metodo para conectarme a la maquina
        {
            try
            {
                client = new TcpClient(serverIP, port); // creamos un cliente
                stream = client.GetStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }
        }
        // metodo para cerrar la conexion
        public void Disconnect()
        {
            try
            {
                stream?.Close(); // cerramos conexion
                client?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desconectar: " + ex.Message); // mensaje para avisar que npo se desconecto adecuadamente
            }
        }


        //metodo para enviar un comando a la impresora
        public async Task<string> SendCommand(string command)
        {
            string response = ""; // valor de la respuesta
            string error = ""; // variable para almacenar el mensaje de error

            if (stream != null && client.Connected) // verificamos que exista conexion
            {
                try
                {
                    // Agrega un carácter de nueva línea al final del comando
                    command += "\r\n";

                    byte[] data = Encoding.GetEncoding("Shift-JIS").GetBytes(command);
                    await stream.WriteAsync(data, 0, data.Length);

                    StringBuilder completeMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    var buffer = new byte[500];
                    var stopwatch = Stopwatch.StartNew();

                    // Sigue leyendo hasta que no haya más datos disponibles
                    while (stream.DataAvailable || stopwatch.ElapsedMilliseconds < 500)
                    {
                        if (stream.DataAvailable)
                        {
                            // codificacion de datos
                            numberOfBytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                            completeMessage.AppendFormat("{0}", Encoding.GetEncoding("Shift-JIS").GetString(buffer, 0, numberOfBytesRead));
                        }
                    }

                    response = completeMessage.ToString();// guardamos la respuesta leida en rezponse y la convertimos en string
                }
                catch (Exception ex)
                {
                    error = "Error al enviar/recibir comando: " + ex.Message;
                }
            }
            else
            {
                response = "No estás conectado al servidor.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                // Aquí puedes manejar el error, por ejemplo, mostrándolo en tu interfaz de usuario
                MessageBox.Show(error);
            }

            return response; // retornamos el  valor de la respuesta
        }
    }
}





