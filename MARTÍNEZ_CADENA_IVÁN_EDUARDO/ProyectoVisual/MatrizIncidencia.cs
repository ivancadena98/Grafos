using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVisual
{
    class MatrizIncidencia
    {
        private List<Vertice> vertice;
        private List<Arista> arista;
        private List<string> CadenaNom;
        private List<string> ListaAd;
        private List<int> ide; //Lista para los vértices 
        private int [,] MatrizIn;
        public MatrizIncidencia(){
            vertice = new List<Vertice>();
            arista = new List<Arista>();
            CadenaNom = new List<string>();
            ListaAd = new List<string>();
            ide = new List<int>();
        }
        //Método para crear la matríz dirigida
        public void Lista(List<Vertice> l, List<Arista> a)
        {
            vertice = l;
            arista = a;
            MatrizIn=new int[vertice.Count, arista.Count];
            for (int i = 0; i < vertice.Count; i++)
            {
                for (int j = 0; j < arista.Count; j++)
                {
                    if (vertice[i].ID == arista[j].IDV1)//Salida
                    {
                        MatrizIn[i,j]=(-1);//Entrada
                    }
                    else if (vertice[i].ID == arista[j].IDV2)//Entrada
                    {

                        MatrizIn[i, j] = (1);//Salida
                    }
                    else if(vertice[i].ID != arista[j].IDV2 && vertice[i].ID != arista[j].IDV1)
                    {
                        MatrizIn[i, j] = (0); //No tiene a nadie
                    }

                }
            }
        }
        //Método para crear la matriz no dirigida
        public void ListaNDir(List<Vertice> l, List<Arista> a)
        {
            vertice = l;
            arista = a;
            MatrizIn = new int[vertice.Count, arista.Count];
            for (int i = 0; i < vertice.Count; i++)
            {
                for (int j = 0; j < arista.Count; j++)
                {
                    if (vertice[i].ID == arista[j].IDV1)//Salida
                    {
                        MatrizIn[i, j] = (1);//Entrada
                    }
                    else if (vertice[i].ID == arista[j].IDV2)//Entrada
                    {

                        MatrizIn[i, j] = (1);//Salida
                    }
                    else if (vertice[i].ID != arista[j].IDV2 && vertice[i].ID != arista[j].IDV1)
                    {
                        MatrizIn[i, j] = (0); //No tiene a nadie
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
