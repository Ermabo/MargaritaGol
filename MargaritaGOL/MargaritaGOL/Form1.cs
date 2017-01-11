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
        public Form1()
        {
            InitializeComponent(); 
        }
        /// <summary>
        /// Sätter storleken på Matrisen och storleken på själva cellen
        /// </summary>
        static int Colums = 30;
        static int Rows = 20;
        static int Depth = 3;

        int CellWidth = 20;
        int Cellhight = 20;
        bool DOA;       //Borde göra en True False istället för " Dead/Alive "

        /// <summary>
        /// Två dimensionell array som cellerna ska plaseras i, Skapar även en panel som allt händer på
        /// </summary>
        string[,,] GridCell = new string[Colums, Rows, Depth];
        Panel Panel1 = new Panel();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Panel1);
            Panel1.Location = new Point(0, 0);
            Panel1.Size = new Size(CellWidth * Colums, Cellhight * Rows);
            Panel1.Visible = true;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Colums; j++)
                {
                    Button cell = new Button();
                    GridCell[j, i, 0] = "Dead";
                    cell.Location = new Point((j * CellWidth), (i * Cellhight));
                    cell.Size = new Size(CellWidth, Cellhight);
                    cell.BackColor = Color.White;

                    cell.Click += Cell_Click;
                    Panel1.Controls.Add(cell);
                }
            }
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Button CellClick = ((Button)sender);
            int xI = (int)(CellClick.Location.X / CellWidth);
            int yI = (int)(CellClick.Location.Y / Cellhight);

            if (CellClick.BackColor == Color.White)
            {
                CellClick.BackColor = Color.Black;
                GridCell[xI, yI, 0] = "Alive";
            }
            else
            {
                CellClick.BackColor = Color.White;
                GridCell[xI, yI, 0] = "Dead";
            }
            //throw new NotImplementedException();
        }

       public void NeighbourCells()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Colums; j++)
                {
                    int neighbourCells = 0;

                    for (int k = i - 0; k < i + 2; k++)
                    {
                        for (int l = j - 1; l < j + 2; l++)
                        {
                            if (k < 0  || k == Rows)
                            {
                                continue;
                            }
                            
                        }
                        GridCell[j, i, 1] = neighbourCells.ToString();
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
