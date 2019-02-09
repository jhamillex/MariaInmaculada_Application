using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace Inmaculada
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmUsuario_IniciarSesion());
            if (mdlVariables.ElUsuarioConectado != null)
            {
                Application.Run(new frmPrincipal());
            }
        }
    }
}
