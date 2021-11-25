using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPrinpal : Form
    {
        readonly UserNegocio _userNegocio;
        private Form formulario;
        private string _idUsuario;

        public FrmPrinpal(string idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _userNegocio = new UserNegocio();
        }

        //Metodos
        private void OpenForm(Form form)
        {                                                                                 //si el formulario/instancia no existe
            if (formulario != null)
            {
                formulario.Close();
            }
            formulario = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(form);
            pnlContenedor.Tag = form;
            form.Show();
            form.BringToFront();
            
        }

        private string DisplayUserRole()
        {
            var result = _userNegocio.GetById(_idUsuario);

            if (result == null)
                return "Usuario no encontrado";

            return result.Role;
        }

        //Eventos
        private void btnAutobuses_Click(object sender, EventArgs e)
        {
            if (DisplayUserRole() == "admin")
            {
                OpenForm(new FrmAutobus());
            }
            else
            {
                MessageBox.Show("No tienes los permisos  necesarios\n" +
                    "para abrir este formulario",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        
        private void btnRutas_Click(object sender, EventArgs e)
        {
            if (DisplayUserRole() == "admin")
            {
                OpenForm(new FrmRuta());
            }
            else
            {
                MessageBox.Show("No tienes los permisos  necesarios\n" +
                    "para abrir este formulario",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnChoferes_Click(object sender, EventArgs e)
        {
            if (DisplayUserRole() == "admin")
            {
                OpenForm(new FrmChoferes());
            }
            else
            {
                MessageBox.Show("No tienes los permisos  necesarios\n" +
                    "para abrir este formulario",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            };
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (formulario != null)
                formulario.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            this.Close();
            login.Visible = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlador_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
