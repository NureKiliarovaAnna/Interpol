namespace Interpol.Forms
{
    partial class CriminalDetailsForm
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
            this.tabGeneralInfo = new System.Windows.Forms.TabPage();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.txtDegreeParticipation = new System.Windows.Forms.TextBox();
            this.txtInvestigationStatus = new System.Windows.Forms.TextBox();
            this.txtCrimeMethod = new System.Windows.Forms.TextBox();
            this.txtCrimeType = new System.Windows.Forms.TextBox();
            this.txtCrimeDate = new System.Windows.Forms.TextBox();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.txtDistinctiveFeatures = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassport = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBirthLocation = new System.Windows.Forms.TextBox();
            this.birthLocation = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.txtBirthDate = new System.Windows.Forms.TextBox();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCrimeLocation = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabGeneralInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabGeneralInfo);
            this.tabControl.Controls.Add(this.tabVictims);
            this.tabControl.Controls.Add(this.tabWitnesses);
            this.tabControl.Controls.Add(this.tabEvidence);
            this.tabControl.Controls.Add(this.tabWanted);
            this.tabControl.Controls.Add(this.tabWarrants);
            this.tabControl.Controls.Add(this.tabCourtCase);
            this.tabControl.Location = new System.Drawing.Point(21, 20);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(996, 606);
            this.tabControl.TabIndex = 0;
            // 
            // tabGeneralInfo
            // 
            this.tabGeneralInfo.AutoScroll = true;
            this.tabGeneralInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabGeneralInfo.Controls.Add(this.pbPhoto);
            this.tabGeneralInfo.Controls.Add(this.txtDegreeParticipation);
            this.tabGeneralInfo.Controls.Add(this.txtInvestigationStatus);
            this.tabGeneralInfo.Controls.Add(this.txtCrimeMethod);
            this.tabGeneralInfo.Controls.Add(this.txtCrimeType);
            this.tabGeneralInfo.Controls.Add(this.txtCrimeDate);
            this.tabGeneralInfo.Controls.Add(this.txtArticle);
            this.tabGeneralInfo.Controls.Add(this.txtDistinctiveFeatures);
            this.tabGeneralInfo.Controls.Add(this.txtPhone);
            this.tabGeneralInfo.Controls.Add(this.txtEmail);
            this.tabGeneralInfo.Controls.Add(this.txtPassport);
            this.tabGeneralInfo.Controls.Add(this.txtStatus);
            this.tabGeneralInfo.Controls.Add(this.label19);
            this.tabGeneralInfo.Controls.Add(this.label17);
            this.tabGeneralInfo.Controls.Add(this.label8);
            this.tabGeneralInfo.Controls.Add(this.label16);
            this.tabGeneralInfo.Controls.Add(this.label15);
            this.tabGeneralInfo.Controls.Add(this.label14);
            this.tabGeneralInfo.Controls.Add(this.label13);
            this.tabGeneralInfo.Controls.Add(this.txtBirthLocation);
            this.tabGeneralInfo.Controls.Add(this.birthLocation);
            this.tabGeneralInfo.Controls.Add(this.txtGender);
            this.tabGeneralInfo.Controls.Add(this.txtBirthDate);
            this.tabGeneralInfo.Controls.Add(this.txtNickname);
            this.tabGeneralInfo.Controls.Add(this.label4);
            this.tabGeneralInfo.Controls.Add(this.label18);
            this.tabGeneralInfo.Controls.Add(this.txtCrimeLocation);
            this.tabGeneralInfo.Controls.Add(this.label11);
            this.tabGeneralInfo.Controls.Add(this.txtNationality);
            this.tabGeneralInfo.Controls.Add(this.label7);
            this.tabGeneralInfo.Controls.Add(this.label6);
            this.tabGeneralInfo.Controls.Add(this.txtResidence);
            this.tabGeneralInfo.Controls.Add(this.label5);
            this.tabGeneralInfo.Controls.Add(this.txtLastName);
            this.tabGeneralInfo.Controls.Add(this.label9);
            this.tabGeneralInfo.Controls.Add(this.label10);
            this.tabGeneralInfo.Controls.Add(this.txtFirstName);
            this.tabGeneralInfo.Controls.Add(this.label12);
            this.tabGeneralInfo.Controls.Add(this.label3);
            this.tabGeneralInfo.Controls.Add(this.label2);
            this.tabGeneralInfo.Controls.Add(this.label1);
            this.tabGeneralInfo.Location = new System.Drawing.Point(4, 33);
            this.tabGeneralInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tabGeneralInfo.Name = "tabGeneralInfo";
            this.tabGeneralInfo.Padding = new System.Windows.Forms.Padding(4);
            this.tabGeneralInfo.Size = new System.Drawing.Size(988, 569);
            this.tabGeneralInfo.TabIndex = 0;
            this.tabGeneralInfo.Text = "Загальна інформація";
            // 
            // pbPhoto
            // 
            this.pbPhoto.Enabled = false;
            this.pbPhoto.Location = new System.Drawing.Point(600, 28);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(330, 381);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 77;
            this.pbPhoto.TabStop = false;
            // 
            // txtDegreeParticipation
            // 
            this.txtDegreeParticipation.Enabled = false;
            this.txtDegreeParticipation.Location = new System.Drawing.Point(173, 832);
            this.txtDegreeParticipation.Name = "txtDegreeParticipation";
            this.txtDegreeParticipation.Size = new System.Drawing.Size(391, 28);
            this.txtDegreeParticipation.TabIndex = 76;
            // 
            // txtInvestigationStatus
            // 
            this.txtInvestigationStatus.Enabled = false;
            this.txtInvestigationStatus.Location = new System.Drawing.Point(244, 793);
            this.txtInvestigationStatus.Name = "txtInvestigationStatus";
            this.txtInvestigationStatus.Size = new System.Drawing.Size(320, 28);
            this.txtInvestigationStatus.TabIndex = 75;
            // 
            // txtCrimeMethod
            // 
            this.txtCrimeMethod.Enabled = false;
            this.txtCrimeMethod.Location = new System.Drawing.Point(185, 755);
            this.txtCrimeMethod.Name = "txtCrimeMethod";
            this.txtCrimeMethod.Size = new System.Drawing.Size(379, 28);
            this.txtCrimeMethod.TabIndex = 74;
            // 
            // txtCrimeType
            // 
            this.txtCrimeType.Enabled = false;
            this.txtCrimeType.Location = new System.Drawing.Point(161, 677);
            this.txtCrimeType.Name = "txtCrimeType";
            this.txtCrimeType.Size = new System.Drawing.Size(403, 28);
            this.txtCrimeType.TabIndex = 73;
            // 
            // txtCrimeDate
            // 
            this.txtCrimeDate.Enabled = false;
            this.txtCrimeDate.Location = new System.Drawing.Point(251, 641);
            this.txtCrimeDate.Name = "txtCrimeDate";
            this.txtCrimeDate.Size = new System.Drawing.Size(313, 28);
            this.txtCrimeDate.TabIndex = 72;
            // 
            // txtArticle
            // 
            this.txtArticle.Enabled = false;
            this.txtArticle.Location = new System.Drawing.Point(242, 601);
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(322, 28);
            this.txtArticle.TabIndex = 71;
            // 
            // txtDistinctiveFeatures
            // 
            this.txtDistinctiveFeatures.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtDistinctiveFeatures.Enabled = false;
            this.txtDistinctiveFeatures.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDistinctiveFeatures.Location = new System.Drawing.Point(190, 493);
            this.txtDistinctiveFeatures.Multiline = true;
            this.txtDistinctiveFeatures.Name = "txtDistinctiveFeatures";
            this.txtDistinctiveFeatures.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDistinctiveFeatures.Size = new System.Drawing.Size(374, 97);
            this.txtDistinctiveFeatures.TabIndex = 70;
            // 
            // txtPhone
            // 
            this.txtPhone.Enabled = false;
            this.txtPhone.Location = new System.Drawing.Point(143, 414);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(421, 28);
            this.txtPhone.TabIndex = 69;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(158, 375);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(406, 28);
            this.txtEmail.TabIndex = 68;
            // 
            // txtPassport
            // 
            this.txtPassport.Enabled = false;
            this.txtPassport.Location = new System.Drawing.Point(194, 336);
            this.txtPassport.Name = "txtPassport";
            this.txtPassport.Size = new System.Drawing.Size(370, 28);
            this.txtPassport.TabIndex = 67;
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(102, 295);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(462, 28);
            this.txtStatus.TabIndex = 66;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(27, 833);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(140, 24);
            this.label19.TabIndex = 65;
            this.label19.Text = "Ступінь участі";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(27, 793);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(212, 24);
            this.label17.TabIndex = 64;
            this.label17.Text = "Статус розслідування";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(27, 756);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 24);
            this.label8.TabIndex = 63;
            this.label8.Text = "Спосіб злочину";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(26, 641);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(217, 24);
            this.label16.TabIndex = 62;
            this.label16.Text = "Дата скоєння злочину";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(26, 604);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(208, 24);
            this.label15.TabIndex = 61;
            this.label15.Text = "Стаття звинувачення";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(27, 493);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(156, 24);
            this.label14.TabIndex = 60;
            this.label14.Text = "Відмітні ознаки";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(26, 418);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 24);
            this.label13.TabIndex = 59;
            this.label13.Text = "Номер тел.";
            // 
            // txtBirthLocation
            // 
            this.txtBirthLocation.Enabled = false;
            this.txtBirthLocation.Location = new System.Drawing.Point(212, 178);
            this.txtBirthLocation.Name = "txtBirthLocation";
            this.txtBirthLocation.Size = new System.Drawing.Size(352, 28);
            this.txtBirthLocation.TabIndex = 58;
            // 
            // birthLocation
            // 
            this.birthLocation.AutoSize = true;
            this.birthLocation.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.birthLocation.Location = new System.Drawing.Point(28, 181);
            this.birthLocation.Name = "birthLocation";
            this.birthLocation.Size = new System.Drawing.Size(188, 24);
            this.birthLocation.TabIndex = 57;
            this.birthLocation.Text = "Місце народження";
            // 
            // txtGender
            // 
            this.txtGender.Enabled = false;
            this.txtGender.Location = new System.Drawing.Point(94, 103);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(470, 28);
            this.txtGender.TabIndex = 56;
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.Enabled = false;
            this.txtBirthDate.Location = new System.Drawing.Point(212, 141);
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.Size = new System.Drawing.Size(352, 28);
            this.txtBirthDate.TabIndex = 55;
            // 
            // txtNickname
            // 
            this.txtNickname.Enabled = false;
            this.txtNickname.Location = new System.Drawing.Point(140, 453);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(424, 28);
            this.txtNickname.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(27, 455);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 24);
            this.label4.TabIndex = 53;
            this.label4.Text = "Псевдонім";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(28, 106);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 24);
            this.label18.TabIndex = 49;
            this.label18.Text = "Стать";
            // 
            // txtCrimeLocation
            // 
            this.txtCrimeLocation.Enabled = false;
            this.txtCrimeLocation.Location = new System.Drawing.Point(178, 717);
            this.txtCrimeLocation.Name = "txtCrimeLocation";
            this.txtCrimeLocation.Size = new System.Drawing.Size(386, 28);
            this.txtCrimeLocation.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(26, 717);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 24);
            this.label11.TabIndex = 48;
            this.label11.Text = "Місце злочину";
            // 
            // txtNationality
            // 
            this.txtNationality.Enabled = false;
            this.txtNationality.Location = new System.Drawing.Point(184, 256);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(380, 28);
            this.txtNationality.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(28, 680);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 24);
            this.label7.TabIndex = 43;
            this.label7.Text = "Тип злочину";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(28, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 24);
            this.label6.TabIndex = 42;
            this.label6.Text = "Національність";
            // 
            // txtResidence
            // 
            this.txtResidence.Enabled = false;
            this.txtResidence.Location = new System.Drawing.Point(218, 218);
            this.txtResidence.Name = "txtResidence";
            this.txtResidence.Size = new System.Drawing.Size(346, 28);
            this.txtResidence.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(28, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 24);
            this.label5.TabIndex = 41;
            this.label5.Text = "Місце проживання";
            // 
            // txtLastName
            // 
            this.txtLastName.Enabled = false;
            this.txtLastName.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLastName.Location = new System.Drawing.Point(134, 66);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(430, 28);
            this.txtLastName.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(28, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 24);
            this.label9.TabIndex = 38;
            this.label9.Text = "Дата народження";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(26, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 24);
            this.label10.TabIndex = 37;
            this.label10.Text = "Прізвище";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Enabled = false;
            this.txtFirstName.Location = new System.Drawing.Point(77, 28);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(487, 28);
            this.txtFirstName.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(28, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 24);
            this.label12.TabIndex = 35;
            this.label12.Text = "Ім\'я";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Номер паспорту";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(26, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Елект. пошта";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(28, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Статус";
            // 
            // tabVictims
            // 
            this.tabVictims.AutoScroll = true;
            this.tabVictims.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabVictims.Location = new System.Drawing.Point(4, 33);
            this.tabVictims.Name = "tabVictims";
            this.tabVictims.Size = new System.Drawing.Size(988, 569);
            this.tabVictims.TabIndex = 3;
            this.tabVictims.Text = "Потерпілі";
            // 
            // tabWitnesses
            // 
            this.tabWitnesses.AutoScroll = true;
            this.tabWitnesses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabWitnesses.Location = new System.Drawing.Point(4, 33);
            this.tabWitnesses.Name = "tabWitnesses";
            this.tabWitnesses.Size = new System.Drawing.Size(988, 569);
            this.tabWitnesses.TabIndex = 2;
            this.tabWitnesses.Text = "Свідки";
            // 
            // tabEvidence
            // 
            this.tabEvidence.AutoScroll = true;
            this.tabEvidence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabEvidence.Location = new System.Drawing.Point(4, 33);
            this.tabEvidence.Margin = new System.Windows.Forms.Padding(4);
            this.tabEvidence.Name = "tabEvidence";
            this.tabEvidence.Padding = new System.Windows.Forms.Padding(4);
            this.tabEvidence.Size = new System.Drawing.Size(1005, 596);
            this.tabEvidence.TabIndex = 1;
            this.tabEvidence.Text = "Докази";
            // 
            // tabWanted
            // 
            this.tabWanted.AutoScroll = true;
            this.tabWanted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabWanted.Location = new System.Drawing.Point(4, 33);
            this.tabWanted.Name = "tabWanted";
            this.tabWanted.Size = new System.Drawing.Size(1005, 596);
            this.tabWanted.TabIndex = 4;
            this.tabWanted.Text = "Розшук";
            // 
            // tabWarrants
            // 
            this.tabWarrants.AutoScroll = true;
            this.tabWarrants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabWarrants.Location = new System.Drawing.Point(4, 33);
            this.tabWarrants.Name = "tabWarrants";
            this.tabWarrants.Size = new System.Drawing.Size(1005, 596);
            this.tabWarrants.TabIndex = 5;
            this.tabWarrants.Text = "Ордер";
            // 
            // tabCourtCase
            // 
            this.tabCourtCase.AutoScroll = true;
            this.tabCourtCase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabCourtCase.Location = new System.Drawing.Point(4, 33);
            this.tabCourtCase.Name = "tabCourtCase";
            this.tabCourtCase.Size = new System.Drawing.Size(988, 569);
            this.tabCourtCase.TabIndex = 6;
            this.tabCourtCase.Text = "Судова справа";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(865, 633);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(152, 34);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Редагувати";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(664, 633);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CriminalDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1038, 675);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CriminalDetailsForm";
            this.Text = "Злочинець";
            this.Load += new System.EventHandler(this.CriminalDetailsForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabGeneralInfo.ResumeLayout(false);
            this.tabGeneralInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGeneralInfo;
        private System.Windows.Forms.TabPage tabEvidence;
        private System.Windows.Forms.TabPage tabVictims;
        private System.Windows.Forms.TabPage tabWitnesses;
        private System.Windows.Forms.TabPage tabWanted;
        private System.Windows.Forms.TabPage tabWarrants;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCrimeLocation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtResidence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtBirthDate;
        private System.Windows.Forms.TextBox txtBirthLocation;
        private System.Windows.Forms.Label birthLocation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtInvestigationStatus;
        private System.Windows.Forms.TextBox txtCrimeMethod;
        private System.Windows.Forms.TextBox txtCrimeType;
        private System.Windows.Forms.TextBox txtCrimeDate;
        private System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.TextBox txtDistinctiveFeatures;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDegreeParticipation;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.TabPage tabCourtCase;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button button2;
    }
}