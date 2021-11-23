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

        //Metodos
        private bool ValidarCampos()
        {
            bool validation = true;
            if ((string.IsNullOrEmpty(TxtUser.Text)) || (TxtUser.Text == "Usuario"))
                validation = false;
            if ((string.IsNullOrEmpty(TxtPass.Text)) || (TxtPass.Text == "Contraseña"))
                validation = false;

            return validation;
        }

        private void Limpiar()
        {
            TxtUser.Text = "Usuario";
            TxtPass.UseSystemPasswordChar = false;
            TxtPass.Text = "Contraseña";
        }

        //Encriptar Contraseña
        private string EncryptPassword(string password)
        {
            string result = string.Empty;
            byte[] encryted = Encoding.Unicode.GetBytes(password);
            result = Convert.ToBase64String(encryted);

            return result;
        }

        //Desencriptar Contraseña
        private string DecryptPassword(string password)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(password);
            result = Encoding.Unicode.GetString(decryted);

            return result;
        }

        //Eventos
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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                MessageBox.Show("Asegurese de completar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Limpiar();
            }
            else
            {
                TxtUser.Text = DecryptPassword("MQAyADMANAA=");
                MessageBox.Show(EncryptPassword(TxtUser.Text));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
