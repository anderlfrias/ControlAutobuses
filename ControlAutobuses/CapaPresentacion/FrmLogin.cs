using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (TxtUser.Text == "Usuario")
                TxtUser.Clear();
        }

        private void TxtUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUser.Text))
                TxtUser.Text = "Usuario";
        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (TxtPass.Text == "Contraseña")
            {
                TxtPass.Clear();
                TxtPass.PasswordChar = '*';
            }
        }

        private void TxtPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPass.Text))
            {
                TxtPass.UseSystemPasswordChar = false;
                TxtPass.Text = "Contraseña";
            }
        }
    }
}
