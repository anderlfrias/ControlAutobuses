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
    public partial class FrmInformes : Form
    {
        readonly ViajesNegocio _viajesNegocio;
        readonly AutobusNegocio _autobusNegocio;
        readonly ChoferNegocio _choferNegocio;
        readonly RutaNegocio _rutaNegocio;

        IList<DisplayChoferes> _Choferes;
        IList<DisplayAutobuses> _Autobuses;
        IList<DisplayRutas> _Rutas;

        string _idAutobus = string.Empty;
        string _idRuta = string.Empty;
        string _idChofer = string.Empty;

        public FrmInformes()
        {
            InitializeComponent();
            _viajesNegocio = new ViajesNegocio();
            _autobusNegocio = new AutobusNegocio();
            _choferNegocio = new ChoferNegocio();
            _rutaNegocio = new RutaNegocio();
            FirstActions();
        }
        
        //Metodos
        private void FirstActions()
        {
            MostarViajes();
            DisplayChoferes();
            DisplayAutobuses();
            DisplayRutas();
        }

        private void MostarViajes()
        {
            dtgViajes.DataSource = _viajesNegocio.GetViajes();
            VisibilidadTabla();
        }

        private void VisibilidadTabla()
        {
            dtgViajes.Columns[0].Visible = false;
            dtgViajes.Columns[1].Visible = false;
            dtgViajes.Columns[2].Visible = false;

            dtgViajes.Columns[3].Width = 125;
            dtgViajes.Columns[4].Width = 110;
            dtgViajes.Columns[5].Width = 150;
            dtgViajes.Columns[6].Width = 110;
            dtgViajes.Columns[7].Width = 95;

            dtgViajes.ClearSelection();
        }


        private void DisplayChoferes()
        {
            cboChoferes.Items.Clear();
            _Choferes = new List<DisplayChoferes>();
            var choferes = _choferNegocio.GetAvailable();
            cboChoferes.Items.Add("Choferes disponibles...");
            foreach (var item in choferes)
            {
                cboChoferes.Items.Add($"{item.Nombre} {item.Apellido}  -  {item.Codigo}");
                cboChoferes.SelectedItem = $"{item.Nombre} {item.Apellido}  -  {item.Codigo}";
                _Choferes.Add(new DisplayChoferes
                {
                    Index = cboChoferes.SelectedIndex,
                    Id = item.Id
                });
            }
            cboChoferes.SelectedIndex = 0;
        }

        private void DisplayAutobuses()
        {
            cboAutobuses.Items.Clear();
            _Autobuses = new List<DisplayAutobuses>();
            var autobuses = _autobusNegocio.GetAvailable();
            cboAutobuses.Items.Add("Autobuses disponibles...");
            foreach (var item in autobuses)
            {
                cboAutobuses.Items.Add($"{item.Marca} {item.Modelo} - {item.Placa}");
                cboAutobuses.SelectedItem = $"{item.Marca} {item.Modelo} - {item.Placa}";
                _Autobuses.Add(new DisplayAutobuses
                {
                    Index = cboAutobuses.SelectedIndex,
                    Id = item.Id
                });
            }
            cboAutobuses.SelectedIndex = 0;
        }

        private void DisplayRutas()
        {
            cboRutas.Items.Clear();
            _Rutas = new List<DisplayRutas>();
            var rutas = _rutaNegocio.GetAvailable();
            cboRutas.Items.Add("Rutas disponibles...");
            foreach (var item in rutas)
            {
                cboRutas.Items.Add(item.Nombre);
                cboRutas.SelectedItem = item.Nombre;
                _Rutas.Add(new DisplayRutas
                {
                    Index = cboRutas.SelectedIndex,
                    Id = item.Id
                });
            }
            cboRutas.SelectedIndex = 0;
        }

        
        private bool ModificarAutobus(string id)
        {
            var autobus = _autobusNegocio.GetById(id);

            autobus.Asignado = true;
            
            var result = _autobusNegocio.Update(autobus);

            if (result == "Operacion exitosa")
                return true;
            else
                return false;
        }

        private bool ModificarChofer(string idChofer, string idAutobus, string idRuta)
        {
            var result = _choferNegocio.Assign(idChofer, idAutobus, idRuta);

            if (result == "Asignacion correcta")
                return true;
            else
                return false;
        }

        private bool ModificarRuta(string id)
        {
            var ruta = _rutaNegocio.GetById(id);

            ruta.Asignado = true;
            var result = _rutaNegocio.Update(ruta);

            if (result == "Operacion exitosa")
                return true;
            else
                return false;
        }

        private void AgregarViaje()
        {
            if (!ModificarChofer(_idChofer, _idAutobus, _idRuta))
                MessageBox.Show("Error al intentar vincular el chofer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!ModificarAutobus(_idAutobus))
                MessageBox.Show("Error al intentar vincular el autobus", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!ModificarRuta(_idRuta))
                MessageBox.Show("Error al intentar vincular la ruta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Asignacion exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            FirstActions();
        }

        //Eventos
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboAutobuses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAutobuses.SelectedIndex != 0)
            {
                foreach (var item in _Autobuses)
                {
                    if (item.Index == cboAutobuses.SelectedIndex)
                    {
                        //MessageBox.Show(item.Id);
                        _idAutobus = item.Id;
                    }
                }

            }
        }

        private void cboChoferes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChoferes.SelectedIndex != 0)
            {
                foreach (var item in _Choferes)
                {
                    if (item.Index == cboChoferes.SelectedIndex)
                    {
                        //MessageBox.Show(item.Id);
                        _idChofer = item.Id;
                    }
                }
            }
        }

        private void cboRutas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRutas.SelectedIndex != 0)
            {
                foreach (var item in _Rutas)
                {
                    if (item.Index == cboRutas.SelectedIndex)
                    {
                        //MessageBox.Show(item.Id);
                        _idRuta = item.Id;
                    }
                }
            }
        }

        private void btnAgregarViaje_Click(object sender, EventArgs e)
        {
            if (cboChoferes.SelectedIndex == 0)
                MessageBox.Show("Seleccion invalida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (cboAutobuses.SelectedIndex == 0)
                MessageBox.Show("Seleccion invalida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (cboRutas.SelectedIndex == 0)
                MessageBox.Show("Seleccion invalida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                AgregarViaje();
        }
    }

    //Clases
    class DisplayChoferes : Chofer
    {
        public int Index { get; set; }
    }

    class DisplayAutobuses : Chofer
    {
        public int Index { get; set; }
    }

    class DisplayRutas : Ruta
    {
        public int Index { get; set; }
    }
}
