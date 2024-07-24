using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion1.Utilidades
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
            Properties.Settings.Default.Save();


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
    }
}
