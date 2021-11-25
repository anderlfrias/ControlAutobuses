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
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        //Eventos
        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtNombre.Text == "Nombre")
                txtNombre.Clear();
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
                txtNombre.Text = "Nombre";

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
                TxtPass.UseSystemPasswordChar = true;
                TxtPass.Clear();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            this.Close();
            login.Visible = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            this.Close();
            login.Visible = true;
        }
    }
}
