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
        private GOLHandler handler;
        private CellState[,] cellGrid;
        public List<CellState> SavedGeneration;
        public MainForm()
        {
            cellWidth = 20;
            cellHeight = 20;
            nrOfColumns = 14;
            nrOfRows = 13;
            cellGrid = new CellState [nrOfRows, nrOfColumns];
            handler = new GOLHandler(nrOfRows, nrOfColumns);
            SavedGeneration = new List<CellState>();
            InitializeComponent(); 
        }
 
        
                
        Panel Panel1 = new Panel();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Panel1);
            Panel1.Location = new Point(0, 0);
            Panel1.Size = new Size(cellWidth * nrOfColumns, cellHeight * nrOfRows);
            Panel1.Visible = true;

            for (int rowY = 0; rowY < nrOfRows; rowY++)
            {
                for (int colX = 0; colX < nrOfColumns; colX++)
                {
                    Button cell = new Button();
                    CellState state = new CellState();
                    cellGrid[rowY, colX] = state;
                    cell.Location = new Point((colX * cellWidth), (rowY * cellHeight));
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


        public void UpdateGameBoard(CellState[,] cellGeneration)
        {
            foreach(Control cell in Panel1.Controls)
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
        }

        private void SaveGame()
        {
            for(int y = 0; y < nrOfRows; y++)
            {
                for(int x = 0; x < nrOfColumns; x++)
                {
                    if(cellGrid[y, x].IsAlive)
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

                    SavedGeneration.Add(copiedCell);
                }
            }

         }

        private void GOLButton_Click(object sender, EventArgs e)
        {
            handler.CheckNeighbours(cellGrid);
            UpdateGameBoard(cellGrid);
            handler.SaveGame(cellGrid);
        }
    }
}
