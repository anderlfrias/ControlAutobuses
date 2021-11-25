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
    public partial class FrmRegistro : Form
    {
        readonly UserNegocio _userNegocio;
        readonly RoleNegocio _roleNegocio;
        User _user;

        public FrmRegistro()
        {
            InitializeComponent();
            _userNegocio = new UserNegocio();
            _roleNegocio = new RoleNegocio();
        }

        //Metodos
        private bool ValidarCampos()
        {
            if ((string.IsNullOrEmpty(txtNombre.Text)) || (txtNombre.Text == "Nombre"))
                return false;
            else if ((string.IsNullOrEmpty(TxtUser.Text)) || (TxtUser.Text == "Usuario"))
                return false;
            else if ((string.IsNullOrEmpty(TxtPass.Text)) || (TxtPass.Text == "Contraseña"))
                return false;
            else
                return true;
        }

        private string RegistrarUsuario(string nombre, string userName, string password)
        {
            _user = new User();
            _user.Nombre = nombre;
            _user.Usuario = userName;
            _user.Password = EncryptPassword(password);
            _user.RoleId = DefaultRole();

            var result = _userNegocio.Create(_user);
            return result;
        }

        //Encriptar Contraseña
        private string EncryptPassword(string password)
        {
            string result = string.Empty;
            byte[] encryted = Encoding.Unicode.GetBytes(password);
            result = Convert.ToBase64String(encryted);

            return result;
        }

        //Obtener el role por defecto cada vez que se ingrese un usuario
        private string DefaultRole()
        {
            var result = _roleNegocio.GetByRoleName("user");
            return result.Id;
        }

        private void Cerrar()
        {
            FrmLogin login = new FrmLogin();
            this.Close();
            login.Visible = true;
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
            Cerrar();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var res = RegistrarUsuario(txtNombre.Text, TxtUser.Text, TxtPass.Text);
                MessageBox.Show(res,
                                "Informacion de Registro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                if (res == "Registro exitoso")
                    Cerrar();
            }
            else
            {
                MessageBox.Show("Asegurese de competar todos los campos.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }
}
