using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criminalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warrantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courtCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проПрограмуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelInterpol = new System.Windows.Forms.Panel();
            this.labelInterpol = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCaseNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtStatusCountry = new System.Windows.Forms.TextBox();
            this.txtCrimeLocation = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.cmbCrimeType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResidence = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dgvCriminals = new System.Windows.Forms.DataGridView();
            this.interpolDataSet = new Interpol.InterpolDataSet();
            this.interpolDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.interpolDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.cmbSortOrder = new System.Windows.Forms.ComboBox();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpBirthDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpBirthDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpCrimeDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpCrimeDateTo = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelInterpol.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriminals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interpolDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interpolDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interpolDataSetBindingSource1)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(1163, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.criminalsToolStripMenuItem,
            this.crimesToolStripMenuItem,
            this.warrantToolStripMenuItem,
            this.courtCaseToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.optionsToolStripMenuItem.Text = "Statistics";
            // 
            // criminalsToolStripMenuItem
            // 
            this.criminalsToolStripMenuItem.Name = "criminalsToolStripMenuItem";
            this.criminalsToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.criminalsToolStripMenuItem.Text = "Злочинці";
            this.criminalsToolStripMenuItem.Click += new System.EventHandler(this.criminalsToolStripMenuItem_Click);
            // 
            // crimesToolStripMenuItem
            // 
            this.crimesToolStripMenuItem.Name = "crimesToolStripMenuItem";
            this.crimesToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.crimesToolStripMenuItem.Text = "Злочини";
            this.crimesToolStripMenuItem.Click += new System.EventHandler(this.crimesToolStripMenuItem_Click);
            // 
            // warrantToolStripMenuItem
            // 
            this.warrantToolStripMenuItem.Name = "warrantToolStripMenuItem";
            this.warrantToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.warrantToolStripMenuItem.Text = "Міжнародні ордери";
            this.warrantToolStripMenuItem.Click += new System.EventHandler(this.warrantToolStripMenuItem_Click);
            // 
            // courtCaseToolStripMenuItem
            // 
            this.courtCaseToolStripMenuItem.Name = "courtCaseToolStripMenuItem";
            this.courtCaseToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.courtCaseToolStripMenuItem.Text = "Судові справи";
            this.courtCaseToolStripMenuItem.Click += new System.EventHandler(this.courtCaseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проПрограмуToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // проПрограмуToolStripMenuItem
            // 
            this.проПрограмуToolStripMenuItem.Name = "проПрограмуToolStripMenuItem";
            this.проПрограмуToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.проПрограмуToolStripMenuItem.Text = "Про програму..";
            this.проПрограмуToolStripMenuItem.Click += new System.EventHandler(this.проПрограмуToolStripMenuItem_Click);
            // 
            // panelInterpol
            // 
            this.panelInterpol.BackColor = System.Drawing.Color.Black;
            this.panelInterpol.Controls.Add(this.labelInterpol);
            this.panelInterpol.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInterpol.Location = new System.Drawing.Point(0, 28);
            this.panelInterpol.Name = "panelInterpol";
            this.panelInterpol.Size = new System.Drawing.Size(1163, 52);
            this.panelInterpol.TabIndex = 1;
            // 
            // labelInterpol
            // 
            this.labelInterpol.AutoSize = true;
            this.labelInterpol.Font = new System.Drawing.Font("Montserrat ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInterpol.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelInterpol.Location = new System.Drawing.Point(13, 6);
            this.labelInterpol.Name = "labelInterpol";
            this.labelInterpol.Size = new System.Drawing.Size(178, 41);
            this.labelInterpol.TabIndex = 0;
            this.labelInterpol.Text = "INTERPOL";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Controls.Add(this.label10);
            this.panelMenu.Controls.Add(this.label9);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 80);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1163, 46);
            this.panelMenu.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1081, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label10.Location = new System.Drawing.Point(994, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 24);
            this.label10.TabIndex = 1;
            this.label10.Text = "Вихід";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            this.label10.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label10.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "Головна";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.dtpCrimeDateFrom);
            this.panel1.Controls.Add(this.dtpCrimeDateTo);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.dtpBirthDateFrom);
            this.panel1.Controls.Add(this.dtpBirthDateTo);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtNickname);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbGender);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtCaseNumber);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtStatusCountry);
            this.panel1.Controls.Add(this.txtCrimeLocation);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtNationality);
            this.panel1.Controls.Add(this.cmbCrimeType);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtResidence);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 476);
            this.panel1.TabIndex = 3;
            // 
            // txtNickname
            // 
            this.txtNickname.Location = new System.Drawing.Point(136, 17);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(278, 28);
            this.txtNickname.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(22, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 24);
            this.label4.TabIndex = 33;
            this.label4.Text = "Псевдонім";
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.ItemHeight = 24;
            this.cmbGender.Items.AddRange(new object[] {
            "Чоловіча",
            "Жіноча"});
            this.cmbGender.Location = new System.Drawing.Point(88, 158);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(327, 32);
            this.cmbGender.TabIndex = 30;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Montserrat ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(24, 162);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 24);
            this.label18.TabIndex = 29;
            this.label18.Text = "Стать";
            // 
            // txtCaseNumber
            // 
            this.txtCaseNumber.Location = new System.Drawing.Point(173, 389);
            this.txtCaseNumber.Name = "txtCaseNumber";
            this.txtCaseNumber.Size = new System.Drawing.Size(241, 28);
            this.txtCaseNumber.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Montserrat ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(24, 390);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 24);
            this.label13.TabIndex = 22;
            this.label13.Text = "Номер справи";
            // 
            // txtStatusCountry
            // 
            this.txtStatusCountry.Location = new System.Drawing.Point(183, 352);
            this.txtStatusCountry.Name = "txtStatusCountry";
            this.txtStatusCountry.Size = new System.Drawing.Size(231, 28);
            this.txtStatusCountry.TabIndex = 15;
            // 
            // txtCrimeLocation
            // 
            this.txtCrimeLocation.Location = new System.Drawing.Point(173, 315);
            this.txtCrimeLocation.Name = "txtCrimeLocation";
            this.txtCrimeLocation.Size = new System.Drawing.Size(241, 28);
            this.txtCrimeLocation.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Montserrat ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(24, 353);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 24);
            this.label12.TabIndex = 21;
            this.label12.Text = "Країна розшуку";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Montserrat ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(23, 316);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 24);
            this.label11.TabIndex = 20;
            this.label11.Text = "Місце злочину";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(22, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(219, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "Дата скоєння злочину";
            // 
            // txtNationality
            // 
            this.txtNationality.Location = new System.Drawing.Point(178, 235);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(236, 28);
            this.txtNationality.TabIndex = 14;
            // 
            // cmbCrimeType
            // 
            this.cmbCrimeType.AutoCompleteCustomSource.AddRange(new string[] {
            "Вбивство",
            "Крадіжка",
            "Шахрайство",
            "Контрабанда",
            "Інше"});
            this.cmbCrimeType.FormattingEnabled = true;
            this.cmbCrimeType.Items.AddRange(new object[] {
            "Вбивство",
            "Крадіжка",
            "Шахрайство",
            "Контрабанда",
            "Тероризм"});
            this.cmbCrimeType.Location = new System.Drawing.Point(152, 273);
            this.cmbCrimeType.Name = "cmbCrimeType";
            this.cmbCrimeType.Size = new System.Drawing.Size(262, 32);
            this.cmbCrimeType.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(22, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = "Тип злочину";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(22, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Національність";
            // 
            // txtResidence
            // 
            this.txtResidence.Location = new System.Drawing.Point(212, 198);
            this.txtResidence.Name = "txtResidence";
            this.txtResidence.Size = new System.Drawing.Size(203, 28);
            this.txtResidence.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(22, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Місце проживання";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLastName.Location = new System.Drawing.Point(1017, 137);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(134, 28);
            this.txtLastName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(22, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Вік";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(909, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Прізвище";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(793, 137);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(105, 28);
            this.txtFirstName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(742, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ім\'я";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearFilters.Location = new System.Drawing.Point(145, 662);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(123, 32);
            this.btnClearFilters.TabIndex = 4;
            this.btnClearFilters.Text = "Очистити";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Location = new System.Drawing.Point(322, 662);
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
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
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
            this.label17.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label17.Location = new System.Drawing.Point(459, 135);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(237, 32);
            this.label17.TabIndex = 7;
            this.label17.Text = "Список злочинців";
            // 
            // dgvCriminals
            // 
            this.dgvCriminals.AllowUserToAddRows = false;
            this.dgvCriminals.AllowUserToDeleteRows = false;
            this.dgvCriminals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCriminals.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCriminals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCriminals.Location = new System.Drawing.Point(465, 175);
            this.dgvCriminals.Name = "dgvCriminals";
            this.dgvCriminals.ReadOnly = true;
            this.dgvCriminals.RowHeadersWidth = 51;
            this.dgvCriminals.RowTemplate.Height = 24;
            this.dgvCriminals.Size = new System.Drawing.Size(686, 477);
            this.dgvCriminals.TabIndex = 8;
            this.dgvCriminals.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCriminals_CellDoubleClick);
            // 
            // interpolDataSet
            // 
            this.interpolDataSet.DataSetName = "InterpolDataSet";
            this.interpolDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // interpolDataSetBindingSource
            // 
            this.interpolDataSetBindingSource.DataSource = this.interpolDataSet;
            this.interpolDataSetBindingSource.Position = 0;
            // 
            // interpolDataSetBindingSource1
            // 
            this.interpolDataSetBindingSource1.DataSource = this.interpolDataSet;
            this.interpolDataSetBindingSource1.Position = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(980, 662);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "Додати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbSortOrder
            // 
            this.cmbSortOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSortOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbSortOrder.FormattingEnabled = true;
            this.cmbSortOrder.Items.AddRange(new object[] {
            "За зростанням",
            "За спаданням"});
            this.cmbSortOrder.Location = new System.Drawing.Point(322, 134);
            this.cmbSortOrder.Name = "cmbSortOrder";
            this.cmbSortOrder.Size = new System.Drawing.Size(124, 32);
            this.cmbSortOrder.TabIndex = 10;
            this.cmbSortOrder.SelectedIndexChanged += new System.EventHandler(this.cmbSortOrder_SelectedIndexChanged);
            // 
            // cmbSortBy
            // 
            this.cmbSortBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSortBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbSortBy.FormattingEnabled = true;
            this.cmbSortBy.Items.AddRange(new object[] {
            "Ім\'я",
            "Прізвище",
            "Дата народження",
            "Дата злочину"});
            this.cmbSortBy.Location = new System.Drawing.Point(185, 134);
            this.cmbSortBy.Name = "cmbSortBy";
            this.cmbSortBy.Size = new System.Drawing.Size(131, 32);
            this.cmbSortBy.TabIndex = 11;
            this.cmbSortBy.SelectedIndexChanged += new System.EventHandler(this.cmbSortBy_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(60, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 24);
            this.label14.TabIndex = 37;
            this.label14.Text = "від";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(241, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 24);
            this.label15.TabIndex = 38;
            this.label15.Text = "до";
            // 
            // dtpBirthDateTo
            // 
            this.dtpBirthDateTo.Checked = false;
            this.dtpBirthDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDateTo.Location = new System.Drawing.Point(275, 51);
            this.dtpBirthDateTo.Name = "dtpBirthDateTo";
            this.dtpBirthDateTo.ShowCheckBox = true;
            this.dtpBirthDateTo.Size = new System.Drawing.Size(139, 28);
            this.dtpBirthDateTo.TabIndex = 39;
            // 
            // dtpBirthDateFrom
            // 
            this.dtpBirthDateFrom.Checked = false;
            this.dtpBirthDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDateFrom.Location = new System.Drawing.Point(102, 51);
            this.dtpBirthDateFrom.Name = "dtpBirthDateFrom";
            this.dtpBirthDateFrom.ShowCheckBox = true;
            this.dtpBirthDateFrom.Size = new System.Drawing.Size(137, 28);
            this.dtpBirthDateFrom.TabIndex = 40;
            // 
            // dtpCrimeDateFrom
            // 
            this.dtpCrimeDateFrom.Checked = false;
            this.dtpCrimeDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCrimeDateFrom.Location = new System.Drawing.Point(103, 121);
            this.dtpCrimeDateFrom.Name = "dtpCrimeDateFrom";
            this.dtpCrimeDateFrom.ShowCheckBox = true;
            this.dtpCrimeDateFrom.Size = new System.Drawing.Size(137, 28);
            this.dtpCrimeDateFrom.TabIndex = 44;
            // 
            // dtpCrimeDateTo
            // 
            this.dtpCrimeDateTo.Checked = false;
            this.dtpCrimeDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCrimeDateTo.Location = new System.Drawing.Point(276, 121);
            this.dtpCrimeDateTo.Name = "dtpCrimeDateTo";
            this.dtpCrimeDateTo.ShowCheckBox = true;
            this.dtpCrimeDateTo.Size = new System.Drawing.Size(138, 28);
            this.dtpCrimeDateTo.TabIndex = 43;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(241, 123);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 24);
            this.label19.TabIndex = 42;
            this.label19.Text = "до";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(61, 123);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 24);
            this.label20.TabIndex = 41;
            this.label20.Text = "від";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1163, 704);
            this.Controls.Add(this.cmbSortBy);
            this.Controls.Add(this.cmbSortOrder);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCriminals);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClearFilters);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelInterpol);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Головна сторінка";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelInterpol.ResumeLayout(false);
            this.panelInterpol.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriminals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interpolDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interpolDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interpolDataSetBindingSource1)).EndInit();
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
        private System.Windows.Forms.TextBox txtResidence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.ComboBox cmbCrimeType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCaseNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtStatusCountry;
        private System.Windows.Forms.TextBox txtCrimeLocation;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dgvCriminals;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.BindingSource interpolDataSetBindingSource;
        private InterpolDataSet interpolDataSet;
        private System.Windows.Forms.BindingSource interpolDataSetBindingSource1;
        private TextBox txtNickname;
        private Label label4;
        private ToolStripMenuItem проПрограмуToolStripMenuItem;
        private Button button1;
        private Label label10;
        private Label label9;
        private PictureBox pictureBox1;
        private ComboBox cmbSortOrder;
        private ComboBox cmbSortBy;
        private ToolStripMenuItem criminalsToolStripMenuItem;
        private ToolStripMenuItem crimesToolStripMenuItem;
        private ToolStripMenuItem warrantToolStripMenuItem;
        private ToolStripMenuItem courtCaseToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label label15;
        private Label label14;
        private DateTimePicker dtpBirthDateFrom;
        private DateTimePicker dtpBirthDateTo;
        private DateTimePicker dtpCrimeDateFrom;
        private DateTimePicker dtpCrimeDateTo;
        private Label label19;
        private Label label20;
    }
}