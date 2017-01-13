using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargaritaGOL
{
    class GOLHandler
    {
        public List<CellState> SavedGeneraton;
        public List<List<CellState>> SavedGame;
        private int currentRow;
        private int currentCol;

        

        public GOLHandler(int yRow, int xCol)
        {
            SavedGame = new List<List<CellState>>();
            SavedGeneraton = new List<CellState>();
        }

       

        public void SaveGame(CellState[,] cellGrid)
        {
            for (int y = 0; y < cellGrid.GetLength(0); y++)
            {
                for (int x = 0; x < cellGrid.GetLength(1); x++)
                {
                    if (cellGrid[y, x].IsAlive)
                    {
                        cellGrid[y, x].XCord = x;
                        cellGrid[y, x].YCord = y;
                    }
                }
            }

            foreach (CellState cellToCopy in cellGrid)
            {
                if (cellToCopy.IsAlive)
                {
                    CellState copiedCell = new CellState();

                    copiedCell.IsAlive = true;
                    copiedCell.Neighbours = cellToCopy.Neighbours;
                    copiedCell.XCord = cellToCopy.XCord;
                    copiedCell.YCord = cellToCopy.YCord;

                    SavedGeneraton.Add(copiedCell);
                }
            }

            SavedGame.Add(SavedGeneraton);
        }
        public CellState[,] CheckNeighbours(CellState[,] recievedCellGrid)
        {
            for (currentRow = 0; currentRow < recievedCellGrid.GetLength(0); currentRow++)
            {
                for (currentCol = 0; currentCol < recievedCellGrid.GetLength(1); currentCol++)
                {
                    var neighbours = 0;

                    for (var rowToCheck = currentRow - 1; rowToCheck < currentRow + 2; rowToCheck++)
                    {
                        if (rowToCheck < 0 || rowToCheck >= recievedCellGrid.GetLength(0))
                        {
                                continue;
                        }

                        for (var colToCheck = currentCol - 1; colToCheck < currentCol + 2; colToCheck++)
                        {
                            if (colToCheck < 0 || colToCheck >= recievedCellGrid.GetLength(1))
                            {
                                continue;
                            }

                            if (recievedCellGrid[rowToCheck, colToCheck].IsAlive == true)
                            {
                                neighbours++;
                            }
                        }
                    }

                    recievedCellGrid[currentRow, currentCol].Neighbours = neighbours;
                }

            }

            return recievedCellGrid;
        }


    }
}
