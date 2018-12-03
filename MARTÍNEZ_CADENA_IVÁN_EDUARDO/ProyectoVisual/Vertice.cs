using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProyectoVisual
{
    public class Vertice
    {
        private int id;
        private int x, y;
        private int xv, yv, radio = 18;
        private List<Arista> AristaV;
        //Listas para saber que arístas salen o entran al vértice
        private List<int> Entrada;
        private List<int> Salida;
        private int VEnt;
        private int VSal;
        private int ColVer = 0;
        private Pen juan = new Pen(Color.Blue,3); //Lapiz 
        private Font letra = new Font("Arial", 20);
        private SolidBrush brocha = new SolidBrush(Color.Black);
        private int Tot = 0;
        private bool VerVisitado = false;
        private List<Vertice> Adyacentes;
        private bool Hoja;
        public Vertice(int id_in, int X, int Y)
        {
            id = id_in;
            radio = 18;
            x = X;
            y = Y;
            Entrada = new List<int>();
            Salida = new List<int>();
            VEnt = 0;
            VSal = 0;
            ColVer = 0;
            Adyacentes = new List<Vertice>();
            AristaV = new List<Arista>();
            Hoja = false;
        }
        public Vertice()
        {
            id = 00;
            radio = 18;
            Adyacentes = new List<Vertice>();
            AristaV = new List<Arista>();
            VEnt = 0;
            VSal = 0;
            Hoja = false;
        }
        public List<int> En
        {
            get {
                return Entrada;
            }
            set {
                Entrada = value;
            }

        }
        public List<int> Sal
        {
            get
            {
                return Salida;
            }
            set
            {
                Salida = value;
            }

        }
        public int VerticesEntrada
        {
            get => VEnt; set => VEnt = value;
        }
        public int VerticesSalida
        {
            get => VSal; set => VSal = value;
        }
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public int XV
        {
            get
            {
                return xv;
            }
            set
            {
                xv = value;
            }
        }
        public int YV
        {
            get
            {
                return yv;
            }
            set
            {
                yv = value;
            }
        }
        public int Radio
        {
            get
            {
                return radio;
            }
            set
            {
                radio = value;
            }
        }
        public bool VerVisitado1 { get => VerVisitado; set => VerVisitado = value; }
        public int Tot1 { get => Tot; set => Tot = value; }
        public int ColVer1 { get => ColVer; set => ColVer = value; }
        internal List<Vertice> Adyacentes1 { get => Adyacentes; set => Adyacentes = value; }
        internal List<Arista> AristaV1 { get => AristaV; set => AristaV = value; }

        public int total()
        {
            calc();
            return (Tot);
        }
        public void calc()
        {
            Tot = VEnt + VSal;
        }
        //Método para dibujar vértice
        public void Dibujar(Graphics g)
        {
            g.DrawEllipse(juan, x - radio, y - radio, radio * 2, radio * 2);
            g.DrawString(Convert.ToString(id + 1), letra, brocha, x - radio + 5, y - radio + 3);
            xv = x - radio +5;
            yv = y - radio +3;
        }
        public void RellenaVer(Graphics g,SolidBrush b)
        {
            g.FillEllipse(b, x - radio, y - radio, radio * 2, radio * 2);
        }
        public bool Seleccion(int xP, int yP)
        {
            // Los parametos de entrada son las coordenadas del click
            bool resp = false;

            if (xP <= x + radio && xP >= x - radio && yP <= y + radio && yP >= y - radio)
                resp = true;

            return resp;
        }
        public void Seleccionar(Graphics g)
        {
            Pen juan = new Pen(Color.Red);
            g.DrawEllipse(juan, x - radio, y - radio, radio * 2, radio * 2);
        }
        public bool ChecarLimites(int xnew, int ynew, int width, int height)
        {
            return (xnew - radio > 0 && xnew + radio < width && ynew - radio > 0 && ynew + radio < height);
        }
        //Método para agregar un "1" al contador de entrada
        public void AgregarVerticeEnt()
        {
            VEnt++;
        }
        //Método para agregar un "1" al contador de salida
        public void AgregarVerticeSal()
        {
            VSal++;
        }
        public void AgregaVerAd(Vertice Ady)
        {
            Adyacentes.Add(Ady);
        }
    }
}
