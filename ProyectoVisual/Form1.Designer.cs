namespace ProyectoVisual
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GuardarG = new System.Windows.Forms.ToolStripMenuItem();
            this.GuardarGrafoC = new System.Windows.Forms.ToolStripMenuItem();
            this.VerticeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AgregarVertice = new System.Windows.Forms.ToolStripMenuItem();
            this.moverVértiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarVérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarVérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AristaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AristaN = new System.Windows.Forms.ToolStripMenuItem();
            this.AristaDir = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.IdGrafos = new System.Windows.Forms.NumericUpDown();
            this.BTNAgregar = new System.Windows.Forms.Button();
            this.MenuLista = new System.Windows.Forms.ToolStripMenuItem();
            this.ListaAdy = new System.Windows.Forms.ToolStripMenuItem();
            this.matrizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrízDeAdyacenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrízDeIncidenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RTBGrafo = new System.Windows.Forms.RichTextBox();
            this.ListaIncidencia = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdGrafos)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(896, 412);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.VerticeMenu,
            this.AristaMenu,
            this.MenuLista,
            this.matrizToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1128, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.GuardarG,
            this.GuardarGrafoC});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // GuardarG
            // 
            this.GuardarG.Name = "GuardarG";
            this.GuardarG.Size = new System.Drawing.Size(188, 26);
            this.GuardarG.Text = "Guardar";
            this.GuardarG.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // GuardarGrafoC
            // 
            this.GuardarGrafoC.Name = "GuardarGrafoC";
            this.GuardarGrafoC.Size = new System.Drawing.Size(188, 26);
            this.GuardarGrafoC.Text = "Guardar como...";
            this.GuardarGrafoC.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // VerticeMenu
            // 
            this.VerticeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgregarVertice,
            this.moverVértiveToolStripMenuItem,
            this.eliminarVérticeToolStripMenuItem,
            this.seleccionarVérticeToolStripMenuItem});
            this.VerticeMenu.Enabled = false;
            this.VerticeMenu.Name = "VerticeMenu";
            this.VerticeMenu.Size = new System.Drawing.Size(66, 24);
            this.VerticeMenu.Text = "Vértice";
            // 
            // AgregarVertice
            // 
            this.AgregarVertice.Name = "AgregarVertice";
            this.AgregarVertice.Size = new System.Drawing.Size(208, 26);
            this.AgregarVertice.Text = "Agregar vértice";
            this.AgregarVertice.Click += new System.EventHandler(this.agregarVérticeToolStripMenuItem_Click);
            // 
            // moverVértiveToolStripMenuItem
            // 
            this.moverVértiveToolStripMenuItem.Name = "moverVértiveToolStripMenuItem";
            this.moverVértiveToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.moverVértiveToolStripMenuItem.Text = "Mover vértice";
            this.moverVértiveToolStripMenuItem.Click += new System.EventHandler(this.moverVértiveToolStripMenuItem_Click);
            // 
            // eliminarVérticeToolStripMenuItem
            // 
            this.eliminarVérticeToolStripMenuItem.Name = "eliminarVérticeToolStripMenuItem";
            this.eliminarVérticeToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.eliminarVérticeToolStripMenuItem.Text = "Eliminar vértice";
            this.eliminarVérticeToolStripMenuItem.Click += new System.EventHandler(this.eliminarVérticeToolStripMenuItem_Click);
            // 
            // seleccionarVérticeToolStripMenuItem
            // 
            this.seleccionarVérticeToolStripMenuItem.Name = "seleccionarVérticeToolStripMenuItem";
            this.seleccionarVérticeToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.seleccionarVérticeToolStripMenuItem.Text = "Seleccionar vértice";
            this.seleccionarVérticeToolStripMenuItem.Click += new System.EventHandler(this.seleccionarVérticeToolStripMenuItem_Click);
            // 
            // AristaMenu
            // 
            this.AristaMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AristaN,
            this.AristaDir});
            this.AristaMenu.Name = "AristaMenu";
            this.AristaMenu.Size = new System.Drawing.Size(59, 24);
            this.AristaMenu.Text = "Arista";
            // 
            // AristaN
            // 
            this.AristaN.Name = "AristaN";
            this.AristaN.Size = new System.Drawing.Size(234, 26);
            this.AristaN.Text = "Agregar arista";
            this.AristaN.Click += new System.EventHandler(this.agregarAristaToolStripMenuItem1_Click);
            // 
            // AristaDir
            // 
            this.AristaDir.Name = "AristaDir";
            this.AristaDir.Size = new System.Drawing.Size(234, 26);
            this.AristaDir.Text = "Agregar arista dirigida";
            this.AristaDir.Click += new System.EventHandler(this.agregarAristaDirigidaToolStripMenuItem1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // IdGrafos
            // 
            this.IdGrafos.InterceptArrowKeys = false;
            this.IdGrafos.Location = new System.Drawing.Point(956, 41);
            this.IdGrafos.Name = "IdGrafos";
            this.IdGrafos.Size = new System.Drawing.Size(120, 22);
            this.IdGrafos.TabIndex = 2;
            // 
            // BTNAgregar
            // 
            this.BTNAgregar.Location = new System.Drawing.Point(956, 81);
            this.BTNAgregar.Name = "BTNAgregar";
            this.BTNAgregar.Size = new System.Drawing.Size(120, 50);
            this.BTNAgregar.TabIndex = 3;
            this.BTNAgregar.Text = "Agregar";
            this.BTNAgregar.UseVisualStyleBackColor = true;
            this.BTNAgregar.Click += new System.EventHandler(this.BTNAgregar_Click);
            // 
            // MenuLista
            // 
            this.MenuLista.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListaAdy,
            this.ListaIncidencia});
            this.MenuLista.Name = "MenuLista";
            this.MenuLista.Size = new System.Drawing.Size(51, 24);
            this.MenuLista.Text = "Lista";
            // 
            // ListaAdy
            // 
            this.ListaAdy.Name = "ListaAdy";
            this.ListaAdy.Size = new System.Drawing.Size(216, 26);
            this.ListaAdy.Text = "Lista de adyacencia";
            this.ListaAdy.Click += new System.EventHandler(this.ListaAdy_Click);
            // 
            // matrizToolStripMenuItem
            // 
            this.matrizToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matrízDeAdyacenciaToolStripMenuItem,
            this.matrízDeIncidenciaToolStripMenuItem});
            this.matrizToolStripMenuItem.Name = "matrizToolStripMenuItem";
            this.matrizToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.matrizToolStripMenuItem.Text = "Matriz";
            // 
            // matrízDeAdyacenciaToolStripMenuItem
            // 
            this.matrízDeAdyacenciaToolStripMenuItem.Name = "matrízDeAdyacenciaToolStripMenuItem";
            this.matrízDeAdyacenciaToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.matrízDeAdyacenciaToolStripMenuItem.Text = "Matríz de adyacencia";
            // 
            // matrízDeIncidenciaToolStripMenuItem
            // 
            this.matrízDeIncidenciaToolStripMenuItem.Name = "matrízDeIncidenciaToolStripMenuItem";
            this.matrízDeIncidenciaToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.matrízDeIncidenciaToolStripMenuItem.Text = "Matríz de incidencia";
            // 
            // RTBGrafo
            // 
            this.RTBGrafo.Location = new System.Drawing.Point(914, 137);
            this.RTBGrafo.Name = "RTBGrafo";
            this.RTBGrafo.Size = new System.Drawing.Size(202, 306);
            this.RTBGrafo.TabIndex = 4;
            this.RTBGrafo.Text = "";
            // 
            // ListaIncidencia
            // 
            this.ListaIncidencia.Name = "ListaIncidencia";
            this.ListaIncidencia.Size = new System.Drawing.Size(216, 26);
            this.ListaIncidencia.Text = "Lista de incidencia";
            this.ListaIncidencia.Click += new System.EventHandler(this.ListaIncidencia_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 457);
            this.Controls.Add(this.RTBGrafo);
            this.Controls.Add(this.BTNAgregar);
            this.Controls.Add(this.IdGrafos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Editor de Grafos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdGrafos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GuardarG;
        private System.Windows.Forms.ToolStripMenuItem GuardarGrafoC;
        private System.Windows.Forms.ToolStripMenuItem VerticeMenu;
        private System.Windows.Forms.ToolStripMenuItem AgregarVertice;
        private System.Windows.Forms.ToolStripMenuItem moverVértiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarVérticeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AristaMenu;
        private System.Windows.Forms.ToolStripMenuItem AristaN;
        private System.Windows.Forms.ToolStripMenuItem AristaDir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem seleccionarVérticeToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown IdGrafos;
        private System.Windows.Forms.Button BTNAgregar;
        private System.Windows.Forms.ToolStripMenuItem MenuLista;
        private System.Windows.Forms.ToolStripMenuItem ListaAdy;
        private System.Windows.Forms.ToolStripMenuItem matrizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrízDeAdyacenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrízDeIncidenciaToolStripMenuItem;
        private System.Windows.Forms.RichTextBox RTBGrafo;
        private System.Windows.Forms.ToolStripMenuItem ListaIncidencia;
    }
}

