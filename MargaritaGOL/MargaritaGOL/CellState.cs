using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargaritaGOL
{
    public class CellState
    {
        public bool IsAlive { get; set; }

        public int? XCord { get; set; }
        public int? YCord { get; set; }
        public int Neighbours { get; set; }
        public CellState()
        {
            this.IsAlive = false;
            Neighbours = 0;
            XCord = null;
            YCord = null;
        }

        public CellState(CellState cellToCopy)
        {
            this.IsAlive = cellToCopy.IsAlive;
            this.Neighbours = cellToCopy.Neighbours;
            this.YCord = cellToCopy.YCord;
            this.XCord = cellToCopy.XCord;
        }
    }
}
