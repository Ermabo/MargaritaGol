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
    public partial class Form1 : Form
    {
        private int cellWidth;
        private int cellHeight;
        //bool DOA;       Borde göra en True False istället för " Dead/Alive "
        private int nrOfColumns;
        private int nrOfRows;
        string[,] GridCell;
        public Form1()
        {
            cellWidth = 20;
            cellHeight = 20;
            nrOfColumns = 14;
            nrOfRows = 13;
            GridCell = new string[nrOfColumns, nrOfRows];
            InitializeComponent(); 
        }
 
        
                
        Panel Panel1 = new Panel();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Panel1);
            Panel1.Location = new Point(0, 0);
            Panel1.Size = new Size(cellWidth * nrOfColumns, cellHeight * nrOfRows);
            Panel1.Visible = true;

            for (int i = 0; i < nrOfRows; i++)
            {
                for (int j = 0; j < nrOfColumns; j++)
                {
                    Button cell = new Button();
                    GridCell[j, i] = "Dead";
                    cell.Location = new Point((j * cellWidth), (i * cellHeight));
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
            int xI = (int)(CellClick.Location.X / cellWidth);
            int yI = (int)(CellClick.Location.Y / cellHeight);

            if (CellClick.BackColor == Color.White)
            {
                CellClick.BackColor = Color.Black;
                GridCell[xI, yI] = "Alive";
            }
            else
            {
                CellClick.BackColor = Color.White;
                GridCell[xI, yI] = "Dead";
            }
            //throw new NotImplementedException();
        }

       public void NeighbourCells()
        {
            for (int i = 0; i < nrOfRows; i++)
            {
                for (int j = 0; j < nrOfColumns; j++)
                {
                    int neighbourCells = 0;

                    for (int k = i - 0; k < i + 2; k++)
                    {
                        for (int l = j - 1; l < j + 2; l++)
                        {
                            if (k < 0  || k == nrOfRows)
                            {
                                continue;
                            }
                            
                        }
                        GridCell[j, i] = neighbourCells.ToString();
                    }
                }
            }
        }

        public void CheckNeigbours()
        {
            foreach(Control cell in Panel1.Controls)
            {

            }
        }

    }
}
