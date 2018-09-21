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
            this.MenuGrafo = new System.Windows.Forms.ToolStripMenuItem();
            this.GrafoNuevo = new System.Windows.Forms.ToolStripMenuItem();
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
            this.MenuLista = new System.Windows.Forms.ToolStripMenuItem();
            this.ListaAdy = new System.Windows.Forms.ToolStripMenuItem();
            this.MatrizMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MatrizAd = new System.Windows.Forms.ToolStripMenuItem();
            this.MatrizInc = new System.Windows.Forms.ToolStripMenuItem();
            this.PropiedadGrafo = new System.Windows.Forms.ToolStripMenuItem();
            this.GrafoIs = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.IdGrafos = new System.Windows.Forms.NumericUpDown();
            this.BTNAgregar = new System.Windows.Forms.Button();
            this.RTBGrafo = new System.Windows.Forms.RichTextBox();
            this.BTNGrado = new System.Windows.Forms.Button();
            this.knToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.k1M = new System.Windows.Forms.ToolStripMenuItem();
            this.k2M = new System.Windows.Forms.ToolStripMenuItem();
            this.k3M = new System.Windows.Forms.ToolStripMenuItem();
            this.k4M = new System.Windows.Forms.ToolStripMenuItem();
            this.k5M = new System.Windows.Forms.ToolStripMenuItem();
            this.k6M = new System.Windows.Forms.ToolStripMenuItem();
            this.k7M = new System.Windows.Forms.ToolStripMenuItem();
            this.regularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.R2 = new System.Windows.Forms.ToolStripMenuItem();
            this.r3 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.pictureBox1.Size = new System.Drawing.Size(896, 414);
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
            this.MenuGrafo,
            this.VerticeMenu,
            this.AristaMenu,
            this.MenuLista,
            this.MatrizMenu,
            this.PropiedadGrafo,
            this.knToolStripMenuItem,
            this.regularToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1223, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuGrafo
            // 
            this.MenuGrafo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GrafoNuevo,
            this.abrirToolStripMenuItem,
            this.GuardarG,
            this.GuardarGrafoC});
            this.MenuGrafo.Name = "MenuGrafo";
            this.MenuGrafo.Size = new System.Drawing.Size(71, 24);
            this.MenuGrafo.Text = "Archivo";
            // 
            // GrafoNuevo
            // 
            this.GrafoNuevo.Enabled = false;
            this.GrafoNuevo.Name = "GrafoNuevo";
            this.GrafoNuevo.Size = new System.Drawing.Size(188, 26);
            this.GrafoNuevo.Text = "Nuevo";
            this.GrafoNuevo.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
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
            // MenuLista
            // 
            this.MenuLista.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListaAdy});
            this.MenuLista.Enabled = false;
            this.MenuLista.Name = "MenuLista";
            this.MenuLista.Size = new System.Drawing.Size(51, 24);
            this.MenuLista.Text = "Lista";
            // 
            // ListaAdy
            // 
            this.ListaAdy.Name = "ListaAdy";
            this.ListaAdy.Size = new System.Drawing.Size(213, 26);
            this.ListaAdy.Text = "Lista de adyacencia";
            this.ListaAdy.Click += new System.EventHandler(this.ListaAdy_Click);
            // 
            // MatrizMenu
            // 
            this.MatrizMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MatrizAd,
            this.MatrizInc});
            this.MatrizMenu.Enabled = false;
            this.MatrizMenu.Name = "MatrizMenu";
            this.MatrizMenu.Size = new System.Drawing.Size(63, 24);
            this.MatrizMenu.Text = "Matriz";
            this.MatrizMenu.Click += new System.EventHandler(this.MatrizMenu_Click);
            // 
            // MatrizAd
            // 
            this.MatrizAd.Name = "MatrizAd";
            this.MatrizAd.Size = new System.Drawing.Size(225, 26);
            this.MatrizAd.Text = "Matríz de adyacencia";
            this.MatrizAd.Click += new System.EventHandler(this.MatrizAd_Click);
            // 
            // MatrizInc
            // 
            this.MatrizInc.Name = "MatrizInc";
            this.MatrizInc.Size = new System.Drawing.Size(225, 26);
            this.MatrizInc.Text = "Matríz de incidencia";
            this.MatrizInc.Click += new System.EventHandler(this.matrízDeIncidenciaToolStripMenuItem_Click);
            // 
            // PropiedadGrafo
            // 
            this.PropiedadGrafo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GrafoIs});
            this.PropiedadGrafo.Enabled = false;
            this.PropiedadGrafo.Name = "PropiedadGrafo";
            this.PropiedadGrafo.Size = new System.Drawing.Size(104, 24);
            this.PropiedadGrafo.Text = "Propiedades";
            // 
            // GrafoIs
            // 
            this.GrafoIs.Enabled = false;
            this.GrafoIs.Name = "GrafoIs";
            this.GrafoIs.Size = new System.Drawing.Size(144, 26);
            this.GrafoIs.Text = "Isomorfo";
            this.GrafoIs.Click += new System.EventHandler(this.GrafoIs_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // IdGrafos
            // 
            this.IdGrafos.InterceptArrowKeys = false;
            this.IdGrafos.Location = new System.Drawing.Point(1022, 31);
            this.IdGrafos.Name = "IdGrafos";
            this.IdGrafos.Size = new System.Drawing.Size(120, 22);
            this.IdGrafos.TabIndex = 2;
            // 
            // BTNAgregar
            // 
            this.BTNAgregar.Location = new System.Drawing.Point(1091, 82);
            this.BTNAgregar.Name = "BTNAgregar";
            this.BTNAgregar.Size = new System.Drawing.Size(120, 49);
            this.BTNAgregar.TabIndex = 3;
            this.BTNAgregar.Text = "Agregar grafo";
            this.BTNAgregar.UseVisualStyleBackColor = true;
            this.BTNAgregar.Click += new System.EventHandler(this.BTNAgregar_Click);
            // 
            // RTBGrafo
            // 
            this.RTBGrafo.Location = new System.Drawing.Point(914, 137);
            this.RTBGrafo.Name = "RTBGrafo";
            this.RTBGrafo.Size = new System.Drawing.Size(297, 308);
            this.RTBGrafo.TabIndex = 4;
            this.RTBGrafo.Text = "";
            // 
            // BTNGrado
            // 
            this.BTNGrado.Enabled = false;
            this.BTNGrado.Location = new System.Drawing.Point(914, 82);
            this.BTNGrado.Name = "BTNGrado";
            this.BTNGrado.Size = new System.Drawing.Size(128, 49);
            this.BTNGrado.TabIndex = 5;
            this.BTNGrado.Text = "Grado de vértices";
            this.BTNGrado.UseVisualStyleBackColor = true;
            this.BTNGrado.Click += new System.EventHandler(this.BTNGrado_Click);
            // 
            // knToolStripMenuItem
            // 
            this.knToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.k1M,
            this.k2M,
            this.k3M,
            this.k4M,
            this.k5M,
            this.k6M,
            this.k7M});
            this.knToolStripMenuItem.Name = "knToolStripMenuItem";
            this.knToolStripMenuItem.Size = new System.Drawing.Size(38, 24);
            this.knToolStripMenuItem.Text = "Kn";
            // 
            // k1M
            // 
            this.k1M.Name = "k1M";
            this.k1M.Size = new System.Drawing.Size(216, 26);
            this.k1M.Text = "k1";
            this.k1M.Click += new System.EventHandler(this.k1M_Click);
            // 
            // k2M
            // 
            this.k2M.Name = "k2M";
            this.k2M.Size = new System.Drawing.Size(216, 26);
            this.k2M.Text = "k2";
            this.k2M.Click += new System.EventHandler(this.k2M_Click);
            // 
            // k3M
            // 
            this.k3M.Name = "k3M";
            this.k3M.Size = new System.Drawing.Size(216, 26);
            this.k3M.Text = "k3";
            this.k3M.Click += new System.EventHandler(this.k3M_Click);
            // 
            // k4M
            // 
            this.k4M.Name = "k4M";
            this.k4M.Size = new System.Drawing.Size(216, 26);
            this.k4M.Text = "k4";
            this.k4M.Click += new System.EventHandler(this.k4M_Click);
            // 
            // k5M
            // 
            this.k5M.Name = "k5M";
            this.k5M.Size = new System.Drawing.Size(216, 26);
            this.k5M.Text = "k5";
            this.k5M.Click += new System.EventHandler(this.k5M_Click);
            // 
            // k6M
            // 
            this.k6M.Name = "k6M";
            this.k6M.Size = new System.Drawing.Size(216, 26);
            this.k6M.Text = "k6";
            this.k6M.Click += new System.EventHandler(this.k6M_Click);
            // 
            // k7M
            // 
            this.k7M.Name = "k7M";
            this.k7M.Size = new System.Drawing.Size(216, 26);
            this.k7M.Text = "k7";
            this.k7M.Click += new System.EventHandler(this.k7M_Click);
            // 
            // regularToolStripMenuItem
            // 
            this.regularToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.R2,
            this.r3});
            this.regularToolStripMenuItem.Name = "regularToolStripMenuItem";
            this.regularToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.regularToolStripMenuItem.Text = "Regular";
            // 
            // R2
            // 
            this.R2.Name = "R2";
            this.R2.Size = new System.Drawing.Size(216, 26);
            this.R2.Text = "Grafo regular 2";
            this.R2.Click += new System.EventHandler(this.R2_Click);
            // 
            // r3
            // 
            this.r3.Name = "r3";
            this.r3.Size = new System.Drawing.Size(216, 26);
            this.r3.Text = "Grafo regular 3";
            this.r3.Click += new System.EventHandler(this.r3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 457);
            this.Controls.Add(this.BTNGrado);
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
        private System.Windows.Forms.ToolStripMenuItem MenuGrafo;
        private System.Windows.Forms.ToolStripMenuItem GrafoNuevo;
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
        private System.Windows.Forms.ToolStripMenuItem MatrizMenu;
        private System.Windows.Forms.ToolStripMenuItem MatrizAd;
        private System.Windows.Forms.ToolStripMenuItem MatrizInc;
        private System.Windows.Forms.RichTextBox RTBGrafo;
        private System.Windows.Forms.Button BTNGrado;
        private System.Windows.Forms.ToolStripMenuItem PropiedadGrafo;
        private System.Windows.Forms.ToolStripMenuItem GrafoIs;
        private System.Windows.Forms.ToolStripMenuItem knToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem k1M;
        private System.Windows.Forms.ToolStripMenuItem k2M;
        private System.Windows.Forms.ToolStripMenuItem k3M;
        private System.Windows.Forms.ToolStripMenuItem k4M;
        private System.Windows.Forms.ToolStripMenuItem k5M;
        private System.Windows.Forms.ToolStripMenuItem k6M;
        private System.Windows.Forms.ToolStripMenuItem k7M;
        private System.Windows.Forms.ToolStripMenuItem regularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem R2;
        private System.Windows.Forms.ToolStripMenuItem r3;
    }
}

