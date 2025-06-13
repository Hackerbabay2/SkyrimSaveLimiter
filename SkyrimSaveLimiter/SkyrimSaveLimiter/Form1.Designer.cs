namespace SkyrimSaveLimiter
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ProfilePathTextBox = new TextBox();
            StartButton = new Button();
            LimiterSavesNumeric = new NumericUpDown();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            SavePressetToolStrip = new ToolStripMenuItem();
            LoadPressetToolStrip = new ToolStripMenuItem();
            BackupSaveToolStripMenuItem = new ToolStripMenuItem();
            SaveBackup = new ToolStripMenuItem();
            LoadBackup = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            TimerValueNumeric = new NumericUpDown();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)LimiterSavesNumeric).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TimerValueNumeric).BeginInit();
            SuspendLayout();
            // 
            // ProfilePathTextBox
            // 
            ProfilePathTextBox.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProfilePathTextBox.Location = new Point(162, 70);
            ProfilePathTextBox.Name = "ProfilePathTextBox";
            ProfilePathTextBox.Size = new Size(492, 33);
            ProfilePathTextBox.TabIndex = 0;
            ProfilePathTextBox.MouseClick += ProfilePathTextBox_MouseClick;
            // 
            // StartButton
            // 
            StartButton.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartButton.Location = new Point(162, 260);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(492, 33);
            StartButton.TabIndex = 1;
            StartButton.Text = "Запустить";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // LimiterSavesNumeric
            // 
            LimiterSavesNumeric.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LimiterSavesNumeric.Location = new Point(162, 145);
            LimiterSavesNumeric.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            LimiterSavesNumeric.Name = "LimiterSavesNumeric";
            LimiterSavesNumeric.Size = new Size(492, 33);
            LimiterSavesNumeric.TabIndex = 2;
            LimiterSavesNumeric.ValueChanged += LimiterSavesNumeric_ValueChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SavePressetToolStrip, LoadPressetToolStrip, BackupSaveToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // SavePressetToolStrip
            // 
            SavePressetToolStrip.Name = "SavePressetToolStrip";
            SavePressetToolStrip.Size = new Size(180, 22);
            SavePressetToolStrip.Text = "Сохранить прессет";
            SavePressetToolStrip.ToolTipText = "Сохранить настройки программы";
            SavePressetToolStrip.Click += SavePressetToolStrip_Click;
            // 
            // LoadPressetToolStrip
            // 
            LoadPressetToolStrip.Name = "LoadPressetToolStrip";
            LoadPressetToolStrip.Size = new Size(180, 22);
            LoadPressetToolStrip.Text = "Загрузить прессет";
            LoadPressetToolStrip.ToolTipText = "Загрузить настройки программы, путь до сохранений и т.д.";
            LoadPressetToolStrip.Click += LoadPressetToolStrip_Click;
            // 
            // BackupSaveToolStripMenuItem
            // 
            BackupSaveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SaveBackup, LoadBackup });
            BackupSaveToolStripMenuItem.Name = "BackupSaveToolStripMenuItem";
            BackupSaveToolStripMenuItem.Size = new Size(180, 22);
            BackupSaveToolStripMenuItem.Text = "Бэкап";
            BackupSaveToolStripMenuItem.ToolTipText = "Сохроняет или загружает сделанный бэкап, на случай если программа, что-то сделала не так";
            // 
            // SaveBackup
            // 
            SaveBackup.Name = "SaveBackup";
            SaveBackup.Size = new Size(180, 22);
            SaveBackup.Text = "Сохранить";
            SaveBackup.Click += SaveBackup_Click;
            // 
            // LoadBackup
            // 
            LoadBackup.Name = "LoadBackup";
            LoadBackup.Size = new Size(180, 22);
            LoadBackup.Text = "Загрузить";
            LoadBackup.Click += LoadBackup_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Goudy Stout", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(296, 41);
            label1.Name = "label1";
            label1.Size = new Size(223, 26);
            label1.TabIndex = 4;
            label1.Text = "Путь до сохранений";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Goudy Stout", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(288, 116);
            label2.Name = "label2";
            label2.Size = new Size(239, 26);
            label2.TabIndex = 5;
            label2.Text = "Максимум сохранений";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Goudy Stout", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(254, 192);
            label3.Name = "label3";
            label3.Size = new Size(307, 26);
            label3.TabIndex = 7;
            label3.Text = "Период проверки в минутах";
            // 
            // TimerValueNumeric
            // 
            TimerValueNumeric.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TimerValueNumeric.Location = new Point(162, 221);
            TimerValueNumeric.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            TimerValueNumeric.Name = "TimerValueNumeric";
            TimerValueNumeric.Size = new Size(492, 33);
            TimerValueNumeric.TabIndex = 6;
            TimerValueNumeric.ValueChanged += TimerValueNumeric_ValueChanged;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.SkyrimBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(TimerValueNumeric);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LimiterSavesNumeric);
            Controls.Add(StartButton);
            Controls.Add(ProfilePathTextBox);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            Text = "Skyrim Save Limiter";
            ((System.ComponentModel.ISupportInitialize)LimiterSavesNumeric).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TimerValueNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ProfilePathTextBox;
        private Button StartButton;
        private NumericUpDown LimiterSavesNumeric;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem SavePressetToolStrip;
        private ToolStripMenuItem LoadPressetToolStrip;
        private ToolStripMenuItem BackupSaveToolStripMenuItem;
        private ToolStripMenuItem SaveBackup;
        private ToolStripMenuItem LoadBackup;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown TimerValueNumeric;
        private System.Windows.Forms.Timer timer1;
    }
}
