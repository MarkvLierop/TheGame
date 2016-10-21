namespace Game
{
    partial class GameForm
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
            this.pbGameField = new System.Windows.Forms.PictureBox();
            this.tmrGameTimer = new System.Windows.Forms.Timer(this.components);
            this.tmrPUSpeed = new System.Windows.Forms.Timer(this.components);
            this.tmrPUInvisible = new System.Windows.Forms.Timer(this.components);
            this.tmrPUInvulnerable = new System.Windows.Forms.Timer(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMapName = new System.Windows.Forms.TextBox();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameField)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGameField
            // 
            this.pbGameField.Location = new System.Drawing.Point(21, 24);
            this.pbGameField.Name = "pbGameField";
            this.pbGameField.Size = new System.Drawing.Size(811, 500);
            this.pbGameField.TabIndex = 0;
            this.pbGameField.TabStop = false;
            this.pbGameField.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGameField_Paint);
            // 
            // tmrGameTimer
            // 
            this.tmrGameTimer.Interval = 300;
            this.tmrGameTimer.Tick += new System.EventHandler(this.tmrGameTimer_Tick);
            // 
            // tmrPUSpeed
            // 
            this.tmrPUSpeed.Tick += new System.EventHandler(this.tmrPUSpeed_Tick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(843, 476);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save map";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMapName
            // 
            this.txtMapName.Location = new System.Drawing.Point(843, 505);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(100, 20);
            this.txtMapName.TabIndex = 2;
            this.txtMapName.Visible = false;
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblHealth.Location = new System.Drawing.Point(839, 24);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(120, 24);
            this.lblHealth.TabIndex = 3;
            this.lblHealth.Text = "HealthPoints:";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblPoints.Location = new System.Drawing.Point(839, 71);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(66, 24);
            this.lblPoints.TabIndex = 4;
            this.lblPoints.Text = "Points:";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 554);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.lblHealth);
            this.Controls.Add(this.txtMapName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pbGameField);
            this.DoubleBuffered = true;
            this.Name = "GameForm";
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGameField;
        private System.Windows.Forms.Timer tmrGameTimer;
        private System.Windows.Forms.Timer tmrPUSpeed;
        private System.Windows.Forms.Timer tmrPUInvisible;
        private System.Windows.Forms.Timer tmrPUInvulnerable;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label lblPoints;
    }
}

