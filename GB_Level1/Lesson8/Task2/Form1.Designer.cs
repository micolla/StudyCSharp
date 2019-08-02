namespace Task2
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
            this.incremetnor = new System.Windows.Forms.NumericUpDown();
            this.tbLinked = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.incremetnor)).BeginInit();
            this.SuspendLayout();
            // 
            // incremetnor
            // 
            this.incremetnor.Location = new System.Drawing.Point(12, 37);
            this.incremetnor.Name = "incremetnor";
            this.incremetnor.Size = new System.Drawing.Size(120, 20);
            this.incremetnor.TabIndex = 0;
            this.incremetnor.ValueChanged += new System.EventHandler(this.incremetnor_ValueChanged);
            // 
            // tbLinked
            // 
            this.tbLinked.Location = new System.Drawing.Point(209, 37);
            this.tbLinked.Name = "tbLinked";
            this.tbLinked.Size = new System.Drawing.Size(100, 20);
            this.tbLinked.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "При измении счетчика будет измено значение в тексте";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 129);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLinked);
            this.Controls.Add(this.incremetnor);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.incremetnor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown incremetnor;
        private System.Windows.Forms.TextBox tbLinked;
        private System.Windows.Forms.Label label1;
    }
}

