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
        public FrmUsuarios()
        {
            InitializeComponent();
            _userNegocio = new UserNegocio();
            FirstActions();
        }

        //Metodos
        private void FirstActions()
        {
            MostrarUsuarios();
            VisibilidadTabla();
        }

        private void MostrarUsuarios()
        {
            dtgUsuarios.DataSource = _userNegocio.DisplayUsers();
        }

        private void VisibilidadTabla()
        {
            dtgUsuarios.Columns[0].Visible = false;
            dtgUsuarios.Columns[4].Visible = false;

            dtgUsuarios.Columns[1].Width = 100;
            dtgUsuarios.Columns[2].Width = 180;
            dtgUsuarios.Columns[3].Width = 100;
            dtgUsuarios.Columns[5].Width = 60;
        }

        private void dtgUsuarios_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            for (int i = 1; i <=5; i++)
            {
                MessageBox.Show(dtgUsuarios.Columns[i].Width.ToString());
            }
        }
    }
}
