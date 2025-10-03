namespace LiraNote
{
    partial class FormProfile
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
            this.dataGridViewProfile = new System.Windows.Forms.DataGridView();
            this.ColumnMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewProfile);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 254);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewProfile
            // 
            this.dataGridViewProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProfile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMark,
            this.ColumnImage,
            this.ColumnProfile,
            this.ColumnMaterial});
            this.dataGridViewProfile.Location = new System.Drawing.Point(6, 12);
            this.dataGridViewProfile.Name = "dataGridViewProfile";
            this.dataGridViewProfile.Size = new System.Drawing.Size(467, 236);
            this.dataGridViewProfile.TabIndex = 0;
            // 
            // ColumnMark
            // 
            this.ColumnMark.HeaderText = "Марка";
            this.ColumnMark.Name = "ColumnMark";
            // 
            // ColumnImage
            // 
            this.ColumnImage.HeaderText = "Вид";
            this.ColumnImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnImage.Name = "ColumnImage";
            // 
            // ColumnProfile
            // 
            this.ColumnProfile.HeaderText = "Профиль";
            this.ColumnProfile.Name = "ColumnProfile";
            // 
            // ColumnMaterial
            // 
            this.ColumnMaterial.HeaderText = "Материал";
            this.ColumnMaterial.Name = "ColumnMaterial";
            this.ColumnMaterial.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMaterial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FormProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 254);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormProfile";
            this.Text = "Profile";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMark;
        private System.Windows.Forms.DataGridViewImageColumn ColumnImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProfile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMaterial;
        public System.Windows.Forms.DataGridView dataGridViewProfile;
    }
}