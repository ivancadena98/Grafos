using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using System.Drawing.Drawing2D;

namespace ProyectoVisual
{
    public partial class Form1 : Form
    {
        //Archivos
        Archivo archivo;
        bool up2Date; //Variable para saber si el archivo está guardado on las últimas modificaciones
        bool checando = false;
        bool borrar = false;
        bool corriendoPrograma;
        bool control = false;
        bool Krus = false;
        bool ColorearPr = false;
        bool Amplitud = false;
        int XAI, YAI;
        //Bandera para saber si el grafo es dirigido o no dirigido
        bool dirigido;
        int ContVer = 0;
        int nC = 0;
        //Auxiliares
        Vertice v1 = new Vertice();
        Vertice v2 = new Vertice();
        int raiz = -1, raiz2 = -1;
        Vertice VerEuler = new Vertice();
        Arista ArEuler = new Arista ();
        List<Vertice> ListaVerAux = new List<Vertice>();
        List<Arista> ListaArAux = new List<Arista>();
        List<Color> colores;
        Grafo grafoaux;
        Grafo Imp;
        //Graficos
        PictureBox pb;
        Graphics lienzo;
        Pen flD;
        int tam = 4;
        bool BanderaColor = false;
        //Acciones
        int tipo=-1; //Define el tipo de objeto que se va a agregar
        int selectMove = -1;                   //selectMove es para el nodo que fue seleccionado para que se mueva
        int toque = 0; //Bandera para gestionar cómo se agregan las aristas
        bool BanderaPlano = false;
        //Hilos
        Thread Actualizado; // Este hilo checa si hubo modificaciones posteriores a guardar el hilo en un archivo

        //Mover vertices
        bool moviendo = false;

        //Lista de grafos
        List<Grafo> ListGrafo;
        List<Grafo> ListGrafoKurAux;
        Grafo grafoKur;
        //Auxiliares 
        int[,] AuxList;
        public Form1()
        {
            InitializeComponent();
            Inicializar();
        }
        
        //Inicializacion de todas las variables
        public void Inicializar()
        {
            flD = new Pen(Color.Black,tam);
            flD.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;


            archivo = new Archivo();
            pb = new PictureBox();
            lienzo = pictureBox1.CreateGraphics();
            ListGrafo = new List<Grafo>();
            ListGrafoKurAux = new List<Grafo>();
            //grafo = new Grafo(flD);
            grafoaux = new Grafo(flD);
            grafoKur = new Grafo(flD);
            //ListGrafo.Add(grafo);
            Controls.Add(pb);
            colores = new List<Color>();

            Actualizado = new Thread(checarActualizaciones);
            Actualizado.Name = "Actualizado";
            up2Date = true;
            corriendoPrograma = true;
            Actualizado.Start();

            //Deshabilitar opciones hasta que se cree un vértice
            AristaMenu.Enabled = false;
            GuardarG.Enabled = false;
            GuardarGrafoC.Enabled = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            lienzo.Clear(Color.White);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pb.Paint += new PaintEventHandler(pictureBox1_Paint);

        }

        public void DibujarG(int IDG) {
                lienzo.Clear(Color.White);
                foreach (Grafo gr in ListGrafo)
                {
                    gr.Dibujar(lienzo);
                }
            
        }
       
        //CLICK para seleccionar qué se hará (Crear vértice, crear arísta, eliminar vértice).
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int IDG = (int)IdGrafos.Value - 1; //Saber cuál grafo se está modificando
            //Bandera para saber que opción se hará
            switch (tipo)
            {
                case 0: // Agregar vértices
                     ListGrafo[IDG].AgregaVertice(lienzo, e.X, e.Y, pictureBox1.Width, pictureBox1.Height);
                    
                    up2Date = false;
                    RTBGrafo.Text = (ListGrafo[IDG].Vertices.Count).ToString();
                    break;
                case 2: //Agregar arista dirigida
                    AgregarAristaDir(e.X, e.Y,IDG);
                    break;
                case 82: // eliminar vertice
                    ElimVertice(e.X, e.Y,IDG);
                    
                    break;
                case 4: //Agregar aristas
                    AgregarArista(e.X, e.Y,IDG);
                    break;
            }
        }

        /*public void VerticesD(){
            string a, b;
            int c = 0;
            a  = Interaction.InputBox("Vertice inicial: ", "Arista dirigida", "0", 100, 50);
            b= Interaction.InputBox("Vertice final: ", "Arista dirigida", "0", 100, 50);
            try
            {
                auxv1 = Convert.ToInt32(a);
                auxv2 = Convert.ToInt32(b);
            }
            catch (Exception e){ }
            foreach (Vertice v in grafo.Vertices)
            {
                tipo = 2;
                if (auxv1 != auxv2 && (v.ID + 1) == auxv1 && c == 0)
                {
                    v1 = v;
                    v1.Seleccionar(lienzo);
                    c = 1;
                }
            }
                foreach (Vertice v in grafo.Vertices) {
                  if  (auxv1 != auxv2 && (v.ID + 1) == auxv2 && c == 1)
                   {
                        v2 = v;
                        v2.Seleccionar(lienzo);
                        grafo.AgregarAristaDir(lienzo, v1, v2);
                        up2Date = false;
                        toque = 0;
                    }
                }
                 if(auxv1 == auxv2)
                {
                    MessageBox.Show("No pueden ser iguales");
                }
            Console.WriteLine(grafo.Aristas.Count);
        }*/
        //Eliminar Vertice
        public void ElimVertice(int x, int y,int IDG) {
            for (int i = 0; i < ListGrafo[IDG].Vertices.Count; i++)
            {
                Vertice v = ListGrafo[IDG].Vertices[i];
                if (v.Seleccion(x, y))
                {
                    ListGrafo[IDG].elimAr(v.ID);
                    ListGrafo[IDG].Vertices.RemoveAt(i);
                    DibujarG(IDG);
                    break;
                }
            }
            ActualizaCBAr();
        }
        //Agregar Arísta 
        public void AgregarArista(int x, int y,int IDG) {
            string nom= "";
            foreach (Vertice v in ListGrafo[IDG].Vertices)
            {
                if (v.Seleccion(x, y) && toque == 0)
                {
                    v1 = v;
                    XAI = x;
                    YAI = y;
                    toque = 1;
                }
                else if (v.Seleccion(x, y) && toque == 1)
                {
                        v2 = v;
                        ListGrafo[IDG].AgregaArista(lienzo, v1, v2,x,y);
                        up2Date = false;
                        toque = 0;
                        nom += (ListGrafo[IDG].Aristas[ListGrafo[IDG].Aristas.Count - 1].ID + 1).ToString();
                        CBArista.Items.Add(nom);
                }
            }
        }
        // Método para crear la arista dirigida 
        public void AgregarAristaDir(int x, int y,int IDG)
        {
            string nom = "";
            foreach (Vertice v in ListGrafo[IDG].Vertices)
            {
                if (v.Seleccion(x, y) && toque == 0)
                {
                    v1 = v;
                    toque = 1;
                }
                else if (v.Seleccion(x, y) && toque == 1)
                {
                    v2 = v;
                    if (!v1.Equals(v2))
                    {
                        ListGrafo[IDG].AgregarAristaDir(lienzo, v1, v2, x, y);
                        nom += (ListGrafo[IDG].Aristas[ListGrafo[IDG].Aristas.Count - 1].ID+1).ToString();
                        CBArista.Items.Add(nom);
                        up2Date = false;
                        toque = 0;
                    }
                }
            }
        }
        //AGREGAR VERTICE
        private void agregarVérticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipo = 0;
            //Habilitar opciones para el manejo de grafos
            AristaMenu.Enabled = true;
            GuardarG.Enabled = true;
            GuardarGrafoC.Enabled = true;
            MatrizMenu.Enabled = true;
            MenuLista.Enabled = true;
            PropiedadGrafo.Enabled = GrafoIs.Enabled = true;
        }

       //MOVER VERTICE
        private void moverVértiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipo = 1;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int IDG = (int)IdGrafos.Value-1;
            switch (tipo)
            {
                case 1:
                    foreach (Vertice v in ListGrafo[IDG].Vertices)
                    {
                        if (v.Seleccion(e.X, e.Y))
                        {
                            selectMove = v.ID;
                            ListGrafo[IDG].SeleccionarVertice(lienzo, selectMove);
                            moviendo = true;
                            break;
                        }
                    }
                    break;      
            }
        }

        //AGREGAR ARISTA
        private void agregarAristaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tipo = 4;
            AristaDir.Enabled = false;
            dirigido = false;
            MatrizMenu.Enabled = true;
            BTNGrado.Enabled = true;
            MenuLista.Enabled = true;
        }

        //NUEVO
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checando = true; //se activa el hilo que checa que el proyecto actualizado esté guardado
            while (checando) { }

        }
        
        //ABRIR
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checando = true; //se activa el hilo que checa que el proyecto actualizado esté guardado
            while (checando)
            {
            }
            if (borrar)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    AristaMenu.Enabled = MenuLista.Enabled = true;
                    ListGrafo.Clear();
                    lienzo.Clear(Color.White);
                    archivo.Ruta = openFileDialog1.FileName;
                    //abre el grafo nuevo
                    ListGrafo = archivo.Abrir(flD);
                    foreach (Grafo g in ListGrafo)
                    {
                        g.Dibujar(lienzo);
                        IdGrafos.Value++;
                    }
                }
                else
                {
                    foreach (Grafo g in ListGrafo)
                    {
                        grafoaux.copiar(g);
                        grafoaux.destruir();
                        g.Dibujar(lienzo);
                    }
                }
                borrar = false;
                VerticeMenu.Enabled = true;
                MatrizMenu.Enabled = PropiedadGrafo.Enabled = GrafoIs.Enabled = true;
                
            }


        }

        //GUARDAR
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (archivo.Ruta == null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    archivo.Ruta = saveFileDialog1.FileName;
                }
                else
                    return;

             
                    archivo.Guardar(ListGrafo);
                up2Date = true;
            }
        }

        //GUARDAR COMO
        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                archivo.Ruta = saveFileDialog1.FileName;
                archivo.Guardar(ListGrafo);
                up2Date = true;
            }
        }
        
        //Actualizaciones Accion hecha con hilo
        private void checarActualizaciones()
        {
            while (corriendoPrograma)
            {
                if (checando)
                {
                    if (!up2Date)
                    {
                        if (MessageBox.Show("Los cambios se perderán, está seguro de continuar?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            borrar = true;
                            lienzo.Clear(Color.White);
                            foreach(Grafo g in ListGrafo)
                                IdGrafos.Value --;
                            ListGrafo.Clear();
                            //grafo.destruir();
                            up2Date = true;
                            AristaMenu.Enabled = false;
                            GuardarG.Enabled = false;
                            GuardarGrafoC.Enabled = false;
                            BTNAgregar.Enabled = false;
                        }
                    }
                    else
                    {
                        borrar = true;
                        lienzo.Clear(Color.White);
                        foreach (Grafo g in ListGrafo)
                            g.copiar(grafoaux);
                        //grafo.destruir();
                        up2Date = true;
                    }
                    checando = false;
                }
                
            }
           
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int IDG = (int)IdGrafos.Value - 1;
            if (moviendo)
            {
                ListGrafo[IDG].MoverVertice(lienzo, e.X, e.Y, pictureBox1.Width, pictureBox1.Height);
                DibujarG(IDG);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            corriendoPrograma = false;
        }

        private void seleccionarVérticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipo = 1;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            moviendo = false;
            //DibujarG((int)IdGrafos.Value);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
                switch (e.KeyData)
                {
                    case Keys.A:
                           //Abrir Archivo
                        if (control)
                    {
                        checando = true; //se activa el hilo que checa que el proyecto actualizado esté guardado
                        while (checando)
                        {
                        }
                        if (borrar)
                        {
                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {

                                archivo.Ruta = openFileDialog1.FileName;

                                //abre el grafo nuevo
                                ListGrafo = archivo.Abrir(flD);
                                foreach (Grafo g in ListGrafo)
                                    g.Dibujar(lienzo);
                            }
                            else
                            {
                                foreach (Grafo g in ListGrafo)
                                {
                                    grafoaux.copiar(g);
                                    grafoaux.destruir();
                                    g.Dibujar(lienzo);
                                }
                            }
                            borrar = false;
                        }

                    }


                        control = false;
                        break;

                    case Keys.G:
                        //Guarda el archivo
                        if (control)
                    {
                        if (archivo.Ruta == null)
                        {
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                archivo.Ruta = saveFileDialog1.FileName;
                            }
                            else
                                return;
                        }
                        archivo.Guardar(ListGrafo);
                        up2Date = true;
                    }
                        

                        control = false;
                        break;

                    case Keys.ControlKey:
                        control = true;
                        break;

                    default:
                        control = false;
                        break;
                }
            

            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            control = false;
        }

        private void eliminarVérticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipo = 82;
        }
        //Agregar grafo
        private void BTNAgregar_Click(object sender, EventArgs e)
        {
            tipo = -1;
            //GrafoNuevo.Enabled = 
            VerticeMenu.Enabled = true;
            AbrirG.Enabled = false;
            Grafo g = new Grafo(flD);
            ListGrafo.Add(g);
            IdGrafos.Value ++;
        }
        //Imprimir la lista de adyacencia
        private void ListaAdy_Click(object sender, EventArgs e)
        {
            RTBGrafo.Clear();
            List<string> AuxList = new List<string>();
            AuxList.Clear();
            if (ListGrafo[(int)IdGrafos.Value - 1].Aristas.Count == 0)
            {
                RTBGrafo.Text = "Grafo nulo. ";
            }
            //RTBGrafo.Clear();
            else if (!dirigido) //Lista de grafo no dirigido
            {
                ListGrafo[(int)IdGrafos.Value - 1].ListaNoDir();
                AuxList = ListGrafo[(int)IdGrafos.Value - 1].recuperaLista();
                RTBGrafo.Lines = AuxList.ToArray();
                    //RTBGrafo.Text = "Si entra "+(v.ID).ToString()+(ListaVerAux.Count).ToString();
            }
            else if (dirigido)
            {
                ListGrafo[(int)IdGrafos.Value - 1].ListaSiDir();
                AuxList = ListGrafo[(int)IdGrafos.Value - 1].recuperaLista();
                RTBGrafo.Lines = AuxList.ToArray();
            }
        }
        //Imprimir la lista de incidencia
        private void ListaIncidencia_Click(object sender, EventArgs e)
        {
            
        }
        //Imprimir la matríz de incidencia
        private void matrízDeIncidenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTBGrafo.Clear();
            if (ListGrafo[(int)IdGrafos.Value - 1].Aristas.Count == 0)
            {
                RTBGrafo.Text = "Grafo nulo. ";
            }
            else if (dirigido)
            {
                ListGrafo[(int)IdGrafos.Value - 1].ListaIn();
                AuxList = ListGrafo[(int)IdGrafos.Value - 1].recuperaMatIncidencia();
                RTBGrafo.Text += " ";
                RTBGrafo.Text += "|    ";
                foreach (Arista a in  ListGrafo[(int)IdGrafos.Value - 1].Aristas)
                {
                    RTBGrafo.Text += string.Format("{0,4:D}", (a.ID+1).ToString());
                }
                RTBGrafo.Text += "\n";
                for (int i=0; i < ListGrafo[(int)IdGrafos.Value - 1].Vertices.Count; i++)
                {
                    RTBGrafo.Text += (ListGrafo[(int)IdGrafos.Value - 1].Vertices[i].ID+1).ToString() + "|";
                    RTBGrafo.Text += "   ";
                    for (int j = 0; j < ListGrafo[(int)IdGrafos.Value - 1].Aristas.Count; j++)
                    {

                        //RTBGrafo.Text += (AuxList[i, j]).ToString();
                        RTBGrafo.Text += string.Format("{0,4:D}", AuxList[i, j].ToString());
                    }
                    RTBGrafo.Text += Environment.NewLine;
                }
                
            }
            else if (!dirigido)
            {
                ListGrafo[(int)IdGrafos.Value - 1].ListaInNoDir();
                AuxList = ListGrafo[(int)IdGrafos.Value - 1].recuperaMatIncidencia();
                RTBGrafo.Text += " ";
                RTBGrafo.Text += "|    ";
                foreach (Arista a in ListGrafo[(int)IdGrafos.Value - 1].Aristas)
                {
                    //RTBGrafo.Text += "  ";
                    RTBGrafo.Text += string.Format("{0,4:D}", (a.ID + 1).ToString());
                    //RTBGrafo.Text += "";
                }
                RTBGrafo.Text += "\n";
                for (int i = 0; i < ListGrafo[(int)IdGrafos.Value - 1].Vertices.Count; i++)
                {
                    RTBGrafo.Text += (ListGrafo[(int)IdGrafos.Value - 1].Vertices[i].ID + 1).ToString() + "|";
                    RTBGrafo.Text += "   ";
                    for (int j = 0; j < ListGrafo[(int)IdGrafos.Value - 1].Aristas.Count; j++)
                    {

                        //RTBGrafo.Text += (AuxList[i, j]).ToString();
                        RTBGrafo.Text += string.Format("{0,4:D}", AuxList[i, j].ToString());
                    }
                    RTBGrafo.Text += Environment.NewLine;
                }
            }
        }
        //imprimir la matriz de adyacencia
        private void MatrizAd_Click(object sender, EventArgs e)
        {
            Imp = ListGrafo[(int)IdGrafos.Value - 1];
            RTBGrafo.Clear();
            if(ListGrafo[(int)IdGrafos.Value - 1].Aristas.Count == 0)
            {
                RTBGrafo.Text = "Grafo nulo. ";
            }
            else if (dirigido)
            {
                ListGrafo[(int)IdGrafos.Value - 1].MatAdDir();
                AuxList = ListGrafo[(int)IdGrafos.Value - 1].RegresaAd();
                
                ImprimeMat();
            }
            else if (!dirigido)
            {
                ListGrafo[(int)IdGrafos.Value - 1].MatANoDir();
                AuxList = ListGrafo[(int)IdGrafos.Value - 1].RegresaAd();
                ImprimeMat();
            }
        }
        //Método para agregar la matriz de adyacencia al form
        public void ImprimeMat()
        {
            RTBGrafo.Text += " ";
            RTBGrafo.Text += "|    ";
            foreach (Vertice a in Imp.Vertices)
            {
                //RTBGrafo.Text += "  ";
                RTBGrafo.Text += string.Format("{0,4:D}", (a.ID + 1).ToString());
                //RTBGrafo.Text += "";
            }
            RTBGrafo.Text += "\n";
            for (int i = 0; i < Imp.Vertices.Count; i++)
            {
                RTBGrafo.Text += (Imp.Vertices[i].ID + 1).ToString() + "|";
                RTBGrafo.Text += "   ";
                for (int j = 0; j < Imp.Vertices.Count; j++)
                {
                    RTBGrafo.Text += string.Format("{0,4:D}", AuxList[i, j].ToString());
                }
                RTBGrafo.Text += Environment.NewLine;
            }
            RTBGrafo.Text += "\n";
            RTBGrafo.Text += "\n";
        }
        //Método para imprimir los grafos
        private void BTNGrado_Click(object sender, EventArgs e)
        {
            ImprimeGrados();
        }
        public void ImprimeGrados()
        {
            RTBGrafo.Clear();
            ListGrafo[(int)IdGrafos.Value - 1].CalculaGrado();
            foreach (Vertice v in ListGrafo[(int)IdGrafos.Value - 1].Vertices)
            {
                if (!dirigido)
                {
                    RTBGrafo.Text += (v.ID + 1).ToString() + " Total= " + v.total();
                    RTBGrafo.Text += "\n";
                }
                else
                {
                    RTBGrafo.Text += (v.ID + 1).ToString() + " : entrada= " + v.VerticesEntrada.ToString() +
                   " salida= " + v.VerticesSalida.ToString() + " Total= " + v.total();
                    RTBGrafo.Text += "\n";
                }
                
            }
            ListGrafo[(int)IdGrafos.Value - 1].BorraGrados();
        }
        private void MatrizMenu_Click(object sender, EventArgs e)
        {

        }
        //Evento para activar la propiedad de isomorfo
        private void GrafoIs_Click(object sender, EventArgs e)
        {
            if (ListGrafo.Count == 1) //Tamaño de lista de grafos
            {
                MessageBox.Show("Debe haber más de 1 grafo");
            }
            else
            {
                string N= "Matriz de U \n";
                Isomorfo(N);
                //}
                ListGrafo[0].BorraGrados();
                ListGrafo[1].BorraGrados();
               
            }
        }
        public void Isomorfo(string Cad)
        {
            RTBGrafo.Clear();
            int cont = 1;
            ListGrafo[0].MatANoDir(); //Matris de adyacencia del grafo U
            ListGrafo[1].MatANoDir();//Matris de adyacencia del grafo V

            int[,] U = ListGrafo[0].RegresaAd(); //Se guarda la matriz de adyacencia del grafo U
            int[,] V = ListGrafo[1].RegresaAd(); //Se guarda la matriz de adyacencia del grafo V
            Isomorfismo IS = new Isomorfismo(ListGrafo[0], ListGrafo[1], U,
               V, ListGrafo[0].Vertices.Count);//Se crea una instancia de isomorfismo para hacer los cálculos
            if (IS.VerAr()) //Verifica que tengan el mismo numero de vertices y aristas
            {
                ListGrafo[0].CalculaGrado(); //Caldula los grados del grafo U
                ListGrafo[1].CalculaGrado(); //Caldula los grados del grafo V
                RTBGrafo.Text += Cad;
                AuxList = ListGrafo[0].RegresaAd(); //Matriz de adyacencia original del grafo U
                Imp = ListGrafo[0];
                ImprimeMat(); //Metodo para imprimir la matriz AuxList
                RTBGrafo.Text += "Matriz inicial del grafo a comparar V \n";
                AuxList = ListGrafo[1].RegresaAd(); //Matriz de adyacencia original del grafo V
                Imp = ListGrafo[1];
                ImprimeMat(); //Metodo para imprimir la matriz AuxList
                IS.MatrizIGual(); //Método que compara las matrices de U y V

                if (!IS.Ban)//No son iguales
                {

                    if (IS.GradoVertice()) //Verifica el numero de grados de los nodos
                    {
                        for (int i = 0; i < ListGrafo[0].Vertices.Count; i++) //accede al grafo u y v
                        {
                            //Se guarda el grado el primer nodo de V
                            int a1 = ListGrafo[1].Vertices[i].total();

                            for (int j =0; j < ListGrafo[0].Vertices.Count; j++)
                            {
                                //Se guarda el grado del nodo j de U
                                int a2 = ListGrafo[0].Vertices[j].total(); //Se guarda el grado del nodo
                                if (a1 == a2) //Se busca que los grado sean iguales
                                {
                                    /*Se hace el cambio de matriz entre la posicion de i  por el de j
                                    Se efectua el cambio del mismo vertice
                                    esto no afecta en nada el resultado final*/
                                    IS.CambiaMat(i, j);
                                    //Se recupera la matriz modificada
                                    AuxList = IS.AuxListV1;
                                    //Se compara con la original de U
                                    IS.MatrizIGual();
                                    RTBGrafo.Text += "Cambio numero: " + cont.ToString() +
                                    " | Se cambia " + (i + 1).ToString() +
                                    " por " + (j + 1).ToString() + "\n";
                                    cont++;
                                    ImprimeMat();
                                    //j = ListGrafo[0].Vertices.Count;
                                    if (IS.Ban) //Si son iguales se sale del ciclo
                                    {
                                        i = ListGrafo[0].Vertices.Count;
                                        j = ListGrafo[0].Vertices.Count;
                                    }
                                    //break;
                                }

                            }
                        }
                        if (IS.Ban) //Si recorre los movimientos y son iguales dispara el mensaje
                        {
                            MessageBox.Show("Son isomorficos");
                            BanderaPlano = true;
                        }
                        else
                        {
                            //Si recorre los movimientos y no son iguales dispara el mensaje
                            MessageBox.Show("No son isomorficos");
                        }

                    }
                    else
                        //Los grados son diferentes
                        MessageBox.Show("Grado mayor de vertice diferente, no son isomorficos");
                    //IS.GradosRenglon();
                }
                else
                    //Son iguales de entrada, deben ser diferentes
                    MessageBox.Show("Los grafos son iguales");

            }
            else
                //No tiene le mismo numero de nodos o aristas
                MessageBox.Show("No tiene el mismo numero de vertices o aristas");
            cont = 1;
        }
        //Eventos para mostrar los grafos kn,wn,cn, rn
        #region Especiales
        public void AbreEspecial() {
            IdGrafos.Value = 0;
            BTNGrado.Enabled= GuardarGrafoC.Enabled= VerticeMenu.Enabled = true;
            PropiedadGrafo.Enabled = MatrizMenu.Enabled = MenuLista.Enabled = true;
            ListGrafo.Clear();
            lienzo.Clear(Color.White);
            ListGrafo = archivo.Abrir(flD);
            foreach (Grafo g in ListGrafo)
            {
                IdGrafos.Value++;
                g.Dibujar(lienzo);
            }
            
                
        }
        private void k1M_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/k1.json";
            AbreEspecial();
        }

        private void k2M_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/k2.json";
            AbreEspecial();
        }

        private void k3M_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/k3.json";
            AbreEspecial();
        }

        private void k4M_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/k4.json";
            AbreEspecial();
        }

        private void k5M_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/k5.json";
            AbreEspecial();
        }

        private void k6M_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/k6.json";
            AbreEspecial();
        }

        private void k7M_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/k7.json";
            AbreEspecial();
        }

        private void R2_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/GRegular2.json";
            AbreEspecial();
        }

        private void r3_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/GRegular3.json";
            AbreEspecial();
        }

        private void R4_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/GRegular4.json";
            AbreEspecial();
        }

        private void c3_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "Grafos/GEspecial/c3.json";
            AbreEspecial();
        }

        private void c4_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/c4.json";
            AbreEspecial();
        }

        private void c5_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/c5.json";
            AbreEspecial();
        }

        private void c6_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/c6.json";
            AbreEspecial();
        }

        private void c7_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/c7.json";
            AbreEspecial();
        }

        private void w3_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/w3.json";
            AbreEspecial();
        }

        private void w4_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/w4.json";
            AbreEspecial();
        }

        private void w5_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/w5.json";
            AbreEspecial();
        }

        private void w6_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/w6.json";
            AbreEspecial();
        }

        private void w7_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/w7.json";
            AbreEspecial();
        }

        private void q3_Click(object sender, EventArgs e)
        {
            archivo.Ruta = "GEspecial/Cubo.json";
            AbreEspecial();
        }

        private void Euler_Click(object sender, EventArgs e)
        {
        }

        #endregion
        public bool Valida()
        {
            int Pos = (int)IdGrafos.Value;
            if (ListGrafo[Pos - 1].Vertices.Count == 0 || ListGrafo[Pos - 1].Aristas.Count == 0)
            {
                return false;
            }
            return true;
        }
        
        //Agregar Arista Dirigida
        private void agregarAristaDirigidaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AristaN.Enabled = false;
            dirigido = true;
            MenuLista.Enabled = true;
            MatrizMenu.Enabled = true;
            BTNGrado.Enabled = true;
            tipo = 2;
        }

        private void CamCirEuler_Click(object sender, EventArgs e)
        {
            int C = 0;
            if (ListGrafo.Count == 0)
                MessageBox.Show("No hay grafos");
            else
            {
                if (Valida())
                {
                    int Pos = (int)IdGrafos.Value;

                    if (!dirigido)
                    {
                        ListGrafo[Pos - 1].CalculaGrado();
                        if (ListGrafo[Pos - 1].GradosPares())
                        {
                            RTBGrafo.Clear();
                            BanderaColor = true;
                            VerEuler = ListGrafo[Pos - 1].Vertices[0];
                            CambiaColor();
                                for (int i = 0; i < ListGrafo[Pos - 1].Aristas.Count; i++)
                            {
                                C++;
                                RTBGrafo.Text += (VerEuler.ID + 1).ToString();
                                RTBGrafo.Text += "-> ";
                                Thread.Sleep(1000);
                                EncuentraSigVer(Pos, C);
                                CambiaColor();
                            }
                                RTBGrafo.Text += "1";

                                Thread.Sleep(1000);
                                BanderaColor = false;
                                CambiaColor();
                                MessageBox.Show("Es circuito");
                            
                        }
                        else if (ListGrafo[Pos - 1].CaminoNoDirEuler1)
                        {
                            RTBGrafo.Clear();
                            int id = ListGrafo[Pos - 1].IDVer11;
                            BanderaColor = true;
                            VerEuler = ListGrafo[Pos - 1].Vertices[id];
                            for (int i = 0; i < ListGrafo[Pos - 1].Aristas.Count; i++)
                            {
                                C++;
                                RTBGrafo.Text += (VerEuler.ID + 1).ToString();
                                RTBGrafo.Text += "-> ";
                                Thread.Sleep(1000);
                                EncuentraSigVer(Pos, C);
                                CambiaColor();
                            }
                                id = ListGrafo[Pos - 1].IDVer21;
                                RTBGrafo.Text += (id + 1).ToString();
                                Thread.Sleep(1000);
                                BanderaColor = false;
                                CambiaColor();
                                MessageBox.Show("Es camino");
                            
                        }
                        else
                            MessageBox.Show("No tiene camino ni circuito");
                    }
                
                    ListGrafo[Pos - 1].BorraGrados();
                }
                else
                    MessageBox.Show("No hay vértices o arístas");
            }
        }
        public void CambiaColor()
        {
            int Pos = (int)IdGrafos.Value;
            if (BanderaColor == true)
            {
                foreach (Arista a in ListGrafo[Pos - 1].Aristas)
                {
                    if (a.ArVisitado1 == true){
                        a.Color = Color.Red;
                        a.DibujaArista(lienzo);
                    }
                   
                }
            }
            else if (ColorearPr)
            {
                foreach (Arista a in ListGrafo[Pos - 1].Aristas)
                {
                    a.DibujaArista(lienzo);
                }
            }
            else if (Amplitud)
            {
                foreach (Arista a in ListGrafo[Pos - 1].Aristas)
                {
                    a.DibujaArista(lienzo);
                }
            }
            else if (Krus)
            {
                foreach (Arista a in ListGrafo[Pos - 1].Aristas)
                {
                    a.DibujaArista(lienzo);
                }
            }
            else
            {
                foreach (Arista a in ListGrafo[Pos - 1].Aristas)
                {
                    a.ArVisitado1 = false;
                    a.Color = Color.Black;
                    a.DibujaArista(lienzo);
                }
            }
        }
        //Métodos para que encontrar los vértices
        public void EncuentraSigVer(int Pos,int C)
        {
            int Eu = 0, IDv1 = 0, IDv2 = 0,ID=0 ;
            Vertice aux;
            ID = VerEuler.ID;
            for (int i = 0; i < ListGrafo[Pos - 1].Aristas.Count; i++) //Ciclo para recorrer las aristas
            {
                if (ListGrafo[Pos - 1].Aristas[i].ArVisitado1 == false) //Verifica si la arista está visitada
                {
                    //Condicional para encontrar el vértice actual
                    if (VerEuler.ID == ListGrafo[Pos - 1].Aristas[i].IDV1 || VerEuler.ID == ListGrafo[Pos - 1].Aristas[i].IDV2)
                    {
                        for (int j = C; j < ListGrafo[Pos - 1].Vertices.Count; j++) //Ciclo para recorrer los vértices
                        {
                            aux = ListGrafo[Pos - 1].Vertices[j];
                            IDv1 = ListGrafo[Pos - 1].Aristas[i].IDV1;
                            IDv2 = ListGrafo[Pos - 1].Aristas[i].IDV2;
                            if ((aux.ID == IDv1 || aux.ID == IDv2) && aux.ID != VerEuler.ID) //Condicional para encontrar la siguiente arísta
                            {
                                ContVer+=1;
                                VerEuler = ListGrafo[Pos - 1].Vertices[j];
                                ListGrafo[Pos - 1].Aristas[i].ArVisitado1 = true; //Cambio de vértice y visita la arista

                                j = ListGrafo[Pos - 1].Vertices.Count;
                                i = ListGrafo[Pos - 1].Aristas.Count;
                            }
                        }
                    }
                }
                Eu = i;
            }
            if (ID == VerEuler.ID)
                EncuentraSigVer2(Eu,Pos,C);
        }
        //Método para volver a buscar un vértice inicial
        //La lógica se repite como en el método anterior
        public void EncuentraSigVer2(int i,int Pos, int C)
        {
            Vertice aux;
            for (int j = 0; j < ListGrafo[Pos - 1].Aristas.Count; j++)
            {
                if (ListGrafo[Pos - 1].Aristas[j].ArVisitado1 == false)
                {
                    {
                        if (VerEuler.ID == ListGrafo[Pos - 1].Aristas[j].IDV1 || VerEuler.ID == ListGrafo[Pos - 1].Aristas[j].IDV2)
                        {
                            for (int k = 0; k < i; k++)
                            {
                                aux = ListGrafo[Pos - 1].Vertices[k];
                                if ((aux.ID == ListGrafo[Pos - 1].Aristas[j].IDV2 || aux.ID == ListGrafo[Pos - 1].Aristas[j].IDV1) && aux.ID != VerEuler.ID)
                                {
                                    ContVer += 1;
                                    VerEuler = ListGrafo[Pos - 1].Vertices[k];
                                    ListGrafo[Pos - 1].Aristas[j].ArVisitado1 = true;
                                    k = i;
                                    j = ListGrafo[Pos - 1].Aristas.Count;
                                }
                            }
                        }
                    }
                }
            }

        }
        private void K33_Click(object sender, EventArgs e)
        {
            string k3= "Matriz de K33 \n";
            Grafo aux;
            archivo.Ruta = "K33.json";
            ListGrafoKurAux = archivo.Abrir(flD);
            grafoKur = ListGrafoKurAux[0];
            aux = ListGrafo[0];
            ListGrafo[0] = grafoKur;
            ListGrafo.Add(aux);

            Isomorfo(k3); //Llama a isomorfo para verificar si son iguales
            if(BanderaPlano == true)
            {
                BanderaPlano = false;
                MessageBox.Show("No es plano");
            } //Si son iguales no es plano
            else
                MessageBox.Show("Es plano");
            //}
            ListGrafo[0].BorraGrados();
            ListGrafo[1].BorraGrados();

            aux = ListGrafo[1];
            ListGrafo.Clear();
            ListGrafo.Add(aux);
        }
        private void K5_Click(object sender, EventArgs e)
        {
            string k5 = "Matriz de K 5\n";
            Grafo aux;
            archivo.Ruta = "K5.json";
            ListGrafoKurAux = archivo.Abrir(flD);
            grafoKur = ListGrafoKurAux[0];
            aux = ListGrafo[0];
            ListGrafo[0] = grafoKur;
            ListGrafo.Add(aux);


            Isomorfo(k5);
            if (BanderaPlano == true)
            {
                MessageBox.Show("No es plano");
                BanderaPlano = false;
            }
            else
                MessageBox.Show("Es plano");
            //}
            ListGrafo[0].BorraGrados();
            ListGrafo[1].BorraGrados();

            aux = ListGrafo[1];
            ListGrafo.Clear();
            ListGrafo.Add(aux);
        }
        private void Corolario_Click(object sender, EventArgs e)
        {
            int E = ListGrafo[(int)IdGrafos.Value - 1].Aristas.Count;
            int V = ListGrafo[(int)IdGrafos.Value - 1].Vertices.Count;
            int Col1 = (3 * V) - 6;
            int Col2 = (2 * V) - 4;

            RTBGrafo.Clear();
            RTBGrafo.Text += "Corolario 1 \n";
            RTBGrafo.Text += "E <= 3v -6 \n";
            RTBGrafo.Text +=E.ToString()+ " <= 3("+V.ToString()+") -6 \n";
            RTBGrafo.Text += E.ToString() + " <= "+ Col1.ToString() +"\n";
            if (E <= Col1)
            {
                MessageBox.Show("Cumple el Corolario 1");
                RTBGrafo.Text += "Corolario 2 \n";
                RTBGrafo.Text += "E <= 2v -4 \n";
                RTBGrafo.Text += E.ToString() + " <= 2(" + V.ToString() + ") -4 \n";
                RTBGrafo.Text += E.ToString() + " <= " + Col2.ToString();
                if(E <= Col2)
                    MessageBox.Show("Cumple el Corolario 2, es plano");
            }
            else
                MessageBox.Show("No es plano");

        }
        //Método para calcular la matríz de costo
        public int[,] CalculaMatrizCosto()
        {
            int q = 0, p = 0;
            int Pos = (int)IdGrafos.Value;
            List<Vertice> vertice = ListGrafo[Pos - 1].Vertices;
            List<Arista> arista = ListGrafo[Pos - 1].Aristas;
            int[,] MatrizCosto = new int[vertice.Count, vertice.Count];
            for (int i = 0; i < vertice.Count; i++)
            {
                for (int j = 0; j < ListGrafo[Pos - 1].Aristas.Count; j++)
                {
                    //Condicional para saber si un vértice es entrada
                    if (vertice[i].ID == arista[j].IDV1)//Entrada
                    {
                        for (int h = 0; h < vertice.Count; h++)
                        {
                            if (vertice[h].ID == arista[j].IDV2)
                            {
                                if (arista[j].Costo == 0)
                                    p = 100;
                                else
                                    p = arista[j].Costo;
                                q = h;
                                MatrizCosto[i, h] = p;//Entrada
                                h = vertice.Count;
                            }
                            
                        }
                    }
                }
            }

            return MatrizCosto;
        
        }
        public void Cambia0(ref int[,] MatC)
        {
            int q = 0, p = 0;
            int Pos = (int)IdGrafos.Value;
            for (int i=0; i< ListGrafo[Pos - 1].Vertices.Count; i++)
            {
                for (int j = 0; j < ListGrafo[Pos - 1].Vertices.Count; j++)
                {
                    if (MatC[i, j] == 0)
                        MatC[i, j] = 1000;
                }
            }
        }
        //Evento de floyd
        private void floydToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTBGrafo.Clear();
            int Pos = (int)IdGrafos.Value;
            int tamV = ListGrafo[Pos - 1].Vertices.Count;
            int[,] C;
            int[,] A;
            int[,] P = new int[tamV, tamV];
            C = CalculaMatrizCosto();
            A = C;
            Cambia0(ref A);
            for (int i = 0; i < ListGrafo[Pos - 1].Vertices.Count; i++)
            {
                A[i, i] = 0;
            }
            RTBGrafo.Text += "Matriz de costo\n";
            AuxList = C; //Matriz de adyacencia original del grafo U
            Imp = ListGrafo[Pos-1];
            ImprimeMat(); //Metodo para imprimir la matriz AuxList
            for (int k = 0; k < ListGrafo[Pos - 1].Vertices.Count; k++)
            {
                for (int i = 0; i < ListGrafo[Pos - 1].Vertices.Count; i ++)
                {
                    for (int j = 0; j < ListGrafo[Pos - 1].Vertices.Count; j++)
                    {
                        if (A[i, k] + A[k, j] < A[i, j])
                        {
                            A[i, j] = A[i, k] + A[k, j];
                            P[i, j] = k+1;
                        }
                    }
                }
            }
            RTBGrafo.Text += "Matriz de Floyd\n";
            AuxList = A; //Matriz de adyacencia original del grafo U
            Imp = ListGrafo[Pos - 1];
            ImprimeMat(); //Metodo para imprimir la matriz AuxList
            RTBGrafo.Text += "Matriz de P\n";
            AuxList = P; //Matriz de adyacencia original del grafo U
            Imp = ListGrafo[Pos - 1];
            ImprimeMat(); //Metodo para imprimir la matriz AuxList
        }
        //Método para cambiar el peso de una arísta
        private void CambiarC_Click(object sender, EventArgs e)
        {
            int NumAr;
            int Pos = (int)IdGrafos.Value;
            Arista AAux = new Arista();
            try
            {
                NumAr = Convert.ToInt32(CBArista.Text);
                ListGrafo[Pos - 1].EncuentraAr((NumAr-1), ref AAux);
                AAux.Costo = Convert.ToInt32(TBModificar.Text);
                DibujarG(0);
            }
            catch(Exception es)
            {
                MessageBox.Show("Introduce un número");
            }
        }
        //Método para actualizar CB
        public void ActualizaCBAr()
        {
            CBArista.Items.Clear();
            foreach(Arista a in ListGrafo[(int)IdGrafos.Value - 1].Aristas)
            {
                CBArista.Items.Add((a.ID + 1).ToString());
            }
        }
        //Evento para borrar arísta
        private void BTNBorrar_Click(object sender, EventArgs e)
        {
            int NumAr;
            int Pos = (int)IdGrafos.Value;
            Arista AAux = new Arista();
            try
            {
                NumAr = Convert.ToInt32(CBArista.Text);
                ListGrafo[Pos - 1].EncuentraAr((NumAr - 1), ref AAux);
                ListGrafo[Pos - 1].EliminaAr(AAux);
                DibujarG(0);
                ActualizaCBAr();
            }
            catch (Exception es)
            {
                MessageBox.Show("Introduce un número");
            }
        }
        //Evento de agregar vértice de corte
        private void button1_Click(object sender, EventArgs e)
        {
            if (ListGrafo[(int)IdGrafos.Value - 1].Vertices.Count > 1 &&
                ListGrafo[(int)IdGrafos.Value - 1].Aristas.Count > 0)
            {
                string a;
                Vertice v1 = new Vertice();
                Vertice v2 = new Vertice();
                Vertice v3 = new Vertice();
                int Xin, Yin, Xfin, Yfin,Xint,Yint;
                Arista arx = new Arista();
                int c = 0;
                a = Interaction.InputBox("Id de arista", "Vértice de corte", "0", 100, 50);
                try
                {
                    //pictureBox1.Width
                    c = Convert.ToInt32(a) - 1;
                    ListGrafo[(int)IdGrafos.Value - 1].EncuentraAr(c, ref arx);
                    ListGrafo[(int)IdGrafos.Value - 1].EncuentraVer(arx.IDV1, ref v1);
                    ListGrafo[(int)IdGrafos.Value - 1].EncuentraVer(arx.IDV2, ref v2);
                    //Xin = arx.X1;
                    //Yin = arx.Y1;
                    Xfin = arx.X2;
                    Yfin = arx.Y2;
                    Xint = arx.CordInX1;
                    Yint = arx.CordIny1;
                    ListGrafo[(int)IdGrafos.Value - 1].EliminaAr(arx);
                    ListGrafo[(int)IdGrafos.Value - 1].AgregaVertice(lienzo, Xint, Yint, pictureBox1.Width, pictureBox1.Height);
                    ListGrafo[(int)IdGrafos.Value - 1].EncuentraVer((ListGrafo[(int)IdGrafos.Value - 1].IDV-1), ref v3);
                    if (dirigido)
                    {
                        ListGrafo[(int)IdGrafos.Value - 1].AgregarAristaDir(lienzo, v1, v3, Xint, Yint);
                        ListGrafo[(int)IdGrafos.Value - 1].AgregarAristaDir(lienzo, v3, v2, Xfin, Yfin);
                    }
                    else
                    {
                        ListGrafo[(int)IdGrafos.Value - 1].AgregaArista(lienzo, v1, v3, Xint, Yint);
                        ListGrafo[(int)IdGrafos.Value - 1].AgregaArista(lienzo, v3, v2, Xfin, Yfin);
                    }
                    DibujarG(0);
                    ActualizaCBAr();
                }
                catch (Exception ex) {
                    MessageBox.Show("Ingrese un número");
                }
            }
            else
                MessageBox.Show("Deben de existir al menos dos vértices y un arísta");
        }
        //Evento de borrar vértice de corte y agregar una arísta puente
        private void button2_Click(object sender, EventArgs e)
        {
            if (ListGrafo[(int)IdGrafos.Value - 1].Vertices.Count > 2 &&
                ListGrafo[(int)IdGrafos.Value - 1].Aristas.Count > 1)
            {
                Vertice v1 = new Vertice();
                Vertice v2 = new Vertice();
                Vertice v3 = new Vertice();
                int Cont = 0;
                int ArEn=0, ArSal=0;
                int c = 0;
                string a;
                int pos = (int)IdGrafos.Value - 1;
                a = Interaction.InputBox("Id de vértice a borrar", "Arísta de puente", "0", 100, 50);
                try
                {
                    c = Convert.ToInt32(a) - 1;
                    ListGrafo[pos].EncuentraVer(c, ref v3);

                    for (int j = 0; j < ListGrafo[pos].Aristas.Count; j++)
                    {
                        if(ListGrafo[pos].Aristas[j].IDV1 == v3.ID)
                        {
                            ArSal = ListGrafo[pos].Aristas[j].IDV2;
                            Cont++;
                            j = ListGrafo[pos].Aristas.Count;
                        }
                        else if (ListGrafo[pos].Aristas[j].IDV2 == v3.ID)
                        {
                            ArSal = ListGrafo[pos].Aristas[j].IDV1;
                            j = ListGrafo[pos].Aristas.Count;
                            Cont++;
                        }
                    }
                    for (int j = 0; j < ListGrafo[pos].Aristas.Count; j++)
                    {
                        if (ListGrafo[pos].Aristas[j].IDV1 == v3.ID && ListGrafo[pos].Aristas[j].IDV2 != ArSal)
                        {
                            ArEn = ListGrafo[pos].Aristas[j].IDV2;
                            Cont++;
                        }
                        else if (ListGrafo[pos].Aristas[j].IDV2 == v3.ID && ListGrafo[pos].Aristas[j].IDV1 != ArSal)
                        {
                            ArEn = ListGrafo[pos].Aristas[j].IDV1;
                            Cont++;
                        }
                    }
                    if (Cont < 3)
                    {
                        ElimVertice(v3.XV, v3.YV, pos);
                        ListGrafo[pos].EncuentraVer(ArEn, ref v1);
                        ListGrafo[pos].EncuentraVer(ArSal, ref v2);
                        int t = v1.XV;
                        int b = v1.YV;
                        ListGrafo[pos].AgregaArista(lienzo, v1, v2, v2.XV,v2.YV);
                        DibujarG(0);
                        ActualizaCBAr();
                    }
                    else
                        MessageBox.Show("Tiene más de 2 arístas, no se puede crear arísta de puente");

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ingrese un número");
                }
            }
            else
                MessageBox.Show("Deben de existir al menos tres vértices y dos aristas");
        }

        private void MenuCrom_Click(object sender, EventArgs e)
        {
            int Color = 1;
            cromatico(ref Color);
            cromatico(ref Color);
            int pos = (int)IdGrafos.Value - 1;

            Grafo g = ListGrafo[pos];
            List<Vertice> auxv = new List<Vertice>();
            auxv = g.Vertices.OrderBy(o => o.ColVer1).ToList();
            Color = auxv[auxv.Count-1].ColVer1;
            MessageBox.Show("El número cromático es: " + Color.ToString());
            
        }
        public void cromatico(ref int C)
        {
            int pos = (int)IdGrafos.Value - 1;
            nC = 1;
            ListGrafo[pos].ListAdVer();
            for (int i = 0; i < ListGrafo[pos].Vertices.Count; i++)
            {
                ListGrafo[pos].Vertices[i].ColVer1 = nC;
                for (int j = 0; j < ListGrafo[pos].Vertices[i].Adyacentes1.Count; j++)
                {
                    if (ListGrafo[pos].Vertices[i].Adyacentes1[j].ColVer1 == ListGrafo[pos].Vertices[i].ColVer1)
                    {
                        C++;
                        nC++;
                        ListGrafo[pos].Vertices[i].ColVer1 = nC;
                        j = 0;
                    }
                    else
                        ListGrafo[pos].Vertices[i].ColVer1 = nC;
                }
                C = nC;
                nC = 1;
            }
            DibujarG(0);
        }

        private void ProfMenu_Click(object sender, EventArgs e)
        {
            int pos = (int)IdGrafos.Value - 1;
            int IDV = 0;
            Grafo g = ListGrafo[pos];
            foreach(Vertice v in g.Vertices)
            {
                v.VerVisitado1 = false;
            }
            Vertice auxV = new Vertice();
            try
            {
                if (dirigido)
                {
                    int R = 1;
                    g.CalculaGrado();
                    ColorearPr = true;
                    string a = Interaction.InputBox("Id de vértice", "Inicio de bosque", "0", 100, 50);
                    RTBGrafo.Clear();
                    MessageBox.Show("El color azul representa el arco del árbol, el rojo el de retroceso, el verde de cruce y el amarillo de avance");
                    IDV = Convert.ToInt32(a) -1;
                    raiz = IDV;
                    g.EncuentraVer(IDV, ref auxV);
                    BosqueP(auxV, pos,ref R);
                    for(int i = 0; i < g.Vertices.Count; i++)
                    {
                        
                        if(g.Vertices[i].ID != IDV)
                        {
                            if (R == 2)
                            {
                                raiz2 = g.Vertices[i].ID;
                                R = 1;
                            }
                            
                            auxV = g.Vertices[i];
                            BosqueP(auxV, pos,ref R);
                        }
                    }
                    
                    Thread.Sleep(3000);
                    ColorearPr = false;
                    CambiaColor();
                    g.BorraGrados();
                    raiz = raiz2 = -1;
                }
            }
            catch(Exception ex) { MessageBox.Show("Ingresa un ID válido"); }
        }
        /**
         * Método de bosque abarcardor en profundidad
         * Hace un recorrido en profundida y marca los tipos de aristas
         * 
         * Azul - arbol
         * Rojo - retoceso
         * Verde - cruce
         * 
         * */
        public void BosqueP(Vertice v,int posG,ref int R)
        {
            int r = R;
            List<Arista> ArVer = new List<Arista>();
            if (v.VerVisitado1)
            {
                return;
            }
            if (!v.VerVisitado1)
            {
                Console.WriteLine((v.ID +1));
                v.VerVisitado1 = true;
            }
            ArVer = ListGrafo[posG].AristV(v);
            if(ArVer.Count == 0)
            {
                R = 2;
                return;
            }
            foreach (Arista a in ArVer)
            {
                Vertice sig = new Vertice();
                ListGrafo[posG].EncuentraVer(a.IDV2, ref sig);
                ListGrafo[posG].ListaAristas(ref sig);
                if(!sig.VerVisitado1)
                    a.Color = Color.Blue;
                if (sig.VerVisitado1)
                {
                    if (sig.ID == raiz)
                    {
                        if (raiz2 != -1)
                            a.Color = Color.Green;
                        else
                            a.Color = Color.Red;
                    }

                    else if (sig.ID == raiz2)
                        a.Color = Color.Red;
                    else if (v.ID == raiz2)
                    {
                        a.Color = Color.Yellow;
                    }
                    else if (v.ID == raiz)
                    {
                        a.Color = Color.Yellow;
                    }
                    else
                        a.Color = Color.Green;
                    

                }
                CambiaColor();
                Thread.Sleep(1500);
                BosqueP(sig, posG,ref r);
            }

        }

        private void AmplMenu_Click(object sender, EventArgs e)
        {
            int pos = (int)IdGrafos.Value - 1;
            int IDV = 0;
            
            Grafo g = ListGrafo[pos];
            foreach (Vertice v in g.Vertices)
            {
                v.VerVisitado1 = false;
            }
            Vertice auxV = new Vertice();
            if (!dirigido)
            {
                try
                {
                    Amplitud = true;
                    RTBGrafo.Clear();
                    RTBGrafo.Text += "Representación del camino \n";
                    string a = Interaction.InputBox("Id de vértice", "Inicio de amplitud", "0", 100, 50);
                    MessageBox.Show("El azul representa arco del arbol y el amarrillo el arco de cruce");
                    IDV = Convert.ToInt32(a) - 1;
                    g.EncuentraVer(IDV, ref auxV);
                    g.ListAdVer();
                    string S = BusquedaAm(auxV);
                    
                    //MessageBox.Show(S, "Busqueda en amplitud", MessageBoxButtons.OK);
                    foreach(Vertice ve in g.Vertices)
                    {
                        if(!ve.VerVisitado1)
                            S = BusquedaAm(ve);
                    }
                    
                    PintaAMplitud();
                    CambiaColor();
                    Amplitud = false;
                    Thread.Sleep(2000);
                    CambiaColor();
                }
                catch(Exception ex) { }
            }
        }

        public string BusquedaAm(Vertice v)
        {
            int pos = (int)IdGrafos.Value - 1;
            Grafo g = ListGrafo[pos];
            Arista auxA = new Arista();
            string Sec = "";
            int i = 0;
            List<Vertice> Cola = new List<Vertice>();
            v.VerVisitado1 = true;
            Cola.Add(v);
            
            while (Cola.Count > 0)
            {
                Vertice x = Cola[0];
                Cola.Remove(x);
                RTBGrafo.Text += (x.ID + 1).ToString() + " visita a: ";
                Sec += " " + (x.ID+1);
                List<Vertice> vAdyacentes = x.Adyacentes1;
                foreach (Vertice adyacente in vAdyacentes)
                {

                    if (adyacente.VerVisitado1 == false)
                    {
                        RTBGrafo.Text += " " + (adyacente.ID+1).ToString();
                        auxA = g.AristaVerT(x, adyacente);
                        auxA.Color = Color.Blue;
                        adyacente.VerVisitado1 = true;
                        Cola.Add(adyacente);
                        CambiaColor();
                        Thread.Sleep(1500);
                    }
                }
                RTBGrafo.Text += "\n";
                
            }
            return Sec;
        }
        public void PintaAMplitud()
        {
            int pos = (int)IdGrafos.Value - 1;
            Grafo g = ListGrafo[pos];
            foreach (Arista a in g.Aristas)
            {
                if(a.Color != System.Drawing.Color.Blue)
                    a.Color = Color.Yellow;
            }
        }

        private void KruskalMenu_Click(object sender, EventArgs e)
        {
            Krus = true;
            int pos = (int)IdGrafos.Value - 1;
            int PesoTot = 0;
            Grafo g = ListGrafo[pos];
            List<Arista> resKruskal = ProcKrus();
            List<Arista> AuxA = new List<Arista>();
            AuxA = g.Aristas.OrderBy(o => o.Costo).ToList();
            foreach (Arista a in AuxA)
            {
                foreach (Arista ak in resKruskal)
                {
                    if (a.ID == ak.ID)
                    {
                        a.Color = Color.Red;
                        PesoTot += a.Costo;
                        CambiaColor();
                        Thread.Sleep(1500);
                    }
                }
            }
            Thread.Sleep(2000);
            Krus = false;
            CambiaColor();
            
            MessageBox.Show("Costo menor: " + PesoTot.ToString());
        }

        private List<Arista> ProcKrus()
        {
            int pos = (int)IdGrafos.Value - 1;
            List<Arista> A = new List<Arista>();                //lista de aristas del grafo actual
            List<Arista> L = new List<Arista>();                //lista de aristas que se regresara
            List<List<Vertice>> C = new List<List<Vertice>>();  //lista de componentes
            Grafo g = ListGrafo[pos];                 //grafo apuntanto al grafo actual
            Vertice vo = new Vertice();
            Vertice vd = new Vertice();
            Arista AristaMenor;
            int cU = -1, cV = -1;
            C = CrearComponentes(g.Vertices);
            List<Arista> SortedAristas = g.Aristas.OrderBy(o => o.Costo).ToList();
            while (L.Count < (g.Vertices.Count-1))// regresa el numero de nodos del grafo
            {
                AristaMenor = AristaMenorPeso(SortedAristas);
                g.EncuentraVer(AristaMenor.IDV1, ref vo);
                g.EncuentraVer(AristaMenor.IDV2, ref vd);
                BuscaComponente(vo, C, ref cU);
                BuscaComponente(vd, C, ref cV);

                if (cU != cV)
                {
                    L.Add(AristaMenor);
                    UnionDeComponentes(cU, cV, C);
                }

            }
            return L;
        }
        private List<List<Vertice>> CrearComponentes(List<Vertice> V)
        {
            List<List<Vertice>> listComp;

            listComp = new List<List<Vertice>>();

            for (int i = 0; i < V.Count; i++)
            {
                listComp.Add(new List<Vertice>());
                listComp[i].Add(V[i]);
            }
            return listComp;
        }
        private Arista AristaMenorPeso(List<Arista> Q)
        {
            Arista ariMenor = null;
            ariMenor = Q[0];
            Q.Remove(ariMenor);
            return (ariMenor);
        }
        //Evento para empezar a dibujar la locura instantánea
        private void locuraInstantáneaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Pen Lapiz = new Pen(Color.Black, 5);
            Brush Brocha = new SolidBrush(Color.Black);
            Pen Lapiz2 = new Pen(Color.FromArgb(0, 0, 0), 5);
            Lapiz2.EndCap = LineCap.Flat;
            //Vertice R
            lienzo.DrawEllipse(Lapiz, 220,50, 30, 30);
            lienzo.FillEllipse((new SolidBrush(Color.Red)), 220, 50, 30, 30);
            lienzo.DrawString("R", new Font("Thaoma", 16), Brocha, 225, 50);
            //vertice A
            lienzo.DrawEllipse(Lapiz, 470, 50, 30, 30);
            lienzo.FillEllipse((new SolidBrush(Color.Yellow)),470, 50, 30, 30);
            lienzo.DrawString("A", new Font("Thaoma", 16), Brocha, 475, 50);
            //vertice V
            lienzo.DrawEllipse(Lapiz, 220, 300, 30, 30);
            lienzo.FillEllipse((new SolidBrush(Color.GreenYellow)), 220, 300, 30, 30);
            lienzo.DrawString("V", new Font("Thaoma", 16), Brocha, 225, 300);
            //vertice B
            lienzo.DrawEllipse(Lapiz, 470, 300, 30, 30);
            lienzo.FillEllipse((new SolidBrush(Color.DeepSkyBlue)), 470, 300, 30, 30);
            lienzo.DrawString("B", new Font("Thaoma", 16), Brocha, 475, 300);
            
            

            lienzo.DrawLine(Lapiz2, 250, 65, 470, 65);
            lienzo.DrawString("1", new Font("Thaoma", 11), Brocha, 345, 40);

            lienzo.DrawLine(Lapiz2, 250, 315, 470, 315);
            lienzo.DrawString("4", new Font("Thaoma", 11), Brocha, 345, 320);

            lienzo.DrawLine(Lapiz2, 233, 80, 233, 300);
            lienzo.DrawString("3", new Font("Thaoma", 11), Brocha, 237, 175);

            lienzo.DrawLine(Lapiz2, 487, 80, 487, 300);
            lienzo.DrawString("2", new Font("Thaoma", 11), Brocha, 475, 175);


            DibujaBezier();
        }
        //Método para dibujar las curvas internas de la locura instantánea
        public void DibujaBezier()
        {
            Pen Lapiz = new Pen(Color.Black, 5);
            Brush Brocha = new SolidBrush(Color.Black);
            Pen Lapiz2 = new Pen(Color.FromArgb(0, 0, 0), 5);
            Lapiz2.EndCap = LineCap.Flat;

            Point Punto1 = new Point(480, 50);
            Point Punto2 = new Point(450,0);
            Point Punto3 = new Point(400,0);
            Point Punto4 = new Point(480, 50);

            lienzo.DrawBezier(Lapiz, Punto1, Punto2, Punto3, Punto4);
            lienzo.DrawString("3", new Font("Thaoma", 11), Brocha, 490, 20);

            Punto1 = new Point(235, 330);
            Punto2 = new Point(165,410);
            Punto3 = new Point(270,410);
            Punto4 = new Point(235, 330);
            lienzo.DrawBezier(Lapiz, Punto1, Punto2, Punto3, Punto4);
            lienzo.DrawString("4", new Font("Thaoma", 11), Brocha, 225, 385);

            Punto1 = new Point(220, 70);
            Punto2 = new Point(170,130);
            Punto3 = new Point(170,245);
            Punto4 = new Point(220, 320);
            lienzo.DrawBezier(Lapiz, Punto1, Punto2, Punto3, Punto4);
            lienzo.DrawString("4", new Font("Thaoma", 11), Brocha, 165, 150);

            Punto1 = new Point(220, 70);
            Punto2 = new Point(70, 125);
            Punto3 = new Point(70, 255);
            Punto4 = new Point(220, 320);
            lienzo.DrawBezier(Lapiz, Punto1, Punto2, Punto3, Punto4);
            lienzo.DrawString("2", new Font("Thaoma", 11), Brocha, 95, 150);

            Punto1 = new Point(500, 70);
            Punto2 = new Point(550, 120);
            Punto3 = new Point(555,255);
            Punto4 = new Point(500, 320);
            lienzo.DrawBezier(Lapiz, Punto1, Punto2, Punto3, Punto4);
            lienzo.DrawString("1", new Font("Thaoma", 11), Brocha, 520, 150);

            Punto1 = new Point(500, 70);
            Punto2 = new Point(650, 120);
            Punto3 = new Point(650, 250);
            Punto4 = new Point(500, 320);
            lienzo.DrawBezier(Lapiz, Punto1, Punto2, Punto3, Punto4);
            lienzo.DrawString("3", new Font("Thaoma", 11), Brocha, 620, 150);

            Punto1 = new Point(235, 80);
            Punto2 = new Point(250, 125);
            Punto3 = new Point(290, 250);
            Punto4 = new Point(470, 310);
            lienzo.DrawBezier(Lapiz, Punto1, Punto2, Punto3, Punto4);
            lienzo.DrawString("1", new Font("Thaoma", 11), Brocha, 345, 250);

            Punto1 = new Point(250, 70);
            Punto2 = new Point(350, 125);
            Punto3 = new Point(450, 255);
            Punto4 = new Point(475, 305);
            lienzo.DrawBezier(Lapiz, Punto1, Punto2, Punto3, Punto4);
            lienzo.DrawString("2", new Font("Thaoma", 11), Brocha, 345, 120);
        }
        public void BuscaComponente(Vertice vert, List<List<Vertice>> C, ref int comp)
        {
            for (int i = 0; i < C.Count; i++)
                if (C[i].Contains(vert) == true)
                {
                    comp = i;
                    break;
                }
        }
        private void UnionDeComponentes(int cU, int cV, List<List<Vertice>> C)
        {
            foreach (Vertice vert in C[cV])
                C[cU].Add(vert);

            C[cV].Clear();
        }
    }
}
