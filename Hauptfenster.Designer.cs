namespace SophosPartnerCentral
{
    partial class HauptFenster
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "PC1",
            "Computer",
            "good",
            "dom\\test1",
            "01.01.2000 15:15 Uhr",
            "Windows 7 Professional",
            "Enabled",
            "192.168.222.177",
            "good",
            "good"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "SBS-SRV",
            "Server",
            "good",
            "dom\\test2",
            "01.01.2000 15:30 Uhr",
            "Windows Server 2012 R2",
            "Disabled",
            "192.168.1.110",
            "good",
            "good"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HauptFenster));
            this.ListBoxKunden = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ListViewDevices = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mapulationsschutzkennwortAbrufenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.LabelSeperator = new System.Windows.Forms.Label();
            this.LabelSonstiges = new System.Windows.Forms.Label();
            this.LabelDataGeography = new System.Windows.Forms.Label();
            this.LabelBillingType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelKundenName = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktualisierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemZKunden = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripLabelPartnerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Ladebalken = new System.Windows.Forms.ToolStripProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxKunden
            // 
            this.ListBoxKunden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxKunden.FormattingEnabled = true;
            this.ListBoxKunden.Items.AddRange(new object[] {
            "Musterkunde GmbH"});
            this.ListBoxKunden.Location = new System.Drawing.Point(1, 1);
            this.ListBoxKunden.Name = "ListBoxKunden";
            this.ListBoxKunden.Size = new System.Drawing.Size(256, 498);
            this.ListBoxKunden.TabIndex = 0;
            this.ListBoxKunden.SelectedIndexChanged += new System.EventHandler(this.ListBoxKunden_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListBoxKunden);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.LabelSeperator);
            this.splitContainer1.Panel2.Controls.Add(this.LabelSonstiges);
            this.splitContainer1.Panel2.Controls.Add(this.LabelDataGeography);
            this.splitContainer1.Panel2.Controls.Add(this.LabelBillingType);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.LabelKundenName);
            this.splitContainer1.Size = new System.Drawing.Size(1268, 499);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 108);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1002, 391);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ListViewDevices);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(994, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Geräte";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ListViewDevices
            // 
            this.ListViewDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader10,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.ListViewDevices.ContextMenuStrip = this.contextMenuStrip1;
            this.ListViewDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewDevices.FullRowSelect = true;
            this.ListViewDevices.GridLines = true;
            this.ListViewDevices.HideSelection = false;
            this.ListViewDevices.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.ListViewDevices.Location = new System.Drawing.Point(3, 3);
            this.ListViewDevices.MultiSelect = false;
            this.ListViewDevices.Name = "ListViewDevices";
            this.ListViewDevices.Size = new System.Drawing.Size(988, 359);
            this.ListViewDevices.TabIndex = 8;
            this.ListViewDevices.UseCompatibleStateImageBehavior = false;
            this.ListViewDevices.View = System.Windows.Forms.View.Details;
            this.ListViewDevices.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewDevices_ColumnClick);
            this.ListViewDevices.DoubleClick += new System.EventHandler(this.ListViewDevices_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Typ";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Zustand";
            this.columnHeader3.Width = 55;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Benutzer";
            this.columnHeader4.Width = 130;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "letzter Kontakt";
            this.columnHeader5.Width = 125;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Betriebssystem";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Manipulationsschutz";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "IP";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Zustand (Bedrohung)";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Zustand (Dienste)";
            this.columnHeader9.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapulationsschutzkennwortAbrufenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(269, 26);
            // 
            // mapulationsschutzkennwortAbrufenToolStripMenuItem
            // 
            this.mapulationsschutzkennwortAbrufenToolStripMenuItem.Name = "mapulationsschutzkennwortAbrufenToolStripMenuItem";
            this.mapulationsschutzkennwortAbrufenToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.mapulationsschutzkennwortAbrufenToolStripMenuItem.Text = "Mapulationsschutzkennwort abrufen";
            this.mapulationsschutzkennwortAbrufenToolStripMenuItem.Click += new System.EventHandler(this.MapulationsschutzkennwortAbrufenToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(994, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Alerts";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(988, 359);
            this.label4.TabIndex = 11;
            this.label4.Text = "ToDo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelSeperator
            // 
            this.LabelSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelSeperator.BackColor = System.Drawing.Color.Black;
            this.LabelSeperator.Location = new System.Drawing.Point(12, 32);
            this.LabelSeperator.Name = "LabelSeperator";
            this.LabelSeperator.Size = new System.Drawing.Size(982, 1);
            this.LabelSeperator.TabIndex = 7;
            // 
            // LabelSonstiges
            // 
            this.LabelSonstiges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSonstiges.Location = new System.Drawing.Point(68, 73);
            this.LabelSonstiges.Name = "LabelSonstiges";
            this.LabelSonstiges.Size = new System.Drawing.Size(397, 18);
            this.LabelSonstiges.TabIndex = 6;
            this.LabelSonstiges.Text = "[...]";
            // 
            // LabelDataGeography
            // 
            this.LabelDataGeography.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDataGeography.Location = new System.Drawing.Point(68, 55);
            this.LabelDataGeography.Name = "LabelDataGeography";
            this.LabelDataGeography.Size = new System.Drawing.Size(187, 18);
            this.LabelDataGeography.TabIndex = 5;
            this.LabelDataGeography.Text = "[dataGeography]";
            // 
            // LabelBillingType
            // 
            this.LabelBillingType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBillingType.Location = new System.Drawing.Point(68, 37);
            this.LabelBillingType.Name = "LabelBillingType";
            this.LabelBillingType.Size = new System.Drawing.Size(179, 18);
            this.LabelBillingType.TabIndex = 4;
            this.LabelBillingType.Text = "[billingType]";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "ID:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Region:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Typ:";
            // 
            // LabelKundenName
            // 
            this.LabelKundenName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelKundenName.Location = new System.Drawing.Point(12, 12);
            this.LabelKundenName.Name = "LabelKundenName";
            this.LabelKundenName.Size = new System.Drawing.Size(555, 18);
            this.LabelKundenName.TabIndex = 0;
            this.LabelKundenName.Text = "[KundenName]";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.ansichtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1268, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aktualisierenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // aktualisierenToolStripMenuItem
            // 
            this.aktualisierenToolStripMenuItem.Name = "aktualisierenToolStripMenuItem";
            this.aktualisierenToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.aktualisierenToolStripMenuItem.Text = "Kundenliste aktualisieren";
            this.aktualisierenToolStripMenuItem.Click += new System.EventHandler(this.AktualisierenToolStripMenuItem_Click);
            // 
            // ansichtToolStripMenuItem
            // 
            this.ansichtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemZKunden});
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ansichtToolStripMenuItem.Text = "Ansicht";
            // 
            // toolStripMenuItemZKunden
            // 
            this.toolStripMenuItemZKunden.Checked = true;
            this.toolStripMenuItemZKunden.CheckOnClick = true;
            this.toolStripMenuItemZKunden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemZKunden.Name = "toolStripMenuItemZKunden";
            this.toolStripMenuItemZKunden.Size = new System.Drawing.Size(222, 22);
            this.toolStripMenuItemZKunden.Text = "Z-/ZZZ-Kunden ausblenden";
            this.toolStripMenuItemZKunden.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemZKunden_CheckedChanged_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLabelPartnerName,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.Ladebalken});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1268, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ToolStripLabelPartnerName
            // 
            this.ToolStripLabelPartnerName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripLabelPartnerName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripLabelPartnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolStripLabelPartnerName.Name = "ToolStripLabelPartnerName";
            this.ToolStripLabelPartnerName.Size = new System.Drawing.Size(79, 17);
            this.ToolStripLabelPartnerName.Text = "[PartnerName]";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(587, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(587, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // Ladebalken
            // 
            this.Ladebalken.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Ladebalken.MarqueeAnimationSpeed = 20;
            this.Ladebalken.Maximum = 50;
            this.Ladebalken.Name = "Ladebalken";
            this.Ladebalken.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Ladebalken.Size = new System.Drawing.Size(100, 16);
            this.Ladebalken.Step = 5;
            this.Ladebalken.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.Ladebalken.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(579, 533);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "© 2019 by Florian Neumann";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HauptFenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 551);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HauptFenster";
            this.Text = "Sophos Partner - Central";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxKunden;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripLabelPartnerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelKundenName;
        private System.Windows.Forms.Label LabelSonstiges;
        private System.Windows.Forms.Label LabelDataGeography;
        private System.Windows.Forms.Label LabelBillingType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelSeperator;
        private System.Windows.Forms.ListView ListViewDevices;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ToolStripProgressBar Ladebalken;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem aktualisierenToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mapulationsschutzkennwortAbrufenToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemZKunden;
    }
}

