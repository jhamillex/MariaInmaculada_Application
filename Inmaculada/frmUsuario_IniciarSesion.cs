using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace Inmaculada
{
    public partial class frmUsuario_IniciarSesion : Form
    {
        public frmUsuario_IniciarSesion()
        {
            InitializeComponent();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //validacion de usuario y clave
            mdlVariables.ElUsuarioConectado = clsUsuario.ValidarCredenciales(txtUsuario.Text, txtClave.Text);
            if (mdlVariables.ElUsuarioConectado == null)
            {
                MessageBox.Show("usuario o clave invalida");
            }
            else
            {
                Close();
            }
        }

    }
}
