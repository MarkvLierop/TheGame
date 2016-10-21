namespace Forms
{
    partial class MainMenuForm
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
            this.btnStartGameFromFile = new System.Windows.Forms.Button();
            this.btnQuitGame = new System.Windows.Forms.Button();
            this.btnCreateMap = new System.Windows.Forms.Button();
            this.btnStartGameFromDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartGameFromFile
            // 
            this.btnStartGameFromFile.Location = new System.Drawing.Point(132, 34);
            this.btnStartGameFromFile.Name = "btnStartGameFromFile";
            this.btnStartGameFromFile.Size = new System.Drawing.Size(383, 54);
            this.btnStartGameFromFile.TabIndex = 0;
            this.btnStartGameFromFile.Text = "Start Game From File";
            this.btnStartGameFromFile.UseVisualStyleBackColor = true;
            this.btnStartGameFromFile.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnQuitGame
            // 
            this.btnQuitGame.Location = new System.Drawing.Point(132, 257);
            this.btnQuitGame.Name = "btnQuitGame";
            this.btnQuitGame.Size = new System.Drawing.Size(383, 54);
            this.btnQuitGame.TabIndex = 4;
            this.btnQuitGame.Text = "Quit Game";
            this.btnQuitGame.UseVisualStyleBackColor = true;
            this.btnQuitGame.Click += new System.EventHandler(this.btnQuitGame_Click);
            // 
            // btnCreateMap
            // 
            this.btnCreateMap.Location = new System.Drawing.Point(132, 184);
            this.btnCreateMap.Name = "btnCreateMap";
            this.btnCreateMap.Size = new System.Drawing.Size(383, 54);
            this.btnCreateMap.TabIndex = 5;
            this.btnCreateMap.Text = "Create a map";
            this.btnCreateMap.UseVisualStyleBackColor = true;
            this.btnCreateMap.Click += new System.EventHandler(this.btnCreateMap_Click);
            // 
            // btnStartGameFromDatabase
            // 
            this.btnStartGameFromDatabase.Location = new System.Drawing.Point(132, 106);
            this.btnStartGameFromDatabase.Name = "btnStartGameFromDatabase";
            this.btnStartGameFromDatabase.Size = new System.Drawing.Size(383, 54);
            this.btnStartGameFromDatabase.TabIndex = 6;
            this.btnStartGameFromDatabase.Text = "Start Game From Database";
            this.btnStartGameFromDatabase.UseVisualStyleBackColor = true;
            this.btnStartGameFromDatabase.Click += new System.EventHandler(this.btnCreateFromDatabase_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 349);
            this.Controls.Add(this.btnStartGameFromDatabase);
            this.Controls.Add(this.btnCreateMap);
            this.Controls.Add(this.btnQuitGame);
            this.Controls.Add(this.btnStartGameFromFile);
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartGameFromFile;
        private System.Windows.Forms.Button btnQuitGame;
        private System.Windows.Forms.Button btnCreateMap;
        private System.Windows.Forms.Button btnStartGameFromDatabase;
    }
}