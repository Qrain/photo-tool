namespace OmronCameraDemo
{
    partial class Params
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
            this.labelMinSize = new System.Windows.Forms.Label();
            this.labelThresh = new System.Windows.Forms.Label();
            this.numericBdThresh = new System.Windows.Forms.NumericUpDown();
            this.numericBdMax = new System.Windows.Forms.NumericUpDown();
            this.labelMaxSize = new System.Windows.Forms.Label();
            this.numericBdMin = new System.Windows.Forms.NumericUpDown();
            this.labelBody = new System.Windows.Forms.Label();
            this.labelFace = new System.Windows.Forms.Label();
            this.labelHand = new System.Windows.Forms.Label();
            this.numericDtThresh = new System.Windows.Forms.NumericUpDown();
            this.numericDtMax = new System.Windows.Forms.NumericUpDown();
            this.numericDtMin = new System.Windows.Forms.NumericUpDown();
            this.numericHdThresh = new System.Windows.Forms.NumericUpDown();
            this.numericHdMax = new System.Windows.Forms.NumericUpDown();
            this.numericHdMin = new System.Windows.Forms.NumericUpDown();
            this.numericPdMin = new System.Windows.Forms.NumericUpDown();
            this.numericPdMax = new System.Windows.Forms.NumericUpDown();
            this.numericPdThresh = new System.Windows.Forms.NumericUpDown();
            this.labelPet = new System.Windows.Forms.Label();
            this.numericRecogThresh = new System.Windows.Forms.NumericUpDown();
            this.labelRecog = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericBdThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBdMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBdMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDtThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDtMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDtMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHdThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHdMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHdMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPdMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPdMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPdThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRecogThresh)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMinSize
            // 
            this.labelMinSize.AutoSize = true;
            this.labelMinSize.Location = new System.Drawing.Point(65, 9);
            this.labelMinSize.Name = "labelMinSize";
            this.labelMinSize.Size = new System.Drawing.Size(50, 12);
            this.labelMinSize.TabIndex = 8;
            this.labelMinSize.Text = "MinSize：";
            // 
            // labelThresh
            // 
            this.labelThresh.AutoSize = true;
            this.labelThresh.Location = new System.Drawing.Point(222, 9);
            this.labelThresh.Name = "labelThresh";
            this.labelThresh.Size = new System.Drawing.Size(46, 12);
            this.labelThresh.TabIndex = 9;
            this.labelThresh.Text = "Thresh：";
            // 
            // numericBdThresh
            // 
            this.numericBdThresh.Location = new System.Drawing.Point(225, 26);
            this.numericBdThresh.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericBdThresh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericBdThresh.Name = "numericBdThresh";
            this.numericBdThresh.Size = new System.Drawing.Size(60, 19);
            this.numericBdThresh.TabIndex = 10;
            this.numericBdThresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericBdThresh.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numericBdMax
            // 
            this.numericBdMax.Location = new System.Drawing.Point(147, 26);
            this.numericBdMax.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numericBdMax.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericBdMax.Name = "numericBdMax";
            this.numericBdMax.Size = new System.Drawing.Size(60, 19);
            this.numericBdMax.TabIndex = 7;
            this.numericBdMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericBdMax.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            // 
            // labelMaxSize
            // 
            this.labelMaxSize.AutoSize = true;
            this.labelMaxSize.Location = new System.Drawing.Point(145, 9);
            this.labelMaxSize.Name = "labelMaxSize";
            this.labelMaxSize.Size = new System.Drawing.Size(53, 12);
            this.labelMaxSize.TabIndex = 6;
            this.labelMaxSize.Text = "MaxSize：";
            // 
            // numericBdMin
            // 
            this.numericBdMin.Location = new System.Drawing.Point(67, 26);
            this.numericBdMin.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numericBdMin.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericBdMin.Name = "numericBdMin";
            this.numericBdMin.Size = new System.Drawing.Size(60, 19);
            this.numericBdMin.TabIndex = 9;
            this.numericBdMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericBdMin.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Location = new System.Drawing.Point(12, 28);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(31, 12);
            this.labelBody.TabIndex = 11;
            this.labelBody.Text = "Body";
            // 
            // labelFace
            // 
            this.labelFace.AutoSize = true;
            this.labelFace.Location = new System.Drawing.Point(12, 103);
            this.labelFace.Name = "labelFace";
            this.labelFace.Size = new System.Drawing.Size(30, 12);
            this.labelFace.TabIndex = 12;
            this.labelFace.Text = "Face";
            // 
            // labelHand
            // 
            this.labelHand.AutoSize = true;
            this.labelHand.Location = new System.Drawing.Point(12, 53);
            this.labelHand.Name = "labelHand";
            this.labelHand.Size = new System.Drawing.Size(31, 12);
            this.labelHand.TabIndex = 13;
            this.labelHand.Text = "Hand";
            // 
            // numericDtThresh
            // 
            this.numericDtThresh.Location = new System.Drawing.Point(225, 101);
            this.numericDtThresh.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericDtThresh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDtThresh.Name = "numericDtThresh";
            this.numericDtThresh.Size = new System.Drawing.Size(60, 19);
            this.numericDtThresh.TabIndex = 16;
            this.numericDtThresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericDtThresh.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numericDtMax
            // 
            this.numericDtMax.Location = new System.Drawing.Point(147, 101);
            this.numericDtMax.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numericDtMax.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericDtMax.Name = "numericDtMax";
            this.numericDtMax.Size = new System.Drawing.Size(60, 19);
            this.numericDtMax.TabIndex = 14;
            this.numericDtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericDtMax.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            // 
            // numericDtMin
            // 
            this.numericDtMin.Location = new System.Drawing.Point(67, 101);
            this.numericDtMin.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numericDtMin.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericDtMin.Name = "numericDtMin";
            this.numericDtMin.Size = new System.Drawing.Size(60, 19);
            this.numericDtMin.TabIndex = 15;
            this.numericDtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericDtMin.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numericHdThresh
            // 
            this.numericHdThresh.Location = new System.Drawing.Point(225, 51);
            this.numericHdThresh.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericHdThresh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericHdThresh.Name = "numericHdThresh";
            this.numericHdThresh.Size = new System.Drawing.Size(60, 19);
            this.numericHdThresh.TabIndex = 19;
            this.numericHdThresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericHdThresh.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numericHdMax
            // 
            this.numericHdMax.Location = new System.Drawing.Point(147, 51);
            this.numericHdMax.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numericHdMax.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericHdMax.Name = "numericHdMax";
            this.numericHdMax.Size = new System.Drawing.Size(60, 19);
            this.numericHdMax.TabIndex = 17;
            this.numericHdMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericHdMax.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            // 
            // numericHdMin
            // 
            this.numericHdMin.Location = new System.Drawing.Point(67, 51);
            this.numericHdMin.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numericHdMin.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericHdMin.Name = "numericHdMin";
            this.numericHdMin.Size = new System.Drawing.Size(60, 19);
            this.numericHdMin.TabIndex = 18;
            this.numericHdMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericHdMin.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numericPdMin
            // 
            this.numericPdMin.Location = new System.Drawing.Point(67, 76);
            this.numericPdMin.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numericPdMin.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericPdMin.Name = "numericPdMin";
            this.numericPdMin.Size = new System.Drawing.Size(60, 19);
            this.numericPdMin.TabIndex = 22;
            this.numericPdMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericPdMin.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numericPdMax
            // 
            this.numericPdMax.Location = new System.Drawing.Point(147, 76);
            this.numericPdMax.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numericPdMax.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericPdMax.Name = "numericPdMax";
            this.numericPdMax.Size = new System.Drawing.Size(60, 19);
            this.numericPdMax.TabIndex = 21;
            this.numericPdMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericPdMax.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            // 
            // numericPdThresh
            // 
            this.numericPdThresh.Location = new System.Drawing.Point(225, 76);
            this.numericPdThresh.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericPdThresh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericPdThresh.Name = "numericPdThresh";
            this.numericPdThresh.Size = new System.Drawing.Size(60, 19);
            this.numericPdThresh.TabIndex = 23;
            this.numericPdThresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericPdThresh.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // labelPet
            // 
            this.labelPet.AutoSize = true;
            this.labelPet.Location = new System.Drawing.Point(12, 78);
            this.labelPet.Name = "labelPet";
            this.labelPet.Size = new System.Drawing.Size(22, 12);
            this.labelPet.TabIndex = 20;
            this.labelPet.Text = "Pet";
            // 
            // numericRecogThresh
            // 
            this.numericRecogThresh.Location = new System.Drawing.Point(224, 126);
            this.numericRecogThresh.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericRecogThresh.Name = "numericRecogThresh";
            this.numericRecogThresh.Size = new System.Drawing.Size(60, 19);
            this.numericRecogThresh.TabIndex = 25;
            this.numericRecogThresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericRecogThresh.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // labelRecog
            // 
            this.labelRecog.AutoSize = true;
            this.labelRecog.Location = new System.Drawing.Point(11, 128);
            this.labelRecog.Name = "labelRecog";
            this.labelRecog.Size = new System.Drawing.Size(37, 12);
            this.labelRecog.TabIndex = 24;
            this.labelRecog.Text = "Recog";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Params
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 192);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericRecogThresh);
            this.Controls.Add(this.labelRecog);
            this.Controls.Add(this.numericPdMin);
            this.Controls.Add(this.numericPdMax);
            this.Controls.Add(this.numericPdThresh);
            this.Controls.Add(this.labelPet);
            this.Controls.Add(this.numericHdMin);
            this.Controls.Add(this.numericHdMax);
            this.Controls.Add(this.numericHdThresh);
            this.Controls.Add(this.labelMinSize);
            this.Controls.Add(this.numericDtMin);
            this.Controls.Add(this.labelThresh);
            this.Controls.Add(this.numericDtMax);
            this.Controls.Add(this.numericBdThresh);
            this.Controls.Add(this.numericDtThresh);
            this.Controls.Add(this.numericBdMax);
            this.Controls.Add(this.labelHand);
            this.Controls.Add(this.labelMaxSize);
            this.Controls.Add(this.labelFace);
            this.Controls.Add(this.numericBdMin);
            this.Controls.Add(this.labelBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Params";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parameter settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericBdThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBdMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBdMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDtThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDtMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDtMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHdThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHdMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHdMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPdMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPdMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPdThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRecogThresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMinSize;
        private System.Windows.Forms.Label labelThresh;
        public System.Windows.Forms.NumericUpDown numericBdThresh;
        private System.Windows.Forms.NumericUpDown numericBdMax;
        private System.Windows.Forms.Label labelMaxSize;
        private System.Windows.Forms.NumericUpDown numericBdMin;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.Label labelFace;
        private System.Windows.Forms.Label labelHand;
        public System.Windows.Forms.NumericUpDown numericDtThresh;
        private System.Windows.Forms.NumericUpDown numericDtMax;
        private System.Windows.Forms.NumericUpDown numericDtMin;
        public System.Windows.Forms.NumericUpDown numericHdThresh;
        private System.Windows.Forms.NumericUpDown numericHdMax;
        private System.Windows.Forms.NumericUpDown numericHdMin;
        private System.Windows.Forms.NumericUpDown numericPdMin;
        private System.Windows.Forms.NumericUpDown numericPdMax;
        public System.Windows.Forms.NumericUpDown numericPdThresh;
        private System.Windows.Forms.Label labelPet;
        public System.Windows.Forms.NumericUpDown numericRecogThresh;
        private System.Windows.Forms.Label labelRecog;
        private System.Windows.Forms.Button button1;
    }
}