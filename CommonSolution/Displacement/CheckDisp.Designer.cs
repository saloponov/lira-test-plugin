namespace LiraDisplacement
{
    partial class CheckDisp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxX = new System.Windows.Forms.CheckBox();
            this.checkBoxY = new System.Windows.Forms.CheckBox();
            this.checkBoxZ = new System.Windows.Forms.CheckBox();
            this.checkBoxUX = new System.Windows.Forms.CheckBox();
            this.checkBoxUY = new System.Windows.Forms.CheckBox();
            this.checkBoxUZ = new System.Windows.Forms.CheckBox();
            this.buttonSetDisp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSetDisp);
            this.groupBox1.Controls.Add(this.checkBoxUZ);
            this.groupBox1.Controls.Add(this.checkBoxUY);
            this.groupBox1.Controls.Add(this.checkBoxZ);
            this.groupBox1.Controls.Add(this.checkBoxUX);
            this.groupBox1.Controls.Add(this.checkBoxY);
            this.groupBox1.Controls.Add(this.checkBoxX);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // checkBoxX
            // 
            this.checkBoxX.AutoSize = true;
            this.checkBoxX.Location = new System.Drawing.Point(12, 12);
            this.checkBoxX.Name = "checkBoxX";
            this.checkBoxX.Size = new System.Drawing.Size(33, 17);
            this.checkBoxX.TabIndex = 0;
            this.checkBoxX.Text = "X";
            this.checkBoxX.UseVisualStyleBackColor = true;
            // 
            // checkBoxY
            // 
            this.checkBoxY.AutoSize = true;
            this.checkBoxY.Location = new System.Drawing.Point(12, 36);
            this.checkBoxY.Name = "checkBoxY";
            this.checkBoxY.Size = new System.Drawing.Size(33, 17);
            this.checkBoxY.TabIndex = 0;
            this.checkBoxY.Text = "Y";
            this.checkBoxY.UseVisualStyleBackColor = true;
            // 
            // checkBoxZ
            // 
            this.checkBoxZ.AutoSize = true;
            this.checkBoxZ.Location = new System.Drawing.Point(12, 60);
            this.checkBoxZ.Name = "checkBoxZ";
            this.checkBoxZ.Size = new System.Drawing.Size(33, 17);
            this.checkBoxZ.TabIndex = 0;
            this.checkBoxZ.Text = "Z";
            this.checkBoxZ.UseVisualStyleBackColor = true;
            // 
            // checkBoxUX
            // 
            this.checkBoxUX.AutoSize = true;
            this.checkBoxUX.Location = new System.Drawing.Point(51, 12);
            this.checkBoxUX.Name = "checkBoxUX";
            this.checkBoxUX.Size = new System.Drawing.Size(41, 17);
            this.checkBoxUX.TabIndex = 0;
            this.checkBoxUX.Text = "UX";
            this.checkBoxUX.UseVisualStyleBackColor = true;
            // 
            // checkBoxUY
            // 
            this.checkBoxUY.AutoSize = true;
            this.checkBoxUY.Location = new System.Drawing.Point(51, 36);
            this.checkBoxUY.Name = "checkBoxUY";
            this.checkBoxUY.Size = new System.Drawing.Size(41, 17);
            this.checkBoxUY.TabIndex = 0;
            this.checkBoxUY.Text = "UY";
            this.checkBoxUY.UseVisualStyleBackColor = true;
            // 
            // checkBoxUZ
            // 
            this.checkBoxUZ.AutoSize = true;
            this.checkBoxUZ.Location = new System.Drawing.Point(51, 60);
            this.checkBoxUZ.Name = "checkBoxUZ";
            this.checkBoxUZ.Size = new System.Drawing.Size(41, 17);
            this.checkBoxUZ.TabIndex = 0;
            this.checkBoxUZ.Text = "UZ";
            this.checkBoxUZ.UseVisualStyleBackColor = true;
            // 
            // buttonSetDisp
            // 
            this.buttonSetDisp.Location = new System.Drawing.Point(98, 8);
            this.buttonSetDisp.Name = "buttonSetDisp";
            this.buttonSetDisp.Size = new System.Drawing.Size(75, 23);
            this.buttonSetDisp.TabIndex = 1;
            this.buttonSetDisp.Text = "Назначить";
            this.buttonSetDisp.UseVisualStyleBackColor = true;
            this.buttonSetDisp.Click += new System.EventHandler(this.buttonSetDisp_Click);
            // 
            // CheckDisp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 83);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CheckDisp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Объединение перемещений";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSetDisp;
        private System.Windows.Forms.CheckBox checkBoxUZ;
        private System.Windows.Forms.CheckBox checkBoxUY;
        private System.Windows.Forms.CheckBox checkBoxZ;
        private System.Windows.Forms.CheckBox checkBoxUX;
        private System.Windows.Forms.CheckBox checkBoxY;
        private System.Windows.Forms.CheckBox checkBoxX;
    }
}