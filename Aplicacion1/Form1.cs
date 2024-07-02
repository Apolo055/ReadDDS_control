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
using Aplicacion1.Utilidades;


// El namespace se utiliza para declarar un ámbito que contiene un conjunto de objetos relacionados. Puedes usar un espacio de nombres para organizar los elementos de código y crear tipos únicos globales
namespace Aplicacion1
{
    public partial class Form1 : Form // clase que contiene los metodos variables y eventos necesarios para el funcionamiento de la interfaz grafica de usuario
    {
        private SimpleTcpClient client; // palabra clave de la instancia
        bool serial = false, SSH = false; // variables utilizadas para funcionamiento de la aplicacion
        string command = "", response = ""; // variable para almacenar la respuesta y mensaje que se envia entre el usuario y la maquina
        string filePath2;
        double Tamcaracter = 0.0;
        string acum =" ";
        string Encender = "^0!PO", Apagar = "^0!PF", Apertura = "^0!NO", Cierre = "^0!NC", Inicio = "^0!GO", Paro = "^0!ST", Descarga = "^0?JB";
        // valiables que almacenan comando especificos para mandar a la maquina atraves de botones de control
        string ruta =" ";
        public Form1() // metodo utilizado para inicalizar componentes y estados de los elementos que se utilizan
        {
            InitializeComponent();// inicializacion de la aplicacion
            Configuracion.cargarConfiguracion();

            // habilitar o desabilitar elementos de la aplicacion
            textBox_IP.Enabled = false;
            textBox_Puerto.Enabled = false;
            label_serial.Visible = false;
            label_velocidad.Visible = false;
            button_leer.Visible = true;
            label_serial.Visible = false;
            textBox_ruta_de_carpeta.Text = MiConfig.Nombre_archivo;
            textBox_IP.Text = MiConfig.IP;
            textBox_Puerto.Text = MiConfig.Puerto;
            textBox_matriz.Text = MiConfig.Matriz;
            textBox_altura.Text = MiConfig.Altura;
            textBox_modoPG.Text = MiConfig.Modo;
            textBox_ANCHOFUENTE.Text = MiConfig.Ancho;



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
            //textBox_Comando.Text=($"El archivo {e.Name} ha sido {e.ChangeType}");
        }

       /* private void OnChanged(object source, FileSystemEventArgs e)
        {
            // Especifica qué se debe hacer cuando el archivo se cambia
            this.Invoke((MethodInvoker)delegate {
                button_leer_Click(this, EventArgs.Empty);
            });
        }
       */
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
            



            serial = false;
            SSH = true;
        }

        private async void button_leer_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(MiConfig.Ruta))
                {
                    string contenidoArchivo1 = File.ReadAllText(MiConfig.Ruta);

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

                    int longitud = valoresEncontrados1["MarkingTextBegin"][1].Length;
                    int anchoFuente = 0;
                    bool isParsed = int.TryParse(textBox_ANCHOFUENTE.Text, out anchoFuente);

                    if (isParsed)
                    {
                        string texto = textBox_matriz.Text; // Obtén el texto del TextBox
                        string[] partes = texto.Split('X'); // Divide el texto por 'X'
                        double numero;
                        if (Double.TryParse(partes[1], out numero)) // Intenta convertir la segunda parte a double
                        {
                            //Console.WriteLine(numero.ToString());
                            Tamcaracter = longitud * ((anchoFuente * 0.001) * (numero + 1.0));// Aquí puedes usar la variable 'numero'
                        }
                        else
                        {
                            MessageBox.Show("El valor en textBox_Matriz no es esta en un formato válido."); // Maneja el caso en que la conversión a double falla
                        }
                    
                    }
                    else
                    {
                        MessageBox.Show("El valor en textBox_ANCHOFUENTE no es un número entero válido.");
                    }
                    
                    var resultado = Operacion(Distancia_Total,mark1,mark2,mark3);

                  
                    string plantilla =

@"
^0*BEGINLJSCRIPT[(V01.06.00.31)]
^0*JLPAR[" + textBox_altura.Text + @" 1 0 3 30 0 0 9900 00:00 0 7000 0 0 1000 0 0]
^0*VISION[0 1 0 55000 3 5 3 5 0]
^0*MOBAPARAMETERUSAGE[0]
^0*BEGINJOB[0 (|_BEGINJOB_1| 1)]
^0*JOBPAR[0 0 0 " + textBox_ANCHOFUENTE.Text +" "+ @"" + textBox_modoPG.Text + " " + @" 0 0 1 1 0 -1 ({ F6B5362F - 0298 - 2263 - D0BD - 7D1D37A02B21}) 1 1 55000 1 11 0 0 0 0 0 1 0 0 ]
^0*OBJ[1 1 0 0 (" + textBox_matriz.Text + @") (|_OBJ_1|) 1 0 0 0 0 1 0 0 0 0 0 0 () () 0 0 ()]
^0*ENDJOB[]
^0*BEGINJOB[1( |_BEGINJOB_2| 2)]
^0*JOBPAR[0 |_JOBPAR_R| |_JOBPAR_2| " + textBox_ANCHOFUENTE.Text + @" " + textBox_modoPG.Text + @" 0 0 1 1 0 -1 ({ F6B5362F - 0298 - 2263 - D0BD - 7D1D37A02B21}) 1 1 55000 1 11 0 0 0 0 0 1 0 0 ]
^0*OBJ[1 0 0 0 (" +textBox_matriz.Text + @") (|_OBJ_2|) 1 0 0 0 0 1 0 0 0 0 0 0 () () 0 0 ()]
^0*ENDJOB[]
^0*JOBORG[1 " + resultado.Item3.ToString() + @" 0]
^0*JOBORG[2 " + resultado.Item4.ToString() + @" 1]
^0*ENDLJSCRIPT[]
";




                    Dictionary<string, string> parametros = new Dictionary<string, string>();
                    parametros.Add("|_BEGINJOB_1|", valoresEncontrados1["Name"][0]);
                    parametros.Add("|_BEGINJOB_2|", valoresEncontrados1["Name"][0]);
                    parametros.Add("|_JOBPAR_2|", resultado.Item2.ToString());
                    parametros.Add("|_JOBPAR_R|", (resultado.Item1-1).ToString());
                    parametros.Add("|_OBJ_1|", valoresEncontrados1["MarkingTextBegin"][1]);
                    parametros.Add("|_OBJ_2|", valoresEncontrados1["MarkingTextEndless"][1]);


                    foreach (KeyValuePair<string, string> item in parametros)
                    {
                        plantilla = plantilla.Replace(item.Key, item.Value);
                    }

                    textBox_Comando.Text = plantilla;

                    command = textBox_Comando.Text;
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
                MessageBox.Show("Ocurrió un error al leer el archivo verifique el archivo seleccionado: " + ex.Message);
                Console.WriteLine("El error ocurrió en la línea: " + new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber());
            }
        }

        private (int, int, int, int) Operacion(string X, string Y, string Z, string W)
        {
            if (int.TryParse(X, out int dtX) && int.TryParse(Y, out int dtY) && int.TryParse(Z, out int dtZ) && int.TryParse(W, out int dtW))
            {
                
                int Dist_I = dtY* 1000;
                int Dist_F = dtW * 1000;
                int Dist_T = dtX * 1000;
                int Constantetext = Convert.ToInt32(Tamcaracter * 1000);
                int Dist_M = (dtZ*1000)+ Constantetext;
                double Distancia_disponible = Dist_T - (Constantetext + Dist_I + Constantetext + Dist_F);
                double N_OBJ = Distancia_disponible / Dist_M;
                int resultadoRedondeado = Convert.ToInt32(Math.Floor(N_OBJ));
                double parteDecimal =(N_OBJ - resultadoRedondeado)  * Dist_M;
                int residuo = Convert.ToInt32(parteDecimal);
                int Dist_job1 = Convert.ToInt32(Dist_I - (8 * 1000));
                int Dist_job2 = 0;
                if (resultadoRedondeado - 1 == 0)
                {
                    Dist_job2 = Dist_T - (Constantetext + Dist_F+8000);
                }
                else 
                {
                    Dist_job2 = Dist_T - ((Constantetext) + (Dist_M * (resultadoRedondeado - 1)) + Dist_F+8000);
                }
                    

               // Console.WriteLine(residuo.ToString());
               // Console.WriteLine(N_OBJ.ToString());
                

                // Retorna los cuatro valores como una tupla
                return (resultadoRedondeado, Dist_M, Dist_job1, Dist_job2);
            }
            else
            {
                Console.WriteLine("No se pudo convertir uno o más valores a un entero.");
                return (0, 0, 0, 0); // Retorna una tupla de ceros si hay un error
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
                MiConfig.Ruta = openFileDialog_dds.FileName;
                MiConfig.Nombre_archivo = Path.GetFileName(MiConfig.Ruta);
                // Obtener el nombre del archivo
                Configuracion.GuardarConfiguracion();
                
               
                textBox_ruta_de_carpeta.Text = MiConfig.Nombre_archivo;
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = Path.GetDirectoryName(MiConfig.Ruta); // Observa el directorio del archivo
                watcher. Filter = Path.GetFileName(MiConfig.Ruta); // Observa específicamente este archivo
                watcher.Deleted += OnDeleted;
                watcher.Created += OnCreated;
               // watcher.Changed += OnChanged;

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

        private void textBox_IP_TextChanged(object sender, EventArgs e)
        {
            MiConfig.IP = textBox_IP.Text;            
            Configuracion.GuardarConfiguracion();
        }

        private void textBox_Puerto_TextChanged(object sender, EventArgs e)
        {

            MiConfig.Puerto = textBox_Puerto.Text;
            Configuracion.GuardarConfiguracion();
        }

        private void textBox_matriz_TextChanged(object sender, EventArgs e)
        {
            MiConfig.Matriz = textBox_matriz.Text;
            Configuracion.GuardarConfiguracion();

        }

        private void textBox_altura_TextChanged(object sender, EventArgs e)
        {
            MiConfig.Altura = textBox_altura.Text;
            Configuracion.GuardarConfiguracion();

        }

        private void textBox_modoPG_TextChanged(object sender, EventArgs e)
        {
            MiConfig.Modo = textBox_modoPG.Text;
            Configuracion.GuardarConfiguracion();

        }

        private void textBox_ANCHOFUENTE_TextChanged(object sender, EventArgs e)
        {
            MiConfig.Ancho = textBox_ANCHOFUENTE.Text;
            Configuracion.GuardarConfiguracion();

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





