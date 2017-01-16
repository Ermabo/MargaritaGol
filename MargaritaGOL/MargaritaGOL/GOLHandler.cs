using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargaritaGOL
{
    public class GOLHandler
    {
        //private CellState[,] cellGrid;
        //public List<CellState> SavedGeneraton;
        //public List<List<CellState>> SavedGame;
        //Not sure if needed

        private Game currentGame;
        private Generation currentGeneration;
        public List<Game> SavedGames;
        private int currentRow;
        private int currentCol;
        private int nrOfRows;
        private int nrOfColumns;

        

        public GOLHandler(int y, int x)
        {
            //SavedGame = new List<List<CellState>>();
            //SavedGeneraton = new List<CellState>();
            SavedGames = new List<Game>();
            currentGame = new Game();
            nrOfRows = y;
            nrOfColumns = x;
        }

       

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

        public void SaveGame()
        {
            Game gameToSave = new Game(currentGame);

            using (GOLContext db = new GOLContext())
            {
                db.Games.Add(gameToSave);
                db.SaveChanges();
            }
            
            SavedGames.Add(gameToSave);
        }

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
