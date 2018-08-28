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

        //Auxiliares
        Vertice v1 = new Vertice();
        Vertice v2 = new Vertice();
        Grafo grafoaux;

        //Graficos
        PictureBox pb;
        Graphics lienzo;
        Pen flD;
        int tam = 4;
        int auxv1, auxv2;
        delegate void d();
        d arisDir;
        //Acciones
        int tipo; //Define el tipo de objeto que se va a agregar
        int selectMove = -1;                   //selectMove es para el nodo que fue seleccionado para que se mueva
        int toque = 0; //Bandera para gestionar cómo se agregan las aristas

        //Hilos
        Thread Actualizado; // Este hilo checa si hubo modificaciones posteriores a guardar el hilo en un archivo

        //Mover vertices
        bool moviendo = false;

        Grafo grafo;
        

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
            grafo = new Grafo(flD);
            grafoaux = new Grafo(flD);
            Controls.Add(pb);

            Actualizado = new Thread(checarActualizaciones);
            Actualizado.Name = "Actualizado";
            up2Date = true;
            corriendoPrograma = true;
            Actualizado.Start();

            arisDir = VerticesD;

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            lienzo.Clear(Color.White);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pb.Paint += new PaintEventHandler(pictureBox1_Paint);
        }
        public void DibujarG() {
            lienzo.Clear(Color.White);
            grafo.Dibujar(lienzo);
        }
        //CLICK
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (tipo)
            {
                case 0: // Agregar vértices
                    grafo.AgregaVertice(lienzo, e.X, e.Y, pictureBox1.Width, pictureBox1.Height);
                    up2Date = false;
                    break;
                case 82: // eliminar vertice
                        for (int i = 0; i < grafo.Vertices.Count; i++) {
                             Vertice v = grafo.Vertices[i];
                             if (v.Seleccion(e.X, e.Y))
                                {
                                      grafo.elimAr(v.ID);
                                      grafo.Vertices.RemoveAt(i);
                                      break;
                                }
                            }
                    DibujarG();
                    break;
                case 4: //Agregar aristas
                    foreach(Vertice v in grafo.Vertices){
                        if (v.Seleccion(e.X, e.Y) && toque == 0)
                        {
                            v1 = v;
                            toque = 1;
                            v1.Seleccionar(lienzo);
                        }
                        else if (v.Seleccion(e.X, e.Y) && toque == 1)
                        {
                            v2 = v;
                            v2.Seleccionar(lienzo);
                            if (!v1.Equals(v2))
                            {
                                grafo.AgregaArista(lienzo,v1, v2);
                                up2Date = false;
                                toque = 0;
                            }
                        }
                    }
                    break;
            }
        }

        public void VerticesD(){
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
                    //Console.WriteLine("entre ejejejeje");
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
                        //Console.WriteLine("entre 2 ejejejeje");
                    }
                }
                 if(auxv1 == auxv2)
                {
                    MessageBox.Show("No pueden ser iguales");
                }
            Console.WriteLine(grafo.Aristas.Count);
        }
        //AGREGAR VERTICE
        private void agregarVérticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipo = 0;
        }

       //MOVER VERTICE
        private void moverVértiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipo = 1;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (tipo)
            {
                case 1:
                    foreach (Vertice v in grafo.Vertices)
                    {
                        if (v.Seleccion(e.X, e.Y))
                        {
                            selectMove = v.ID;
                            grafo.SeleccionarVertice(lienzo, selectMove);
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
                    grafo = archivo.Abrir(flD);
                    grafo.Dibujar(lienzo);
                }
                else
                {
                    grafoaux.copiar(grafo);
                    grafoaux.destruir();
                    grafo.Dibujar(lienzo);
                }
                borrar = false;
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
            }
            archivo.Guardar(grafo);
            up2Date = true;
        }

        //GUARDAR COMO
        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                archivo.Ruta = saveFileDialog1.FileName;

                archivo.Guardar(grafo);
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
                        if (MessageBox.Show("Si continúa los cambios se perderán, está seguro de continuar?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            borrar = true;
                            lienzo.Clear(Color.White);
                            grafo.copiar(grafoaux);
                            grafo.destruir();
                            up2Date = true;
                        }
                    }
                    else
                    {
                        borrar = true;
                        lienzo.Clear(Color.LightGray);
                        grafo.copiar(grafoaux);
                        grafo.destruir();
                        up2Date = true;
                    }
                        

                    checando = false;
                }
                
            }
           
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (moviendo)
            {
                grafo.MoverVertice(lienzo, e.X, e.Y, pictureBox1.Width, pictureBox1.Height);
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
                                grafo = archivo.Abrir(flD);
                                grafo.Dibujar(lienzo);
                            }
                            else
                            {
                                grafoaux.copiar(grafo);
                                grafoaux.destruir();
                                grafo.Dibujar(lienzo);
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
                        archivo.Guardar(grafo);
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

        private void agregarAristaDirigidaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //tipo = 2;
            arisDir.Invoke();
        }

    }
}
