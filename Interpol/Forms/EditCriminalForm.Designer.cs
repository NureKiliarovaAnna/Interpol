namespace Interpol.Forms
{
    partial class EditCriminalForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbInvestigationStatus = new System.Windows.Forms.ComboBox();
            this.cmbDegreeParticipation = new System.Windows.Forms.ComboBox();
            this.cmbCrimeType = new System.Windows.Forms.ComboBox();
            this.dtpCrimeDate = new System.Windows.Forms.DateTimePicker();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.txtPhotoPath = new System.Windows.Forms.TextBox();
            this.btnChoosePhoto = new System.Windows.Forms.Button();
            this.txtCrimeMethod = new System.Windows.Forms.TextBox();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCrimeLocation = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.txtDistinctiveFeatures = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassport = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBirthLocation = new System.Windows.Forms.TextBox();
            this.birthLocation = new System.Windows.Forms.Label();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResidence = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabVictims = new System.Windows.Forms.TabPage();
            this.tabWitnesses = new System.Windows.Forms.TabPage();
            this.tabEvidence = new System.Windows.Forms.TabPage();
            this.tabWanted = new System.Windows.Forms.TabPage();
            this.tabWarrants = new System.Windows.Forms.TabPage();
            this.tabCourtCase = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabVictims);
            this.tabControl.Controls.Add(this.tabWitnesses);
            this.tabControl.Controls.Add(this.tabEvidence);
            this.tabControl.Controls.Add(this.tabWanted);
            this.tabControl.Controls.Add(this.tabWarrants);
            this.tabControl.Controls.Add(this.tabCourtCase);
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(949, 615);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage1.Controls.Add(this.cmbInvestigationStatus);
            this.tabPage1.Controls.Add(this.cmbDegreeParticipation);
            this.tabPage1.Controls.Add(this.cmbCrimeType);
            this.tabPage1.Controls.Add(this.dtpCrimeDate);
            this.tabPage1.Controls.Add(this.cmbStatus);
            this.tabPage1.Controls.Add(this.cmbGender);
            this.tabPage1.Controls.Add(this.dtpBirthDate);
            this.tabPage1.Controls.Add(this.txtPhotoPath);
            this.tabPage1.Controls.Add(this.btnChoosePhoto);
            this.tabPage1.Controls.Add(this.txtCrimeMethod);
            this.tabPage1.Controls.Add(this.txtArticle);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.txtCrimeLocation);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.pbPhoto);
            this.tabPage1.Controls.Add(this.txtDistinctiveFeatures);
            this.tabPage1.Controls.Add(this.txtPhone);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.txtPassport);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txtBirthLocation);
            this.tabPage1.Controls.Add(this.birthLocation);
            this.tabPage1.Controls.Add(this.txtNickname);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.txtNationality);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtResidence);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtLastName);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtFirstName);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(941, 578);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Загальна інформація";
            // 
            // cmbInvestigationStatus
            // 
            this.cmbInvestigationStatus.FormattingEnabled = true;
            this.cmbInvestigationStatus.Items.AddRange(new object[] {
            "Активне",
            "Закрите",
            "В очікуванні"});
            this.cmbInvestigationStatus.Location = new System.Drawing.Point(243, 783);
            this.cmbInvestigationStatus.Name = "cmbInvestigationStatus";
            this.cmbInvestigationStatus.Size = new System.Drawing.Size(320, 32);
            this.cmbInvestigationStatus.TabIndex = 127;
            // 
            // cmbDegreeParticipation
            // 
            this.cmbDegreeParticipation.FormattingEnabled = true;
            this.cmbDegreeParticipation.Items.AddRange(new object[] {
            "Організатор",
            "Учасник",
            "Спостерігач"});
            this.cmbDegreeParticipation.Location = new System.Drawing.Point(171, 823);
            this.cmbDegreeParticipation.Name = "cmbDegreeParticipation";
            this.cmbDegreeParticipation.Size = new System.Drawing.Size(392, 32);
            this.cmbDegreeParticipation.TabIndex = 126;
            // 
            // cmbCrimeType
            // 
            this.cmbCrimeType.FormattingEnabled = true;
            this.cmbCrimeType.Items.AddRange(new object[] {
            "Вбивство",
            "Крадіжка",
            "Шахрайство",
            "Контрабанда",
            "Тероризм"});
            this.cmbCrimeType.Location = new System.Drawing.Point(159, 670);
            this.cmbCrimeType.Name = "cmbCrimeType";
            this.cmbCrimeType.Size = new System.Drawing.Size(404, 32);
            this.cmbCrimeType.TabIndex = 125;
            // 
            // dtpCrimeDate
            // 
            this.dtpCrimeDate.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)), true);
            this.dtpCrimeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCrimeDate.Location = new System.Drawing.Point(247, 634);
            this.dtpCrimeDate.Name = "dtpCrimeDate";
            this.dtpCrimeDate.Size = new System.Drawing.Size(316, 28);
            this.dtpCrimeDate.TabIndex = 124;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Живий",
            "Мертвий",
            "Зниклий безвісти"});
            this.cmbStatus.Location = new System.Drawing.Point(103, 294);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(460, 32);
            this.cmbStatus.TabIndex = 123;
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Чоловіча",
            "Жіноча"});
            this.cmbGender.Location = new System.Drawing.Point(93, 102);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(470, 32);
            this.cmbGender.TabIndex = 122;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)), true);
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(211, 140);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(352, 28);
            this.dtpBirthDate.TabIndex = 121;
            // 
            // txtPhotoPath
            // 
            this.txtPhotoPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPhotoPath.Location = new System.Drawing.Point(700, 417);
            this.txtPhotoPath.Name = "txtPhotoPath";
            this.txtPhotoPath.Size = new System.Drawing.Size(100, 28);
            this.txtPhotoPath.TabIndex = 120;
            this.txtPhotoPath.Visible = false;
            // 
            // btnChoosePhoto
            // 
            this.btnChoosePhoto.Location = new System.Drawing.Point(675, 193);
            this.btnChoosePhoto.Name = "btnChoosePhoto";
            this.btnChoosePhoto.Size = new System.Drawing.Size(141, 38);
            this.btnChoosePhoto.TabIndex = 119;
            this.btnChoosePhoto.Text = "Обрати фото";
            this.btnChoosePhoto.UseVisualStyleBackColor = true;
            this.btnChoosePhoto.Click += new System.EventHandler(this.btnChoosePhoto_Click);
            // 
            // txtCrimeMethod
            // 
            this.txtCrimeMethod.HideSelection = false;
            this.txtCrimeMethod.Location = new System.Drawing.Point(183, 746);
            this.txtCrimeMethod.Name = "txtCrimeMethod";
            this.txtCrimeMethod.Size = new System.Drawing.Size(380, 28);
            this.txtCrimeMethod.TabIndex = 116;
            // 
            // txtArticle
            // 
            this.txtArticle.HideSelection = false;
            this.txtArticle.Location = new System.Drawing.Point(240, 598);
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(323, 28);
            this.txtArticle.TabIndex = 113;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(25, 826);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(140, 24);
            this.label19.TabIndex = 112;
            this.label19.Text = "Ступінь участі";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(25, 786);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(212, 24);
            this.label17.TabIndex = 111;
            this.label17.Text = "Статус розслідування";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(25, 747);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 24);
            this.label8.TabIndex = 110;
            this.label8.Text = "Спосіб злочину";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(24, 638);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(217, 24);
            this.label16.TabIndex = 109;
            this.label16.Text = "Дата скоєння злочину";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(24, 601);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(208, 24);
            this.label15.TabIndex = 108;
            this.label15.Text = "Стаття звинувачення";
            // 
            // txtCrimeLocation
            // 
            this.txtCrimeLocation.HideSelection = false;
            this.txtCrimeLocation.Location = new System.Drawing.Point(176, 710);
            this.txtCrimeLocation.Name = "txtCrimeLocation";
            this.txtCrimeLocation.Size = new System.Drawing.Size(387, 28);
            this.txtCrimeLocation.TabIndex = 106;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(24, 710);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 24);
            this.label11.TabIndex = 107;
            this.label11.Text = "Місце злочину";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(26, 673);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 24);
            this.label7.TabIndex = 105;
            this.label7.Text = "Тип злочину";
            // 
            // pbPhoto
            // 
            this.pbPhoto.Enabled = false;
            this.pbPhoto.Location = new System.Drawing.Point(593, 29);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(299, 381);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 104;
            this.pbPhoto.TabStop = false;
            // 
            // txtDistinctiveFeatures
            // 
            this.txtDistinctiveFeatures.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtDistinctiveFeatures.HideSelection = false;
            this.txtDistinctiveFeatures.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDistinctiveFeatures.Location = new System.Drawing.Point(189, 493);
            this.txtDistinctiveFeatures.Multiline = true;
            this.txtDistinctiveFeatures.Name = "txtDistinctiveFeatures";
            this.txtDistinctiveFeatures.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDistinctiveFeatures.Size = new System.Drawing.Size(374, 97);
            this.txtDistinctiveFeatures.TabIndex = 103;
            // 
            // txtPhone
            // 
            this.txtPhone.HideSelection = false;
            this.txtPhone.Location = new System.Drawing.Point(142, 413);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(421, 28);
            this.txtPhone.TabIndex = 102;
            // 
            // txtEmail
            // 
            this.txtEmail.HideSelection = false;
            this.txtEmail.Location = new System.Drawing.Point(157, 374);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(406, 28);
            this.txtEmail.TabIndex = 101;
            // 
            // txtPassport
            // 
            this.txtPassport.HideSelection = false;
            this.txtPassport.Location = new System.Drawing.Point(193, 335);
            this.txtPassport.Name = "txtPassport";
            this.txtPassport.Size = new System.Drawing.Size(370, 28);
            this.txtPassport.TabIndex = 100;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(26, 493);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(156, 24);
            this.label14.TabIndex = 98;
            this.label14.Text = "Відмітні ознаки";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(25, 417);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 24);
            this.label13.TabIndex = 97;
            this.label13.Text = "Номер тел.";
            // 
            // txtBirthLocation
            // 
            this.txtBirthLocation.HideSelection = false;
            this.txtBirthLocation.Location = new System.Drawing.Point(211, 179);
            this.txtBirthLocation.Name = "txtBirthLocation";
            this.txtBirthLocation.Size = new System.Drawing.Size(352, 28);
            this.txtBirthLocation.TabIndex = 96;
            // 
            // birthLocation
            // 
            this.birthLocation.AutoSize = true;
            this.birthLocation.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.birthLocation.Location = new System.Drawing.Point(27, 180);
            this.birthLocation.Name = "birthLocation";
            this.birthLocation.Size = new System.Drawing.Size(188, 24);
            this.birthLocation.TabIndex = 95;
            this.birthLocation.Text = "Місце народження";
            // 
            // txtNickname
            // 
            this.txtNickname.HideSelection = false;
            this.txtNickname.Location = new System.Drawing.Point(139, 452);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(424, 28);
            this.txtNickname.TabIndex = 92;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(26, 454);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 24);
            this.label4.TabIndex = 91;
            this.label4.Text = "Псевдонім";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(27, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 24);
            this.label18.TabIndex = 90;
            this.label18.Text = "Стать";
            // 
            // txtNationality
            // 
            this.txtNationality.HideSelection = false;
            this.txtNationality.Location = new System.Drawing.Point(183, 255);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(380, 28);
            this.txtNationality.TabIndex = 89;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(27, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 24);
            this.label6.TabIndex = 88;
            this.label6.Text = "Національність";
            // 
            // txtResidence
            // 
            this.txtResidence.HideSelection = false;
            this.txtResidence.Location = new System.Drawing.Point(217, 217);
            this.txtResidence.Name = "txtResidence";
            this.txtResidence.Size = new System.Drawing.Size(346, 28);
            this.txtResidence.TabIndex = 86;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(27, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 24);
            this.label5.TabIndex = 87;
            this.label5.Text = "Місце проживання";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLastName.HideSelection = false;
            this.txtLastName.Location = new System.Drawing.Point(133, 65);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(430, 28);
            this.txtLastName.TabIndex = 85;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(27, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 24);
            this.label9.TabIndex = 84;
            this.label9.Text = "Дата народження";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(25, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 24);
            this.label10.TabIndex = 83;
            this.label10.Text = "Прізвище";
            // 
            // txtFirstName
            // 
            this.txtFirstName.HideSelection = false;
            this.txtFirstName.Location = new System.Drawing.Point(76, 27);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(487, 28);
            this.txtFirstName.TabIndex = 82;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(27, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 24);
            this.label12.TabIndex = 81;
            this.label12.Text = "Ім\'я";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(26, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 24);
            this.label3.TabIndex = 80;
            this.label3.Text = "Номер паспорту";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(25, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 79;
            this.label2.Text = "Елект. пошта";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 78;
            this.label1.Text = "Статус";
            // 
            // tabVictims
            // 
            this.tabVictims.AutoScroll = true;
            this.tabVictims.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabVictims.Location = new System.Drawing.Point(4, 33);
            this.tabVictims.Margin = new System.Windows.Forms.Padding(4);
            this.tabVictims.Name = "tabVictims";
            this.tabVictims.Padding = new System.Windows.Forms.Padding(4);
            this.tabVictims.Size = new System.Drawing.Size(941, 578);
            this.tabVictims.TabIndex = 1;
            this.tabVictims.Text = "Потерпілі";
            // 
            // tabWitnesses
            // 
            this.tabWitnesses.AutoScroll = true;
            this.tabWitnesses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabWitnesses.Location = new System.Drawing.Point(4, 33);
            this.tabWitnesses.Name = "tabWitnesses";
            this.tabWitnesses.Size = new System.Drawing.Size(941, 578);
            this.tabWitnesses.TabIndex = 2;
            this.tabWitnesses.Text = "Свідки";
            // 
            // tabEvidence
            // 
            this.tabEvidence.AutoScroll = true;
            this.tabEvidence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabEvidence.Location = new System.Drawing.Point(4, 33);
            this.tabEvidence.Name = "tabEvidence";
            this.tabEvidence.Size = new System.Drawing.Size(941, 578);
            this.tabEvidence.TabIndex = 3;
            this.tabEvidence.Text = "Докази";
            // 
            // tabWanted
            // 
            this.tabWanted.AutoScroll = true;
            this.tabWanted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabWanted.Location = new System.Drawing.Point(4, 33);
            this.tabWanted.Name = "tabWanted";
            this.tabWanted.Size = new System.Drawing.Size(941, 578);
            this.tabWanted.TabIndex = 4;
            this.tabWanted.Text = "Розшук";
            // 
            // tabWarrants
            // 
            this.tabWarrants.AutoScroll = true;
            this.tabWarrants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabWarrants.Location = new System.Drawing.Point(4, 33);
            this.tabWarrants.Name = "tabWarrants";
            this.tabWarrants.Size = new System.Drawing.Size(941, 578);
            this.tabWarrants.TabIndex = 5;
            this.tabWarrants.Text = "Ордер";
            // 
            // tabCourtCase
            // 
            this.tabCourtCase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabCourtCase.Location = new System.Drawing.Point(4, 33);
            this.tabCourtCase.Name = "tabCourtCase";
            this.tabCourtCase.Size = new System.Drawing.Size(941, 578);
            this.tabCourtCase.TabIndex = 6;
            this.tabCourtCase.Text = "Судова справа";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(200, 100);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Потерпілі";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(200, 100);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Докази";
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(0, 0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(200, 100);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Розшук";
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(0, 0);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(200, 100);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Ордер";
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(0, 0);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(200, 100);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Судова справа";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(821, 635);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(643, 635);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 34);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Назад";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EditCriminalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(975, 675);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditCriminalForm";
            this.Text = "Редагування злочинця";
            this.Load += new System.EventHandler(this.EditCriminalForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabVictims;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabWitnesses;
        private System.Windows.Forms.TabPage tabEvidence;
        private System.Windows.Forms.TabPage tabWanted;
        private System.Windows.Forms.TabPage tabWarrants;
        private System.Windows.Forms.TabPage tabCourtCase;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.TextBox txtDistinctiveFeatures;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBirthLocation;
        private System.Windows.Forms.Label birthLocation;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtResidence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCrimeMethod;
        private System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCrimeLocation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnChoosePhoto;
        private System.Windows.Forms.TextBox txtPhotoPath;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker dtpCrimeDate;
        private System.Windows.Forms.ComboBox cmbCrimeType;
        private System.Windows.Forms.ComboBox cmbInvestigationStatus;
        private System.Windows.Forms.ComboBox cmbDegreeParticipation;
    }
}