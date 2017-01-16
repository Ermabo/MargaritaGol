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
            this.saveButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.savedGamesListBox = new System.Windows.Forms.ListBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.generationTimer = new System.Windows.Forms.Timer(this.components);
            this.menuGroupBox = new System.Windows.Forms.GroupBox();
            this.randomButton = new System.Windows.Forms.Button();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.deleteButton = new System.Windows.Forms.Button();
            this.labelLoaded = new System.Windows.Forms.Label();
            this.menuGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // GOLButton
            // 
            this.GOLButton.Location = new System.Drawing.Point(19, 236);
            this.GOLButton.Name = "GOLButton";
            this.GOLButton.Size = new System.Drawing.Size(75, 23);
            this.GOLButton.TabIndex = 0;
            this.GOLButton.Text = "Start";
            this.GOLButton.UseVisualStyleBackColor = true;
            this.GOLButton.Click += new System.EventHandler(this.GOLButton_Click);
            // 
            // generationLabel
            // 
            this.generationLabel.AutoSize = true;
            this.generationLabel.Location = new System.Drawing.Point(59, 330);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.Size = new System.Drawing.Size(71, 13);
            this.generationLabel.TabIndex = 1;
            this.generationLabel.Text = "Generation: 1";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(97, 236);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save Game";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(19, 294);
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
            this.savedGamesListBox.Location = new System.Drawing.Point(19, 19);
            this.savedGamesListBox.Name = "savedGamesListBox";
            this.savedGamesListBox.Size = new System.Drawing.Size(153, 95);
            this.savedGamesListBox.TabIndex = 5;
            this.savedGamesListBox.SelectedIndexChanged += new System.EventHandler(this.savedGamesListBox_SelectedIndexChanged);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(97, 294);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load Game";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // generationTimer
            // 
            this.generationTimer.Interval = 300;
            this.generationTimer.Tick += new System.EventHandler(this.generationTimer_Tick);
            // 
            // menuGroupBox
            // 
            this.menuGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuGroupBox.Controls.Add(this.labelLoaded);
            this.menuGroupBox.Controls.Add(this.randomButton);
            this.menuGroupBox.Controls.Add(this.labelSpeed);
            this.menuGroupBox.Controls.Add(this.trackBarSpeed);
            this.menuGroupBox.Controls.Add(this.deleteButton);
            this.menuGroupBox.Controls.Add(this.savedGamesListBox);
            this.menuGroupBox.Controls.Add(this.generationLabel);
            this.menuGroupBox.Controls.Add(this.loadButton);
            this.menuGroupBox.Controls.Add(this.GOLButton);
            this.menuGroupBox.Controls.Add(this.resetButton);
            this.menuGroupBox.Controls.Add(this.saveButton);
            this.menuGroupBox.Location = new System.Drawing.Point(440, 12);
            this.menuGroupBox.Name = "menuGroupBox";
            this.menuGroupBox.Size = new System.Drawing.Size(200, 377);
            this.menuGroupBox.TabIndex = 7;
            this.menuGroupBox.TabStop = false;
            this.menuGroupBox.Text = "Menu";
            // 
            // randomButton
            // 
            this.randomButton.Location = new System.Drawing.Point(97, 265);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(75, 23);
            this.randomButton.TabIndex = 10;
            this.randomButton.Text = "Random";
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(41, 121);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(80, 13);
            this.labelSpeed.TabIndex = 9;
            this.labelSpeed.Text = "Interval speed: ";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(44, 137);
            this.trackBarSpeed.Maximum = 600;
            this.trackBarSpeed.Minimum = 300;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trackBarSpeed.RightToLeftLayout = true;
            this.trackBarSpeed.Size = new System.Drawing.Size(104, 45);
            this.trackBarSpeed.TabIndex = 8;
            this.trackBarSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarSpeed.Value = 450;
            this.trackBarSpeed.ValueChanged += new System.EventHandler(this.trackBarSpeed_ValueChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(19, 265);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete Game";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // labelLoaded
            // 
            this.labelLoaded.AutoSize = true;
            this.labelLoaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoaded.Location = new System.Drawing.Point(30, 168);
            this.labelLoaded.Name = "labelLoaded";
            this.labelLoaded.Size = new System.Drawing.Size(142, 25);
            this.labelLoaded.TabIndex = 11;
            this.labelLoaded.Text = "Game Loaded!";
            this.labelLoaded.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(652, 428);
            this.Controls.Add(this.menuGroupBox);
            this.Name = "MainForm";
            this.Text = "GOL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuGroupBox.ResumeLayout(false);
            this.menuGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GOLButton;
        private System.Windows.Forms.Label generationLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ListBox savedGamesListBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Timer generationTimer;
        private System.Windows.Forms.GroupBox menuGroupBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Button randomButton;
        private System.Windows.Forms.Label labelLoaded;
    }
}

