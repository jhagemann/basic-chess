using BasicChess.Rules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessForm
{
    public partial class Form1 : Form
    {
        Game chessGame = null;
        public Form1()
        {
            InitializeComponent();
            chessGame = new Game("p1", "White", "p2", "Black"); ;
            chessGame.SetUpBoard();
            MirrorBoard();
        }

        private void BlockSelected(object sender, EventArgs e)
        {
            PictureContainer blockSelected = (PictureContainer)sender;

        }

        private void MirrorBoard()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (chessGame.GameBoard.Blocks[x, y].ChessPiece != null)
                    {
                        string color = chessGame.GameBoard.Blocks[x, y].ChessPiece.Color;
                        string name = chessGame.GameBoard.Blocks[x, y].ChessPiece.Name.Substring(0,1);
                        System.Drawing.Icon c = new Icon("../../img/"+ color + " " + name + ".ico");
                        pc[x, y].Image = c.ToBitmap();
                    }
                }
            }
        }

    }
}
