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
        string filePath2;
        string acum=" ";
        string filePath1;
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
            button_leer.Visible = true;
            label_serial.Visible = false;






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
            textBox_IP.Text = "172.16.23.97";
            textBox_Puerto.Text = "3000";
            


            serial = false;
            SSH = true;
        }

        private async void button_leer_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(filePath1))
                {
                    string contenidoArchivo1 = File.ReadAllText(filePath1);

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
                            else if (clave == "Name" || clave == "WireLength")
                            {
                                valor = valor.Trim('"');
                                valoresEncontrados1[clave] = new string[] { valor };
                            }
                        }
                    }

                    string Distancia_Total = valoresEncontrados1["WireLength"][0];
                    string mark1 = valoresEncontrados1["MarkingTextBegin"][0];
                    string mark2 = valoresEncontrados1["MarkingTextEndless"][0];
                    string mark3 = valoresEncontrados1["MarkingTextEnd"][0];

                    var resultado = Operacion(Distancia_Total,mark1,mark2,mark3);

                    // Acceder al primer valor
                    int Dist_I = resultado.Item1;

                    // Acceder al segundo valor
                    int Dist_F = resultado.Item2;

                    // Acceder al tercer valor
                    int Dist_M = resultado.Item3;

                    // Acceder al cuarto valor
                    int N_OBJ = resultado.Item4;

                    string plantilla = @"
^0*BEGINLJSCRIPT [(V01.06.00.26)]
^0*JLPAR [80 0 0 0 80 0 0 0 00:00 0 7000 0 0 0 0]
^0*VISION [ 0 1 1 55000 3 5 3 5 0 ]
^0*BEGINJOB [ 0 (|_BEGINJOB_|) ]
^0*JOBPAR [ 1000 65535 130000 250 0 0 0 1 0 0 -1 ({B5F013C6-1F3D-53FC-8C1D-E8CC699050E4}) 1 0 0 1 1 0 0 0 0 0 1 0 ]
^0*OBJ [1 |_OBJ1_| 16 0 (ISO1_7X5)  (|_OBJY_I|) 1 0 0 0 0 0 0 0 0 0 0 0 ()  () 0 0 () ]
";

                    for (int i = 2; i <= N_OBJ; i++)
                    {
                        plantilla += $"^0*OBJ [{i} |_OBJ{i}_| 16 0 (ISO1_7X5)  (|_OBJX{i-1}_|) 1 0 0 0 0 0 0 0 0 0 0 0 ()  () 0 0 () ]\n";
                    }

                    plantilla += $"^0*OBJ [{N_OBJ+1} |_OBJ{N_OBJ + 1}_| 16 0 (ISO1_7X5)  (|_OBJYE_|) 1 0 0 0 0 0 0 0 0 0 0 0 ()  () 0 0 () ]\n^0*ENDJOB []\n^0*ENDLJSCRIPT []";


                    Dictionary<string, string> parametros = new Dictionary<string, string>();
                    parametros.Add("|_BEGINJOB_|", valoresEncontrados1["Name"][0]);
                    int acumulador = 0;

                    for (int i = 1; i <= N_OBJ; i++)
                    {


                        if (i == 1)
                        {
                            parametros.Add($"|_OBJ{i}_|", mark1);
                            parametros.Add($"|_OBJY_I|", valoresEncontrados1["MarkingTextBegin"][1]);
                            parametros.Add($"|_OBJX1_|", valoresEncontrados1["MarkingTextEndless"][1]);
                            acumulador = resultado.Item1;
                        }
                        else if (i == N_OBJ)
                        {
                            acumulador += (60 + resultado.Item6); acum = acumulador.ToString();
                            parametros.Add($"|_OBJ{i}_|", acum);
                            parametros.Add($"|_OBJYE_|", valoresEncontrados1["MarkingTextEnd"][1]);
                            if (i == N_OBJ)
                            {
                                acumulador = 0;
                                acumulador =  resultado.Item8; acum = acumulador.ToString();
                                parametros.Add($"|_OBJ{i+1}_|", acum);
                            }

                        }
                        else
                        {
                            if (i == 2) { acumulador += resultado.Item6; acum = acumulador.ToString(); }
                            if (i == 3) { acumulador += (60 + resultado.Item6); acum = acumulador.ToString(); }
                            if (i >3 && i< N_OBJ) { acumulador += (60 + resultado.Item6); acum = acumulador.ToString(); }
                            parametros.Add($"|_OBJ{i}_|", acum);
                            parametros.Add($"|_OBJX{i}_|", valoresEncontrados1["MarkingTextEndless"][1]);
                        }
                    }



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

        private (int, int, int, int,int,int,int,int) Operacion(string X, string Y, string Z, string W)
        {
            if (int.TryParse(X, out int dtX) && int.TryParse(Y, out int dtY) && int.TryParse(Z, out int dtZ) && int.TryParse(W, out int dtW))
            {
                int Dist_I = dtY + 60;
                int Dist_F = dtW + 60;
                int Dist_M = dtZ + 60;
                int Distancia_disponible = dtX - ((Dist_I) + (Dist_F));
                int N_OBJ = Distancia_disponible / Dist_M;
                int acumf = dtX - Dist_F;

                // Retorna los cuatro valores como una tupla
                return (Dist_I, Dist_F, Dist_M, N_OBJ,dtY,dtZ,dtW,acumf);
            }
            else
            {
                Console.WriteLine("No se pudo convertir uno o más valores a un entero.");
                return (0, 0, 0, 0,0,0,0,0); // Retorna una tupla de ceros si hay un error
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

        private void button_dds_Click(object sender, EventArgs e)
        {
            if (openFileDialog_dds.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionado
                 filePath1 = openFileDialog_dds.FileName;

                // Obtener el nombre del archivo
                string fileName = Path.GetFileName(filePath1);


                textBox_ruta_de_carpeta.Text = fileName;
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = Path.GetDirectoryName(filePath1); // Observa el directorio del archivo
                watcher. Filter = Path.GetFileName(filePath1); // Observa específicamente este archivo
                watcher.Deleted += OnDeleted;
                watcher.Created += OnCreated;

                // Iniciar la observación
                watcher.EnableRaisingEvents = true;

                // Aquí puedes trabajar con el archivo seleccionado
                // Por ejemplo, leer el archivo
                // string fileContent = File.ReadAllText(filePath);
            }
        }

        private void button1_txt_Click(object sender, EventArgs e)
        {
            if (openFileDialog_txt.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionado
                 filePath2 = openFileDialog_txt.FileName;

                // Obtener el nombre del archivo
                string fileName = Path.GetFileName(filePath2);

                textBox_archivotxt.Text = fileName;

                // Aquí puedes trabajar con el archivo seleccionado
                // Por ejemplo, leer el archivo
                //string fileContent = File.ReadAllText(filePath);
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





