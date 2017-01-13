﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargaritaGOL
{
    public class Generation
    {
        public int Id { get; set; }

        public List<CellState> CellList;

        public Generation(int generationNumber)
        {
            Id = generationNumber;
            CellList = new List<CellState>();
        }
    }
}
