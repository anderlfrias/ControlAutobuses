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
    public partial class FrmInformes : Form
    {
        readonly ViajesNegocio _viajesNegocio;
        public FrmInformes()
        {
            InitializeComponent();
            _viajesNegocio = new ViajesNegocio();
            MostarViajes();
        }

        private void MostarViajes()
        {
            dtgViajes.DataSource = _viajesNegocio.GetViajes();
        }
    }
}
