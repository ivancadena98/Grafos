using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVisual
{
    class MatrizAdyacencia
    {
        private List<Vertice> vertice;
        private List<Arista> arista;
        private List<string> CadenaNom;
        private List<string> ListaAd;
        private List<int> ide; //Lista para los vértices 
        private int[,] MatrizIn;
        public MatrizAdyacencia()
        {
            vertice = new List<Vertice>();
            arista = new List<Arista>();
            CadenaNom = new List<string>();
            ListaAd = new List<string>();
            ide = new List<int>();
        }


        //Realiza matríz adyacencia no dirigida
        public void RealizaMatrizNDir(List<Vertice> l, List<Arista> a)
        {
            int v1=0, v2=0;
            vertice = l;
            arista = a;
            MatrizIn = new int[vertice.Count, vertice.Count];
                for (int j = 0; j < arista.Count; j++)
                {
                    //Condicionales para verificar la comunicación entre vértices.
                    if (arista[j].IDV2 == arista[j].IDV1)
                    {
                        for(int i=0; i< vertice.Count; i++)
                        {
                            if(vertice[i].ID == arista[j].IDV2)
                            {
                                v1 = i;
                                i = vertice.Count;
                            }
                        }
                        MatrizIn[v1,v1] = 1;
                    }
                    else
                    {
                        for (int i = 0; i < vertice.Count; i++)
                        {
                            if (vertice[i].ID == arista[j].IDV2)
                            {
                                v1 = i;
                                i = vertice.Count;
                            }
                        }
                        for (int i = 0; i < vertice.Count; i++)
                        {
                            if (vertice[i].ID == arista[j].IDV1)
                            {
                                v2 = i;
                                i = vertice.Count;
                            }
                        }
                       MatrizIn[v1,v2] += 1;
                       MatrizIn[v2,v1] += 1;
                    }

                }
        }
        //Realiza matriz adyacencia dirigida
        public void RealizaMatriz(List<Vertice> l, List<Arista> a)
        {
            vertice = l;
            arista = a;
            MatrizIn = new int[vertice.Count, vertice.Count];
            //Ciclos para acceder a los vértices y arístas
            for (int i = 0; i < vertice.Count; i++)
            {
                for (int j = 0; j < arista.Count; j++)
                {
                    //Condicional para saber si es una oreja
                    if (vertice[i].ID == arista[j].IDV2 && vertice[i].ID == arista[j].IDV1)
                    {
                        MatrizIn[arista[j].IDV1, arista[j].IDV2] = 1;
                    }
                    //Condicional para saber si un vértice es entrada
                    else if (vertice[i].ID == arista[j].IDV1)//Entrada
                    {
                        MatrizIn[arista[j].IDV1, arista[j].IDV2] = 1;//Entrada
                    }

                }
            }
        }

        public int[,] recuperamatriz()
        {
            return (MatrizIn);
        }
    }
}
