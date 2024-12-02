namespace Interpol.Forms
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelInterpol = new System.Windows.Forms.Panel();
            this.labelInterpol = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numAgeTo = new System.Windows.Forms.NumericUpDown();
            this.numAgeFrom = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResidence = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCrimeType = new System.Windows.Forms.ComboBox();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpCrimeDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpCrimeDateTo = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCrimeLocation = new System.Windows.Forms.TextBox();
            this.txtWantedCountry = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCaseNumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbEvidenceType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEvidenceStorage = new System.Windows.Forms.TextBox();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dgvCriminals = new System.Windows.Forms.DataGridView();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.panelInterpol.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAgeTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAgeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriminals)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 26);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // panelInterpol
            // 
            this.panelInterpol.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelInterpol.Controls.Add(this.labelInterpol);
            this.panelInterpol.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInterpol.Location = new System.Drawing.Point(0, 30);
            this.panelInterpol.Name = "panelInterpol";
            this.panelInterpol.Size = new System.Drawing.Size(1100, 52);
            this.panelInterpol.TabIndex = 1;
            // 
            // labelInterpol
            // 
            this.labelInterpol.AutoSize = true;
            this.labelInterpol.Font = new System.Drawing.Font("Montserrat", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInterpol.Location = new System.Drawing.Point(13, 6);
            this.labelInterpol.Name = "labelInterpol";
            this.labelInterpol.Size = new System.Drawing.Size(131, 39);
            this.labelInterpol.TabIndex = 0;
            this.labelInterpol.Text = "Interpol";
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelMenu.Location = new System.Drawing.Point(0, 80);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1100, 46);
            this.panelMenu.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.cmbGender);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtEvidenceStorage);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.cmbEvidenceType);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtCaseNumber);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtWantedCountry);
            this.panel1.Controls.Add(this.txtCrimeLocation);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dtpCrimeDateTo);
            this.panel1.Controls.Add(this.dtpCrimeDateFrom);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtNationality);
            this.panel1.Controls.Add(this.cmbCrimeType);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtResidence);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.numAgeTo);
            this.panel1.Controls.Add(this.numAgeFrom);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtLastName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtFirstName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 429);
            this.panel1.TabIndex = 3;
            // 
            // numAgeTo
            // 
            this.numAgeTo.Location = new System.Drawing.Point(247, 98);
            this.numAgeTo.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numAgeTo.Name = "numAgeTo";
            this.numAgeTo.Size = new System.Drawing.Size(69, 28);
            this.numAgeTo.TabIndex = 8;
            // 
            // numAgeFrom
            // 
            this.numAgeFrom.Location = new System.Drawing.Point(122, 98);
            this.numAgeFrom.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numAgeFrom.Name = "numAgeFrom";
            this.numAgeFrom.Size = new System.Drawing.Size(69, 28);
            this.numAgeFrom.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "(до)";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(122, 54);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(194, 28);
            this.txtLastName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Вік (від)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Прізвище";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(65, 14);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(194, 28);
            this.txtFirstName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ім\'я";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Місце проживання";
            // 
            // txtResidence
            // 
            this.txtResidence.Location = new System.Drawing.Point(206, 171);
            this.txtResidence.Name = "txtResidence";
            this.txtResidence.Size = new System.Drawing.Size(194, 28);
            this.txtResidence.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Національність";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = "Тип злочину";
            // 
            // cmbCrimeType
            // 
            this.cmbCrimeType.FormattingEnabled = true;
            this.cmbCrimeType.Location = new System.Drawing.Point(146, 247);
            this.cmbCrimeType.Name = "cmbCrimeType";
            this.cmbCrimeType.Size = new System.Drawing.Size(164, 32);
            this.cmbCrimeType.TabIndex = 13;
            // 
            // txtNationality
            // 
            this.txtNationality.Location = new System.Drawing.Point(172, 209);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(194, 28);
            this.txtNationality.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(212, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "Дата скоєння злочину";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 327);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "від";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(209, 325);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 24);
            this.label10.TabIndex = 17;
            this.label10.Text = "до";
            // 
            // dtpCrimeDateFrom
            // 
            this.dtpCrimeDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCrimeDateFrom.Location = new System.Drawing.Point(58, 325);
            this.dtpCrimeDateFrom.Name = "dtpCrimeDateFrom";
            this.dtpCrimeDateFrom.Size = new System.Drawing.Size(143, 28);
            this.dtpCrimeDateFrom.TabIndex = 18;
            // 
            // dtpCrimeDateTo
            // 
            this.dtpCrimeDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCrimeDateTo.Location = new System.Drawing.Point(247, 325);
            this.dtpCrimeDateTo.Name = "dtpCrimeDateTo";
            this.dtpCrimeDateTo.Size = new System.Drawing.Size(143, 28);
            this.dtpCrimeDateTo.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 372);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 24);
            this.label11.TabIndex = 20;
            this.label11.Text = "Місце злочину";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 412);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 24);
            this.label12.TabIndex = 21;
            this.label12.Text = "Країна розшуку";
            // 
            // txtCrimeLocation
            // 
            this.txtCrimeLocation.Location = new System.Drawing.Point(170, 371);
            this.txtCrimeLocation.Name = "txtCrimeLocation";
            this.txtCrimeLocation.Size = new System.Drawing.Size(194, 28);
            this.txtCrimeLocation.TabIndex = 15;
            // 
            // txtWantedCountry
            // 
            this.txtWantedCountry.Location = new System.Drawing.Point(179, 411);
            this.txtWantedCountry.Name = "txtWantedCountry";
            this.txtWantedCountry.Size = new System.Drawing.Size(194, 28);
            this.txtWantedCountry.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 451);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 24);
            this.label13.TabIndex = 22;
            this.label13.Text = "Номер справи";
            // 
            // txtCaseNumber
            // 
            this.txtCaseNumber.Location = new System.Drawing.Point(169, 451);
            this.txtCaseNumber.Name = "txtCaseNumber";
            this.txtCaseNumber.Size = new System.Drawing.Size(194, 28);
            this.txtCaseNumber.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 491);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 24);
            this.label14.TabIndex = 24;
            this.label14.Text = "Тип доказу";
            // 
            // cmbEvidenceType
            // 
            this.cmbEvidenceType.FormattingEnabled = true;
            this.cmbEvidenceType.Location = new System.Drawing.Point(136, 488);
            this.cmbEvidenceType.Name = "cmbEvidenceType";
            this.cmbEvidenceType.Size = new System.Drawing.Size(164, 32);
            this.cmbEvidenceType.TabIndex = 25;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 533);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(169, 24);
            this.label15.TabIndex = 26;
            this.label15.Text = "Місце зберігання";
            // 
            // txtEvidenceStorage
            // 
            this.txtEvidenceStorage.Location = new System.Drawing.Point(195, 530);
            this.txtEvidenceStorage.Name = "txtEvidenceStorage";
            this.txtEvidenceStorage.Size = new System.Drawing.Size(194, 28);
            this.txtEvidenceStorage.TabIndex = 28;
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Location = new System.Drawing.Point(68, 629);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(123, 32);
            this.btnClearFilters.TabIndex = 4;
            this.btnClearFilters.Text = "Очистити";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(230, 629);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(123, 32);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Montserrat SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(18, 135);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 32);
            this.label16.TabIndex = 6;
            this.label16.Text = "Фільтр";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Montserrat SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(459, 135);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(237, 32);
            this.label17.TabIndex = 7;
            this.label17.Text = "Список злочинців";
            // 
            // dgvCriminals
            // 
            this.dgvCriminals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCriminals.Location = new System.Drawing.Point(465, 175);
            this.dgvCriminals.Name = "dgvCriminals";
            this.dgvCriminals.RowHeadersWidth = 51;
            this.dgvCriminals.RowTemplate.Height = 24;
            this.dgvCriminals.Size = new System.Drawing.Size(623, 430);
            this.dgvCriminals.TabIndex = 8;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 138);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 24);
            this.label18.TabIndex = 29;
            this.label18.Text = "Стать";
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(84, 137);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(164, 32);
            this.cmbGender.TabIndex = 30;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 675);
            this.Controls.Add(this.dgvCriminals);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClearFilters);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelInterpol);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Головна сторінка";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelInterpol.ResumeLayout(false);
            this.panelInterpol.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAgeTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAgeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriminals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel panelInterpol;
        private System.Windows.Forms.Label labelInterpol;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numAgeTo;
        private System.Windows.Forms.NumericUpDown numAgeFrom;
        private System.Windows.Forms.TextBox txtResidence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.ComboBox cmbCrimeType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpCrimeDateTo;
        private System.Windows.Forms.DateTimePicker dtpCrimeDateFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCaseNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtWantedCountry;
        private System.Windows.Forms.TextBox txtCrimeLocation;
        private System.Windows.Forms.TextBox txtEvidenceStorage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbEvidenceType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dgvCriminals;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label18;
    }
}