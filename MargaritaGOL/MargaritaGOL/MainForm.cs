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
        private bool replayRunning;
        private GOLHandler handler;
        private CellState[,] cellGrid;
        private List<Generation> savedGenerations;
        Panel buttonPanel;
        public MainForm()
        {
            cellWidth = 30;
            cellHeight = 30;
            nrOfColumns = 30;
            nrOfRows = 20;
            generationNumber = 1;
            cellGrid = new CellState [nrOfRows, nrOfColumns];
            handler = new GOLHandler(nrOfRows, nrOfColumns);
            buttonPanel = new Panel();
            InitializeComponent();
            loadButton.Enabled = false;
            deleteButton.Enabled = false;
            PopulateListBox();
        }
 
        
                
        

        /// <summary>
        /// Loads the MainForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(buttonPanel);
            buttonPanel.Location = new Point(100, 50);
            buttonPanel.Size = new Size(cellWidth * nrOfColumns, cellHeight * nrOfRows);
            buttonPanel.Visible = true;


            for (int selectedRow = 0; selectedRow < nrOfRows; selectedRow++)
            {
                for (int selectedCol = 0; selectedCol < nrOfColumns; selectedCol++)
                {
                    Button cell = new Button();
                    //cell.FlatStyle = FlatStyle.Flat;
                    CellState state = new CellState();
                    cellGrid[selectedRow, selectedCol] = state;
                    cell.Location = new Point((selectedCol * cellWidth), (selectedRow * cellHeight));
                    cell.Size = new Size(cellWidth, cellHeight);
                    cell.BackColor = Color.White;

                    cell.Click += Cell_Click;
                    buttonPanel.Controls.Add(cell);
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


        public void NextGeneration()
        {
            foreach(Button cell in buttonPanel.Controls)
            {
                var row = cell.Top / cellHeight;
                var col = cell.Left / cellWidth;
                var neighbours = cellGrid[row, col].Neighbours;

                if(neighbours < 3 || neighbours > 4)
                {
                    cellGrid[row, col].IsAlive = false;
                    cell.BackColor = Color.White;
                }

                else if(neighbours == 3)
                {
                    cellGrid[row, col].IsAlive = true;
                    cell.BackColor = Color.Black;
                }

            }
            generationNumber++;
            generationLabel.Text = "Generation: " + generationNumber.ToString();
        }

        public void DisplayGeneration()
        {
            //todo: Baka in den här metoden i NextGen(?)
            foreach (Button cell in buttonPanel.Controls)
            {
                var row = cell.Top / cellHeight;
                var col = cell.Left / cellWidth;

                if (cellGrid[row, col].IsAlive == false)
                {
                    cell.BackColor = Color.White;
                }

                else if (cellGrid[row, col].IsAlive == true)
                {
                    cell.BackColor = Color.Black;
                }
            }
        }



        /// <summary>
        /// Button click event that advances generation, also saves the upcoming generation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GOLButton_Click(object sender, EventArgs e)
        {
            if(generationTimer.Enabled)
            {
                generationTimer.Stop();
                GOLButton.Text = "Start";
            }
            else
            {
                generationTimer.Start();
                GOLButton.Text = "Stop";
            }
                 
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(generationNumber == 1) // Saves the very first generation at new game or reset
                handler.SaveGeneration(cellGrid, generationNumber);

            handler.SaveGeneration(cellGrid, generationNumber);
            handler.SaveGame();
            PopulateListBox();
        }


        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetGame();
            savedGamesListBox.ClearSelected();
        }

        private void ResetGame()
        {
            loadButton.Enabled = false;
            deleteButton.Enabled = false;
            labelLoaded.Visible = false;
            ClearBoard();
            handler.ClearGenerationList();
            generationNumber = 1;
            generationLabel.Text = "Generation: " + generationNumber.ToString();
        }

        private void ClearBoard()
        {
            foreach (Control cell in buttonPanel.Controls)
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

            using (GOLContext db = new GOLContext())
            {
                foreach(Game g in db.Games)
                {
                    savedGamesListBox.Items.Add(g);
                }
            }

        }


        private void PlaySavedGame(int genToPlay)
        {
            genToPlay -= 1; //-1 because the first element in a list is 0
            foreach (CellState cell in savedGenerations[genToPlay].CellList)
            {
                cellGrid[(int)cell.YCord, (int)cell.XCord] = new CellState(cell);
            }

            DisplayGeneration();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            ResetGame();
            replayRunning = true;
            labelLoaded.Visible = true;
            Game gameToLoad = (Game)savedGamesListBox.SelectedItem;
            savedGenerations = handler.LoadSavedGame(gameToLoad.Id);
            savedGamesListBox.ClearSelected();
        }

        private void generationTimer_Tick(object sender, EventArgs e)
        {

            switch (replayRunning)
            {
                case true:

                    if (generationNumber <= savedGenerations.Count)
                    {
                        ClearBoard();
                        PlaySavedGame(generationNumber);
                        generationNumber++;
                        generationLabel.Text = "Generation: " + (generationNumber - 1).ToString();
                    }
                    else
                    {
                        generationTimer.Stop();
                        GOLButton.Text = "Start";
                        replayRunning = false;
                    }
                        
                 break;

                case false:

                    handler.CheckNeighbours(cellGrid);
                    handler.SaveGeneration(cellGrid, generationNumber);
                    NextGeneration();

                    break;
            }


        }

        private void savedGamesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(savedGamesListBox.SelectedItem != null)
            {
                loadButton.Enabled = true;
                deleteButton.Enabled = true;
            }
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            using(GOLContext db = new GOLContext())
            {
                Game test = (Game)savedGamesListBox.SelectedItem;

                var gameToDelete = db.Games.SingleOrDefault(x => x.Id == test.Id);

                foreach (Generation gen in gameToDelete.GenerationList.ToList())
                {
                    foreach (CellState cell in gen.CellList.ToList())
                    {
                        db.CellStates.Remove(cell);
                    }

                    db.Generations.Remove(gen);

                    if (savedGamesListBox.Items != null)
                    {
                        deleteButton.Enabled = false;
                        loadButton.Enabled = false;
                    }
                        
                }

                if (gameToDelete != null)
                {
                    db.Games.Remove(gameToDelete);
                    db.SaveChanges();
                }
            }

            PopulateListBox();
        }

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            generationTimer.Interval = trackBarSpeed.Value;
            labelSpeed.Text = "Interval speed: " + generationTimer.Interval.ToString();
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            ResetGame();
            ClearBoard();
            Random randomRow = new Random(System.DateTime.Now.Millisecond);
            Random randomCol = new Random(Guid.NewGuid().GetHashCode());
            Random randomCells = new Random(Guid.NewGuid().GetHashCode());
            int nrOfCells = randomCells.Next(20, 200);

            for (int i = 0; i < nrOfCells; i++)
            {
                var selectedRow = randomRow.Next(1, nrOfRows);
                var selectedCol = randomCol.Next(1, nrOfColumns);

                cellGrid[selectedRow, selectedCol].IsAlive = true;

            }

            DisplayGeneration();
        }
    }
}
