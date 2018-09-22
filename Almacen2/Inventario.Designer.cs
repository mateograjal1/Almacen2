namespace Almacen2
{
    partial class Inventario
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarCambiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descartarCambiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventarioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarCambiosToolStripMenuItem,
            this.descartarCambiosToolStripMenuItem});
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // guardarCambiosToolStripMenuItem
            // 
            this.guardarCambiosToolStripMenuItem.Name = "guardarCambiosToolStripMenuItem";
            this.guardarCambiosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardarCambiosToolStripMenuItem.Text = "Guardar cambios";
            this.guardarCambiosToolStripMenuItem.Click += new System.EventHandler(this.guardarCambiosToolStripMenuItem_Click);
            // 
            // descartarCambiosToolStripMenuItem
            // 
            this.descartarCambiosToolStripMenuItem.Name = "descartarCambiosToolStripMenuItem";
            this.descartarCambiosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.descartarCambiosToolStripMenuItem.Text = "Descartar cambios";
            this.descartarCambiosToolStripMenuItem.Click += new System.EventHandler(this.descartarCambiosToolStripMenuItem_Click);
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventario.Location = new System.Drawing.Point(0, 24);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new System.Drawing.Size(800, 426);
            this.dgvInventario.TabIndex = 2;
            this.dgvInventario.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvInventario_DataError);
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Inventario";
            this.Text = "Inventario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Inventario_FormClosed);
            this.Load += new System.EventHandler(this.Inventario_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarCambiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descartarCambiosToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvInventario;
    }
}