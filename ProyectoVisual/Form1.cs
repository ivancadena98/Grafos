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

        //Bandera para saber si el grafo es dirigido o no dirigido
        bool dirigido;

        //Auxiliares
        Vertice v1 = new Vertice();
        Vertice v2 = new Vertice();
        List<Vertice> ListaVerAux = new List<Vertice>();
        Grafo grafoaux;

        //Graficos
        PictureBox pb;
        Graphics lienzo;
        Pen flD;
        int tam = 4;
        int auxv1, auxv2;
        //Acciones
        int tipo=-1; //Define el tipo de objeto que se va a agregar
        int selectMove = -1;                   //selectMove es para el nodo que fue seleccionado para que se mueva
        int toque = 0; //Bandera para gestionar cómo se agregan las aristas

        //Hilos
        Thread Actualizado; // Este hilo checa si hubo modificaciones posteriores a guardar el hilo en un archivo

        //Mover vertices
        bool moviendo = false;

        //Lista de grafos
        List<Grafo> ListGrafo;
        Grafo grafo;
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
            //grafo = new Grafo(flD);
            grafoaux = new Grafo(flD);
            //ListGrafo.Add(grafo);
            Controls.Add(pb);

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
            
        }
        //Agregar Arísta 
        public void AgregarArista(int x, int y,int IDG) {
            foreach (Vertice v in ListGrafo[IDG].Vertices)
            {
                if (v.Seleccion(x, y) && toque == 0)
                {
                    v1 = v;
                    toque = 1;
                    v1.Seleccionar(lienzo);
                }
                else if (v.Seleccion(x, y) && toque == 1)
                {
                    v2 = v;
                    v2.Seleccionar(lienzo);
                    if (!v1.Equals(v2))
                    {
                        ListGrafo[IDG].AgregaArista(lienzo, v1, v2,x,y);
                        up2Date = false;
                        toque = 0;
                    }
                }
            }
        }
        // Método para crear la arista dirigida 
        public void AgregarAristaDir(int x, int y,int IDG)
        {
            foreach (Vertice v in ListGrafo[IDG].Vertices)
            {
                if (v.Seleccion(x, y) && toque == 0)
                {
                    v1 = v;
                    toque = 1;
                    v1.Seleccionar(lienzo);
                }
                else if (v.Seleccion(x, y) && toque == 1)
                {
                    v2 = v;
                    v2.Seleccionar(lienzo);
                    if (!v1.Equals(v2))
                    {
                        ListGrafo[IDG].AgregarAristaDir(lienzo, v1, v2,x,y);
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
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
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
                VerticeMenu.Enabled = true;
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
                                g.copiar(grafoaux);
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
            GrafoNuevo.Enabled = VerticeMenu.Enabled = true;
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
        //Método para agregar la atriz de adyacencia al form
        public void ImprimeMat()
        {
            RTBGrafo.Text += " ";
            RTBGrafo.Text += "|    ";
            foreach (Vertice a in ListGrafo[(int)IdGrafos.Value - 1].Vertices)
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
                for (int j = 0; j < ListGrafo[(int)IdGrafos.Value - 1].Vertices.Count; j++)
                {
                    RTBGrafo.Text += string.Format("{0,4:D}", AuxList[i, j].ToString());
                }
                RTBGrafo.Text += Environment.NewLine;
            }
        }
        //Método para imprimir los grafos
        private void BTNGrado_Click(object sender, EventArgs e)
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
        }

        private void MatrizMenu_Click(object sender, EventArgs e)
        {

        }
        //Evento para activar la propiedad de isomorfo
        private void GrafoIs_Click(object sender, EventArgs e)
        {
            
            if (ListGrafo.Count == 1)
            {
                MessageBox.Show("Debe haber más de 1 grafo");
            }
            else
            {
                int[,] U = ListGrafo[0].RegresaAd();
                int[,] V = ListGrafo[1].RegresaAd();
                Isomorfismo IS = new Isomorfismo(ListGrafo[0], ListGrafo[1],U,
                V,ListGrafo[0].Vertices.Count);
                if (!IS.Ban) //Es falso
                {
                    MessageBox.Show("Los grafos no son iguales");
                    if (IS.VerAr())
                    {
                        IS.CambiaMat();
                        AuxList = IS.AuxListV1;
                        ImprimeMat();
                        //IS.GradosRenglon();
                    }
                    else
                        MessageBox.Show("No tiene el mismo numero de vertices o aristas");
                }
                else
                    MessageBox.Show("Los grafos son iguales");
                //}
            }
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

    }
}
