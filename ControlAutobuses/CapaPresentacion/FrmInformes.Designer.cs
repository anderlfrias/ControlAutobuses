namespace CapaPresentacion
{
    partial class FrmInformes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInformes));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgViajes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgregarViaje = new System.Windows.Forms.Button();
            this.cboRutas = new System.Windows.Forms.ComboBox();
            this.cboChoferes = new System.Windows.Forms.ComboBox();
            this.cboAutobuses = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgViajes)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 556);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dtgViajes);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(598, 287);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // dtgViajes
            // 
            this.dtgViajes.AllowUserToAddRows = false;
            this.dtgViajes.AllowUserToDeleteRows = false;
            this.dtgViajes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgViajes.BackgroundColor = System.Drawing.Color.White;
            this.dtgViajes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgViajes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgViajes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgViajes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgViajes.ColumnHeadersHeight = 25;
            this.dtgViajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgViajes.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgViajes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgViajes.Location = new System.Drawing.Point(3, 14);
            this.dtgViajes.Name = "dtgViajes";
            this.dtgViajes.ReadOnly = true;
            this.dtgViajes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgViajes.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(81)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dtgViajes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgViajes.RowTemplate.Height = 35;
            this.dtgViajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgViajes.Size = new System.Drawing.Size(592, 267);
            this.dtgViajes.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregarViaje);
            this.groupBox1.Controls.Add(this.cboRutas);
            this.groupBox1.Controls.Add(this.cboChoferes);
            this.groupBox1.Controls.Add(this.cboAutobuses);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 121);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo Viaje";
            // 
            // btnAgregarViaje
            // 
            this.btnAgregarViaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(81)))), ((int)(((byte)(136)))));
            this.btnAgregarViaje.FlatAppearance.BorderSize = 0;
            this.btnAgregarViaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarViaje.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarViaje.ForeColor = System.Drawing.Color.White;
            this.btnAgregarViaje.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarViaje.Image")));
            this.btnAgregarViaje.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarViaje.Location = new System.Drawing.Point(393, 73);
            this.btnAgregarViaje.Name = "btnAgregarViaje";
            this.btnAgregarViaje.Size = new System.Drawing.Size(176, 33);
            this.btnAgregarViaje.TabIndex = 11;
            this.btnAgregarViaje.Text = "Agregar Viaje";
            this.btnAgregarViaje.UseVisualStyleBackColor = false;
            // 
            // cboRutas
            // 
            this.cboRutas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboRutas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRutas.FormattingEnabled = true;
            this.cboRutas.Location = new System.Drawing.Point(14, 75);
            this.cboRutas.Name = "cboRutas";
            this.cboRutas.Size = new System.Drawing.Size(249, 29);
            this.cboRutas.TabIndex = 10;
            this.cboRutas.Text = "Rutas disponibles...";
            // 
            // cboChoferes
            // 
            this.cboChoferes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboChoferes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChoferes.FormattingEnabled = true;
            this.cboChoferes.Location = new System.Drawing.Point(320, 26);
            this.cboChoferes.Name = "cboChoferes";
            this.cboChoferes.Size = new System.Drawing.Size(249, 29);
            this.cboChoferes.TabIndex = 9;
            this.cboChoferes.Text = "Choferes disponibles...";
            // 
            // cboAutobuses
            // 
            this.cboAutobuses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAutobuses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAutobuses.FormattingEnabled = true;
            this.cboAutobuses.Location = new System.Drawing.Point(14, 26);
            this.cboAutobuses.Name = "cboAutobuses";
            this.cboAutobuses.Size = new System.Drawing.Size(249, 29);
            this.cboAutobuses.TabIndex = 8;
            this.cboAutobuses.Text = "Autobuses disponibles...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(35, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "INFORME DE VIAJES";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(6, 6);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(23, 21);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 556);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInformes";
            this.Text = "FrmInformes";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgViajes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAgregarViaje;
        private System.Windows.Forms.ComboBox cboRutas;
        private System.Windows.Forms.ComboBox cboChoferes;
        private System.Windows.Forms.ComboBox cboAutobuses;
        private System.Windows.Forms.DataGridView dtgViajes;
    }
}