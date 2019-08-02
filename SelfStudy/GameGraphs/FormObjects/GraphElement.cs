using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGraphs.FormObjects
{
    public class GraphElement : Label
    {
        private Graphs.Point p;
        private Dictionary<Graphs.pointsValue, System.Drawing.Color> colorDict;
        internal GraphElement(Graphs.Point point, int width, int height, int xCoord, int yCoord) : base()
        {
            this.colorDict = new Dictionary<Graphs.pointsValue, System.Drawing.Color>();
            this.colorDict.Add(Graphs.pointsValue.UNVISITED, System.Drawing.Color.White);
            this.colorDict.Add(Graphs.pointsValue.VISITED, System.Drawing.Color.Gray);
            this.colorDict.Add(Graphs.pointsValue.BLOCK, System.Drawing.Color.Black);
            this.colorDict.Add(Graphs.pointsValue.START, System.Drawing.Color.Yellow);
            this.colorDict.Add(Graphs.pointsValue.STOP, System.Drawing.Color.Red);
            this.p = point;
            this.BackColor = colorDict[point.state];
            this.Width = width;
            this.Height = height;
            this.Location = new Point(xCoord, yCoord);
            this.BorderStyle = BorderStyle.FixedSingle;
            if (point.Iterator > 0)
                this.Text = point.Iterator.ToString();
            this.MouseClick += ElementClick;
            this.MouseDoubleClick += ElementDoubleClick;
            p.PointStateChanged += RefreshState;
        }

        void ElementClick(object o, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ChangeState(Graphs.pointsValue.START);
            else if (e.Button == MouseButtons.Right)
                ChangeState(Graphs.pointsValue.STOP);
        }

        void ElementDoubleClick(object o, MouseEventArgs e)
        {
            ChangeState(Graphs.pointsValue.BLOCK);
        }

        public void ChangeState(Graphs.pointsValue newState)
        {
            this.BackColor = colorDict[newState];
            p.ChangeState(newState);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        private void RefreshState()
        {
            this.Text = p.Iterator > 0 ? p.Iterator.ToString() : String.Empty;
            this.BackColor = colorDict[p.state];
            this.Refresh();
        }
    }
}