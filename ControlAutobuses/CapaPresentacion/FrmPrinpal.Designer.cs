namespace CapaPresentacion
{
    partial class FrmPrinpal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlControlador = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.btnAutobuses = new System.Windows.Forms.Button();
            this.btnRutas = new System.Windows.Forms.Button();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnChoferes = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.pnlControlador.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControlador
            // 
            this.pnlControlador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlControlador.Controls.Add(this.label1);
            this.pnlControlador.Controls.Add(this.btnCerrar);
            this.pnlControlador.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControlador.Location = new System.Drawing.Point(0, 0);
            this.pnlControlador.Name = "pnlControlador";
            this.pnlControlador.Size = new System.Drawing.Size(780, 32);
            this.pnlControlador.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlMenu.Controls.Add(this.btnSalir);
            this.pnlMenu.Controls.Add(this.btnRutas);
            this.pnlMenu.Controls.Add(this.btnAutobuses);
            this.pnlMenu.Controls.Add(this.btnChoferes);
            this.pnlMenu.Controls.Add(this.btnInicio);
            this.pnlMenu.Controls.Add(this.pnlLogo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMenu.Location = new System.Drawing.Point(0, 32);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(144, 428);
            this.pnlMenu.TabIndex = 1;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(144, 86);
            this.pnlLogo.TabIndex = 0;
            // 
            // btnAutobuses
            // 
            this.btnAutobuses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAutobuses.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAutobuses.FlatAppearance.BorderSize = 0;
            this.btnAutobuses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutobuses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutobuses.ForeColor = System.Drawing.Color.White;
            this.btnAutobuses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutobuses.Location = new System.Drawing.Point(0, 162);
            this.btnAutobuses.Name = "btnAutobuses";
            this.btnAutobuses.Size = new System.Drawing.Size(144, 38);
            this.btnAutobuses.TabIndex = 4;
            this.btnAutobuses.Text = "Autobuses";
            this.btnAutobuses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutobuses.UseVisualStyleBackColor = true;
            // 
            // btnRutas
            // 
            this.btnRutas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRutas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRutas.FlatAppearance.BorderSize = 0;
            this.btnRutas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRutas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRutas.ForeColor = System.Drawing.Color.White;
            this.btnRutas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRutas.Location = new System.Drawing.Point(0, 200);
            this.btnRutas.Name = "btnRutas";
            this.btnRutas.Size = new System.Drawing.Size(144, 38);
            this.btnRutas.TabIndex = 5;
            this.btnRutas.Text = "Rutas";
            this.btnRutas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRutas.UseVisualStyleBackColor = true;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.White;
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(144, 32);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(636, 428);
            this.pnlContenedor.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "SISTEMA DE CONTROL DE AUTOBUSES";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(0, 238);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(144, 38);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnChoferes
            // 
            this.btnChoferes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChoferes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChoferes.FlatAppearance.BorderSize = 0;
            this.btnChoferes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoferes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoferes.ForeColor = System.Drawing.Color.White;
            this.btnChoferes.Image = global::CapaPresentacion.Properties.Resources.icons8_conductor_24;
            this.btnChoferes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChoferes.Location = new System.Drawing.Point(0, 124);
            this.btnChoferes.Name = "btnChoferes";
            this.btnChoferes.Size = new System.Drawing.Size(144, 38);
            this.btnChoferes.TabIndex = 3;
            this.btnChoferes.Text = "        Choferes";
            this.btnChoferes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChoferes.UseVisualStyleBackColor = true;
            // 
            // btnInicio
            // 
            this.btnInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Image = global::CapaPresentacion.Properties.Resources.icons8_página_principal_30;
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.Location = new System.Drawing.Point(0, 86);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(144, 38);
            this.btnInicio.TabIndex = 2;
            this.btnInicio.Text = "         Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::CapaPresentacion.Properties.Resources.icons8_cerrar_ventana_26;
            this.btnCerrar.Location = new System.Drawing.Point(751, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(26, 23);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.TabStop = false;
            // 
            // FrmPrinpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(780, 460);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlControlador);
            this.Name = "FrmPrinpal";
            this.Text = "Form1";
            this.pnlControlador.ResumeLayout(false);
            this.pnlControlador.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControlador;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnRutas;
        private System.Windows.Forms.Button btnAutobuses;
        private System.Windows.Forms.Button btnChoferes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Button btnSalir;
    }
}

