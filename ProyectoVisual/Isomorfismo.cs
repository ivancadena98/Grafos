using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVisual
{
    class Isomorfismo
    {
        private Grafo g1;
        private Grafo g2;

        private int[,] AuxListU;
        private int[,] AuxListV;
        private bool ban;
        
        private int tam;
        private int[] GradosU;
        private int[] GradosV;
        private int[] AuxV;
        
        private int aux;

        public Isomorfismo(Grafo gU, Grafo gV,int[,] MatU, int[,] MatV, int T)
        {
            g1 = gU;
            g2 = gV;
            //Crea la matriz de adyacencia del grafo U
            AuxListU = MatU;
            //Crea la matriz de adyacencia del grafo V
            AuxListV = MatV;
            tam = T;
            AuxV = new int[tam];
            GradosV = new int[tam];
            GradosU = new int[tam];
        }
        public bool Ban { get => ban; set => ban = value; }
        public int[,] AuxListV1 { get => AuxListV; set => AuxListV = value; }

        //Método para ver si tiene el mismo número de vértices o arístas
        public bool VerAr()
        {
            bool B = true;
            if (g1.Vertices.Count != g2.Vertices.Count)
                B = false;
            else if (g1.Aristas.Count != g2.Aristas.Count)
                B = false;
            return B;
        }
        public bool GradoVertice()
        {
            int Mu = 0;
            int mV = 0;
            foreach(Vertice v in g1.Vertices)
            {
                if (Mu < v.total())
                    Mu = v.total();
            }
            foreach (Vertice v in g2.Vertices)
            {
                if (mV < v.total())
                    mV = v.total();
            }
            if (mV != Mu)
                return false;
            else
            {
                
                return true;
            }
        }

        public void MatrizIGual()
        {
           ban = true;

            for (int i = 0; i < tam; i++) //Renglon
            {
                for (int j = 0; j < tam; j++) //Columna
                {
                    if (AuxListU[i, j] != AuxListV[i, j])
                    {
                        ban = false;
                        break;
                    }
                }
            }
            
        }
        
        public void CambiaMat(int i,int j)
        {
                    for (int c = 0; c < tam; c++)
                    {
                        int aux2 = AuxListV[i, c];
                        AuxListV[i, c] = AuxListV[j, c];
                        AuxListV[j, c] = aux2;
                    }
                    for (int c = 0; c < tam; c++)
                    {
                        int aux2 = AuxListV[c, i];
                        AuxListV[c, i] = AuxListV[c, j];
                        AuxListV[c, j] = aux2;
                    }
            
        }
        public void GradosRenglon(int[,] prueba)
            {
            int b = 0;
            for (int i=0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    //GradosU[i] += AuxListU[j, i]; //Sumatoria de los grados por renglón de U
                    int a = AuxListV[j, i];
                    GradosV[i] += a; //Sumatoria de los grados por renglón de V
                }
            }
            for(int i=0; i<tam; i++)
            {
                if (b < GradosV[i])
                    b = GradosV[i];
            }
            aux = b; //Número más grande de renglón
        }
        //Método para sacar el grado más alto y el número de renglones que tienen ese grado


    }
}
