using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVisual
{
    class ListaAdyacente
    {
        private List<Vertice> vertice;
        private List<Arista> arista;
        private List<string> CadenaNom;
        private List<string> ListaAd;
        private List<int> ide; //Lista para los vértices de entrada

        public ListaAdyacente() {
            vertice = new List<Vertice>();
            arista = new List<Arista>();
            CadenaNom = new List<string>();
            ListaAd = new List<string>();
            ide = new List<int>();
        }

        /*Método para saber si un vértice tiene relación con otro (Grafo no dirigifo)
         *
         */
        public void Lista(List<Vertice> l, List<Arista> a)
        {
            vertice = l;
            arista = a;

            for (int i = 0; i < vertice.Count; i++)
            {
                for (int j = 0; j < arista.Count; j++)
                {
                    if (vertice[i].ID == arista[j].IDV1)//Salida
                    {
                        ide.Add(arista[j].IDV2+1);//Entrada
                    }
                    else if (vertice[i].ID == arista[j].IDV2)//Entrada
                    {
                        ide.Add(arista[j].IDV1+1);//Salida
                    }

                }
                ide.Add(-3);
            }
        }
        //Método para saber si un vértice tiene relación de entrada con otro (Grafo dirigido)
        public void ListaDir(List<Vertice> l, List<Arista> a)
        {
            vertice = l;
            arista = a;

            for (int i = 0; i < vertice.Count; i++)
            {
                for (int j = 0; j < arista.Count; j++)
                {
                    if (vertice[i].ID == arista[j].IDV1)//Salida
                    {
                        ide.Add(arista[j].IDV2 + 1);//Entrada
                    }

                }
                ide.Add(-3);
            }
        }
        //Método para realizar la lista de adyacencia
        public void RealizaLista()
        {
            CadenaNom.Clear();
            string aux="";
            for (int i = 0; i < ide.Count; i++) {
                
                if (ide[i] != -3)
                {
                    aux = aux+Convert.ToString(ide[i]) + " "; //Concatena cadena
                    
                }
                else
                {
                    
                    CadenaNom.Add(aux);
                    aux ="A";
                    CadenaNom.Add(aux);
                    aux = "";
                }
                
            }
        }

        public List<string> ImpLista()
        {
            ListaAd.Clear();
            string auxL="";
            int aux = 1;
            for(int i=0; i < CadenaNom.Count; i++)
            {
                if (CadenaNom[i]!="A")
                {
                    auxL = auxL+ Convert.ToString(aux) + "| " + CadenaNom[i];
                }
                else
                {
                    
                    ListaAd.Add(auxL);
                    aux++;
                    auxL = "";
                }
                
            }
            return (ListaAd);
        }
        }
    }
