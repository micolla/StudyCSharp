using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGraphs.FormObjects
{
    class GraphElementFabric
    {
        private int Width { get; set; }
        private int Height { get; set; }

        public GraphElementFabric(int w,int h)
        {
            this.Width = w;
            this.Height = h;
        }

        public GraphElement GetLabel(Graphs.Point p, int xCoord, int yCoord)
        {
            return new GraphElement(p,this.Width,this.Height,xCoord,yCoord);
        }

        public GraphElement[] GetLabel(Graphs.Graph g, int xStart, int yStart,int countX,int countY)
        {
            GraphElement[] gArray = new GraphElement[countX * countY];
            GraphElement temp;
            for (int i = 0; i < countY; i++)
            {
                for (int j = 0; j < countX; j++)
                {
                    temp = new GraphElement(g[i, j], this.Width, this.Height, xStart + j * this.Width, yStart + i * this.Height);
                    //temp.Click += delegate (object o, EventArgs e){ temp.ChangeState(Graphs.pointsValue.BLOCK);};
                    gArray[j + i * countX] = temp;
                }
            }
            return gArray;
        }
    }
}
