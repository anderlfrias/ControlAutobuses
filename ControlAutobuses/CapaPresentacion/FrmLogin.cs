using CapaEntidades;
using CapaNegocio;
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
        readonly UserNegocio _userNegocio;
        User _user;

        public FrmLogin()
        {
            InitializeComponent();
            _userNegocio = new UserNegocio();
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

        private bool VerificarUsuario(string userName)
        {
            _user = _userNegocio.GetByUserName(userName);

            if (_user == null)
                return false;

            return true;
        }

        private bool VerificarPassword(string password)
        {
            //MessageBox.Show(password, "Password de la base de datos");
            string passDb = DecryptPassword(password);
            //MessageBox.Show(passDb, "Password desencriptada");

            if (TxtPass.Text == passDb)
                return true;

            return false;
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
                if (VerificarUsuario(TxtUser.Text))
                {
                    if (VerificarPassword(_user.Password))
                    {
                        //Abrir form aqui
                        FrmPrinpal frmPrinpal = new FrmPrinpal(_user.Id);
                        this.Visible = false;
                        frmPrinpal.Show();
                        //MessageBox.Show("Usuario y contraseña correctos", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Contraseña Incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TxtPass.Clear();
                        TxtPass.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LnkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegistro frmRegistro = new FrmRegistro();
            this.Visible = false;
            frmRegistro.Show();
        }
    }
}
