using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGraphs.Graphs
{
    public class Point
    {
       
        public event Action PointStateChanged;
        public event Action<Point> PointStartSet;
        public event Action<Point> PointStopSet;

        class NotRightGraphValueException : ApplicationException
        {
            public NotRightGraphValueException() : base() { }
            public NotRightGraphValueException(string message) : base(message) { }

            public NotRightGraphValueException(string message, Exception innerException) : base(message, innerException) { }
        }
        public pointsValue state { get; private set; }
        public int Y { get; private set; }
        public int X { get; private set; }
        public int Iterator { get; private set; }

        public Point(int y, int x)
        {
            this.Y = y;
            this.X = x;
            ChangeState(pointsValue.UNVISITED);
            this.Iterator = 0;
        }

        public Point(pointsValue initState)
        {
            ChangeState(initState, initState == pointsValue.VISITED ? 1 : 0);
        }

        public void ChangeState(pointsValue newState)
        {
            ChangeState(newState, 0);
        }

        public void ChangeState(pointsValue newState, int iterator)
        {
            if (newState != pointsValue.VISITED && iterator == 0)
            {
                this.state = newState;
                this.Iterator = 0;
            }
            else if (newState == pointsValue.VISITED && iterator > 0)
            {
                this.state = newState;
                this.Iterator = iterator;
            }
            else
            {
                throw new NotRightGraphValueException($"Запрещена передача {newState.ToString()} c {iterator}");
            }
            if (PointStateChanged != null)
            {
                PointStateChanged();
            }
            if (newState == pointsValue.START && PointStartSet != null)
            {
                PointStartSet(this);
            }
            else if (newState == pointsValue.STOP && PointStopSet != null)
            {
                PointStopSet(this);
            }
        }
    }
}
