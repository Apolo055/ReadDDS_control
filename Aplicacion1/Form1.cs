//librerias utilizadas para el proyecto

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Trapid.Utilidades;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Threading;


// El namespace se utiliza para declarar un ámbito que contiene un conjunto de objetos relacionados. Puedes usar un espacio de nombres para organizar los elementos de código y crear tipos únicos globales
namespace Trapid
{
    public partial class Form1 : Form // clase que contiene los metodos variables y eventos necesarios para el funcionamiento de la interfaz grafica de usuario
    {
        private SimpleTcpClient client; // palabra clave de la instancia
        bool serial = false, SSH = false; // variables utilizadas para funcionamiento de la aplicacion
        string command = "", response = ""; // variable para almacenar la respuesta y mensaje que se envia entre el usuario y la maquina
        string filePath2;
        double Tamcaracter = 0.0;
        string joborg1 = " ";
        string plantilla = "";
        string joborg2 = " ";
        string begingjob = " ";
        string obj1 = " ";
        string obj2 = " ";
        string jobparR = " ";
        string jobpar2 = " ";
        string acum = " ";
        bool endless = true;

        string Distancia_Total = "";
        string mark1 = "";
        string mark2 = "";
        string mark3 = "";
        int longitud = 0;
        int anchoFuente = 0;
        string signal = "";
        




        string Encender = "^0!PO", Apagar = "^0!PF", Apertura = "^0!NO", Cierre = "^0!NC", Inicio = "^0!GO", Paro = "^0!ST", Descarga = "^0?JB";
        // valiables que almacenan comando especificos para mandar a la maquina atraves de botones de control
        string ruta = " ";
        public Form1() // metodo utilizado para inicalizar componentes y estados de los elementos que se utilizan
        {
            InitializeComponent();// inicializacion de la aplicacion
            Configuracion.CargarConfiguracion();

            // habilitar o desabilitar elementos de la aplicacion
            textBox_IP.Enabled = false;
            textBox_Puerto.Enabled = false;
            label_serial.Visible = false;
            label_velocidad.Visible = false;
            button_leer.Visible = true;
            label_serial.Visible = false;
            textBox_espejo.Visible = false;
            textBox_orientacion.Visible = false;
            textBox_ruta_de_carpeta.Text = MiConfig.Nombre_archivo;
            textBox_IP.Text = MiConfig.IP;
            textBox_Puerto.Text = MiConfig.Puerto;
            textBox_matriz.Text = MiConfig.Matriz;
            textBox_altura.Text = MiConfig.Altura;
            textBox_modoPG.Text = MiConfig.Modo;
            textBox_ANCHOFUENTE.Text = MiConfig.Ancho;
            textBox_espejo.Text = MiConfig.espejo;
            textBox_resolucion.Text = MiConfig.resolucion;
            textBox_orientacion.Text = MiConfig.orientacion;
            comboBox_orientacion.Text = MiConfig.orientacion;
            comboBox_espejo.Text = MiConfig.espejo;
            comboBox_signal.Text = MiConfig.señalgo;

            try
            {
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = Path.GetDirectoryName(MiConfig.Ruta); // Observa el directorio del archivo
                watcher.Filter = Path.GetFileName(MiConfig.Ruta); // Observa específicamente este archivo
                watcher.Filter = "Article*";                                                   // 
                watcher.Created += OnCreated;
                //watcher.Changed += OnChanged;

                // Iniciar la observación
                watcher.EnableRaisingEvents = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show("verifique la ruta de article");
            }

        }
        /*
        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            /////  MessageBox.Show($"Archivo agregado: {e.FullPath}");
            // invocamos el evento click desde el hilo de la UI O hilo principal
            // Esperar a que el archivo esté completamente escrito antes de intentar leerlo
            System.Threading.Thread.Sleep(1000);//1000

            try
            {
                string fileContent = File.ReadAllText(e.FullPath);
                //MessageBox.Show($"Archivo creado: {e.Name}\nContenido:\n{fileContent}");
                string plantilla = procesar(fileContent);
                Invoke(new Action(() => textBox_Comando.Text = plantilla));

                command = plantilla;
                conectar();
                imprimir();

                
                //File.Delete(MiConfig.Ruta);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo: {ex.Message}");
            }
           // button_leer_Click(this, EventArgs.Empty);
            

        }
        */

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            System.Threading.Thread.Sleep(20);//1000
            try
            {
                // Obtener el nombre del archivo y la extensión
                string fileName = Path.GetFileNameWithoutExtension(e.FullPath).ToLower(); // Nombre del archivo en minúsculas
                string extension = Path.GetExtension(e.FullPath).ToLower(); // Extensión en minúsculas

                // Validar nombres y extensiones
                if ((fileName == "article" || fileName == "article.dds") &&
                    (extension == ".dds" || extension == ".dds.arc"))
                {
                    // Leer contenido del archivo
                    string fileContent = File.ReadAllText(e.FullPath);

                    // Procesar el contenido y obtener la plantilla
                    string plantilla = procesar(fileContent);

                    // Actualizar el textBox_Comando en el hilo principal
                    Invoke(new Action(() => textBox_Comando.Text = plantilla));

                    // Asignar el comando y ejecutar lógica adicional
                    command = plantilla;
                    conectar();
                    imprimir();
                }
                else
                {
                    // Ignorar archivos no deseados
                    //MessageBox.Show($"Archivo ignorado: {e.FullPath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error procesando archivo: {ex.Message}");
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
            



            serial = false;
            SSH = true;
        }

        private  void button_leer_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(MiConfig.Ruta))
                {
                    string contenidoArchivo1 = File.ReadAllText(MiConfig.Ruta);

                    string plantilla = this.procesar(contenidoArchivo1);

                    textBox_Comando.Text = plantilla;

                    command = plantilla;
                    conectar();
                    imprimir();

                    textBox_Comando.Text = "El mensaje modificado ha sido enviado";
                    //File.Delete(MiConfig.Ruta);
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

        public string procesar(string contenidoArchivo1)
        {
            string plantilla = "";
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

            if (valoresEncontrados1.ContainsKey("MarkingTextEndless") &&
                valoresEncontrados1.ContainsKey("MarkingTextBegin") &&
                valoresEncontrados1.ContainsKey("MarkingTextEnd") &&
                valoresEncontrados1.ContainsKey("WireLength") &&
                valoresEncontrados1.ContainsKey("Name"))
            {
                endless = true;
                valoresEncontrados1["MarkingTextBegin"][1] = Modificar(valoresEncontrados1["MarkingTextBegin"][1]);
                valoresEncontrados1["MarkingTextEnd"][1] = Modificar(valoresEncontrados1["MarkingTextEnd"][1]);
                valoresEncontrados1["MarkingTextEndless"][1] = Modificar(valoresEncontrados1["MarkingTextEndless"][1]);

                Distancia_Total = valoresEncontrados1["WireLength"][0];
                mark1 = valoresEncontrados1["MarkingTextBegin"][0];
                mark2 = valoresEncontrados1["MarkingTextEndless"][0];
                mark3 = valoresEncontrados1["MarkingTextEnd"][0];

                if (Regex.IsMatch(valoresEncontrados1["MarkingTextBegin"][1], @"\("))
                {
                    longitud = valoresEncontrados1["MarkingTextBegin"][1].Length;
                    longitud = longitud - 2;
                }
                else
                {
                    longitud = valoresEncontrados1["MarkingTextBegin"][1].Length;
                }
                anchoFuente = 0;
                bool isParsed = int.TryParse(textBox_ANCHOFUENTE.Text, out anchoFuente);

                if (isParsed)
                {
                    string texto = textBox_matriz.Text; // Obtén el texto del TextBox
                    string[] partes = texto.Split('x'); // Divide el texto por 'x'
                    double numero;
                    if (Double.TryParse(partes[1], out numero)) // Intenta convertir la segunda parte a double
                    {
                        Tamcaracter = longitud * ((anchoFuente * 0.001) * (numero + 1.0)); // Cálculo
                    }
                    else
                    {
                        MessageBox.Show("El valor en textBox_Matriz no está en un formato válido."); // Manejo de error
                    }
                }
                else
                {
                    MessageBox.Show("El valor en textBox_ANCHOFUENTE no es un número entero válido.");
                }

                var resultado = Operacion(Distancia_Total, mark1, mark2, mark3);
                joborg1 = resultado.DistJob1.ToString();
                joborg2 = resultado.DistJob2.ToString();

                Invoke(new Action(() => textBox_orientacion.Text = comboBox_orientacion.Text));
                Invoke(new Action(() => textBox_espejo.Text = comboBox_espejo.Text));
                Invoke(new Action(() => signal = comboBox_signal.Text));

                int printgo = Convert.ToInt32(textBox_modoPG.Text) - 1;
                string modoPG = Convert.ToString(printgo);

                plantilla =

@"
^0*BEGINLJSCRIPT[(V01.06.00.31)]
^0*JLPAR[" + textBox_altura.Text + @" " + signal + @" 0 3 400 " + textBox_orientacion.Text + @" " + textBox_espejo.Text + @" " + textBox_resolucion.Text + @" 00:00 1 7000 0 0 1000 0 0]
^0*VISION[0 1 0 55000 3 5 3 5 0]
^0*MOBAPARAMETERUSAGE[0]
^0*BEGINJOB[0 (|_BEGINJOB_1| 1)]
^0*JOBPAR[0 0 0 " + textBox_ANCHOFUENTE.Text + " " + textBox_modoPG.Text + @" 0 0 0 0 0 -1 ({ F671A72C-E135-DD52-6599-54EDDA3BE6D6 }) 1 1 55000 1 " + modoPG + @" 0 " + textBox_espejo.Text + @" 0 0 0 1 0 0 ]
^0*OBJ[1 0 0 0 (ISO1_" + textBox_matriz.Text + @") (|_OBJ_1|) 1 0 0 0 0 1 0 0 0 0 0 0 () () 0 0 ()]
^0*ENDJOB[]
^0*BEGINJOB[1 (|_BEGINJOB_2| 2)]
^0*JOBPAR[0 |_JOBPAR_R| |_JOBPAR_2| " + textBox_ANCHOFUENTE.Text + @" " + textBox_modoPG.Text + @" 0 0 0 0 0 -1 ({ F671A72C-E135-DD52-6599-54EDDA3BE6D6 }) 1 1 55000 1 " + modoPG + @" 0 " + textBox_espejo.Text + @" 0 0 0 1 0 0 ]
^0*OBJ[1 0 0 0 (ISO1_" + textBox_matriz.Text + @") (|_OBJ_2|) 1 0 0 0 0 1 0 0 0 0 0 0 () () 0 0 ()]
^0*ENDJOB[]
^0*JOBORG[1 " + resultado.DistJob1.ToString() + @" 0]
^0*JOBORG[2 " + resultado.DistJob2.ToString() + @" 1]
^0*ENDLJSCRIPT[]
";

                //^0*JOBPAR[0 0 0 " + textBox_ANCHOFUENTE.Text + " " + textBox_modoPG.Text + @" 0 0 0 0 0 -1 ({ F671A72C-E135-DD52-6599-54EDDA3BE6D6 }) 1 1 55000 1 " + modoPG + @" 0 " + textBox_espejo.Text + @" 0 0 0 1 0 0 ]

               

                begingjob = valoresEncontrados1["Name"][0];
                obj1 = valoresEncontrados1["MarkingTextEndless"][1];
                jobparR = (resultado.ResultadoRedondeado - 1).ToString();
                jobpar2 = resultado.DistM.ToString();

                Dictionary<string, string> parametros = new Dictionary<string, string>
    {
        {"|_BEGINJOB_1|", valoresEncontrados1["Name"][0]},
        {"|_BEGINJOB_2|", valoresEncontrados1["Name"][0]},
        {"|_JOBPAR_2|", resultado.DistM.ToString()},
        {"|_JOBPAR_R|", (resultado.ResultadoRedondeado - 1).ToString()},
        {"|_OBJ_1|", valoresEncontrados1["MarkingTextBegin"][1]},
        {"|_OBJ_2|", valoresEncontrados1["MarkingTextEndless"][1]}
    };

                foreach (KeyValuePair<string, string> item in parametros)
                {
                    plantilla = plantilla.Replace(item.Key, item.Value);
                }
                return plantilla;
            }
            else
            {
                    endless = false;
                    valoresEncontrados1["MarkingTextBegin"][1] = Modificar(valoresEncontrados1["MarkingTextBegin"][1]);
                    valoresEncontrados1["MarkingTextEnd"][1] = Modificar(valoresEncontrados1["MarkingTextEnd"][1]);
                   

                    Distancia_Total = valoresEncontrados1["WireLength"][0];
                    mark1 = valoresEncontrados1["MarkingTextBegin"][0];
                    mark2 = "0";
                    mark3 = valoresEncontrados1["MarkingTextEnd"][0];
                if (Regex.IsMatch(valoresEncontrados1["MarkingTextBegin"][1], @"\("))
                {
                    longitud = valoresEncontrados1["MarkingTextBegin"][1].Length;
                    longitud = longitud - 2;
                }
                else
                {
                    longitud = valoresEncontrados1["MarkingTextBegin"][1].Length;
                }
                
              
                anchoFuente = 0;
                    bool isParsed = int.TryParse(textBox_ANCHOFUENTE.Text, out anchoFuente);

                    if (isParsed)
                    {
                        string texto = textBox_matriz.Text; // Obtén el texto del TextBox
                        string[] partes = texto.Split('x'); // Divide el texto por 'x'
                        double numero;
                        if (Double.TryParse(partes[1], out numero)) // Intenta convertir la segunda parte a double
                        {
                            Tamcaracter = (longitud) * ((anchoFuente * 0.001) * (numero + 1.0)); // Cálculo
                        
                    }
                        else
                        {
                            MessageBox.Show("El valor en textBox_Matriz no está en un formato válido."); // Manejo de error
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor en textBox_ANCHOFUENTE no es un número entero válido.");
                    }

                    var resultado1 = Operacion1(Distancia_Total, mark1, mark2, mark3);
                    joborg1 = valoresEncontrados1["MarkingTextBegin"][0];
                    joborg2 = resultado1.DistJob2.ToString();

                    Invoke(new Action(() => textBox_orientacion.Text = comboBox_orientacion.Text));
                    Invoke(new Action(() => textBox_espejo.Text = comboBox_espejo.Text));
                    Invoke(new Action(() => signal = comboBox_signal.Text));

                    int printgo = Convert.ToInt32(textBox_modoPG.Text) - 1;
                    string modoPG = Convert.ToString(printgo);
                    plantilla =
 
@"
^0*BEGINLJSCRIPT[(V01.06.00.31)]
^0*JLPAR[" + textBox_altura.Text + @" " + signal + @" 0 3 400 " + textBox_orientacion.Text + @" " + textBox_espejo.Text + @" " + textBox_resolucion.Text + @" 00:00 1 7000 0 0 1000 0 0]
^0*VISION[0 1 0 55000 3 5 3 5 0]
^0*MOBAPARAMETERUSAGE[0]
^0*BEGINJOB[0 (|_BEGINJOB_1| 1)]
^0*JOBPAR[|_JOBPAR_R1|"+" 1" + @" |_JOBPAR_2| " + textBox_ANCHOFUENTE.Text + @" " + textBox_modoPG.Text + @" 0 0 0 0 0 -1 ({ F671A72C-E135-DD52-6599-54EDDA3BE6D6 }) 1 1 55000 1 " + modoPG + @" 0 " + textBox_espejo.Text + @" 0 0 0 1 0 0 ]
^0*OBJ[1 0 0 0 (ISO1_" + textBox_matriz.Text + @") (|_OBJ_2|) 1 0 0 0 0 1 0 0 0 0 0 0 () () 0 0 ()]
^0*ENDJOB[]
^0*ENDLJSCRIPT[]
";

                //^0*JOBPAR[|_JOBPAR_R1|"+" 1" + @" |_JOBPAR_2| " + textBox_ANCHOFUENTE.Text + @" " + textBox_modoPG.Text + @" 0 0 0 0 0 -1 ({ F671A72C-E135-DD52-6599-54EDDA3BE6D6 }) 1 1 55000 1 " + modoPG + @" 0 " + textBox_espejo.Text + @" 0 0 0 1 0 0 ]


                Dictionary<string, string> parametros = new Dictionary<string, string>
    {
        {"|_BEGINJOB_1|", valoresEncontrados1["Name"][0]},
        {"|_JOBPAR_R1|",resultado1.DistI.ToString()},
        {"|_OBJ_2|", valoresEncontrados1["MarkingTextBegin"][1]},
        {"|_JOBPAR_2|", joborg2},
    };

                foreach (KeyValuePair<string, string> item in parametros)
                {
                    plantilla = plantilla.Replace(item.Key, item.Value);
                }
                return plantilla;
            }



        }
        /*
        private (int, int, int, int) Operacion(string X, string Y, string Z, string W)
        {
            if (int.TryParse(X, out int dtX) && int.TryParse(Y, out int dtY) && int.TryParse(Z, out int dtZ) && int.TryParse(W, out int dtW))
            {
                
                int Dist_I = dtY* 1000;
                int Dist_F = dtW * 1000;
                int Dist_T = dtX * 1000;
                int Constantetext = Convert.ToInt32((Tamcaracter) * 1000);
                int Dist_M = (dtZ*1000)+ Constantetext;
                double Distancia_disponible = Dist_T - (Constantetext + Dist_I + Constantetext + Dist_F);
                double N_OBJ = Distancia_disponible / Dist_M;
                int resultadoRedondeado = Convert.ToInt32(Math.Floor(N_OBJ));
                double parteDecimal =(N_OBJ - resultadoRedondeado)  * Dist_M;
                int residuo = Convert.ToInt32(parteDecimal);
                //int Dist_job1 = Convert.ToInt32(Dist_I - (8 * 1000));
                int Dist_job1 = Convert.ToInt32(Dist_I );
                int Dist_job2 = 0;
                if (resultadoRedondeado - 1 == 0)
                {
                    //Dist_job2 = Dist_T - (Constantetext + Dist_F+8000);
                    Dist_job2 = Dist_T - (Constantetext + Dist_F );
                }
                else 
                {
                    //Dist_job2 = Dist_T - ((Constantetext) + (Dist_M * (resultadoRedondeado - 1)) + Dist_F+8000);
                    Dist_job2 = Dist_T - ((Constantetext) + (Dist_M * (resultadoRedondeado - 1)) + Dist_F);
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

        private (int, int, int, int) Operacion1(string X, string Y, string Z, string W)
        {
            if (int.TryParse(X, out int dtX) && int.TryParse(Y, out int dtY) && int.TryParse(Z, out int dtZ) && int.TryParse(W, out int dtW))
            {

                int Dist_I = dtY * 1000;
                int Dist_F = dtW * 1000;
                int Dist_T = dtX * 1000;
                int Constantetext = Convert.ToInt32((Tamcaracter) * 1000);
                //int Dist_job1 = Convert.ToInt32(Dist_I - (8 * 1000));
                int Dist_job1 = 0;
                int Dist_job2 = Dist_T-(Dist_I+Dist_F+Constantetext);
               

                // Console.WriteLine(residuo.ToString());
                // Console.WriteLine(N_OBJ.ToString());


                // Retorna los cuatro valores como una tupla
                return (Constantetext, Dist_F, Dist_I, Dist_job2);
            }
            else
            {
                Console.WriteLine("No se pudo convertir uno o más valores a un entero.");
                return (0, 0, 0, 0); // Retorna una tupla de ceros si hay un error
            }
        }
        */
        private void actualizar()

        {

            anchoFuente = 0;
            bool isParsed = int.TryParse(textBox_ANCHOFUENTE.Text, out anchoFuente);

            if (isParsed)
            {
                string texto = textBox_matriz.Text; // Obtén el texto del TextBox
                string[] partes = texto.Split('x'); // Divide el texto por 'X'
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

            
        }

        private string Modificar(string texto)
        {
            // Usar una expresión regular para encontrar los paréntesis y formatearlos correctamente
            return Regex.Replace(texto, @"\((.*?)\)", @"\($1\)");
        }
       
        private void imprimir() // metodo para imprimir respuesta y mensaje 
        {
            Invoke(new Action(() => textBox_Respuesta.AppendText(">> " + command + "\r\n")));
            Invoke(new Action(() => textBox_Respuesta.AppendText(">> " + response + "\r\n")));

            Invoke(new Action(() => textBox_Comando.Clear()));//limpiamos la consola
            Invoke(new Action(() => textBox_Comando.Text ="Mensaje enviado y modificado"));
            client.Disconnect();
            client = null;
        }

        /*
        private   Task conectar() // metodo utilizado para comenzar la conexion
        {
            if (client == null) //verificamos el estado de nuestra conexion
            {
                string serverIP = textBox_IP.Text.Trim(); // obtenemos la direccion ip de la text box y la almcenamos en la variable
                int port = int.Parse(textBox_Puerto.Text.Trim()); // obtenemos y convertimos a entero  el numero de puerto capturado en la caja de texto

                client = new SimpleTcpClient(); // creacion de una nueva conexion
                client.Connect(serverIP, port); // conexion establecia con el numero de puerto y direccion ip capturados
            }

            // Envía el comando a la impresora
            if (client != null)
            {
                response = await client.SendCommand(command);
            }
            else
            {
                Console.WriteLine("La conexión no se estableció correctamente.");
            }
        }
        */

        private void conectar() // Método adaptado para comenzar la conexión
        {
            if (client == null) // Verificamos el estado de nuestra conexión
            {
                string serverIP = textBox_IP.Text.Trim(); // Obtenemos la dirección IP de la TextBox
                int port = int.Parse(textBox_Puerto.Text.Trim()); // Obtenemos y convertimos a entero el número de puerto

                client = new SimpleTcpClient(); // Creación de una nueva conexión

                try
                {
                    // Establecemos la conexión en un hilo separado para evitar bloquear la interfaz gráfica
                    Thread connectThread = new Thread(() =>
                    {
                        try
                        {
                            client.Connect(serverIP, port); // Conexión con el servidor
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al conectar: " + ex.Message);
                        }
                    });
                    connectThread.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al crear el cliente: " + ex.Message);
                }
            }

            // Envía el comando a la impresora
            if (client != null)
            {
                try
                {
                    string response = client.SendCommand(command);
                    Console.WriteLine("Respuesta recibida: " + response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al enviar el comando: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("La conexión no se estableció correctamente.");
            }
        }
        // evento para detectar cuando se presiona enter
        private   void textBox_Comando_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //verificamos que se presiones enter
            {
                e.SuppressKeyPress = true; // se presiona enter

                command = textBox_Comando.Text;// obtenemos y almacenamos el comando de la caja de texto
                response = ""; //damos el contenido de respuesta

                try
                {
                    conectar();
                    response = client.SendCommand(command);
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

        private void button_actualizar_Click(object sender, EventArgs e)
        {
            if (endless == true)
            {
                actualizar();
                var resultado = Operacion(Distancia_Total, mark1, mark2, mark3);
                jobparR = (resultado.ResultadoRedondeado - 1).ToString();
                jobpar2 = resultado.DistM.ToString();
                joborg1 = resultado.DistJob1.ToString();
                joborg2 = resultado.DistJob2.ToString();

                Invoke(new Action(() => textBox_orientacion.Text = comboBox_orientacion.Text));
                Invoke(new Action(() => textBox_espejo.Text = comboBox_espejo.Text));
                Invoke(new Action(() => signal = comboBox_signal.Text));

                int printgo1 = Convert.ToInt32(textBox_modoPG.Text) - 1;
                string modoPG1 = Convert.ToString(printgo1);
                string plantilla =

    @"
^0*BEGINLJSCRIPT[(V01.06.00.31)]
^0*JLPAR[" + textBox_altura.Text + @" " + signal + @" 0 3 400 " + textBox_orientacion.Text + @" " + textBox_espejo.Text + @" " + textBox_resolucion.Text + @" 00:00 1 7000 0 0 1000 0 0]
^0*VISION[0 1 0 55000 3 5 3 5 0]
^0*MOBAPARAMETERUSAGE[0]
^0*BEGINJOB[0 (" + begingjob + @" 1)]
^0*JOBPAR[0 0 0 " + textBox_ANCHOFUENTE.Text + " " + @"" + textBox_modoPG.Text + " " + @"0 0 0 0 0 -1 ({ F671A72C-E135-DD52-6599-54EDDA3BE6D6 }) 1 1 55000 1 " + modoPG1 + @" 0 " + textBox_espejo.Text + @" 0 0 0 1 0 0 ]
^0*OBJ[1 0 0 0 (ISO1_" + textBox_matriz.Text + @") (" + obj1 + @") 1 0 0 0 0 1 0 0 0 0 0 0 () () 0 0 ()]
^0*ENDJOB[]
^0*BEGINJOB[1( " + begingjob + @" 2)]
^0*JOBPAR[0 " + jobparR + @" " + jobpar2 + @" " + textBox_ANCHOFUENTE.Text + @" " + textBox_modoPG.Text + @" 0 0 0 0 0 -1 ({ F671A72C-E135-DD52-6599-54EDDA3BE6D6 }) 1 1 55000 1 " + modoPG1 + @" 0 " + textBox_espejo.Text + @" 0 0 0 1 0 0 ]
^0*OBJ[1 0 0 0 (ISO1_" + textBox_matriz.Text + @") (" + obj1 + @") 1 0 0 0 0 1 0 0 0 0 0 0 () () 0 0 ()]
^0*ENDJOB[]
^0*JOBORG[1 " + joborg1 + @" 0]
^0*JOBORG[2 " + joborg2 + @" 1]
^0*ENDLJSCRIPT[]
";

                //^0*JOBPAR[0 0 0 " + textBox_ANCHOFUENTE.Text + " " + @"" + textBox_modoPG.Text + " " + @"0 0 0 0 0 -1 ({ F671A72C-E135-DD52-6599-54EDDA3BE6D6 }) 1 1 55000 1 " + modoPG1 + @" 0 " + textBox_espejo.Text + @" 0 0 0 1 0 0 ]



                textBox_Respuesta.Text = plantilla;

                command = plantilla;
            }

            else
            {
                actualizar();
                var resultado1 = Operacion1(Distancia_Total, mark1, mark2, mark3);
                Invoke(new Action(() => textBox_orientacion.Text = comboBox_orientacion.Text));
                Invoke(new Action(() => textBox_espejo.Text = comboBox_espejo.Text));
                Invoke(new Action(() => signal = comboBox_signal.Text));

                
                int printgo1 = Convert.ToInt32(textBox_modoPG.Text) - 1;
                string modoPG1 = Convert.ToString(printgo1);
                string plantilla =
 
  @"
^0*BEGINLJSCRIPT[(V01.06.00.31)]
^0*JLPAR[" + textBox_altura.Text + @" " + signal + @" 0 3 400 " + textBox_orientacion.Text + @" " + textBox_espejo.Text + @" " + textBox_resolucion.Text + @" 00:00 1 7000 0 0 1000 0 0]
^0*VISION[0 1 0 55000 3 5 3 5 0]
^0*MOBAPARAMETERUSAGE[0]
^0*BEGINJOB[0( " + begingjob + @" 2)]
^0*JOBPAR["+ resultado1.DistI.ToString() +" 1"+ @" " + resultado1.DistJob2.ToString() + @" " + textBox_ANCHOFUENTE.Text + @" " + textBox_modoPG.Text + @" 0 0 0 0 0 -1 ({ F671A72C-E135-DD52-6599-54EDDA3BE6D6 }) 1 1 55000 1 " + modoPG1 + @" 0 " + textBox_espejo.Text + @" 0 0 0 1 0 0 ]
^0*OBJ[1 0 0 0 (ISO1_" + textBox_matriz.Text + @") (" + obj1 + @") 1 0 0 0 0 1 0 0 0 0 0 0 () () 0 0 ()]
^0*ENDJOB[]
^0*ENDLJSCRIPT[]
 ";

                //^0*JOBPAR["+ resultado1.Item3.ToString() +"1"+ @" " + resultado1.Item4.ToString() + @" " + textBox_ANCHOFUENTE.Text + @" " + textBox_modoPG.Text + @" 0 0 0 0 0 -1 ({ F671A72C-E135-DD52-6599-54EDDA3BE6D6 }) 1 1 55000 1 " + modoPG1 + @" 0 " + textBox_espejo.Text + @" 0 0 0 1 0 0 ]


                /*
                @"
                ^0*BEGINLJSCRIPT[(V01.06.00.31)]
                ^0*JLPAR[" + textBox_altura.Text + @" " + signal + @" 0 3 30 " + textBox_orientacion.Text + @" " + textBox_espejo.Text + @" " + textBox_resolucion.Text + @" 00:00 0 7000 0 0 1000 0 0]
                ^0*VISION[0 1 0 55000 3 5 3 5 0]
                ^0*MOBAPARAMETERUSAGE[0]
                ^0*BEGINJOB[0 ( " + begingjob + @" 1)]
                ^0*JOBPAR[0 0 0 " + textBox_ANCHOFUENTE.Text + " " + @"" + textBox_modoPG.Text + " " + @" 0 0 1 1 0 -1 ({ F6B5362F - 0298 - 2263 - D0BD - 7D1D37A02B21}) 1 1 55000 1 11 0 " + textBox_espejo.Text + @" 0 0 0 1 0 0 ]
                ^0*OBJ[1 1 0 0 (ISO1_" + textBox_matriz.Text + @") (" + obj1 + @") 1 0 0 0 0 1 0 0 0 0 0 0 () () 0 0 ()]
                ^0*ENDJOB[]
                ^0*BEGINJOB[1( " + begingjob + @" 2)]
                ^0*JOBPAR[0 " + jobparR + @" " + jobpar2 + @" " + textBox_ANCHOFUENTE.Text + @" " + textBox_modoPG.Text + @" 0 0 1 1 0 -1 ({ F6B5362F - 0298 - 2263 - D0BD - 7D1D37A02B21}) 1 1 55000 1 11 0 0 0 0 0 1 0 0 ]
                ^0*OBJ[1 0 0 0 (ISO1_" + textBox_matriz.Text + @") (" + obj1 + @") 1 0 0 0 0 1 0 0 0 0 0 0 () () 0 0 ()]
                ^0*ENDJOB[]
                ^0*JOBORG[1 " + joborg1 + @" 0]
                ^0*JOBORG[2 " + joborg2 + @" 1]
                ^0*ENDLJSCRIPT[]
                ";
                */

                textBox_Respuesta.Text = plantilla;

                command = plantilla;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            command = textBox_Respuesta.Text.Trim();
            conectar();
            imprimir();

            textBox_Comando.Text = "El mensaje modificado ha sido enviado ACTUALIZADO Y ENVIADO";
           
        }

        private void textBox_espejo_TextChanged(object sender, EventArgs e)
        {
            MiConfig.espejo = textBox_espejo.Text;
            Configuracion.GuardarConfiguracion();

        }

        private void textBox_orientacion_TextChanged(object sender, EventArgs e)
        {
            MiConfig.orientacion = textBox_orientacion.Text;
            Configuracion.GuardarConfiguracion();
        }

        private void textBox_resolucion_TextChanged(object sender, EventArgs e)
        {
            MiConfig.resolucion = textBox_resolucion.Text;
            Configuracion.GuardarConfiguracion();

        }
        
        private void comboBox_signal_SelectedIndexChanged(object sender, EventArgs e)
        {
            MiConfig.señalgo = comboBox_signal.Text;
            Configuracion.GuardarConfiguracion();
        }

        private void comboBox_orientacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            MiConfig.orientacion = comboBox_orientacion.Text;
            Configuracion.GuardarConfiguracion();
        }

        private void comboBox_espejo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MiConfig.espejo = comboBox_espejo.Text;
            Configuracion.GuardarConfiguracion();
        }

        

        private void button_Encender_Click(object sender, EventArgs e)
        {


            response = "";
            command = Encender; // el comando es igual al valor de la variable encender

            try
            {
               conectar(); // nos conectamos

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
        private   void button_descarga_Click(object sender, EventArgs e)
        {
            response = " ";
            command = Descarga; // comando igual al valor de descarga

            try
            {
               conectar(); // nos conectamos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar comando: " + ex.Message);
            }

            imprimir(); // imprimimos mensaje y respuesta y cerramos conexion
        }

        // evento para apagar  la maquina cuando se presiona el boton apagar
        private   void button_apagar_Click(object sender, EventArgs e)
        {
            response = " ";
            command = Apagar;// comando igual al valor de apagar

            try
            {
               conectar(); // nos conectamos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar comando: " + ex.Message);
            }

            imprimir(); // imprimimos la respuesta y el mensjae  y cerramos la conexion
        }

        //evento para abrir la boquilla del cabezal de la maquina

        private   void button_apertura_Click(object sender, EventArgs e)
        {
            response = " ";
            command = Apertura; // comando igual a apertura

            try
            {
               conectar();// nos conectamos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar comando: " + ex.Message);
            }

            imprimir(); // imprimimos el mensaje y la respuesta y cerramos la conexion
        }

        //metodo para cerrar la boquilla del cabezal cuando se presione el boton cierre
        private void button_Cierre_Click(object sender, EventArgs e)
        {
            response = " ";
            command = Cierre;// el comando es igual al cierre

            try
            {
               conectar();// nos conectamos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar comando: " + ex.Message);
            }

            imprimir();// imprimimosel mensaje y la respuesta y cerramos la conexion
        }

        // evento para comenzar la impresion al presionar el boton inicio
        private void button_inicio_Click(object sender, EventArgs e)
        {
            response = " ";
            command = Inicio; //comando es igual a inicio

            try
            {
                conectar(); // nos conectamos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar comando: " + ex.Message);
            }

            imprimir(); // nos conectamos e imprimimos y cerramos conexion
        }


        //evento para detener la impresion al presionar el boton paro
        private  void button_paro_Click(object sender, EventArgs e)
        {
            response = " ";
            command = Paro; // comandpo igual a impresion

            try
            {
              conectar(); // nos conectamos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar comando: " + ex.Message);
            }

            imprimir(); // imprimimos el mensja ey la respuesta y cerramos la conexion
        }

        private OperacionResult Operacion1(string X, string Y, string Z, string W)
        {
            if (int.TryParse(X, out int dtX) && int.TryParse(Y, out int dtY) && int.TryParse(Z, out int dtZ) && int.TryParse(W, out int dtW))
            {
                int Dist_I = dtY * 1000;
                int Dist_F = dtW * 1000;
                int Dist_T = dtX * 1000;
                int Constantetext = Convert.ToInt32((Tamcaracter) * 1000);
                //int Dist_job1 = Convert.ToInt32(Dist_I - (8 * 1000));
                int Dist_job1 = 0;
                int Dist_job2 = Dist_T - (Dist_I + Dist_F + Constantetext);

                // Retorna los valores encapsulados en una instancia de la clase
                return new OperacionResult
                {
                    ConstanteText = Constantetext,
                    DistF = Dist_F,
                    DistI = Dist_I,
                    DistJob2 = Dist_job2
                };
            }
            else
            {
                Console.WriteLine("No se pudo convertir uno o más valores a un entero.");
                return new OperacionResult
                {
                    ConstanteText = 0,
                    DistF = 0,
                    DistI = 0,
                    DistJob2 = 0
                }; // Retorna una instancia con valores predeterminados si hay un error
            }
        }

        public OperacionResult Operacion(string X, string Y, string Z, string W)
        {
            if (int.TryParse(X, out int dtX) && int.TryParse(Y, out int dtY) && int.TryParse(Z, out int dtZ) && int.TryParse(W, out int dtW))
            {
                int Dist_I = dtY * 1000;
                int Dist_F = dtW * 1000;
                int Dist_T = dtX * 1000;
                int Constantetext = Convert.ToInt32((Tamcaracter) * 1000);
                int Dist_M = (dtZ * 1000) + Constantetext;
                double Distancia_disponible = Dist_T - (Constantetext + Dist_I + Constantetext + Dist_F);
                double N_OBJ = Distancia_disponible / Dist_M;
                int resultadoRedondeado = Convert.ToInt32(Math.Floor(N_OBJ));
                double parteDecimal = (N_OBJ - resultadoRedondeado) * Dist_M;
                int residuo = Convert.ToInt32(parteDecimal);
                int Dist_job1 = Convert.ToInt32(Dist_I);
                int Dist_job2 = 0;

                if (resultadoRedondeado - 1 == 0)
                {
                    Dist_job2 = Dist_T - (Constantetext + Dist_F);
                }
                else
                {
                    Dist_job2 = Dist_T - ((Constantetext) + (Dist_M * (resultadoRedondeado - 1)) + Dist_F);
                }
                
                // Retorna los resultados encapsulados en una instancia de OperacionResult
                return new OperacionResult
                {
                    ResultadoRedondeado = resultadoRedondeado,
                    DistM = Dist_M,
                    DistJob1 = Dist_job1,
                    DistJob2 = Dist_job2
                };
            }
            else
            {
                Console.WriteLine("No se pudo convertir uno o más valores a un entero.");
                return new OperacionResult
                {
                    ResultadoRedondeado = 0,
                    DistM = 0,
                    DistJob1 = 0,
                    DistJob2 = 0
                };
            }
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

        public string SendCommand(string command)
{
    string response = ""; // Valor de la respuesta
    string error = ""; // Variable para almacenar el mensaje de error

    if (stream != null && client.Connected) // Verificamos que exista conexión
    {
        try
        {
            // Agrega un carácter de nueva línea al final del comando
            command += "\r\n";

            // Codificación de datos
            byte[] data = Encoding.GetEncoding("Shift-JIS").GetBytes(command);
            stream.Write(data, 0, data.Length); // Enviar datos al flujo

            StringBuilder completeMessage = new StringBuilder();
            int numberOfBytesRead = 0;
            var buffer = new byte[500];

            // Variable para manejar tiempo de espera
            var stopwatch = Stopwatch.StartNew();

            // Sigue leyendo hasta que no haya más datos disponibles o hasta que se alcance el límite de tiempo
            while (stream.DataAvailable || stopwatch.ElapsedMilliseconds < 500)
            {
                if (stream.DataAvailable)
                {
                    numberOfBytesRead = stream.Read(buffer, 0, buffer.Length);
                    completeMessage.Append(Encoding.GetEncoding("Shift-JIS").GetString(buffer, 0, numberOfBytesRead));
                }
            }

            response = completeMessage.ToString(); // Guardamos la respuesta leída
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

    return response; // Retornamos el valor de la respuesta
}

        /*//metodo para enviar un comando a la impresora
        public   Task<string> SendCommand(string command)
        {
            string response = ""; // valor de la respuesta
            string error = ""; // variable para almacenar el mensaje de error

            if (stream != null && client.Connected) // verificamos que exista conexion
            {
                //try
                //{
                // Agrega un carácter de nueva línea al final del comando
                command += "\r\n";

                byte[] data = Encoding.GetEncoding("Shift-JIS").GetBytes(command);
                await stream.Write (data, 0, data.Length);

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
                        numberOfBytesRead = await stream.Read (buffer, 0, buffer.Length);
                        completeMessage.AppendFormat("{0}", Encoding.GetEncoding("Shift-JIS").GetString(buffer, 0, numberOfBytesRead));
                    }
                }

                response = completeMessage.ToString();// guardamos la respuesta leida en rezponse y la convertimos en string
                                                      // }
                                                      // catch (Exception ex)
                                                      //{
                                                      //  error = "Error al enviar/recibir comando: " + ex.Message;
                                                      // }
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
        */
    }

    public class OperacionResult
    {
        public int ConstanteText { get; set; }
        public int DistF { get; set; }
        public int DistI { get; set; }
        public int DistJob2 { get; set; }
        public int ResultadoRedondeado { get; set; }
        public int DistM { get; set; }
        public int DistJob1 { get; set; }
        
    }
}





