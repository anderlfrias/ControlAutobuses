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
    public partial class FrmRuta : Form
    {
        readonly RutaNegocio _rutaNegocio;
        Ruta _ruta;
        bool toEdit;
        string id;
        public FrmRuta()
        {
            InitializeComponent();
            _rutaNegocio = new RutaNegocio();
            FirstActions();
        }

        //Metodos
        private void FirstActions()
        {
            toEdit = false;
            txtCodigo.ReadOnly = true;
            txtCodigo.BackColor = Color.White;
            MostrarRutas();
            VisibilidadTabla();
        }

        private void MostrarRutas(string filtro = "")
        {
            dgvRutas.DataSource = _rutaNegocio.Get(filtro); ;
        }

        private void VisibilidadTabla()
        {
            dgvRutas.Columns[0].Visible = false;
            dgvRutas.Columns[1].Width = 90;
            dgvRutas.Columns[2].Width = 105;
            dgvRutas.Columns[3].Width = 305;
            dgvRutas.Columns[4].Width = 70;

            dgvRutas.AllowUserToResizeColumns = false;
            dgvRutas.AllowUserToResizeRows = false;

            dgvRutas.ClearSelection();
        }

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtBuscar.Text = "Buscar:";
            txtNombre.Focus();
        }

        private void Guardar()
        {
            _ruta = new Ruta();
            _ruta.Nombre = txtNombre.Text;
            _ruta.Descripcion = txtDescripcion.Text;

            var result = _rutaNegocio.Create(_ruta);

            MessageBox.Show(result, "Information");
            Limpiar();
            MostrarRutas();
        }

        private void Editar()
        {
            _ruta = new Ruta();
            _ruta.Id = id;
            _ruta.Nombre = txtNombre.Text;
            _ruta.Descripcion = txtDescripcion.Text;
            _ruta.Asignado = false;

            var result = _rutaNegocio.Update(_ruta);

            MessageBox.Show(result, "Information");
            Limpiar();
            MostrarRutas();
        }

        private void Eliminar()
        {
            id = dgvRutas.CurrentRow.Cells[0].Value.ToString();

            var result = _rutaNegocio.Delete(id);

            MessageBox.Show(result, "Information");
            Limpiar();
            MostrarRutas();
        }

        //Eventos
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "Buscar:")
                MostrarRutas(txtBuscar.Text);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBuscar.Text == "Buscar:")
                txtBuscar.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedRows.Count > 0)
            {
                id = dgvRutas.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = dgvRutas.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgvRutas.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = dgvRutas.CurrentRow.Cells[3].Value.ToString();
                toEdit = true;
            }
            else
            {
                MessageBox.Show("Selecione la ruta a editar.", "Information");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!toEdit)
                Guardar();
            else
                Editar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedRows.Count > 0)
                Eliminar(); 
            else
                MessageBox.Show("Seleccione el autobus que desea eliminar", "Information");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
