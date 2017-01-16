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
            this.components = new System.ComponentModel.Container();
            this.GOLButton = new System.Windows.Forms.Button();
            this.generationLabel = new System.Windows.Forms.Label();
            this.savedGamesBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.savedGamesListBox = new System.Windows.Forms.ListBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.generationTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // GOLButton
            // 
            this.GOLButton.Location = new System.Drawing.Point(441, 127);
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
            this.generationLabel.Location = new System.Drawing.Point(478, 182);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.Size = new System.Drawing.Size(71, 13);
            this.generationLabel.TabIndex = 1;
            this.generationLabel.Text = "Generation: 1";
            // 
            // savedGamesBox
            // 
            this.savedGamesBox.FormattingEnabled = true;
            this.savedGamesBox.Location = new System.Drawing.Point(441, 198);
            this.savedGamesBox.Name = "savedGamesBox";
            this.savedGamesBox.Size = new System.Drawing.Size(153, 21);
            this.savedGamesBox.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(519, 127);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save Game";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(441, 156);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // savedGamesListBox
            // 
            this.savedGamesListBox.FormattingEnabled = true;
            this.savedGamesListBox.Location = new System.Drawing.Point(441, 23);
            this.savedGamesListBox.Name = "savedGamesListBox";
            this.savedGamesListBox.Size = new System.Drawing.Size(153, 95);
            this.savedGamesListBox.TabIndex = 5;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(519, 156);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load Game";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // generationTimer
            // 
            this.generationTimer.Interval = 1000;
            this.generationTimer.Tick += new System.EventHandler(this.generationTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(652, 428);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.savedGamesListBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.saveButton);
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
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ListBox savedGamesListBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Timer generationTimer;
    }
}

