namespace LiraNote
{
    partial class SelectNodesElements
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxNode = new System.Windows.Forms.TextBox();
            this.textBoxElement = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxNode);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Узлы";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBoxElement);
            this.groupBox2.Location = new System.Drawing.Point(12, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 130);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Элементы";
            // 
            // textBoxNode
            // 
            this.textBoxNode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNode.Location = new System.Drawing.Point(3, 16);
            this.textBoxNode.Multiline = true;
            this.textBoxNode.Name = "textBoxNode";
            this.textBoxNode.Size = new System.Drawing.Size(442, 94);
            this.textBoxNode.TabIndex = 0;
            // 
            // textBoxElement
            // 
            this.textBoxElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxElement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxElement.Location = new System.Drawing.Point(3, 16);
            this.textBoxElement.Multiline = true;
            this.textBoxElement.Name = "textBoxElement";
            this.textBoxElement.Size = new System.Drawing.Size(442, 111);
            this.textBoxElement.TabIndex = 0;
            // 
            // SelectNodesElements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 273);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SelectNodesElements";
            this.Text = "Выбранные узлы и элементы";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBoxNode;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox textBoxElement;
    }
}