using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargaritaGOL
{
    public class CellState
    {
        public int Id { get; set; }

        public virtual Generation Generation { get; set; }

        [NotMapped] // IsAlive doesn't need to be saved to DB since every saved cell is alive.
        public bool IsAlive { get; set; }

        public int? XCord { get; set; }
        public int? YCord { get; set; }
        // Variables for coords are nullable since default values are valid coords and may cause confusion
        public int Neighbours { get; set; }

        public CellState()
        {
            this.IsAlive = false;
            Neighbours = 0;
            XCord = null;
            YCord = null;
        }

        public CellState(CellState cellToCopy) // Last step in the chain-copy, copies a cellstate to avoid issues with reference-types
        {
            this.IsAlive = true;
            this.Neighbours = cellToCopy.Neighbours;
            this.YCord = cellToCopy.YCord;
            this.XCord = cellToCopy.XCord;
        }
    }
}
