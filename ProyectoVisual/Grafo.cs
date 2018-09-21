using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;

namespace ProyectoVisual
{
    class Grafo
    {
        private List<Vertice> vertices;
        private List<Arista> aristas;
        private int idv, ida; //Identificador para los vértices y las aristas
        private Pen p;
        private ListaAdyacente lisAd;
        private MatrizIncidencia MatInc;
        private int[,] MatrizIncidencia;
        private MatrizAdyacencia MatAD;
        //selecciones
        private Vertice vselec;
        public Grafo(Pen DL)
        {
            p = DL;
            vertices = new List<Vertice>();
            
            aristas = new List<Arista>();
            idv = 0;
            ida = 0;
            lisAd = new ListaAdyacente();
            MatInc = new MatrizIncidencia();
            MatAD = new MatrizAdyacencia();
        }
        //getters setters
        public List<Vertice> Vertices
        {
            get
            {
                return vertices;
            }
            set
            {
                vertices = value;
            }
        }
        public List<Arista> Aristas
        {
            get
            {
                return aristas;
            }
            set
            {
                aristas = value;
            }
        }
        public int IDV
        {
            get { return idv; }
            set { idv = value; }
        }
        public int IDA
        {
            get { return ida; }
            set { ida = value; }
        }
        //Método para crear vértice
        public void AgregaVertice(Graphics g, int x, int y, int width, int height)
        {
            bool banColision = false;
            Vertice v = new Vertice(idv, x, y);

            foreach(Vertice ver in vertices)
            {
                banColision = x-v.Radio <= ver.X + ver.Radio && x+ v.Radio >= ver.X-ver.Radio && y- v.Radio <= ver.Y + ver.Radio && y+ v.Radio >= ver.Y-ver.Radio;
                if (banColision)
                    return;
            }
                
            

            if (!banColision && v.ChecarLimites(x, y, width, height))
            {
                idv++;
                vertices.Add(v);
                v.Dibujar(g);
            }
        }
        //SELECCIONAR VERTICE
        public void SeleccionarVertice(Graphics g, int vid)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if(vertices[i].ID == vid)
                    vselec = vertices[i];
            }
            vselec.Seleccionar(g);
        }        
        //MOVER VERTICE
        public void MoverVertice(Graphics g, int xmouse, int ymouse, int width, int height)
        {
            bool inicio;
            if (vselec != null&&vselec.ChecarLimites(xmouse, ymouse,width,height))
            {
                vselec.X = xmouse;
                vselec.Y = ymouse;

                foreach (Arista a in aristas)
                {
                    if (a.ChecarVertice(vselec))
                    {
                        inicio=vselec.ID == a.IDV1;
                        if (inicio)
                        {
                            a.X1 = vselec.X;
                            a.Y1 = vselec.Y;
                        }
                        else
                        {
                            a.X2 = vselec.X;
                            a.Y2 = vselec.Y;
                        }
                    }
                }

               // Dibujar(g);

            }

        }
        //AGREGAR ARISTA NO DIRIGIDA
        public void AgregaArista(Graphics g, Vertice v1, Vertice v2,int x, int y)
        {
            
            try
            {
               
                Arista a = new Arista(ida,v1.ID, v2.ID, v1.X, v1.Y, x, y);
                aristas.Add(a);

                a.DibujaArista(g);

                ida++;
            }catch(Exception ex)
            {
                Console.WriteLine("No se puede");
            }

        }
        //Agregar arista dirigida
        public void AgregarAristaDir(Graphics g, Vertice v1, Vertice v2,int x, int y) {
            try {
                Arista a = new Arista(ida, v1.ID, v2.ID, v1.X, v1.Y, x, y,1);
                aristas.Add(a);
                a.DibujaArista(g);
                ida++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se puede");
            }
        }
        //DIBUJAR GRAFO
        public void Dibujar(Graphics g)
        {
            //g.Clear(Color.White);
            if(vertices.Count>0)
                foreach (Vertice v in vertices)
                    v.Dibujar(g);

            if (aristas.Count > 0)
                foreach (Arista a in aristas)
                {
                    if (a.Dire == 0)
                        a.DibujaArista(g);
                    else
                        a.DibujaArista(g);
                }
        }
        public void destruir()
        {
            if(vertices.Count>0)
                vertices.Clear();
            if(aristas.Count>0)
                aristas.Clear();
            idv = 0;
            ida = 0;
        }
        public void copiar(Grafo g)
        {
            g.idv = idv;
            g.ida = ida;

            foreach(Vertice v in vertices)
            {
                g.vertices.Add(v);
            }

            foreach(Arista a in aristas)
            {
                g.aristas.Add(a);
            }
        }
        public void elimAr(int p)
        {
            for (int i = 0; i < aristas.Count; i++) {
                if (aristas[i].IDV1 == p || aristas[i].IDV2 == p) {
                    aristas.RemoveAt(i);
                    i--;
                }
                
            }


        }
        //Método para llamar y acomodar la lista de adyacencia no dirigida
        public void ListaNoDir() {
            lisAd.Lista(vertices, aristas);
            lisAd.RealizaLista();
        }
        //Método para llamar y acomodar la lista de adyacencia dirigida
        public void ListaSiDir()
        {
            lisAd.ListaDir(vertices, aristas);
            lisAd.RealizaLista();
        }

        //Método para recuperar la lista de adyacencia
        public List<string> recuperaLista()
        {
            return (lisAd.ImpLista());

        }

        //Método para crear y acomodar la matriz de incidencia dirigida
        public void ListaIn()
        {
            MatInc.Lista(vertices, aristas);
        }

        //Método para crear y acomodar la matríz de incidencia no dirigida
        public void ListaInNoDir()
        {
            MatInc.ListaNDir(vertices, aristas);
        }

        //Método para recuperar la matriz de incidencia
        public int[,] recuperaMatIncidencia()
        {
            MatrizIncidencia = MatInc.recuperamatriz();
            return (MatrizIncidencia);

        }
        //Método para crear la matríz de adyacencia Dirigida
        public void MatAdDir()
        {
            MatAD.RealizaMatriz(vertices, aristas);
        }

        //Método para crear la matríz de adyacencia no dirigida
        public void MatANoDir()
        {
            MatAD.RealizaMatrizNDir(vertices, aristas);
        }

        //Método para regresar la matríz de adyacencia
        public int[,] RegresaAd()
        {
            return MatAD.recuperamatriz();
        }
        //Método para saber el número de aristas que son de un vértice
        public void CalculaGrado()
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = 0; j < aristas.Count; j++)
                {
                    //Condicionales para verificar la comunicación entre vértices por el id de entrada o salida de los vértices
                    if (vertices[i].ID == aristas[j].IDV1) //Salida
                    {
                        vertices[i].AgregarVerticeEnt();
                    }
                    else if (vertices[i].ID == aristas[j].IDV2) //Entrada
                    {
                        vertices[i].AgregarVerticeSal();
                    }

                }
            }
        }
        public void BorraGrados()
        {
            foreach(Vertice vr in vertices)
            {
                vr.VerticesEntrada = 0;
                vr.VerticesSalida = 0;
            }
        }
    }

}