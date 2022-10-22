namespace ViewFormWindowsForms
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.RemoveFigure = new System.Windows.Forms.Button();
            this.LoadFile = new System.Windows.Forms.Button();
            this.SaveFile = new System.Windows.Forms.Button();
            this.SearchFigure = new System.Windows.Forms.Button();
            this.AddFigure = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewMain);
            this.groupBox1.Controls.Add(this.RemoveFigure);
            this.groupBox1.Controls.Add(this.LoadFile);
            this.groupBox1.Controls.Add(this.SaveFile);
            this.groupBox1.Controls.Add(this.SearchFigure);
            this.groupBox1.Controls.Add(this.AddFigure);
            this.groupBox1.Location = new System.Drawing.Point(11, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(411, 315);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Геометрические фигуры";
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.AllowUserToResizeColumns = false;
            this.dataGridViewMain.AllowUserToResizeRows = false;
            this.dataGridViewMain.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.GridColor = System.Drawing.Color.Black;
            this.dataGridViewMain.Location = new System.Drawing.Point(181, 25);
            this.dataGridViewMain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewMain.RowHeadersVisible = false;
            this.dataGridViewMain.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.dataGridViewMain.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewMain.RowTemplate.Height = 24;
            this.dataGridViewMain.RowTemplate.ReadOnly = true;
            this.dataGridViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMain.Size = new System.Drawing.Size(214, 284);
            this.dataGridViewMain.TabIndex = 1;
            // 
            // RemoveFigure
            // 
            this.RemoveFigure.BackColor = System.Drawing.Color.White;
            this.RemoveFigure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveFigure.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RemoveFigure.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.RemoveFigure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LawnGreen;
            this.RemoveFigure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveFigure.Location = new System.Drawing.Point(12, 84);
            this.RemoveFigure.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RemoveFigure.Name = "RemoveFigure";
            this.RemoveFigure.Size = new System.Drawing.Size(144, 36);
            this.RemoveFigure.TabIndex = 0;
            this.RemoveFigure.Text = "Удалить фигуру";
            this.RemoveFigure.UseVisualStyleBackColor = false;
            this.RemoveFigure.Click += new System.EventHandler(this.RemoveFigureClick);
            // 
            // LoadFile
            // 
            this.LoadFile.BackColor = System.Drawing.Color.White;
            this.LoadFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.LoadFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.LoadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LawnGreen;
            this.LoadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadFile.Location = new System.Drawing.Point(12, 273);
            this.LoadFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LoadFile.Name = "LoadFile";
            this.LoadFile.Size = new System.Drawing.Size(144, 36);
            this.LoadFile.TabIndex = 0;
            this.LoadFile.Text = "Загрузить файл";
            this.LoadFile.UseVisualStyleBackColor = false;
            this.LoadFile.Click += new System.EventHandler(this.LoadFileClick);
            // 
            // SaveFile
            // 
            this.SaveFile.BackColor = System.Drawing.Color.White;
            this.SaveFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SaveFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.SaveFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LawnGreen;
            this.SaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveFile.Location = new System.Drawing.Point(12, 209);
            this.SaveFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(144, 36);
            this.SaveFile.TabIndex = 0;
            this.SaveFile.Text = "Сохранить в файл";
            this.SaveFile.UseVisualStyleBackColor = false;
            this.SaveFile.Click += new System.EventHandler(this.SaveFileClick);
            // 
            // SearchFigure
            // 
            this.SearchFigure.BackColor = System.Drawing.Color.White;
            this.SearchFigure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchFigure.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SearchFigure.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.SearchFigure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LawnGreen;
            this.SearchFigure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchFigure.Location = new System.Drawing.Point(12, 146);
            this.SearchFigure.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchFigure.Name = "SearchFigure";
            this.SearchFigure.Size = new System.Drawing.Size(144, 36);
            this.SearchFigure.TabIndex = 0;
            this.SearchFigure.Text = "Поиск фигуры";
            this.SearchFigure.UseVisualStyleBackColor = false;
            this.SearchFigure.Click += new System.EventHandler(this.SearchFigureClick);
            // 
            // AddFigure
            // 
            this.AddFigure.BackColor = System.Drawing.Color.White;
            this.AddFigure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddFigure.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.AddFigure.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.AddFigure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LawnGreen;
            this.AddFigure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFigure.Location = new System.Drawing.Point(12, 25);
            this.AddFigure.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.AddFigure.Name = "AddFigure";
            this.AddFigure.Size = new System.Drawing.Size(144, 36);
            this.AddFigure.TabIndex = 0;
            this.AddFigure.Text = "Добавить фигуру";
            this.AddFigure.UseVisualStyleBackColor = false;
            this.AddFigure.Click += new System.EventHandler(this.AddFigureClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(432, 338);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RemoveFigure;
        private System.Windows.Forms.Button AddFigure;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.Button SearchFigure;
        private System.Windows.Forms.Button SaveFile;
        private System.Windows.Forms.Button LoadFile;
    }
}

