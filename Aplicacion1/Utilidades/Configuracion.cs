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
            MiConfig.Telefono = Properties.Settings.Default.telefono;
            MiConfig.Puerto = Properties.Settings.Default.Puerto;
        }

        public static void GuardarConfiguracion()
        {
            // Guardar configuración
            Properties.Settings.Default.IP = MiConfig.IP;
            Properties.Settings.Default.telefono = MiConfig.Telefono;
            Properties.Settings.Default.Puerto = MiConfig.Puerto;
            Properties.Settings.Default.Save();

           
        }
    }

    static class MiConfig
    {
        public static string IP { get; set; } = "";
        public static string Puerto { get; set; } = "";
        public static string Telefono { get; set; } = "";
    }
}
