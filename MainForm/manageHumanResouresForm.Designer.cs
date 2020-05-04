namespace MainForm
{
    partial class manageHumanResouresForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddContact = new System.Windows.Forms.Button();
            this.buttonEditContact = new System.Windows.Forms.Button();
            this.buttonSelectContact = new System.Windows.Forms.Button();
            this.buttonRemoveContact = new System.Windows.Forms.Button();
            this.buttonShowFullList = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxContactID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxSelectGroup = new System.Windows.Forms.ComboBox();
            this.textBoxNewGroupName = new System.Windows.Forms.TextBox();
            this.buttonEditGroupName = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxSelectGroupName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonRemoveGroup = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGroupID = new System.Windows.Forms.TextBox();
            this.textBoxGroupName = new System.Windows.Forms.TextBox();
            this.buttonAddGroup = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.linkLabelEditMyInfo = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.linkLabelRefresh = new System.Windows.Forms.LinkLabel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(252, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contact";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(875, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 51);
            this.label2.TabIndex = 0;
            this.label2.Text = "Group";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(623, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 531);
            this.panel1.TabIndex = 1;
            // 
            // buttonAddContact
            // 
            this.buttonAddContact.BackColor = System.Drawing.Color.DarkCyan;
            this.buttonAddContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddContact.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAddContact.Location = new System.Drawing.Point(47, 203);
            this.buttonAddContact.Name = "buttonAddContact";
            this.buttonAddContact.Size = new System.Drawing.Size(206, 64);
            this.buttonAddContact.TabIndex = 2;
            this.buttonAddContact.Text = "Add";
            this.buttonAddContact.UseVisualStyleBackColor = false;
            this.buttonAddContact.Click += new System.EventHandler(this.buttonAddContact_Click);
            // 
            // buttonEditContact
            // 
            this.buttonEditContact.BackColor = System.Drawing.Color.DarkCyan;
            this.buttonEditContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditContact.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonEditContact.Location = new System.Drawing.Point(47, 273);
            this.buttonEditContact.Name = "buttonEditContact";
            this.buttonEditContact.Size = new System.Drawing.Size(206, 64);
            this.buttonEditContact.TabIndex = 2;
            this.buttonEditContact.Text = "Edit";
            this.buttonEditContact.UseVisualStyleBackColor = false;
            this.buttonEditContact.Click += new System.EventHandler(this.buttonEditContact_Click);
            // 
            // buttonSelectContact
            // 
            this.buttonSelectContact.BackColor = System.Drawing.Color.LightSalmon;
            this.buttonSelectContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSelectContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectContact.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSelectContact.Location = new System.Drawing.Point(366, 7);
            this.buttonSelectContact.Name = "buttonSelectContact";
            this.buttonSelectContact.Size = new System.Drawing.Size(203, 49);
            this.buttonSelectContact.TabIndex = 2;
            this.buttonSelectContact.Text = "Select Contact";
            this.buttonSelectContact.UseVisualStyleBackColor = false;
            this.buttonSelectContact.Click += new System.EventHandler(this.buttonSelectContact_Click);
            // 
            // buttonRemoveContact
            // 
            this.buttonRemoveContact.BackColor = System.Drawing.Color.DarkCyan;
            this.buttonRemoveContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemoveContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveContact.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRemoveContact.Location = new System.Drawing.Point(28, 79);
            this.buttonRemoveContact.Name = "buttonRemoveContact";
            this.buttonRemoveContact.Size = new System.Drawing.Size(532, 63);
            this.buttonRemoveContact.TabIndex = 2;
            this.buttonRemoveContact.Text = "Remove";
            this.buttonRemoveContact.UseVisualStyleBackColor = false;
            this.buttonRemoveContact.Click += new System.EventHandler(this.buttonRemoveContact_Click);
            // 
            // buttonShowFullList
            // 
            this.buttonShowFullList.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonShowFullList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShowFullList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowFullList.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonShowFullList.Location = new System.Drawing.Point(47, 599);
            this.buttonShowFullList.Name = "buttonShowFullList";
            this.buttonShowFullList.Size = new System.Drawing.Size(532, 63);
            this.buttonShowFullList.TabIndex = 2;
            this.buttonShowFullList.Text = "Show Full List";
            this.buttonShowFullList.UseVisualStyleBackColor = false;
            this.buttonShowFullList.Click += new System.EventHandler(this.buttonShowFullList_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(11, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Enter Contact ID:";
            // 
            // textBoxContactID
            // 
            this.textBoxContactID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxContactID.Location = new System.Drawing.Point(209, 17);
            this.textBoxContactID.Name = "textBoxContactID";
            this.textBoxContactID.Size = new System.Drawing.Size(151, 30);
            this.textBoxContactID.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBoxContactID);
            this.panel2.Controls.Add(this.buttonRemoveContact);
            this.panel2.Controls.Add(this.buttonSelectContact);
            this.panel2.Location = new System.Drawing.Point(18, 399);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(587, 150);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.comboBoxSelectGroup);
            this.panel3.Controls.Add(this.textBoxNewGroupName);
            this.panel3.Controls.Add(this.buttonEditGroupName);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(658, 366);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(551, 194);
            this.panel3.TabIndex = 5;
            // 
            // comboBoxSelectGroup
            // 
            this.comboBoxSelectGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectGroup.FormattingEnabled = true;
            this.comboBoxSelectGroup.Location = new System.Drawing.Point(245, 13);
            this.comboBoxSelectGroup.Name = "comboBoxSelectGroup";
            this.comboBoxSelectGroup.Size = new System.Drawing.Size(287, 33);
            this.comboBoxSelectGroup.TabIndex = 1;
            // 
            // textBoxNewGroupName
            // 
            this.textBoxNewGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewGroupName.Location = new System.Drawing.Point(245, 66);
            this.textBoxNewGroupName.Name = "textBoxNewGroupName";
            this.textBoxNewGroupName.Size = new System.Drawing.Size(287, 30);
            this.textBoxNewGroupName.TabIndex = 3;
            // 
            // buttonEditGroupName
            // 
            this.buttonEditGroupName.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonEditGroupName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditGroupName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonEditGroupName.Location = new System.Drawing.Point(157, 112);
            this.buttonEditGroupName.Name = "buttonEditGroupName";
            this.buttonEditGroupName.Size = new System.Drawing.Size(206, 64);
            this.buttonEditGroupName.TabIndex = 2;
            this.buttonEditGroupName.Text = "Edit";
            this.buttonEditGroupName.UseVisualStyleBackColor = false;
            this.buttonEditGroupName.Click += new System.EventHandler(this.buttonEditGroupName_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(36, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 29);
            this.label6.TabIndex = 0;
            this.label6.Text = "Enter New Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(79, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select Group:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.comboBoxSelectGroupName);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.buttonRemoveGroup);
            this.panel4.Location = new System.Drawing.Point(658, 566);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(551, 168);
            this.panel4.TabIndex = 6;
            // 
            // comboBoxSelectGroupName
            // 
            this.comboBoxSelectGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectGroupName.FormattingEnabled = true;
            this.comboBoxSelectGroupName.Location = new System.Drawing.Point(245, 28);
            this.comboBoxSelectGroupName.Name = "comboBoxSelectGroupName";
            this.comboBoxSelectGroupName.Size = new System.Drawing.Size(287, 33);
            this.comboBoxSelectGroupName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(79, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "Select Group:";
            // 
            // buttonRemoveGroup
            // 
            this.buttonRemoveGroup.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonRemoveGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemoveGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveGroup.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRemoveGroup.Location = new System.Drawing.Point(157, 81);
            this.buttonRemoveGroup.Name = "buttonRemoveGroup";
            this.buttonRemoveGroup.Size = new System.Drawing.Size(206, 64);
            this.buttonRemoveGroup.TabIndex = 2;
            this.buttonRemoveGroup.Text = "Remove";
            this.buttonRemoveGroup.UseVisualStyleBackColor = false;
            this.buttonRemoveGroup.Click += new System.EventHandler(this.buttonRemoveGroup_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.textBoxGroupID);
            this.panel5.Controls.Add(this.textBoxGroupName);
            this.panel5.Controls.Add(this.buttonAddGroup);
            this.panel5.Location = new System.Drawing.Point(658, 203);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(551, 157);
            this.panel5.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(19, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Enter Group Name:";
            // 
            // textBoxGroupID
            // 
            this.textBoxGroupID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGroupID.Location = new System.Drawing.Point(432, 28);
            this.textBoxGroupID.Name = "textBoxGroupID";
            this.textBoxGroupID.Size = new System.Drawing.Size(100, 30);
            this.textBoxGroupID.TabIndex = 3;
            // 
            // textBoxGroupName
            // 
            this.textBoxGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGroupName.Location = new System.Drawing.Point(245, 29);
            this.textBoxGroupName.Name = "textBoxGroupName";
            this.textBoxGroupName.Size = new System.Drawing.Size(161, 30);
            this.textBoxGroupName.TabIndex = 3;
            // 
            // buttonAddGroup
            // 
            this.buttonAddGroup.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonAddGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddGroup.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAddGroup.Location = new System.Drawing.Point(157, 79);
            this.buttonAddGroup.Name = "buttonAddGroup";
            this.buttonAddGroup.Size = new System.Drawing.Size(206, 64);
            this.buttonAddGroup.TabIndex = 2;
            this.buttonAddGroup.Text = "Add";
            this.buttonAddGroup.UseVisualStyleBackColor = false;
            this.buttonAddGroup.Click += new System.EventHandler(this.buttonAddGroup_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.linkLabelRefresh);
            this.panel6.Controls.Add(this.linkLabelEditMyInfo);
            this.panel6.Controls.Add(this.pictureBoxProfile);
            this.panel6.Controls.Add(this.labelWelcome);
            this.panel6.Controls.Add(this.buttonExit);
            this.panel6.Location = new System.Drawing.Point(0, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1225, 96);
            this.panel6.TabIndex = 8;
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelWelcome.Font = new System.Drawing.Font("MV Boli", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.ForeColor = System.Drawing.Color.Cornsilk;
            this.labelWelcome.Location = new System.Drawing.Point(106, 15);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(100, 26);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome";
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(0, -5);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(100, 101);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 1;
            this.pictureBoxProfile.TabStop = false;
            // 
            // linkLabelEditMyInfo
            // 
            this.linkLabelEditMyInfo.AutoSize = true;
            this.linkLabelEditMyInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelEditMyInfo.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelEditMyInfo.LinkColor = System.Drawing.Color.Teal;
            this.linkLabelEditMyInfo.Location = new System.Drawing.Point(106, 53);
            this.linkLabelEditMyInfo.Name = "linkLabelEditMyInfo";
            this.linkLabelEditMyInfo.Size = new System.Drawing.Size(137, 26);
            this.linkLabelEditMyInfo.TabIndex = 2;
            this.linkLabelEditMyInfo.TabStop = true;
            this.linkLabelEditMyInfo.Text = "Edit My Info";
            this.linkLabelEditMyInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEditMyInfo_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(249, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 26);
            this.label8.TabIndex = 3;
            this.label8.Text = "|";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExit.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonExit.Location = new System.Drawing.Point(955, 15);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(206, 64);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // linkLabelRefresh
            // 
            this.linkLabelRefresh.AutoSize = true;
            this.linkLabelRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelRefresh.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelRefresh.LinkColor = System.Drawing.Color.Teal;
            this.linkLabelRefresh.Location = new System.Drawing.Point(276, 53);
            this.linkLabelRefresh.Name = "linkLabelRefresh";
            this.linkLabelRefresh.Size = new System.Drawing.Size(82, 26);
            this.linkLabelRefresh.TabIndex = 2;
            this.linkLabelRefresh.TabStop = true;
            this.linkLabelRefresh.Text = "Refresh";
            this.linkLabelRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRefresh_LinkClicked);
            // 
            // manageHumanResouresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ClientSize = new System.Drawing.Size(1226, 752);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.buttonShowFullList);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonEditContact);
            this.Controls.Add(this.buttonAddContact);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "manageHumanResouresForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Human Resources";
            this.Load += new System.EventHandler(this.manageHumanResouresForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAddContact;
        private System.Windows.Forms.Button buttonEditContact;
        private System.Windows.Forms.Button buttonSelectContact;
        private System.Windows.Forms.Button buttonRemoveContact;
        private System.Windows.Forms.Button buttonShowFullList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxContactID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBoxSelectGroup;
        private System.Windows.Forms.TextBox textBoxNewGroupName;
        private System.Windows.Forms.Button buttonEditGroupName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGroupName;
        private System.Windows.Forms.Button buttonAddGroup;
        private System.Windows.Forms.ComboBox comboBoxSelectGroupName;
        private System.Windows.Forms.Button buttonRemoveGroup;
        private System.Windows.Forms.TextBox textBoxGroupID;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabelEditMyInfo;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.LinkLabel linkLabelRefresh;
    }
}