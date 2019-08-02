using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameGraphs.Graphs;
using GameGraphs.FormObjects;

namespace GameGraphs
{
    public partial class Form1 : Form
    {
        Graphs.Graph g;
        public Form1()
        {
            InitializeComponent();
            //BtnStart_Click(this, null);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            g = new Graphs.Graph((int)nmUpDownHeight.Value, (int)nmUpDownWidth.Value);
            //g.MakeMap(0, 0, 3, 2);
            MakeTable(g);
            this.btnWide.Visible = true;
        }
        private void MakeTable(Graphs.Graph g)
        {
            int startX = this.btnStart.Left;
            int startY = this.btnStart.Bottom;
            const int board = 5;
            GraphElementFabric gFabric = new GraphElementFabric((this.ClientSize.Width - 2 * startX) / (int)this.nmUpDownWidth.Value
                            , (this.ClientSize.Height - board - startY) / (int)this.nmUpDownHeight.Value);
            this.Controls.AddRange(gFabric.GetLabel(g, startX, startY, (int)this.nmUpDownWidth.Value, (int)this.nmUpDownHeight.Value));
            this.Refresh();
        }

        private void BtnWide_Click(object sender, EventArgs e)
        {
            g.MakeMap();
        }
    }
}
