﻿using System;
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
        /// Draws out the board of buttons
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

        /// <summary>
        /// Click event for turning cells alive/dead manually
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Draws the next generation on board
        /// </summary>
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


        /// <summary>
        /// Displays the currently loaded generation
        /// </summary>
        public void DisplayGeneration()
        {
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
        /// Starts the timer, or stops it if it's started
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

        /// <summary>
        /// Calls all the save functions and refreshes the saved games listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Resets the current game
        /// </summary>
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

        /// <summary>
        /// Clears the board to default state
        /// </summary>
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

        /// <summary>
        /// Displays the saved games from DB
        /// </summary>
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
            foreach (CellState cell in savedGenerations[genToPlay].CellList) //Copies the loaded generation to avoid reference-type problems
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
                case true: //If there is a game loaded, it displays all the generations of that game in intervalls

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

                case false: // Else if there is no game loaded, then display next generation for every intervall

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
                Game selectedGame = (Game)savedGamesListBox.SelectedItem;

                var gameToDelete = db.Games.SingleOrDefault(x => x.Id == selectedGame.Id);

                foreach (Generation gen in gameToDelete.GenerationList.ToList())
               // Removes each cell state in every generation then deletes all generations for that game in DB
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

        /// <summary>
        /// Sets the timer interval when you move the track bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            generationTimer.Interval = trackBarSpeed.Value;
            labelSpeed.Text = "Interval speed: " + generationTimer.Interval.ToString();
        }

        /// <summary>
        /// Populates the board with a random amount of live cells
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
