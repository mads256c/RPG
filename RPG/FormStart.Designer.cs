namespace RPG
{
    partial class FormStart
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
            this.labelRPG = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxSkills = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.numericUpDownStrength = new System.Windows.Forms.NumericUpDown();
            this.labelPointsLeft = new System.Windows.Forms.Label();
            this.labelStrength = new System.Windows.Forms.Label();
            this.labelWisdom = new System.Windows.Forms.Label();
            this.numericUpDownWisdom = new System.Windows.Forms.NumericUpDown();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.numericUpDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.labelResistance = new System.Windows.Forms.Label();
            this.numericUpDownResistance = new System.Windows.Forms.NumericUpDown();
            this.labelDefence = new System.Windows.Forms.Label();
            this.numericUpDownDefence = new System.Windows.Forms.NumericUpDown();
            this.groupBoxSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWisdom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDefence)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRPG
            // 
            this.labelRPG.AutoSize = true;
            this.labelRPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRPG.Location = new System.Drawing.Point(112, 13);
            this.labelRPG.Name = "labelRPG";
            this.labelRPG.Size = new System.Drawing.Size(60, 26);
            this.labelRPG.TabIndex = 0;
            this.labelRPG.Text = "RPG";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(9, 48);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(36, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Navn:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 64);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(260, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // groupBoxSkills
            // 
            this.groupBoxSkills.Controls.Add(this.labelResistance);
            this.groupBoxSkills.Controls.Add(this.numericUpDownResistance);
            this.groupBoxSkills.Controls.Add(this.labelDefence);
            this.groupBoxSkills.Controls.Add(this.numericUpDownDefence);
            this.groupBoxSkills.Controls.Add(this.labelSpeed);
            this.groupBoxSkills.Controls.Add(this.numericUpDownSpeed);
            this.groupBoxSkills.Controls.Add(this.labelWisdom);
            this.groupBoxSkills.Controls.Add(this.numericUpDownWisdom);
            this.groupBoxSkills.Controls.Add(this.labelStrength);
            this.groupBoxSkills.Controls.Add(this.labelPointsLeft);
            this.groupBoxSkills.Controls.Add(this.numericUpDownStrength);
            this.groupBoxSkills.Location = new System.Drawing.Point(12, 91);
            this.groupBoxSkills.Name = "groupBoxSkills";
            this.groupBoxSkills.Size = new System.Drawing.Size(260, 131);
            this.groupBoxSkills.TabIndex = 3;
            this.groupBoxSkills.TabStop = false;
            this.groupBoxSkills.Text = "Færdigheder";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(197, 228);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // numericUpDownStrength
            // 
            this.numericUpDownStrength.Location = new System.Drawing.Point(22, 55);
            this.numericUpDownStrength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownStrength.Name = "numericUpDownStrength";
            this.numericUpDownStrength.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownStrength.TabIndex = 0;
            this.numericUpDownStrength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownStrength.ValueChanged += new System.EventHandler(this.NumericUpDownStrength_ValueChanged);
            // 
            // labelPointsLeft
            // 
            this.labelPointsLeft.AutoSize = true;
            this.labelPointsLeft.Location = new System.Drawing.Point(89, 16);
            this.labelPointsLeft.Name = "labelPointsLeft";
            this.labelPointsLeft.Size = new System.Drawing.Size(83, 13);
            this.labelPointsLeft.TabIndex = 1;
            this.labelPointsLeft.Text = "Point tilbage: 20";
            // 
            // labelStrength
            // 
            this.labelStrength.AutoSize = true;
            this.labelStrength.Location = new System.Drawing.Point(23, 36);
            this.labelStrength.Name = "labelStrength";
            this.labelStrength.Size = new System.Drawing.Size(40, 13);
            this.labelStrength.TabIndex = 2;
            this.labelStrength.Text = "Styrke:";
            // 
            // labelWisdom
            // 
            this.labelWisdom.AutoSize = true;
            this.labelWisdom.Location = new System.Drawing.Point(97, 36);
            this.labelWisdom.Name = "labelWisdom";
            this.labelWisdom.Size = new System.Drawing.Size(44, 13);
            this.labelWisdom.TabIndex = 4;
            this.labelWisdom.Text = "Visdom:";
            // 
            // numericUpDownWisdom
            // 
            this.numericUpDownWisdom.Location = new System.Drawing.Point(96, 55);
            this.numericUpDownWisdom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWisdom.Name = "numericUpDownWisdom";
            this.numericUpDownWisdom.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownWisdom.TabIndex = 3;
            this.numericUpDownWisdom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWisdom.ValueChanged += new System.EventHandler(this.NumericUpDownWisdom_ValueChanged);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(171, 36);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(58, 13);
            this.labelSpeed.TabIndex = 6;
            this.labelSpeed.Text = "Hastighed:";
            // 
            // numericUpDownSpeed
            // 
            this.numericUpDownSpeed.Location = new System.Drawing.Point(170, 55);
            this.numericUpDownSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSpeed.Name = "numericUpDownSpeed";
            this.numericUpDownSpeed.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownSpeed.TabIndex = 5;
            this.numericUpDownSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSpeed.ValueChanged += new System.EventHandler(this.NumericUpDownSpeed_ValueChanged);
            // 
            // labelResistance
            // 
            this.labelResistance.AutoSize = true;
            this.labelResistance.Location = new System.Drawing.Point(134, 86);
            this.labelResistance.Name = "labelResistance";
            this.labelResistance.Size = new System.Drawing.Size(57, 13);
            this.labelResistance.TabIndex = 10;
            this.labelResistance.Text = "Modstand:";
            // 
            // numericUpDownResistance
            // 
            this.numericUpDownResistance.Location = new System.Drawing.Point(133, 105);
            this.numericUpDownResistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownResistance.Name = "numericUpDownResistance";
            this.numericUpDownResistance.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownResistance.TabIndex = 9;
            this.numericUpDownResistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownResistance.ValueChanged += new System.EventHandler(this.NumericUpDownResistance_ValueChanged);
            // 
            // labelDefence
            // 
            this.labelDefence.AutoSize = true;
            this.labelDefence.Location = new System.Drawing.Point(60, 86);
            this.labelDefence.Name = "labelDefence";
            this.labelDefence.Size = new System.Drawing.Size(45, 13);
            this.labelDefence.TabIndex = 8;
            this.labelDefence.Text = "Forsvar:";
            // 
            // numericUpDownDefence
            // 
            this.numericUpDownDefence.Location = new System.Drawing.Point(59, 105);
            this.numericUpDownDefence.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDefence.Name = "numericUpDownDefence";
            this.numericUpDownDefence.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownDefence.TabIndex = 7;
            this.numericUpDownDefence.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDefence.ValueChanged += new System.EventHandler(this.NumericUpDownDefence_ValueChanged);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxSkills);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelRPG);
            this.Name = "FormStart";
            this.Text = "FormStats";
            this.groupBoxSkills.ResumeLayout(false);
            this.groupBoxSkills.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWisdom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDefence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRPG;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBoxSkills;
        private System.Windows.Forms.Label labelPointsLeft;
        private System.Windows.Forms.NumericUpDown numericUpDownStrength;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.NumericUpDown numericUpDownSpeed;
        private System.Windows.Forms.Label labelWisdom;
        private System.Windows.Forms.NumericUpDown numericUpDownWisdom;
        private System.Windows.Forms.Label labelStrength;
        private System.Windows.Forms.Label labelResistance;
        private System.Windows.Forms.NumericUpDown numericUpDownResistance;
        private System.Windows.Forms.Label labelDefence;
        private System.Windows.Forms.NumericUpDown numericUpDownDefence;
    }
}