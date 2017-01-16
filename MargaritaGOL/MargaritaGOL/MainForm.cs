using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MargaritaGOL
{
    public partial class MainForm : Form
    {
        private int cellWidth;
        private int cellHeight;
        private int nrOfColumns;
        private int nrOfRows;
        private int generationNumber;
        private GOLHandler handler;
        private CellState[,] cellGrid;
        private List<Generation> savedGenerations;
        //public List<CellState> SavedGeneration;
        public MainForm()
        {
            cellWidth = 20;
            cellHeight = 20;
            nrOfColumns = 14;
            nrOfRows = 13;
            generationNumber = 1;
            cellGrid = new CellState [nrOfRows, nrOfColumns];
            handler = new GOLHandler(nrOfRows, nrOfColumns);
            //SavedGeneration = new List<CellState>();
            InitializeComponent(); 
        }
 
        
                
        Panel Panel1 = new Panel();

        /// <summary>
        /// Loads the MainForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Panel1);
            Panel1.Location = new Point(0, 0);
            Panel1.Size = new Size(cellWidth * nrOfColumns, cellHeight * nrOfRows);
            Panel1.Visible = true;

            for (int selectedRow = 0; selectedRow < nrOfRows; selectedRow++)
            {
                for (int selectedCol = 0; selectedCol < nrOfColumns; selectedCol++)
                {
                    Button cell = new Button();
                    CellState state = new CellState();
                    cellGrid[selectedRow, selectedCol] = state;
                    cell.Location = new Point((selectedCol * cellWidth), (selectedRow * cellHeight));
                    cell.Size = new Size(cellWidth, cellHeight);
                    cell.BackColor = Color.White;

                    cell.Click += Cell_Click;
                    Panel1.Controls.Add(cell);
                }
            }
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Button CellClick = ((Button)sender);
            int yI = (int)(CellClick.Location.Y / cellHeight);
            int xI = (int)(CellClick.Location.X / cellWidth);

            if (CellClick.BackColor == Color.White)
            {
                CellClick.BackColor = Color.Black;
                cellGrid[yI, xI].IsAlive = true;
            }
            else
            {
                CellClick.BackColor = Color.White;
                cellGrid[yI, xI].IsAlive = false;
            }
            
        }


        public void NextGeneration(CellState[,] cellGeneration)
        {
            foreach(Button cell in Panel1.Controls)
            {
                var row = cell.Top / cellHeight;
                var col = cell.Left / cellWidth;
                var neighbours = cellGeneration[row, col].Neighbours;

                if(neighbours < 3 || neighbours > 4)
                {
                    cellGeneration[row, col].IsAlive = false;
                    cell.BackColor = Color.White;
                }

                else if(neighbours == 3)
                {
                    cellGeneration[row, col].IsAlive = true;
                    cell.BackColor = Color.Black;
                }

            }
            generationNumber++;
            generationLabel.Text = "Generation: " + generationNumber.ToString();
        }

        public void DisplayGeneration(CellState[,] cellGeneration)
        {
            //todo: Baka in den här metoden i NextGen(?)
            foreach (Button cell in Panel1.Controls)
            {
                var row = cell.Top / cellHeight;
                var col = cell.Left / cellWidth;

                if (cellGeneration[row, col].IsAlive == false)
                {
                    cell.BackColor = Color.White;
                }

                else if (cellGeneration[row, col].IsAlive == true)
                {
                    cell.BackColor = Color.Black;
                }
            }
        }

        //private void SaveGame()
        //{
        //    for(int y = 0; y < nrOfRows; y++)
        //    {
        //        for(int x = 0; x < nrOfColumns; x++)
        //        {
        //            if(cellGrid[y, x].IsAlive)
        //            {
        //                cellGrid[y, x].XCord = x;
        //                cellGrid[y, x].YCord = y;
        //            }           
        //        }
        //    }

        //    foreach (CellState cellToCopy in cellGrid)
        //    {
        //        if (cellToCopy.IsAlive)
        //        {
        //            CellState copiedCell = new CellState();

        //            copiedCell.IsAlive = true;
        //            copiedCell.Neighbours = cellToCopy.Neighbours;
        //            copiedCell.XCord = cellToCopy.XCord;
        //            copiedCell.YCord = cellToCopy.YCord;

        //            SavedGeneration.Add(copiedCell);
        //        }
        //    }

        // }


        /// <summary>
        /// Button click event that advances generation, also saves the upcoming generation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GOLButton_Click(object sender, EventArgs e)
        {
            handler.CheckNeighbours(cellGrid);
            handler.SaveGeneration(cellGrid, generationNumber);
            NextGeneration(cellGrid); 
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(generationNumber == 1) // Saves the very first generation at new game or reset
                handler.SaveGeneration(cellGrid, generationNumber);
            
            handler.SaveGame();
            PopulateListBox();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetBoard();
        }

        private void ResetBoard()
        {
            handler.ClearGenerationList();
            generationNumber = 1;
            generationLabel.Text = "Generation: " + generationNumber.ToString();

            foreach (Control cell in Panel1.Controls)
            {
                cell.BackColor = Color.White;
            }

            foreach (CellState cell in cellGrid)
            {
                cell.IsAlive = false;
                cell.Neighbours = 0;
                cell.XCord = null;
                cell.YCord = null;
            }
        }

        private void PopulateListBox()
        {
            savedGamesListBox.Items.Clear();

            foreach (Game g in handler.SavedGames)
            {
                savedGamesListBox.Items.Add(g);
            }
        }

        private void LoadSavedGame(Game gameToLoad)
        {

            //Probably not needed
            //cellGrid = new CellState[nrOfRows, nrOfColumns];

            //for (int selectedRow = 0; selectedRow < nrOfRows; selectedRow++)
            //{
            //    for (int selectedCol = 0; selectedCol < nrOfColumns; selectedCol++)
            //    {
            //        cellGrid[selectedRow, selectedCol] = new CellState();
            //    }
            //}
            savedGenerations = new List<Generation>();

            foreach (Generation gen in gameToLoad.GenerationList)
            {

                //foreach (CellState cell in gen.CellList)
                //{
                //    cellGrid[(int)cell.YCord, (int)cell.XCord] = cell;
                //}

                Generation newGen = new Generation(gen);
                savedGenerations.Add(newGen);

            }



        }

        private void PlaySavedGame(int genToPlay)
        {
            genToPlay -= 1;
            foreach (CellState cell in savedGenerations[genToPlay].CellList)
            {
                cellGrid[(int)cell.YCord, (int)cell.XCord] = new CellState(cell);
            }

            DisplayGeneration(cellGrid);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            ResetBoard();
            LoadSavedGame((Game)savedGamesListBox.SelectedItem);
            generationTimer.Start();

            //Todo: Gör så att den går igenom alla generations och tickar igenom dom, flytta allt under till en metod
            //foreach (CellState cell in savedGenerations[0].CellList)
            //{
            //    cellGrid[(int)cell.YCord, (int)cell.XCord] = new CellState(cell);
            //}

            //ShowFirstGeneration(cellGrid);
        }

        private void generationTimer_Tick(object sender, EventArgs e)
        {

            

            foreach (Control cell in Panel1.Controls)
            {
                cell.BackColor = Color.White;
            }

            foreach (CellState cell in cellGrid)
            {
                cell.IsAlive = false;
                cell.Neighbours = 0;
                cell.XCord = null;
                cell.YCord = null;
            }


            if (generationNumber <= savedGenerations.Count)
            {
                PlaySavedGame(generationNumber);
                generationNumber++;
            }
            else
                generationTimer.Stop();

        }
    }
}
