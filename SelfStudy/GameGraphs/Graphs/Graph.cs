using System;
using System.Collections.Generic;

namespace GameGraphs.Graphs
{
    class Graph
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        private int iter;
        private Point[,] graph;
        private int[,] actions = new int[4, 2] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

        public Point StartPoint { get; set; }
        public Point StopPoint { get; set; }
        public Graph(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            graph = new Point[this.Height, this.Width];
            iter = 1;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    graph[i, j] = new Point(i, j);
                    graph[i, j].PointStartSet += Graph_PointStartSet;
                    graph[i, j].PointStopSet += Graph_PointStopSet;
                }
            }
        }

        private void Graph_PointStopSet(Point obj)
        {
            StopPoint = obj;
        }

        private void Graph_PointStartSet(Point obj)
        {
            StartPoint = obj;
        }

        public void SetGraphFree()
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    graph[i, j].ChangeState(pointsValue.UNVISITED);
                }
            }
        }

        public void ChangeState(int y, int x, pointsValue state, int iterator)
        {
            graph[y, x].ChangeState(state, iterator);
        }

        public bool MakeMap(int startX, int startY, int endX, int endY)
        {
            if (startX == endX && startY == endY)
            {
                ChangeState(startY, startX, pointsValue.VISITED, 1);
                return true;
            }
            else if (graph[startY, startX].state == pointsValue.BLOCK || graph[endX, endY].state == pointsValue.BLOCK)
                return false;
            else
            {
                Queue<Point> q = new Queue<Point>();
                q.Enqueue(graph[startY, startX]);
                Point currentPoint;
                //ChangeState(startY, startX, pointsValue.VISITED, 1);
                while (q.Count != 0 && graph[endY, endX].state != pointsValue.VISITED)
                {
                    currentPoint = q.Dequeue();
                    for (int i = 0; i < this.actions.GetLength(0); i++)
                    {
                        if (currentPoint.Y + this.actions[i, 0] < this.Height && currentPoint.Y + this.actions[i, 0] >= 0
                            && currentPoint.X + this.actions[i, 1] < this.Width && currentPoint.X + this.actions[i, 1] >= 0
                            && graph[currentPoint.Y + this.actions[i, 0], currentPoint.X + this.actions[i, 1]].state == pointsValue.UNVISITED)
                        {
                            ChangeState(currentPoint.Y + this.actions[i, 0], currentPoint.X + this.actions[i, 1],
                                pointsValue.VISITED, currentPoint.Iterator + 1);
                            q.Enqueue(graph[currentPoint.Y + this.actions[i, 0], currentPoint.X + this.actions[i, 1]]);
                        }
                    }
                }
            }
            if (graph[endY, endX].state == pointsValue.VISITED)
            {
                this.iter = graph[endY, endX].Iterator;
                return true;
            }
            else
                return false;
        }
        public bool MakeMap()
        {
            return MakeMap(StartPoint.X, StartPoint.Y, StopPoint.X, StopPoint.Y);
        }

        public Point this[int y, int x]
        {
            get{ return graph[y, x]; }
        }

        public void PrintGraph()
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.WriteLine($"{graph[i, j].Iterator:5}");
                }
            }
            Console.WriteLine("\n");
        }
    }
}
