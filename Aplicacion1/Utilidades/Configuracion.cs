using System;
using System.IO;
using System.Xml;

namespace Trapid.Utilidades
{
    internal class Configuracion
    {
        // Ruta del archivo de configuración en AppData
        private static readonly string ConfigFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "configuracion.xml");

        public static void CargarConfiguracion()
        {
            try
            {
                if (File.Exists(ConfigFilePath))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(ConfigFilePath);

                    XmlNode root = doc.DocumentElement;
                    if (root != null)
                    {
                        MiConfig.IP = root.SelectSingleNode("IP")?.InnerText ?? "";
                        MiConfig.Puerto = root.SelectSingleNode("Puerto")?.InnerText ?? "";
                        MiConfig.Ruta = root.SelectSingleNode("Ruta")?.InnerText ?? "";
                        MiConfig.Nombre_archivo = root.SelectSingleNode("Nombre_archivo")?.InnerText ?? "";
                        MiConfig.Matriz = root.SelectSingleNode("Matriz")?.InnerText ?? "";
                        MiConfig.Altura = root.SelectSingleNode("Altura")?.InnerText ?? "";
                        MiConfig.Modo = root.SelectSingleNode("Modo")?.InnerText ?? "";
                        MiConfig.Ancho = root.SelectSingleNode("Ancho")?.InnerText ?? "";
                        MiConfig.espejo = root.SelectSingleNode("Espejo")?.InnerText ?? "";
                        MiConfig.resolucion = root.SelectSingleNode("Resolucion")?.InnerText ?? "";
                        MiConfig.orientacion = root.SelectSingleNode("Orientacion")?.InnerText ?? "";
                        MiConfig.señalgo = root.SelectSingleNode("Senalgo")?.InnerText ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la configuración: " + ex.Message);
            }
        }

        public static void GuardarConfiguracion()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("Configuracion");

                root.AppendChild(CreateElement(doc, "IP", MiConfig.IP));
                root.AppendChild(CreateElement(doc, "Puerto", MiConfig.Puerto));
                root.AppendChild(CreateElement(doc, "Ruta", MiConfig.Ruta));
                root.AppendChild(CreateElement(doc, "Nombre_archivo", MiConfig.Nombre_archivo));
                root.AppendChild(CreateElement(doc, "Matriz", MiConfig.Matriz));
                root.AppendChild(CreateElement(doc, "Altura", MiConfig.Altura));
                root.AppendChild(CreateElement(doc, "Modo", MiConfig.Modo));
                root.AppendChild(CreateElement(doc, "Ancho", MiConfig.Ancho));
                root.AppendChild(CreateElement(doc, "Espejo", MiConfig.espejo));
                root.AppendChild(CreateElement(doc, "Resolucion", MiConfig.resolucion));
                root.AppendChild(CreateElement(doc, "Orientacion", MiConfig.orientacion));
                root.AppendChild(CreateElement(doc, "Senalgo", MiConfig.señalgo));

                doc.AppendChild(root);
                doc.Save(ConfigFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar la configuración: " + ex.Message);
            }
        }

        private static XmlElement CreateElement(XmlDocument doc, string name, string value)
        {
            XmlElement element = doc.CreateElement(name);
            element.InnerText = value;
            return element;
        }
    }

    static class MiConfig
    {
        private static string _ip = "";
        private static string _puerto = "";
        private static string _ruta = "";
        private static string _nombreArchivo = "";
        private static string _matriz = "";
        private static string _altura = "";
        private static string _modo = "";
        private static string _ancho = "";
        private static string _espejo = "";
        private static string _resolucion = "";
        private static string _orientacion = "";
        private static string _senalgo = "";

        public static string IP { get { return _ip; } set { _ip = value; } }
        public static string Puerto { get { return _puerto; } set { _puerto = value; } }
        public static string Ruta { get { return _ruta; } set { _ruta = value; } }
        public static string Nombre_archivo { get { return _nombreArchivo; } set { _nombreArchivo = value; } }
        public static string Matriz { get { return _matriz; } set { _matriz = value; } }
        public static string Altura { get { return _altura; } set { _altura = value; } }
        public static string Modo { get { return _modo; } set { _modo = value; } }
        public static string Ancho { get { return _ancho; } set { _ancho = value; } }
        public static string espejo { get { return _espejo; } set { _espejo = value; } }
        public static string resolucion { get { return _resolucion; } set { _resolucion = value; } }
        public static string orientacion { get { return _orientacion; } set { _orientacion = value; } }
        public static string señalgo { get { return _senalgo; } set { _senalgo = value; } }
    }
}

/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Trapid.Utilidades
{
    internal class Configuracion
    {
        public static void cargarConfiguracion()
        {          

            // Cargar configuración
            MiConfig.IP = Properties.Settings.Default.IP;
            MiConfig.Ruta = Properties.Settings.Default.Ruta;
            MiConfig.Puerto = Properties.Settings.Default.Puerto;
            MiConfig.Nombre_archivo = Properties.Settings.Default.Nombre_archivo;
            MiConfig.Matriz = Properties.Settings.Default.Matriz;
            MiConfig.Altura = Properties.Settings.Default.Altura;
            MiConfig.Modo = Properties.Settings.Default.Modo;
            MiConfig.Ancho = Properties.Settings.Default.Ancho;
            MiConfig.espejo = Properties.Settings.Default.espejo;
            MiConfig.resolucion = Properties.Settings.Default.resolucion;
            MiConfig.orientacion = Properties.Settings.Default.orientacion;
            MiConfig.señalgo = Properties.Settings.Default.señalgo;
        }

        public static void GuardarConfiguracion()
        {
            // Guardar configuración
            Properties.Settings.Default.IP = MiConfig.IP;
            Properties.Settings.Default.Ruta = MiConfig.Ruta;
            Properties.Settings.Default.Puerto = MiConfig.Puerto;
            Properties.Settings.Default.Nombre_archivo = MiConfig.Nombre_archivo;
            Properties.Settings.Default.Matriz = MiConfig.Matriz;
            Properties.Settings.Default.Altura = MiConfig.Altura;
            Properties.Settings.Default.Modo = MiConfig.Modo;
            Properties.Settings.Default.Ancho = MiConfig.Ancho;
            Properties.Settings.Default.espejo = MiConfig.espejo;
            Properties.Settings.Default.resolucion= MiConfig.resolucion;
            Properties.Settings.Default.orientacion = MiConfig.orientacion;
            Properties.Settings.Default.señalgo = MiConfig.señalgo;
            //Properties.Settings.Default.Save();


        }
    }

    static class MiConfig
    {
        public static string IP { get; set; } = "";
        public static string Puerto { get; set; } = "";
        public static string Ruta { get; set; } = "";
        public static string Nombre_archivo { get; set; } = "";
        public static string Matriz { get; set; } = "";
        public static string Altura { get; set; } = "";
        public static string Modo { get; set; } = "";
        public static string Ancho { get; set; } = "";
        public static string espejo { get; set; } = "";
        public static string resolucion { get; set; } = "";
        public static string orientacion { get; set; } = "";
        public static string señalgo { get; set; } = "";
    }
}
*/