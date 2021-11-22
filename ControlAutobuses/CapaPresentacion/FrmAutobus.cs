using CapaEntidades;
using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmAutobus : Form
    {
        readonly AutobusNegocio _autobusNegocio;
        Autobus _autobus;
        bool toEdit;
        public FrmAutobus()
        {
            InitializeComponent();
            _autobusNegocio = new AutobusNegocio();
            FirstActions();
        }

        //Metodos
        private void FirstActions()
        {
            toEdit = false;
            txtCodigo.ReadOnly = true;
            txtCodigo.BackColor = Color.White;
            MostrarAutobuses();
            VisibilidadTabla();
        }

        private void MostrarAutobuses(string filtro = "")
        {
            dgvAutobuses.DataSource = _autobusNegocio.Get(filtro);
        }

        private void VisibilidadTabla()
        {
            dgvAutobuses.Columns[0].Visible = false;
            dgvAutobuses.Columns[1].Width = 80;
            dgvAutobuses.Columns[2].Width = 80;
            dgvAutobuses.Columns[3].Width = 95;
            dgvAutobuses.Columns[4].Width = 90;
            dgvAutobuses.Columns[5].Width = 75;
            dgvAutobuses.Columns[6].Width = 60;
            dgvAutobuses.Columns[7].Width = 82;
            dgvAutobuses.ClearSelection();
        }

        private void CrearAutobus()
        {
            _autobus = new Autobus();
            _autobus.Marca = txtMarca.Text;
            _autobus.Modelo = txtModelo.Text;
            _autobus.Placa = txtPlaca.Text;
            _autobus.Color = txtColor.Text;
            _autobus.Anio = Convert.ToInt32(txtAnio.Text);

            var result = _autobusNegocio.Create(_autobus);

            MessageBox.Show(result, "Information");
            Limpiar();
            MostrarAutobuses();
        }

        private void EditarAutobus()
        {
            _autobus = new Autobus();
            _autobus.Id = dgvAutobuses.CurrentRow.Cells[0].Value.ToString();
            _autobus.Marca = txtMarca.Text;
            _autobus.Modelo = txtModelo.Text;
            _autobus.Placa = txtPlaca.Text;
            _autobus.Color = txtColor.Text;
            _autobus.Anio = Convert.ToInt32(txtAnio.Text);
            _autobus.Asignado = false;

            var result = _autobusNegocio.Update(_autobus);

            MessageBox.Show(result, "Information");
            Limpiar();
            MostrarAutobuses();
        }

        private void EliminarAutobus()
        {
            string Id = dgvAutobuses.CurrentRow.Cells[0].Value.ToString();

            var result = _autobusNegocio.Delete(Id);

            MessageBox.Show(result, "Information");
            Limpiar();
            MostrarAutobuses();
        }

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtColor.Clear();
            txtPlaca.Clear();
            txtAnio.Clear();
            txtBuscar.Text = "Buscar:";
            txtMarca.Focus();
        }

        //Eventos
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "Buscar:")
                MostrarAutobuses(txtBuscar.Text);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBuscar.Text == "Buscar:")
                txtBuscar.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (toEdit)
                EditarAutobus();
            else
                CrearAutobus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAutobuses.SelectedRows.Count > 0)
            {
                txtCodigo.Text = dgvAutobuses.CurrentRow.Cells[1].Value.ToString();
                txtMarca.Text = dgvAutobuses.CurrentRow.Cells[2].Value.ToString();
                txtModelo.Text = dgvAutobuses.CurrentRow.Cells[3].Value.ToString();
                txtPlaca.Text = dgvAutobuses.CurrentRow.Cells[4].Value.ToString();
                txtColor.Text = dgvAutobuses.CurrentRow.Cells[5].Value.ToString();
                txtAnio.Text = dgvAutobuses.CurrentRow.Cells[6].Value.ToString();
                toEdit = true;
            }
            else
            {
                MessageBox.Show("Selecione el autobus a editar.", "Information");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAutobuses.SelectedRows.Count > 0)
                EliminarAutobus();
            else
                MessageBox.Show("Seleccione el autobus que desea eliminar", "Information");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
