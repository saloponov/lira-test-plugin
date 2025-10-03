namespace LiraFund
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewRSN = new System.Windows.Forms.DataGridView();
            this.buttonExtrRSU = new System.Windows.Forms.Button();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.ColumnTypeLoad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRSN4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumberNode4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxLamdaN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSaveParameters = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownPrecision = new System.Windows.Forms.NumericUpDown();
            this.buttonCopyClipBoard = new System.Windows.Forms.Button();
            this.comboBoxTypeRSU = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRSN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecision)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRSN
            // 
            this.dataGridViewRSN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewRSN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRSN.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewRSN.Name = "dataGridViewRSN";
            this.dataGridViewRSN.Size = new System.Drawing.Size(692, 480);
            this.dataGridViewRSN.TabIndex = 0;
            // 
            // buttonExtrRSU
            // 
            this.buttonExtrRSU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExtrRSU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExtrRSU.Location = new System.Drawing.Point(1067, 498);
            this.buttonExtrRSU.Name = "buttonExtrRSU";
            this.buttonExtrRSU.Size = new System.Drawing.Size(189, 23);
            this.buttonExtrRSU.TabIndex = 2;
            this.buttonExtrRSU.Text = "Найти экстремумы";
            this.buttonExtrRSU.UseVisualStyleBackColor = true;
            this.buttonExtrRSU.Click += new System.EventHandler(this.buttonExtrRSU_Click);
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTypeLoad,
            this.ColumnN,
            this.ColumnMk,
            this.ColumnMy,
            this.ColumnQz,
            this.ColumnMz,
            this.ColumnQy,
            this.ColumnRSN4,
            this.ColumnNumberNode4,
            this.ColumnResult});
            this.dataGridViewResult.Location = new System.Drawing.Point(710, 12);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewResult.Size = new System.Drawing.Size(741, 480);
            this.dataGridViewResult.TabIndex = 9;
            // 
            // ColumnTypeLoad
            // 
            this.ColumnTypeLoad.HeaderText = "Тип нагрузки";
            this.ColumnTypeLoad.Name = "ColumnTypeLoad";
            // 
            // ColumnN
            // 
            this.ColumnN.HeaderText = "N, кН";
            this.ColumnN.Name = "ColumnN";
            // 
            // ColumnMk
            // 
            this.ColumnMk.HeaderText = "Mk, кН*м";
            this.ColumnMk.Name = "ColumnMk";
            // 
            // ColumnMy
            // 
            this.ColumnMy.HeaderText = "My, кН*м";
            this.ColumnMy.Name = "ColumnMy";
            // 
            // ColumnQz
            // 
            this.ColumnQz.HeaderText = "Qz, кН";
            this.ColumnQz.Name = "ColumnQz";
            // 
            // ColumnMz
            // 
            this.ColumnMz.HeaderText = "Mz, кН*м";
            this.ColumnMz.Name = "ColumnMz";
            // 
            // ColumnQy
            // 
            this.ColumnQy.HeaderText = "Qy, кН";
            this.ColumnQy.Name = "ColumnQy";
            // 
            // ColumnRSN4
            // 
            this.ColumnRSN4.HeaderText = "Комбинация РСУ";
            this.ColumnRSN4.Name = "ColumnRSN4";
            // 
            // ColumnNumberNode4
            // 
            this.ColumnNumberNode4.HeaderText = "Номер элемента";
            this.ColumnNumberNode4.Name = "ColumnNumberNode4";
            this.ColumnNumberNode4.Width = 50;
            // 
            // ColumnResult
            // 
            this.ColumnResult.HeaderText = "Результат";
            this.ColumnResult.Name = "ColumnResult";
            // 
            // textBoxLamdaN
            // 
            this.textBoxLamdaN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxLamdaN.Location = new System.Drawing.Point(417, 500);
            this.textBoxLamdaN.Name = "textBoxLamdaN";
            this.textBoxLamdaN.Size = new System.Drawing.Size(100, 20);
            this.textBoxLamdaN.TabIndex = 10;
            this.textBoxLamdaN.Text = "1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 504);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Коэф. надежности по ответственности";
            // 
            // buttonSaveParameters
            // 
            this.buttonSaveParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveParameters.Location = new System.Drawing.Point(12, 499);
            this.buttonSaveParameters.Name = "buttonSaveParameters";
            this.buttonSaveParameters.Size = new System.Drawing.Size(189, 23);
            this.buttonSaveParameters.TabIndex = 2;
            this.buttonSaveParameters.Text = "Сохранить параметры";
            this.buttonSaveParameters.UseVisualStyleBackColor = true;
            this.buttonSaveParameters.Click += new System.EventHandler(this.buttonSaveParameters_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(523, 504);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Точность (знаков)";
            // 
            // numericUpDownPrecision
            // 
            this.numericUpDownPrecision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownPrecision.Location = new System.Drawing.Point(629, 499);
            this.numericUpDownPrecision.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownPrecision.Name = "numericUpDownPrecision";
            this.numericUpDownPrecision.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownPrecision.TabIndex = 12;
            this.numericUpDownPrecision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownPrecision.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // buttonCopyClipBoard
            // 
            this.buttonCopyClipBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCopyClipBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCopyClipBoard.Location = new System.Drawing.Point(1262, 498);
            this.buttonCopyClipBoard.Name = "buttonCopyClipBoard";
            this.buttonCopyClipBoard.Size = new System.Drawing.Size(189, 23);
            this.buttonCopyClipBoard.TabIndex = 13;
            this.buttonCopyClipBoard.Text = "Копировать выбранное";
            this.buttonCopyClipBoard.UseVisualStyleBackColor = true;
            this.buttonCopyClipBoard.Click += new System.EventHandler(this.buttonCopyClipBoard_Click);
            // 
            // comboBoxTypeRSU
            // 
            this.comboBoxTypeRSU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxTypeRSU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeRSU.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxTypeRSU.FormattingEnabled = true;
            this.comboBoxTypeRSU.Items.AddRange(new object[] {
            "РСУ",
            "РСУ (Длительнодействующая)",
            "НСУ",
            "НСУ (Длительнодействующая)"});
            this.comboBoxTypeRSU.Location = new System.Drawing.Point(812, 499);
            this.comboBoxTypeRSU.Name = "comboBoxTypeRSU";
            this.comboBoxTypeRSU.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTypeRSU.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(712, 504);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Тип сочетания:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 529);
            this.Controls.Add(this.comboBoxTypeRSU);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCopyClipBoard);
            this.Controls.Add(this.numericUpDownPrecision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLamdaN);
            this.Controls.Add(this.dataGridViewResult);
            this.Controls.Add(this.buttonSaveParameters);
            this.Controls.Add(this.buttonExtrRSU);
            this.Controls.Add(this.dataGridViewRSN);
            this.Name = "Form1";
            this.Text = "Выборка из РСУ (стержни)";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRSN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewRSN;
        private System.Windows.Forms.Button buttonExtrRSU;
        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTypeLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMk;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQz;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMz;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRSN4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumberNode4;
        private System.Windows.Forms.TextBox textBoxLamdaN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSaveParameters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownPrecision;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnResult;
        private System.Windows.Forms.Button buttonCopyClipBoard;
        private System.Windows.Forms.ComboBox comboBoxTypeRSU;
        private System.Windows.Forms.Label label3;
    }
}

