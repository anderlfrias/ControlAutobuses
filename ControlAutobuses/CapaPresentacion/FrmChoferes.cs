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
    public partial class FrmChoferes : Form
    {
        readonly ChoferNegocio _chofereNegocio;
        Chofer _chofer;
        string id;
        bool toEdit;
        public FrmChoferes()
        {
            InitializeComponent();
            _chofereNegocio = new ChoferNegocio();
            FirstActions();
        }

        //Metodos
        private void FirstActions()
        {
            MostrarChoferes();
            txtCodigo.ReadOnly = true;
            txtCodigo.BackColor = Color.White;
            toEdit = false;
        }

        private void MostrarChoferes(string filtro = "")
        {
            dgvChoferes.DataSource = _chofereNegocio.Get(filtro);
            VisibilidadTabla();
        }

        private void VisibilidadTabla()
        {
            dgvChoferes.Columns[0].Visible = false;
            dgvChoferes.Columns[6].Visible = false;
            dgvChoferes.Columns[7].Visible = false;

            dgvChoferes.Columns[1].Width = 100;
            dgvChoferes.Columns[2].Width = 110;
            dgvChoferes.Columns[3].Width = 120;
            dgvChoferes.Columns[4].Width = 120;
            dgvChoferes.Columns[5].Width = 120;

            dgvChoferes.ClearSelection();
        }

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            dtpBirthDay.Value = DateTime.Parse("1/1/1753");
            txtBuscar.Text = "Buscar:";
        }

        private void Guardar()
        {
            _chofer = new Chofer();
            _chofer.Nombre = txtNombre.Text;
            _chofer.Apellido = txtApellido.Text;
            _chofer.Cedula = txtCedula.Text;
            _chofer.BirthDay = dtpBirthDay.Value;

            var result =_chofereNegocio.Create(_chofer);

            MessageBox.Show(result, "Information");
            Limpiar();
            MostrarChoferes();
        }

        private void Editar()
        {
            _chofer = new Chofer();
            _chofer.Id = id;
            _chofer.Nombre = txtNombre.Text;
            _chofer.Apellido = txtApellido.Text;
            _chofer.BirthDay = dtpBirthDay.Value;
            _chofer.Cedula = txtCedula.Text;

            var result = _chofereNegocio.Update(_chofer);

            MessageBox.Show(result, "Information");
            Limpiar();
            MostrarChoferes();
        }

        private void Eliminar()
        {
            var result = _chofereNegocio.Delete(id);

            MessageBox.Show(result, "Information");
            Limpiar();
            MostrarChoferes();
        }

        //Eventos
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (toEdit)
                Editar();
            else
                Guardar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvChoferes.SelectedRows.Count > 0)
            {
                id = dgvChoferes.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = dgvChoferes.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgvChoferes.CurrentRow.Cells[2].Value.ToString();
                txtApellido.Text = dgvChoferes.CurrentRow.Cells[3].Value.ToString();
                txtCedula.Text = dgvChoferes.CurrentRow.Cells[5].Value.ToString();
                dtpBirthDay.Value = Convert.ToDateTime(dgvChoferes.CurrentRow.Cells[4].Value.ToString());
                toEdit = true;
            }
            else
            {
                MessageBox.Show("Selecione la ruta a editar.", "Information");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            id = dgvChoferes.CurrentRow.Cells[0].Value.ToString();
            Eliminar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "Buscar:")
                MostrarChoferes(txtBuscar.Text);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBuscar.Text == "Buscar:")
                txtBuscar.Text = "";
        }
    }
}
