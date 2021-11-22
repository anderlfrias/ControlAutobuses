﻿using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        private void OpenForm(Form form)
        {                                                                                 //si el formulario/instancia no existe
            if (formulario != null)
            {
                formulario.Close();
            }
            formulario = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(form);
            pnlContenedor.Tag = form;
            form.Show();
            form.BringToFront();
            
        }

        private void btnAutobuses_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmAutobus());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlador_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmRuta());
        }

        private void btnChoferes_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmChoferes());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (formulario != null)
                formulario.Close();
        }
    }
}
