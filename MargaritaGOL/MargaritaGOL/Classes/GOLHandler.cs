using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargaritaGOL
{
    public class GOLHandler
    {
        private Game currentGame;
        private Generation currentGeneration;
        public List<Game> SavedGames;
        private int currentRow;
        private int currentCol;
        private int nrOfRows;
        private int nrOfColumns;

        
        
        public GOLHandler(int y, int x)
        {
            SavedGames = new List<Game>();
            currentGame = new Game();
            nrOfRows = y;
            nrOfColumns = x;
        }

       
        /// <summary>
        /// Gives each live cell coords and saves the current generation to a list
        /// </summary>
        /// <param name="cellGrid"></param>
        /// <param name="generationNumber"></param>
        public void SaveGeneration(CellState[,] cellGrid, int generationNumber)
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

            currentGeneration = new Generation(generationNumber);

            foreach (CellState cellToCopy in cellGrid)
            {
                if (cellToCopy.IsAlive)
                {
                    CellState copiedCell = new CellState(cellToCopy);
                    currentGeneration.CellList.Add(copiedCell);
                }
            }

            currentGame.GenerationList.Add(currentGeneration);
        }

        /// <summary>
        /// Saves the current game to local-DB using Entity Framework
        /// </summary>
        public void SaveGame()
        {
            Game gameToSave = new Game(currentGame); //Copies the current game to avoid reference-type problems

            using (GOLContext db = new GOLContext())
            {
                db.Games.Add(gameToSave);
                db.SaveChanges();
            }

            SavedGames.Add(gameToSave);
        }

        /// <summary>
        /// Loads the game from local-db using Entity Framework, chosen by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<Generation> LoadSavedGame(int index)
        {
            List<Generation> savedGenerations = new List<Generation>();

            using (GOLContext db = new GOLContext())
            {

                Game loadedGame = (from Games in db.Games
                                 where Games.Id == index
                                 select Games).FirstOrDefault();

                foreach (Generation gen in loadedGame.GenerationList)
                {
                    Generation newGen = new Generation(gen);
                    savedGenerations.Add(newGen);
                }
            }

            return savedGenerations;
        }

        public void ClearGenerationList()
        {
            currentGame.GenerationList.Clear();
        }

        /// <summary>
        /// Checks the number of live neighbours of each cell
        /// </summary>
        /// <param name="recievedCellGrid"></param>
        /// <returns></returns>
        public CellState[,] CheckNeighbours(CellState[,] recievedCellGrid)
        {
            for (currentRow = 0; currentRow < recievedCellGrid.GetLength(0); currentRow++)
            {
                for (currentCol = 0; currentCol < recievedCellGrid.GetLength(1); currentCol++)
                {
                    var neighbours = 0;

                    // Checks neighbours in a square around the current cell, starting from top left

                    for (var rowToCheck = currentRow - 1; rowToCheck < currentRow + 2; rowToCheck++) 
                    {
                        if (rowToCheck < 0 || rowToCheck >= recievedCellGrid.GetLength(0)) // Fail-check to make sure index in 2d array is not out of range
                        {
                                continue;
                        }

                        for (var colToCheck = currentCol - 1; colToCheck < currentCol + 2; colToCheck++)
                        {
                            if (colToCheck < 0 || colToCheck >= recievedCellGrid.GetLength(1)) // Fail-check to make sure index in 2d array is not out of range
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
