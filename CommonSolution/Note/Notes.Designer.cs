namespace LiraNote
{
    partial class Notes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewDescription = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonProfile = new System.Windows.Forms.Button();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonCopyNumberEl = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDescription)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.textBoxDescription);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridViewDescription);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 243);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.Location = new System.Drawing.Point(157, 216);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(431, 20);
            this.textBoxDescription.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Добавить описание";
            // 
            // dataGridViewDescription
            // 
            this.dataGridViewDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDescription.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDescription.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName});
            this.dataGridViewDescription.Location = new System.Drawing.Point(0, 6);
            this.dataGridViewDescription.Name = "dataGridViewDescription";
            this.dataGridViewDescription.ReadOnly = true;
            this.dataGridViewDescription.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDescription.Size = new System.Drawing.Size(588, 204);
            this.dataGridViewDescription.TabIndex = 0;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Описание";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 500;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonCopyNumberEl);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.buttonProfile);
            this.groupBox2.Controls.Add(this.buttonSet);
            this.groupBox2.Controls.Add(this.buttonSelect);
            this.groupBox2.Location = new System.Drawing.Point(606, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 243);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(6, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(157, 30);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Выбрать все элементы\r\nс выделенным описанием";
            this.toolTip1.SetToolTip(this.checkBox1, resources.GetString("checkBox1.ToolTip"));
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonProfile
            // 
            this.buttonProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProfile.Location = new System.Drawing.Point(6, 213);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Size = new System.Drawing.Size(154, 23);
            this.buttonProfile.TabIndex = 1;
            this.buttonProfile.Text = "Получить ведомость";
            this.buttonProfile.UseVisualStyleBackColor = true;
            this.buttonProfile.Visible = false;
            this.buttonProfile.Click += new System.EventHandler(this.buttonProfile_Click);
            // 
            // buttonSet
            // 
            this.buttonSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSet.Location = new System.Drawing.Point(6, 82);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(154, 23);
            this.buttonSet.TabIndex = 0;
            this.buttonSet.Text = "Назначить на выбранное";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelect.Location = new System.Drawing.Point(6, 53);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(154, 23);
            this.buttonSelect.TabIndex = 0;
            this.buttonSelect.Text = "Выбрать отмеченное";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonCopyNumberEl
            // 
            this.buttonCopyNumberEl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCopyNumberEl.Location = new System.Drawing.Point(6, 166);
            this.buttonCopyNumberEl.Name = "buttonCopyNumberEl";
            this.buttonCopyNumberEl.Size = new System.Drawing.Size(154, 44);
            this.buttonCopyNumberEl.TabIndex = 3;
            this.buttonCopyNumberEl.Text = "Получить номера выбранных элементов";
            this.buttonCopyNumberEl.UseVisualStyleBackColor = true;
            this.buttonCopyNumberEl.Click += new System.EventHandler(this.buttonCopyNumberEl_Click);
            // 
            // Notes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 261);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 300);
            this.MinimumSize = new System.Drawing.Size(800, 300);
            this.Name = "Notes";
            this.Text = "Работа с атрибутом \"Описание\"";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDescription)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonProfile;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonCopyNumberEl;
    }
}