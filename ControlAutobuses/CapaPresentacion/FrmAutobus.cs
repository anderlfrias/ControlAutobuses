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
    public partial class FrmAutobus : Form
    {
        readonly AutobusNegocio _autobusNegocio;
        public FrmAutobus()
        {
            InitializeComponent();
            _autobusNegocio = new AutobusNegocio();
            MostrarAutobuses();
        }

        private void MostrarAutobuses(string filtro = "")
        {
            dgvAutobuses.DataSource = _autobusNegocio.Get(filtro);
        }
    }
}
