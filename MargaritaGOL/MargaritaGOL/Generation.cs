using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargaritaGOL
{
    public class Generation
    {
        public int Id { get; set; }

        public virtual List<CellState> CellList { get; set; }
        public virtual Game Game { get; set; }

        public Generation()
        {

        }
        public Generation(int generationNumber)
        {
            Id = generationNumber;
            CellList = new List<CellState>();
        }

        public Generation(Generation genToCopy)
        {
            this.Id = genToCopy.Id;
            CellList = new List<CellState>();
            foreach (CellState cellToCopy in genToCopy.CellList)
            {
                CellState newCell = new CellState(cellToCopy);
                CellList.Add(newCell);
            }
        }
    }
}
