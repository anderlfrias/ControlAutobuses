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
    public partial class FrmUsuarios : Form
    {
        readonly UserNegocio _userNegocio;
        readonly RoleNegocio _roleNegocio;

        IList<DisplayRoles> lstRoles;

        string roleId;
        string userId;

        public FrmUsuarios()
        {
            InitializeComponent();
            _userNegocio = new UserNegocio();
            _roleNegocio = new RoleNegocio();
            FirstActions();
        }

        //Metodos
        private void FirstActions()
        {
            MostrarUsuarios();
        }

        private void MostrarUsuarios()
        {
            dtgUsuarios.DataSource = _userNegocio.DisplayUsers();
            VisibilidadTabla();
        }

        private void VisibilidadTabla()
        {
            dtgUsuarios.Columns[0].Visible = false;
            dtgUsuarios.Columns[4].Visible = false;
            dtgUsuarios.Columns[5].Visible = false;

            dtgUsuarios.Columns[1].Width = 100;
            dtgUsuarios.Columns[2].Width = 180;
            dtgUsuarios.Columns[3].Width = 150;
            dtgUsuarios.Columns[6].Width = 140;

            dtgUsuarios.AllowUserToResizeColumns = false;
            dtgUsuarios.AllowUserToResizeRows = false;
        }

        private void DisplayRoles()
        {
            cboRoles.Items.Clear();
            lstRoles = new List<DisplayRoles>();
            var roles = _roleNegocio.Get();
            cboRoles.Items.Add("Roles...");
            foreach (var item in roles)
            {
                cboRoles.Items.Add(item.NombreNormal);
                cboRoles.SelectedItem = item.NombreNormal;
                lstRoles.Add(new DisplayRoles
                {
                    Id = item.Id,
                    Index = cboRoles.SelectedIndex
                });
            }
            cboRoles.SelectedIndex = 0;
        }

        private void RellenarCampos()
        {
            txtCodigo.Text = dtgUsuarios.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dtgUsuarios.CurrentRow.Cells[2].Value.ToString();
            txtUsuario.Text = dtgUsuarios.CurrentRow.Cells[3].Value.ToString();
            DisplayRoles();
            cboRoles.SelectedItem = dtgUsuarios.CurrentRow.Cells[6].Value.ToString();
        }

        private void Guardar()
        {
            MessageBox.Show(_userNegocio.ChangeRole(userId, roleId),
                "Informacion",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        
        private void Limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtUsuario.Clear();
            cboRoles.Items.Clear();
        }
        
        //Eventos
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cboRoles.SelectedIndex != 0)
                RellenarCampos();
            else
                MessageBox.Show("Selecione el usuario que desea editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRoles.SelectedIndex != 0)
            {
                foreach (var item in lstRoles)
                {
                    if (item.Index == cboRoles.SelectedIndex)
                    {
                        roleId = item.Id;
                        userId = dtgUsuarios.CurrentRow.Cells[0].Value.ToString();
                        //MessageBox.Show(roleId, "Role Id");
                        //MessageBox.Show(userId, "User Id");
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            MostrarUsuarios();
            Limpiar();
        }
    }

    class DisplayRoles : Role
    {
        public int Index { get; set; }
    }
}
