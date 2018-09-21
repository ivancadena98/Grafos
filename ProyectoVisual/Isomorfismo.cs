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
        private int[,] AuxListFinal;
        private bool ban;

        private int tam;
        private int[] GradosU;
        private int[] GradosV;
        private int[] AuxV;
        
        private int v1, v2,aux;

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
        /*public void CambiaMat(ref int[,] prueba)
        {
            GradosRenglon(prueba);
            BuscaPos();
            for (int c = 0; c < tam; c++)
            {
                int aux2 = prueba[v1, c];
                prueba[v1, c] = prueba[v2, c];
                prueba[v2, c] = aux2;
            }
            for (int c = 0; c < tam; c++)
            {
                int aux2 = prueba[c,v1];
                prueba[c,v1] = prueba[c,v2];
                prueba[c,v2] = aux2;
            }
        }*/
        public void CambiaMat()
        {
            GradosRenglon(AuxListV);
            BuscaPos();
            for (int c = 0; c < tam; c++)
            {
                int aux2 = AuxListV[v1, c];
                AuxListV[v1, c] = AuxListV[v2, c];
                AuxListV[v2, c] = aux2;
            }
            for (int c = 0; c < tam; c++)
            {
                int aux2 = AuxListV[c, v1];
                AuxListV[c, v1] = AuxListV[c, v2];
                AuxListV[c, v2] = aux2;
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
        public void BuscaPos()
        {
            for(int i=0; i< tam; i++)
            {
                if(aux == GradosV[i])
                {
                    v1 = i;
                    break;
                }
            }
            for(int j =0; j < tam; j++)
            {
                if(aux == GradosV[j] && j != v1)
                {
                    v2 = j;
                    break;
                }
            }
        }

    }
}
