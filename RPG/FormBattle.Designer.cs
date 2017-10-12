namespace RPG
{
    partial class FormBattle
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
            this.pictureBoxPlayer = new System.Windows.Forms.PictureBox();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.pictureBoxEnemy = new System.Windows.Forms.PictureBox();
            this.groupBoxPlayer = new System.Windows.Forms.GroupBox();
            this.groupBoxEnemy = new System.Windows.Forms.GroupBox();
            this.labelPlayerHP = new System.Windows.Forms.Label();
            this.progressBarPlayerHP = new System.Windows.Forms.ProgressBar();
            this.progressBarPlayerMP = new System.Windows.Forms.ProgressBar();
            this.labelPlayerMP = new System.Windows.Forms.Label();
            this.progressBarPlayerXP = new System.Windows.Forms.ProgressBar();
            this.labelPlayerXP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy)).BeginInit();
            this.groupBoxPlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPlayer
            // 
            this.pictureBoxPlayer.Image = global::RPG.Properties.Resources.Player;
            this.pictureBoxPlayer.Location = new System.Drawing.Point(12, 139);
            this.pictureBoxPlayer.Name = "pictureBoxPlayer";
            this.pictureBoxPlayer.Size = new System.Drawing.Size(136, 153);
            this.pictureBoxPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPlayer.TabIndex = 0;
            this.pictureBoxPlayer.TabStop = false;
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxActions.Location = new System.Drawing.Point(12, 311);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(512, 101);
            this.groupBoxActions.TabIndex = 1;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Handlinger:";
            // 
            // pictureBoxEnemy
            // 
            this.pictureBoxEnemy.Location = new System.Drawing.Point(388, 12);
            this.pictureBoxEnemy.Name = "pictureBoxEnemy";
            this.pictureBoxEnemy.Size = new System.Drawing.Size(136, 153);
            this.pictureBoxEnemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEnemy.TabIndex = 2;
            this.pictureBoxEnemy.TabStop = false;
            // 
            // groupBoxPlayer
            // 
            this.groupBoxPlayer.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxPlayer.Controls.Add(this.progressBarPlayerXP);
            this.groupBoxPlayer.Controls.Add(this.labelPlayerXP);
            this.groupBoxPlayer.Controls.Add(this.progressBarPlayerMP);
            this.groupBoxPlayer.Controls.Add(this.labelPlayerMP);
            this.groupBoxPlayer.Controls.Add(this.progressBarPlayerHP);
            this.groupBoxPlayer.Controls.Add(this.labelPlayerHP);
            this.groupBoxPlayer.Location = new System.Drawing.Point(12, 51);
            this.groupBoxPlayer.Name = "groupBoxPlayer";
            this.groupBoxPlayer.Size = new System.Drawing.Size(136, 82);
            this.groupBoxPlayer.TabIndex = 3;
            this.groupBoxPlayer.TabStop = false;
            this.groupBoxPlayer.Text = "Name";
            // 
            // groupBoxEnemy
            // 
            this.groupBoxEnemy.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxEnemy.Location = new System.Drawing.Point(388, 171);
            this.groupBoxEnemy.Name = "groupBoxEnemy";
            this.groupBoxEnemy.Size = new System.Drawing.Size(136, 71);
            this.groupBoxEnemy.TabIndex = 4;
            this.groupBoxEnemy.TabStop = false;
            this.groupBoxEnemy.Text = "Enemy";
            // 
            // labelPlayerHP
            // 
            this.labelPlayerHP.AutoSize = true;
            this.labelPlayerHP.Location = new System.Drawing.Point(7, 20);
            this.labelPlayerHP.Name = "labelPlayerHP";
            this.labelPlayerHP.Size = new System.Drawing.Size(25, 13);
            this.labelPlayerHP.TabIndex = 0;
            this.labelPlayerHP.Text = "HP:";
            // 
            // progressBarPlayerHP
            // 
            this.progressBarPlayerHP.ForeColor = System.Drawing.Color.Red;
            this.progressBarPlayerHP.Location = new System.Drawing.Point(39, 19);
            this.progressBarPlayerHP.Name = "progressBarPlayerHP";
            this.progressBarPlayerHP.Size = new System.Drawing.Size(91, 13);
            this.progressBarPlayerHP.TabIndex = 1;
            this.progressBarPlayerHP.Value = 10;
            // 
            // progressBarPlayerMP
            // 
            this.progressBarPlayerMP.ForeColor = System.Drawing.Color.Green;
            this.progressBarPlayerMP.Location = new System.Drawing.Point(39, 38);
            this.progressBarPlayerMP.Name = "progressBarPlayerMP";
            this.progressBarPlayerMP.Size = new System.Drawing.Size(91, 13);
            this.progressBarPlayerMP.TabIndex = 3;
            this.progressBarPlayerMP.Value = 10;
            // 
            // labelPlayerMP
            // 
            this.labelPlayerMP.AutoSize = true;
            this.labelPlayerMP.Location = new System.Drawing.Point(7, 39);
            this.labelPlayerMP.Name = "labelPlayerMP";
            this.labelPlayerMP.Size = new System.Drawing.Size(26, 13);
            this.labelPlayerMP.TabIndex = 2;
            this.labelPlayerMP.Text = "MP:";
            // 
            // progressBarPlayerXP
            // 
            this.progressBarPlayerXP.ForeColor = System.Drawing.Color.Green;
            this.progressBarPlayerXP.Location = new System.Drawing.Point(39, 57);
            this.progressBarPlayerXP.Name = "progressBarPlayerXP";
            this.progressBarPlayerXP.Size = new System.Drawing.Size(91, 13);
            this.progressBarPlayerXP.TabIndex = 5;
            this.progressBarPlayerXP.Value = 10;
            // 
            // labelPlayerXP
            // 
            this.labelPlayerXP.AutoSize = true;
            this.labelPlayerXP.Location = new System.Drawing.Point(7, 58);
            this.labelPlayerXP.Name = "labelPlayerXP";
            this.labelPlayerXP.Size = new System.Drawing.Size(24, 13);
            this.labelPlayerXP.TabIndex = 4;
            this.labelPlayerXP.Text = "XP:";
            // 
            // FormBattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(536, 424);
            this.Controls.Add(this.groupBoxEnemy);
            this.Controls.Add(this.groupBoxPlayer);
            this.Controls.Add(this.pictureBoxEnemy);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.pictureBoxPlayer);
            this.Name = "FormBattle";
            this.Text = "FormBattle";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy)).EndInit();
            this.groupBoxPlayer.ResumeLayout(false);
            this.groupBoxPlayer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPlayer;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.PictureBox pictureBoxEnemy;
        private System.Windows.Forms.GroupBox groupBoxPlayer;
        private System.Windows.Forms.ProgressBar progressBarPlayerMP;
        private System.Windows.Forms.Label labelPlayerMP;
        private System.Windows.Forms.ProgressBar progressBarPlayerHP;
        private System.Windows.Forms.Label labelPlayerHP;
        private System.Windows.Forms.GroupBox groupBoxEnemy;
        private System.Windows.Forms.ProgressBar progressBarPlayerXP;
        private System.Windows.Forms.Label labelPlayerXP;
    }
}