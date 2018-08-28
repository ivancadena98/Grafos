using System;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;

namespace ProyectoVisual
{
    class Arista
    {
        private int id, idv1, idv2;
        private int x1, y1, x2, y2;
        private int Dir;
        public Arista(int id_in, int idv1_in, int idv2_in, int x1_in, int y1_in, int x2_in, int y2_in, int D=0) {
            id = id_in;
            idv1 = idv1_in;
            idv2 = idv2_in;
            x1 = x1_in;
            y1 = y1_in;
            x2 = x2_in;
            y2 = y2_in;
            Dir = D;
        }
        //getters setters
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
        public int IDV1
        {
            get
            {
                return idv1;
            }

            set
            {
                idv1 = value;
            }
        }
        public int IDV2
        {
            get
            {
                return idv2;
            }

            set
            {
                idv2 = value;
            }
        }
        public int X1
        {
            get
            {
                return x1;
            }

            set
            {
                x1 = value;
            }
        }
        public int Y1
        {
            get
            {
                return y1;
            }

            set
            {
                y1 = value;
            }
        }
        public int X2
        {
            get
            {
                return x2;
            }

            set
            {
                x2 = value;
            }
        }
        public int Y2
        {
            get
            {
                return y2;
            }

            set
            {
                y2 = value;
            }
        }
        public int Dire
        {
            get
            {
                return Dir;
            }

            set
            {
                Dir = value;
            }
        }
        public void DibujaArista(Graphics g)
        {
            if (Dir == 0)
            {
                Pen pablo = new Pen(Color.Black, 4);

                g.DrawLine(pablo, x1, y1, x2, y2);
            }
            else {
                Pen pablo = new Pen(Color.Black, 4);
                pablo.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                g.DrawLine(pablo, x1, y1, x2, y2);
            }
        }
        public bool ChecarVertice(Vertice v)
        {
            return ((v.ID==idv1) || (v.ID==idv2));
        }
    }
}
