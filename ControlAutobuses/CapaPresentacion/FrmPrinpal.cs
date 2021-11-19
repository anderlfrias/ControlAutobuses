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
    public partial class FrmPrinpal : Form
    {
        readonly AutobusNegocio _autobusNegocio;
        readonly ChoferNegocio _choferNegocio;
        readonly RutaNegocio _rutaNegocio;
        public FrmPrinpal()
        {
            InitializeComponent();
            _autobusNegocio = new AutobusNegocio();
            _choferNegocio = new ChoferNegocio();
            _rutaNegocio = new RutaNegocio();
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            dgvPrueba.DataSource = _choferNegocio.Get();
        }
    }
}
