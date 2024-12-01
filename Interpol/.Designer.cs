namespace Interpol
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
            this.dataGridViewCriminals = new System.Windows.Forms.DataGridView();
            this.CriminalNickname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistinctiveFeatures = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArticleOfAccusation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriminals)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCriminals
            // 
            this.dataGridViewCriminals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCriminals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CriminalNickname,
            this.DistinctiveFeatures,
            this.ArticleOfAccusation});
            this.dataGridViewCriminals.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewCriminals.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCriminals.Name = "dataGridViewCriminals";
            this.dataGridViewCriminals.RowHeadersWidth = 51;
            this.dataGridViewCriminals.RowTemplate.Height = 24;
            this.dataGridViewCriminals.Size = new System.Drawing.Size(800, 294);
            this.dataGridViewCriminals.TabIndex = 0;
            this.dataGridViewCriminals.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCriminals_CellContentClick);
            // 
            // CriminalNickname
            // 
            this.CriminalNickname.HeaderText = "Псевдонім";
            this.CriminalNickname.MinimumWidth = 6;
            this.CriminalNickname.Name = "CriminalNickname";
            this.CriminalNickname.Width = 125;
            // 
            // DistinctiveFeatures
            // 
            this.DistinctiveFeatures.HeaderText = "Відмітні ознаки";
            this.DistinctiveFeatures.MinimumWidth = 6;
            this.DistinctiveFeatures.Name = "DistinctiveFeatures";
            this.DistinctiveFeatures.Width = 125;
            // 
            // ArticleOfAccusation
            // 
            this.ArticleOfAccusation.HeaderText = "Стаття звинувачення";
            this.ArticleOfAccusation.MinimumWidth = 6;
            this.ArticleOfAccusation.Name = "ArticleOfAccusation";
            this.ArticleOfAccusation.Width = 125;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(110, 364);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(251, 364);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(108, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Редагувати";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(414, 363);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewCriminals);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriminals)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCriminals;
        private System.Windows.Forms.DataGridViewTextBoxColumn CriminalNickname;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistinctiveFeatures;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArticleOfAccusation;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}

