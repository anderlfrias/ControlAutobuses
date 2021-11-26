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
            dtgViajes.ClearSelection();
        }


        private void DisplayChoferes()
        {
            _Choferes = new List<DisplayChoferes>();
            var choferes = _choferNegocio.GetAvailable();
            cboChoferes.Items.Add("Choferes disponibles...");
            foreach (var item in choferes)
            {
                cboChoferes.Items.Add(item.Nombre);
                cboChoferes.SelectedItem = item.Nombre;
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


        //private Chofer CargarChofer(string id)
        //{
        //    return _choferNegocio.GetById(id);
        //}

        //private Autobus CargarAutobus(string id)
        //{
        //    return _autobusNegocio.GetById(id);
        //}

        //private Ruta CargarRuta(string id)
        //{
        //    return _rutaNegocio.GetById(id);
        //}
        
        private string ModificarAutobus(Autobus model)
        {
            return _autobusNegocio.Update(model);
        }

        private string ModificarChofer(Chofer model)
        {
            return _choferNegocio.Update(model);
        }

        private string ModificarRuta(Ruta model)
        {
            return _rutaNegocio.Update(model);
        }

        private void AgregarViaje()
        {
            var chofer = _choferNegocio.GetById(_idChofer);
            var autobus = _autobusNegocio.GetById(_idAutobus);
            var ruta = _rutaNegocio.GetById(_idRuta);

            chofer.AutobusId = _idAutobus;
            chofer.RutaId = _idRuta;
            MessageBox.Show(_choferNegocio.Update(chofer), "Information");

            autobus.Asignado = false;
            MessageBox.Show(_autobusNegocio.Update(autobus), "Information");

            ruta.Asignado = false;
            MessageBox.Show(_rutaNegocio.Update(ruta), "Information");
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
