using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;

namespace ProyectoVisual
{
    class Archivo
    {
        private string ruta;
        public string Ruta
        {
            get
            {
                return ruta;
            }
            set
            {
                ruta = value;
            }
        }
        public void Guardar(List<Grafo> g)
        {
            var jsongrafo = JsonConvert.SerializeObject(g);
            System.IO.File.WriteAllText(ruta, jsongrafo);
        }
        public List<Grafo> Abrir(Pen D)
        {

           List< Grafo> r = new List<Grafo>();
            r = JsonConvert.DeserializeObject<List<Grafo>>(System.IO.File.ReadAllText(ruta));
            return r;
        }
    }
}
