namespace RPG
{
    partial class FormDebug
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Walls");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Grasses");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Entrances");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Doors");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Keys");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Floor");
            this.groupBoxLoadLevel = new System.Windows.Forms.GroupBox();
            this.buttonLoadLevel = new System.Windows.Forms.Button();
            this.numericUpDownLoadLevel = new System.Windows.Forms.NumericUpDown();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.labelLevelID = new System.Windows.Forms.Label();
            this.labelPlayerSize = new System.Windows.Forms.Label();
            this.labelPlayfieldSize = new System.Windows.Forms.Label();
            this.labelPlayerPosition = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBoxObjects = new System.Windows.Forms.GroupBox();
            this.treeViewObjects = new System.Windows.Forms.TreeView();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.groupBoxLoadLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLoadLevel)).BeginInit();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxObjects.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLoadLevel
            // 
            this.groupBoxLoadLevel.Controls.Add(this.buttonLoadLevel);
            this.groupBoxLoadLevel.Controls.Add(this.numericUpDownLoadLevel);
            this.groupBoxLoadLevel.Location = new System.Drawing.Point(13, 13);
            this.groupBoxLoadLevel.Name = "groupBoxLoadLevel";
            this.groupBoxLoadLevel.Size = new System.Drawing.Size(200, 56);
            this.groupBoxLoadLevel.TabIndex = 0;
            this.groupBoxLoadLevel.TabStop = false;
            this.groupBoxLoadLevel.Text = "Load level";
            // 
            // buttonLoadLevel
            // 
            this.buttonLoadLevel.Location = new System.Drawing.Point(119, 19);
            this.buttonLoadLevel.Name = "buttonLoadLevel";
            this.buttonLoadLevel.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadLevel.TabIndex = 1;
            this.buttonLoadLevel.Text = "Load";
            this.buttonLoadLevel.UseVisualStyleBackColor = true;
            this.buttonLoadLevel.Click += new System.EventHandler(this.buttonLoadLevel_Click);
            // 
            // numericUpDownLoadLevel
            // 
            this.numericUpDownLoadLevel.Location = new System.Drawing.Point(6, 19);
            this.numericUpDownLoadLevel.Name = "numericUpDownLoadLevel";
            this.numericUpDownLoadLevel.Size = new System.Drawing.Size(107, 20);
            this.numericUpDownLoadLevel.TabIndex = 0;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.labelLevelID);
            this.groupBoxInfo.Controls.Add(this.labelPlayerSize);
            this.groupBoxInfo.Controls.Add(this.labelPlayfieldSize);
            this.groupBoxInfo.Controls.Add(this.labelPlayerPosition);
            this.groupBoxInfo.Location = new System.Drawing.Point(13, 76);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(200, 376);
            this.groupBoxInfo.TabIndex = 1;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Info";
            // 
            // labelLevelID
            // 
            this.labelLevelID.AutoSize = true;
            this.labelLevelID.Location = new System.Drawing.Point(7, 68);
            this.labelLevelID.Name = "labelLevelID";
            this.labelLevelID.Size = new System.Drawing.Size(60, 13);
            this.labelLevelID.TabIndex = 3;
            this.labelLevelID.Text = "Level ID: X";
            // 
            // labelPlayerSize
            // 
            this.labelPlayerSize.AutoSize = true;
            this.labelPlayerSize.Location = new System.Drawing.Point(7, 33);
            this.labelPlayerSize.Name = "labelPlayerSize";
            this.labelPlayerSize.Size = new System.Drawing.Size(83, 13);
            this.labelPlayerSize.TabIndex = 2;
            this.labelPlayerSize.Text = "Player size: X, Y";
            // 
            // labelPlayfieldSize
            // 
            this.labelPlayfieldSize.AutoSize = true;
            this.labelPlayfieldSize.Location = new System.Drawing.Point(7, 46);
            this.labelPlayfieldSize.Name = "labelPlayfieldSize";
            this.labelPlayfieldSize.Size = new System.Drawing.Size(93, 13);
            this.labelPlayfieldSize.TabIndex = 1;
            this.labelPlayfieldSize.Text = "Playfield size: X, Y";
            // 
            // labelPlayerPosition
            // 
            this.labelPlayerPosition.AutoSize = true;
            this.labelPlayerPosition.Location = new System.Drawing.Point(7, 20);
            this.labelPlayerPosition.Name = "labelPlayerPosition";
            this.labelPlayerPosition.Size = new System.Drawing.Size(101, 13);
            this.labelPlayerPosition.TabIndex = 0;
            this.labelPlayerPosition.Text = "Player position: X, Y";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // groupBoxObjects
            // 
            this.groupBoxObjects.Controls.Add(this.treeViewObjects);
            this.groupBoxObjects.Location = new System.Drawing.Point(219, 13);
            this.groupBoxObjects.Name = "groupBoxObjects";
            this.groupBoxObjects.Size = new System.Drawing.Size(297, 439);
            this.groupBoxObjects.TabIndex = 2;
            this.groupBoxObjects.TabStop = false;
            this.groupBoxObjects.Text = "Objects";
            // 
            // treeViewObjects
            // 
            this.treeViewObjects.Location = new System.Drawing.Point(6, 19);
            this.treeViewObjects.Name = "treeViewObjects";
            treeNode1.Name = "NodeWalls";
            treeNode1.Text = "Walls";
            treeNode2.Name = "NodeGrasses";
            treeNode2.Text = "Grasses";
            treeNode3.Name = "NodeEntrances";
            treeNode3.Text = "Entrances";
            treeNode4.Name = "NodeDoors";
            treeNode4.Text = "Doors";
            treeNode5.Name = "NodeKeys";
            treeNode5.Text = "Keys";
            treeNode6.Name = "Floor";
            treeNode6.Text = "Floor";
            this.treeViewObjects.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.treeViewObjects.Size = new System.Drawing.Size(285, 414);
            this.treeViewObjects.TabIndex = 0;
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.textBoxLog);
            this.groupBoxLog.Location = new System.Drawing.Point(523, 13);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(286, 439);
            this.groupBoxLog.TabIndex = 3;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Log";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(6, 19);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(274, 414);
            this.textBoxLog.TabIndex = 0;
            // 
            // FormDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 464);
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.groupBoxObjects);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.groupBoxLoadLevel);
            this.Name = "FormDebug";
            this.Text = "Debug window";
            this.groupBoxLoadLevel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLoadLevel)).EndInit();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.groupBoxObjects.ResumeLayout(false);
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLoadLevel;
        private System.Windows.Forms.Button buttonLoadLevel;
        private System.Windows.Forms.NumericUpDown numericUpDownLoadLevel;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label labelPlayerSize;
        private System.Windows.Forms.Label labelPlayfieldSize;
        private System.Windows.Forms.Label labelPlayerPosition;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelLevelID;
        private System.Windows.Forms.GroupBox groupBoxObjects;
        private System.Windows.Forms.TreeView treeViewObjects;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.TextBox textBoxLog;
    }
}