namespace GameGraphs
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.nmUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.nmUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.btnWide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDownWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 31);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Make";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // nmUpDownHeight
            // 
            this.nmUpDownHeight.Location = new System.Drawing.Point(138, 12);
            this.nmUpDownHeight.Name = "nmUpDownHeight";
            this.nmUpDownHeight.Size = new System.Drawing.Size(68, 26);
            this.nmUpDownHeight.TabIndex = 1;
            this.nmUpDownHeight.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nmUpDownWidth
            // 
            this.nmUpDownWidth.Location = new System.Drawing.Point(232, 12);
            this.nmUpDownWidth.Name = "nmUpDownWidth";
            this.nmUpDownWidth.Size = new System.Drawing.Size(68, 26);
            this.nmUpDownWidth.TabIndex = 2;
            this.nmUpDownWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // btnWide
            // 
            this.btnWide.Location = new System.Drawing.Point(334, 9);
            this.btnWide.Name = "btnWide";
            this.btnWide.Size = new System.Drawing.Size(80, 31);
            this.btnWide.TabIndex = 3;
            this.btnWide.Text = "Start";
            this.btnWide.UseVisualStyleBackColor = true;
            this.btnWide.Visible = false;
            this.btnWide.Click += new System.EventHandler(this.BtnWide_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 450);
            this.Controls.Add(this.btnWide);
            this.Controls.Add(this.nmUpDownWidth);
            this.Controls.Add(this.nmUpDownHeight);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDownWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown nmUpDownHeight;
        private System.Windows.Forms.NumericUpDown nmUpDownWidth;
        private System.Windows.Forms.Button btnWide;
    }
}

