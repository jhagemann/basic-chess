using System.Collections.Generic;
namespace ChessForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        PictureContainer[,] pc;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpBoard = new System.Windows.Forms.TableLayoutPanel();
            string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h" };
            pc = new PictureContainer[8,8];
            for (int x = 0; x < 8; x++)
			{
                    for (int y = 0; y < 8; y++)
			    {
                    pc[x,y] = new PictureContainer()
                    {                        
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        Location = new System.Drawing.Point(336, 329),
                        Margin = new System.Windows.Forms.Padding(0),
                        Name = letters[x] + (y+1),
                        Size = new System.Drawing.Size(48, 47),
                        TabIndex = 63,
                        TabStop = false,
                    };

                    if (x % 2 == 1 && y % 2 == 0 || x % 2 == 0 && y % 2 == 1)
                    {
                        pc[x, y].BackColor = System.Drawing.SystemColors.ControlLightLight;
                    }
                    else
                    {
                        pc[x,y].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                    }

                    pc[x, y].Click += new System.EventHandler(this.BlockSelected);
                    ((System.ComponentModel.ISupportInitialize)(pc[x, y])).BeginInit();
                    this.tlpBoard.Controls.Add(pc[x, y], x, 7-y);
                }

			}

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    ((System.ComponentModel.ISupportInitialize)(pc[x, y])).EndInit();
                }

            }
			
            this.tlpBoard.SuspendLayout();
           
            this.SuspendLayout();
            // 
            // tlpBoard
            // 
            this.tlpBoard.AutoSize = true;
            this.tlpBoard.ColumnCount = 8;
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
           
            this.tlpBoard.Location = new System.Drawing.Point(0, 0);
            this.tlpBoard.Name = "tlpBoard";
            this.tlpBoard.RowCount = 8;
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.Size = new System.Drawing.Size(384, 376);
            this.tlpBoard.TabIndex = 0;
           
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 377);
            this.Controls.Add(this.tlpBoard);
            this.Name = "Form1";
            this.Text = "Basic Chess";
            this.tlpBoard.ResumeLayout(false);
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    ((System.ComponentModel.ISupportInitialize)(pc[x, y])).EndInit();
                }

            }
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.TableLayoutPanel tlpBoard;
        
    }
}

