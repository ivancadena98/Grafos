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
            this.AbrirG = new System.Windows.Forms.ToolStripMenuItem();
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
            this.CamCirEuler = new System.Windows.Forms.ToolStripMenuItem();
            this.KurAu = new System.Windows.Forms.ToolStripMenuItem();
            this.K33 = new System.Windows.Forms.ToolStripMenuItem();
            this.K5 = new System.Windows.Forms.ToolStripMenuItem();
            this.Corolario = new System.Windows.Forms.ToolStripMenuItem();
            this.floydToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.R4 = new System.Windows.Forms.ToolStripMenuItem();
            this.CicloG = new System.Windows.Forms.ToolStripMenuItem();
            this.c3 = new System.Windows.Forms.ToolStripMenuItem();
            this.c4 = new System.Windows.Forms.ToolStripMenuItem();
            this.c5 = new System.Windows.Forms.ToolStripMenuItem();
            this.c6 = new System.Windows.Forms.ToolStripMenuItem();
            this.c7 = new System.Windows.Forms.ToolStripMenuItem();
            this.volanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.w3 = new System.Windows.Forms.ToolStripMenuItem();
            this.w4 = new System.Windows.Forms.ToolStripMenuItem();
            this.w5 = new System.Windows.Forms.ToolStripMenuItem();
            this.w6 = new System.Windows.Forms.ToolStripMenuItem();
            this.w7 = new System.Windows.Forms.ToolStripMenuItem();
            this.cuboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.q3 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.IdGrafos = new System.Windows.Forms.NumericUpDown();
            this.BTNAgregar = new System.Windows.Forms.Button();
            this.RTBGrafo = new System.Windows.Forms.RichTextBox();
            this.BTNGrado = new System.Windows.Forms.Button();
            this.CBArista = new System.Windows.Forms.ComboBox();
            this.TBModificar = new System.Windows.Forms.TextBox();
            this.CambiarC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTNBorrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdGrafos)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 49);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(896, 427);
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
            this.regularToolStripMenuItem,
            this.CicloG,
            this.volanteToolStripMenuItem,
            this.cuboToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1217, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuGrafo
            // 
            this.MenuGrafo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GrafoNuevo,
            this.AbrirG,
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
            // AbrirG
            // 
            this.AbrirG.Name = "AbrirG";
            this.AbrirG.Size = new System.Drawing.Size(188, 26);
            this.AbrirG.Text = "Abrir";
            this.AbrirG.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
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
            this.GrafoIs,
            this.CamCirEuler,
            this.KurAu,
            this.Corolario,
            this.floydToolStripMenuItem});
            this.PropiedadGrafo.Enabled = false;
            this.PropiedadGrafo.Name = "PropiedadGrafo";
            this.PropiedadGrafo.Size = new System.Drawing.Size(104, 24);
            this.PropiedadGrafo.Text = "Propiedades";
            // 
            // GrafoIs
            // 
            this.GrafoIs.Enabled = false;
            this.GrafoIs.Name = "GrafoIs";
            this.GrafoIs.Size = new System.Drawing.Size(236, 26);
            this.GrafoIs.Text = "Isomorfo";
            this.GrafoIs.Click += new System.EventHandler(this.GrafoIs_Click);
            // 
            // CamCirEuler
            // 
            this.CamCirEuler.Name = "CamCirEuler";
            this.CamCirEuler.Size = new System.Drawing.Size(236, 26);
            this.CamCirEuler.Text = "Euler";
            this.CamCirEuler.Click += new System.EventHandler(this.CamCirEuler_Click);
            // 
            // KurAu
            // 
            this.KurAu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.K33,
            this.K5});
            this.KurAu.Name = "KurAu";
            this.KurAu.Size = new System.Drawing.Size(216, 26);
            this.KurAu.Text = "Kuratowski ";
            // 
            // K33
            // 
            this.K33.Name = "K33";
            this.K33.Size = new System.Drawing.Size(116, 26);
            this.K33.Text = "K 3:3";
            this.K33.Click += new System.EventHandler(this.K33_Click);
            // 
            // K5
            // 
            this.K5.Name = "K5";
            this.K5.Size = new System.Drawing.Size(116, 26);
            this.K5.Text = "K 5";
            this.K5.Click += new System.EventHandler(this.K5_Click);
            // 
            // Corolario
            // 
            this.Corolario.Name = "Corolario";
            this.Corolario.Size = new System.Drawing.Size(236, 26);
            this.Corolario.Text = "Corolario";
            this.Corolario.Click += new System.EventHandler(this.Corolario_Click);
            // 
            // floydToolStripMenuItem
            // 
            this.floydToolStripMenuItem.Name = "floydToolStripMenuItem";
            this.floydToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.floydToolStripMenuItem.Text = "Floyd";
            this.floydToolStripMenuItem.Click += new System.EventHandler(this.floydToolStripMenuItem_Click);
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
            this.k1M.Size = new System.Drawing.Size(99, 26);
            this.k1M.Text = "k1";
            this.k1M.Click += new System.EventHandler(this.k1M_Click);
            // 
            // k2M
            // 
            this.k2M.Name = "k2M";
            this.k2M.Size = new System.Drawing.Size(99, 26);
            this.k2M.Text = "k2";
            this.k2M.Click += new System.EventHandler(this.k2M_Click);
            // 
            // k3M
            // 
            this.k3M.Name = "k3M";
            this.k3M.Size = new System.Drawing.Size(99, 26);
            this.k3M.Text = "k3";
            this.k3M.Click += new System.EventHandler(this.k3M_Click);
            // 
            // k4M
            // 
            this.k4M.Name = "k4M";
            this.k4M.Size = new System.Drawing.Size(99, 26);
            this.k4M.Text = "k4";
            this.k4M.Click += new System.EventHandler(this.k4M_Click);
            // 
            // k5M
            // 
            this.k5M.Name = "k5M";
            this.k5M.Size = new System.Drawing.Size(99, 26);
            this.k5M.Text = "k5";
            this.k5M.Click += new System.EventHandler(this.k5M_Click);
            // 
            // k6M
            // 
            this.k6M.Name = "k6M";
            this.k6M.Size = new System.Drawing.Size(99, 26);
            this.k6M.Text = "k6";
            this.k6M.Click += new System.EventHandler(this.k6M_Click);
            // 
            // k7M
            // 
            this.k7M.Name = "k7M";
            this.k7M.Size = new System.Drawing.Size(99, 26);
            this.k7M.Text = "k7";
            this.k7M.Click += new System.EventHandler(this.k7M_Click);
            // 
            // regularToolStripMenuItem
            // 
            this.regularToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.R2,
            this.r3,
            this.R4});
            this.regularToolStripMenuItem.Name = "regularToolStripMenuItem";
            this.regularToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.regularToolStripMenuItem.Text = "Regular";
            // 
            // R2
            // 
            this.R2.Name = "R2";
            this.R2.Size = new System.Drawing.Size(184, 26);
            this.R2.Text = "Grafo regular 2";
            this.R2.Click += new System.EventHandler(this.R2_Click);
            // 
            // r3
            // 
            this.r3.Name = "r3";
            this.r3.Size = new System.Drawing.Size(184, 26);
            this.r3.Text = "Grafo regular 3";
            this.r3.Click += new System.EventHandler(this.r3_Click);
            // 
            // R4
            // 
            this.R4.Name = "R4";
            this.R4.Size = new System.Drawing.Size(184, 26);
            this.R4.Text = "Grafo regular 4";
            this.R4.Click += new System.EventHandler(this.R4_Click);
            // 
            // CicloG
            // 
            this.CicloG.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c3,
            this.c4,
            this.c5,
            this.c6,
            this.c7});
            this.CicloG.Name = "CicloG";
            this.CicloG.Size = new System.Drawing.Size(54, 24);
            this.CicloG.Text = "Ciclo";
            // 
            // c3
            // 
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(101, 26);
            this.c3.Text = "C3";
            this.c3.Click += new System.EventHandler(this.c3_Click);
            // 
            // c4
            // 
            this.c4.Name = "c4";
            this.c4.Size = new System.Drawing.Size(101, 26);
            this.c4.Text = "C4";
            this.c4.Click += new System.EventHandler(this.c4_Click);
            // 
            // c5
            // 
            this.c5.Name = "c5";
            this.c5.Size = new System.Drawing.Size(101, 26);
            this.c5.Text = "C5";
            this.c5.Click += new System.EventHandler(this.c5_Click);
            // 
            // c6
            // 
            this.c6.Name = "c6";
            this.c6.Size = new System.Drawing.Size(101, 26);
            this.c6.Text = "C6";
            this.c6.Click += new System.EventHandler(this.c6_Click);
            // 
            // c7
            // 
            this.c7.Name = "c7";
            this.c7.Size = new System.Drawing.Size(101, 26);
            this.c7.Text = "C7";
            this.c7.Click += new System.EventHandler(this.c7_Click);
            // 
            // volanteToolStripMenuItem
            // 
            this.volanteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.w3,
            this.w4,
            this.w5,
            this.w6,
            this.w7});
            this.volanteToolStripMenuItem.Name = "volanteToolStripMenuItem";
            this.volanteToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.volanteToolStripMenuItem.Text = "Giratorio";
            // 
            // w3
            // 
            this.w3.Name = "w3";
            this.w3.Size = new System.Drawing.Size(103, 26);
            this.w3.Text = "w3";
            this.w3.Click += new System.EventHandler(this.w3_Click);
            // 
            // w4
            // 
            this.w4.Name = "w4";
            this.w4.Size = new System.Drawing.Size(103, 26);
            this.w4.Text = "w4";
            this.w4.Click += new System.EventHandler(this.w4_Click);
            // 
            // w5
            // 
            this.w5.Name = "w5";
            this.w5.Size = new System.Drawing.Size(103, 26);
            this.w5.Text = "w5";
            this.w5.Click += new System.EventHandler(this.w5_Click);
            // 
            // w6
            // 
            this.w6.Name = "w6";
            this.w6.Size = new System.Drawing.Size(103, 26);
            this.w6.Text = "w6";
            this.w6.Click += new System.EventHandler(this.w6_Click);
            // 
            // w7
            // 
            this.w7.Name = "w7";
            this.w7.Size = new System.Drawing.Size(103, 26);
            this.w7.Text = "w7";
            this.w7.Click += new System.EventHandler(this.w7_Click);
            // 
            // cuboToolStripMenuItem
            // 
            this.cuboToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.q3});
            this.cuboToolStripMenuItem.Name = "cuboToolStripMenuItem";
            this.cuboToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.cuboToolStripMenuItem.Text = "Cubo";
            // 
            // q3
            // 
            this.q3.Name = "q3";
            this.q3.Size = new System.Drawing.Size(103, 26);
            this.q3.Text = "Q3";
            this.q3.Click += new System.EventHandler(this.q3_Click);
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
            this.BTNAgregar.Location = new System.Drawing.Point(1091, 59);
            this.BTNAgregar.Name = "BTNAgregar";
            this.BTNAgregar.Size = new System.Drawing.Size(120, 49);
            this.BTNAgregar.TabIndex = 3;
            this.BTNAgregar.Text = "Agregar grafo";
            this.BTNAgregar.UseVisualStyleBackColor = true;
            this.BTNAgregar.Click += new System.EventHandler(this.BTNAgregar_Click);
            // 
            // RTBGrafo
            // 
            this.RTBGrafo.Location = new System.Drawing.Point(914, 114);
            this.RTBGrafo.Name = "RTBGrafo";
            this.RTBGrafo.Size = new System.Drawing.Size(297, 233);
            this.RTBGrafo.TabIndex = 4;
            this.RTBGrafo.Text = "";
            // 
            // BTNGrado
            // 
            this.BTNGrado.Enabled = false;
            this.BTNGrado.Location = new System.Drawing.Point(914, 59);
            this.BTNGrado.Name = "BTNGrado";
            this.BTNGrado.Size = new System.Drawing.Size(128, 49);
            this.BTNGrado.TabIndex = 5;
            this.BTNGrado.Text = "Grado de vértices";
            this.BTNGrado.UseVisualStyleBackColor = true;
            this.BTNGrado.Click += new System.EventHandler(this.BTNGrado_Click);
            // 
            // CBArista
            // 
            this.CBArista.FormattingEnabled = true;
            this.CBArista.Location = new System.Drawing.Point(917, 370);
            this.CBArista.Name = "CBArista";
            this.CBArista.Size = new System.Drawing.Size(125, 24);
            this.CBArista.TabIndex = 6;
            // 
            // TBModificar
            // 
            this.TBModificar.Location = new System.Drawing.Point(1091, 372);
            this.TBModificar.Name = "TBModificar";
            this.TBModificar.Size = new System.Drawing.Size(120, 22);
            this.TBModificar.TabIndex = 7;
            // 
            // CambiarC
            // 
            this.CambiarC.Location = new System.Drawing.Point(1091, 400);
            this.CambiarC.Name = "CambiarC";
            this.CambiarC.Size = new System.Drawing.Size(120, 23);
            this.CambiarC.TabIndex = 8;
            this.CambiarC.Text = "Modificar";
            this.CambiarC.UseVisualStyleBackColor = true;
            this.CambiarC.Click += new System.EventHandler(this.CambiarC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(914, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Id de arista";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1165, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Peso";
            // 
            // BTNBorrar
            // 
            this.BTNBorrar.Location = new System.Drawing.Point(917, 400);
            this.BTNBorrar.Name = "BTNBorrar";
            this.BTNBorrar.Size = new System.Drawing.Size(125, 23);
            this.BTNBorrar.TabIndex = 11;
            this.BTNBorrar.Text = "Borrar";
            this.BTNBorrar.UseVisualStyleBackColor = true;
            this.BTNBorrar.Click += new System.EventHandler(this.BTNBorrar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(917, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 46);
            this.button1.TabIndex = 12;
            this.button1.Text = "Agregar vértice de corte";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1091, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 47);
            this.button2.TabIndex = 13;
            this.button2.Text = "Crear arísta de puente";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 487);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BTNBorrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CambiarC);
            this.Controls.Add(this.TBModificar);
            this.Controls.Add(this.CBArista);
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
        private System.Windows.Forms.ToolStripMenuItem AbrirG;
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
        private System.Windows.Forms.ToolStripMenuItem R4;
        private System.Windows.Forms.ToolStripMenuItem CicloG;
        private System.Windows.Forms.ToolStripMenuItem c3;
        private System.Windows.Forms.ToolStripMenuItem c4;
        private System.Windows.Forms.ToolStripMenuItem c5;
        private System.Windows.Forms.ToolStripMenuItem c6;
        private System.Windows.Forms.ToolStripMenuItem c7;
        private System.Windows.Forms.ToolStripMenuItem volanteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem w3;
        private System.Windows.Forms.ToolStripMenuItem w4;
        private System.Windows.Forms.ToolStripMenuItem w5;
        private System.Windows.Forms.ToolStripMenuItem w6;
        private System.Windows.Forms.ToolStripMenuItem w7;
        private System.Windows.Forms.ToolStripMenuItem cuboToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem q3;
        private System.Windows.Forms.ToolStripMenuItem CamCirEuler;
        private System.Windows.Forms.ToolStripMenuItem KurAu;
        private System.Windows.Forms.ToolStripMenuItem K33;
        private System.Windows.Forms.ToolStripMenuItem K5;
        private System.Windows.Forms.ToolStripMenuItem Corolario;
        private System.Windows.Forms.ToolStripMenuItem floydToolStripMenuItem;
        private System.Windows.Forms.ComboBox CBArista;
        private System.Windows.Forms.TextBox TBModificar;
        private System.Windows.Forms.Button CambiarC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTNBorrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

