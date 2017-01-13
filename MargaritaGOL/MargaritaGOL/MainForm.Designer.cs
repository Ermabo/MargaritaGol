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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(652, 428);
            this.Controls.Add(this.GOLButton);
            this.Name = "MainForm";
            this.Text = "GOL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GOLButton;
    }
}

