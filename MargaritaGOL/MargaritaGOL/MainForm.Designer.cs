namespace MargaritaGOL
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.GOLButton = new System.Windows.Forms.Button();
            this.generationLabel = new System.Windows.Forms.Label();
            this.savedGamesBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // GOLButton
            // 
            this.GOLButton.Location = new System.Drawing.Point(541, 135);
            this.GOLButton.Name = "GOLButton";
            this.GOLButton.Size = new System.Drawing.Size(75, 23);
            this.GOLButton.TabIndex = 0;
            this.GOLButton.Text = "Next Generation";
            this.GOLButton.UseVisualStyleBackColor = true;
            this.GOLButton.Click += new System.EventHandler(this.GOLButton_Click);
            // 
            // generationLabel
            // 
            this.generationLabel.AutoSize = true;
            this.generationLabel.Location = new System.Drawing.Point(545, 161);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.Size = new System.Drawing.Size(71, 13);
            this.generationLabel.TabIndex = 1;
            this.generationLabel.Text = "Generation: 1";
            // 
            // savedGamesBox
            // 
            this.savedGamesBox.FormattingEnabled = true;
            this.savedGamesBox.Location = new System.Drawing.Point(519, 80);
            this.savedGamesBox.Name = "savedGamesBox";
            this.savedGamesBox.Size = new System.Drawing.Size(121, 21);
            this.savedGamesBox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(652, 428);
            this.Controls.Add(this.savedGamesBox);
            this.Controls.Add(this.generationLabel);
            this.Controls.Add(this.GOLButton);
            this.Name = "MainForm";
            this.Text = "GOL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GOLButton;
        private System.Windows.Forms.Label generationLabel;
        private System.Windows.Forms.ComboBox savedGamesBox;
    }
}

