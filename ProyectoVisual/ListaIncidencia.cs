using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVisual
{
    class ListaIncidencia
    {
        private List<Vertice> vertice;
        private List<Arista> arista;
        private List<string> CadenaNom;
        private List<string> ListaAd;
        private List<int> ide; //Lista para los vértices 
        public ListaIncidencia(){
            vertice = new List<Vertice>();
            arista = new List<Arista>();
            CadenaNom = new List<string>();
            ListaAd = new List<string>();
            ide = new List<int>();
        }

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
                        ide.Add(arista[j].ID + 1);//Entrada
                    }
                    /*else if (vertice[i].ID == arista[j].IDV2)//Entrada
                    {

                        ide.Add(arista[j].ID + 1);//Salida
                    }*/

                }
                ide.Add(-3);
            }
        }

        public void RealizaLista()
        {
            CadenaNom.Clear();
            string aux = "";
            string auxe = "e";
            for (int i = 0; i < ide.Count; i++)
            {

                if (ide[i] != -3)
                {
                    aux = aux+auxe + Convert.ToString(ide[i]) + "   "; //Concatena cadena

                }
                else
                {

                    CadenaNom.Add(aux);
                    aux = "A";
                    CadenaNom.Add(aux);
                    aux = "";
                }

            }
        }

        public List<string> ImpLista()
        {
            ListaAd.Clear();
            string auxL = "";
            int auxId = 1;
            for (int i = 0; i < CadenaNom.Count; i++)
            {
                if (CadenaNom[i] != "A")
                {
                    auxL = auxL + Convert.ToString(auxId) + "| "+ CadenaNom[i];
                }
                else
                {
                    ListaAd.Add(auxL);
                    auxId++;
                    auxL = "";
                }
            }
            return (ListaAd);
        }
    }
}
