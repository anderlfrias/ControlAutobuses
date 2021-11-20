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
        private Form formulario;
        public FrmPrinpal()
        {
            InitializeComponent();
        }

        private void OpenForm<MiForm>() where MiForm : Form, new()
        {
            formulario = pnlContenedor.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
                                                                                 //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                pnlContenedor.Controls.Add(formulario);
                pnlContenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }

        private void btnAutobuses_Click(object sender, EventArgs e)
        {
            OpenForm<FrmAutobus>();
        }
    }
}
