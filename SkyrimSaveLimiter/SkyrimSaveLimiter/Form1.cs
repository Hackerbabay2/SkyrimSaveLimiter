using System.IO;
using System.Text.Json;

namespace SkyrimSaveLimiter
{
    public partial class MainForm : Form
    {
        private Data _data;
        private string _pressetSettingsPath;
        private bool _isTimerStart;

        public MainForm()
        {
            InitializeComponent();
            _pressetSettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _data = new Data();
            InitializeSettings();
        }

        private void InitializeSettings()
        {
            if (File.Exists(_pressetSettingsPath))
            {
                try
                {
                    _data = DeserializeData();
                    ProfilePathTextBox.Text = _data.ProfilePath;
                    LimiterSavesNumeric.Value = _data.TimerValue;
                    TimerValueNumeric.Value = _data.TimerValue;
                    timer1.Interval = _data.TimerValue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ �������� ��������: {ex.Message}", "������",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ProfilePathTextBox.Text = _data.ProfilePath;
                LimiterSavesNumeric.Value = _data.TimerValue;
                TimerValueNumeric.Value = _data.TimerValue;
                timer1.Interval = _data.TimerValue;
            }
        }

        private void SerializeData(Data data)
        {
            try
            {
                string fullPath = _pressetSettingsPath.EndsWith(".json")
                    ? _pressetSettingsPath
                    : Path.Combine(_pressetSettingsPath, "config.json");

                string directory = Path.GetDirectoryName(fullPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                string json = JsonSerializer.Serialize(data, options);
                File.WriteAllText(fullPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ����������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Data DeserializeData()
        {
            string filePath = _pressetSettingsPath.EndsWith(".json")
                ? _pressetSettingsPath
                : Path.Combine(_pressetSettingsPath, "config.json");

            if (!File.Exists(filePath))
            {
                return new Data();
            }

            try
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Data>(json);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("��� ���� ������� � ����� ��������.", "������",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ �������� ��������: {ex.Message}", "������",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Data();
            }
        }

        private void ProfilePathTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "�������� ����� � ������������";
                folderBrowserDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    ProfilePathTextBox.Text = folderBrowserDialog.SelectedPath;
                    _data.InitializeProfilePath(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void SavePressetToolStrip_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "������� ����, ���� ����� ��������� ������ ��������";
                saveFileDialog.FileName = "config.json";
                saveFileDialog.InitialDirectory = _pressetSettingsPath;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog.FileName != null || saveFileDialog.FileName != string.Empty)
                    {
                        _pressetSettingsPath = Path.GetDirectoryName(saveFileDialog.FileName);
                        SerializeData(_data);
                    }
                    else
                    {
                        MessageBox.Show("���������� ����������, �� ������ ���� ��� ����", "������", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void LimiterSavesNumeric_ValueChanged(object sender, EventArgs e)
        {
            _data.InitializeSaveLimit((int)LimiterSavesNumeric.Value);
        }

        private void TimerValueNumeric_ValueChanged(object sender, EventArgs e)
        {
            _data.InitializeTimerValue(((int)TimerValueNumeric.Value * 1000) * 60);
            timer1.Interval = _data.TimerValue;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (_data.ProfilePath != null && _data.ProfilePath != string.Empty)
            {
                StartButton.Text = _isTimerStart ? "���������" : "����������";

                if (_isTimerStart)
                {
                    MessageBox.Show("���������� ���������� ����������");
                    _isTimerStart = false;
                    timer1.Stop();
                }
                else
                {
                    MessageBox.Show("���������� ���������� �������, ������ ������");
                    _isTimerStart = true;
                    timer1.Start();
                }
            }
        }

        public void DeleteOldSaves()
        {
            if (string.IsNullOrEmpty(_data.ProfilePath) || !Directory.Exists(_data.ProfilePath))
            {
                MessageBox.Show("�������� ���� � �����������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var files = Directory.GetFiles(_data.ProfilePath)
                    .Select(file => new FileInfo(file))
                    .OrderBy(file => file.LastWriteTime)
                    .ToList();

                if (files.Count > _data.SaveLimit)
                {
                    int filesToDelete = files.Count - _data.SaveLimit;
                    for (int i = 0; i < filesToDelete; i++)
                    {
                        files[i].Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ������: {ex.Message}", "������",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopyDirectory(string sourceDir, string destinationDir)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                throw new DirectoryNotFoundException($"����� �� �������: {sourceDir}");

            Directory.CreateDirectory(destinationDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                CopyDirectory(subDir.FullName, newDestinationDir);
            }
        }

        public void MakeBackupSaves()
        {
            if (string.IsNullOrEmpty(_data.ProfilePath) || !Directory.Exists(_data.ProfilePath))
            {
                MessageBox.Show("�������� ���� � �����������!", "������",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(_pressetSettingsPath))
            {
                MessageBox.Show("�� ������ ���� ��� ��������� �����!", "������",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string backupPath = Path.Combine(_pressetSettingsPath, "BackupSaves");

                if (Directory.Exists(backupPath))
                {
                    Directory.Delete(backupPath, true);
                }

                CopyDirectory(_data.ProfilePath, backupPath);

                MessageBox.Show("��������� ����� ���������� ������� �������!", "�����",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ��������� �����: {ex.Message}", "������",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadBackupSaves()
        {
            if (string.IsNullOrEmpty(_pressetSettingsPath))
            {
                MessageBox.Show("�� ������ ���� � ��������� �����!", "������",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string backupPath = Path.Combine(_pressetSettingsPath, "BackupSaves");

            if (!Directory.Exists(backupPath))
            {
                MessageBox.Show("��������� ����� �� �������!", "������",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (Directory.Exists(_data.ProfilePath))
                {
                    Directory.Delete(_data.ProfilePath, true);
                }

                CopyDirectory(backupPath, _data.ProfilePath);

                MessageBox.Show("���������� ������� ������������� �� ��������� �����!", "�����",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ��������������: {ex.Message}", "������",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DeleteOldSaves();
        }

        private void SaveBackup_Click(object sender, EventArgs e)
        {
            MakeBackupSaves();
        }

        private void LoadBackup_Click(object sender, EventArgs e)
        {
            LoadBackupSaves();
        }

        private void LoadPressetToolStrip_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "�������� ���� � �����������";
                openFileDialog.InitialDirectory = Path.GetDirectoryName(_data.ProfilePath);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _pressetSettingsPath = openFileDialog.FileName;
                    _data = DeserializeData();
                    InitializeSettings();
                }
            }
        }
    }

    [Serializable]
    public class Data
    {
        public string ProfilePath { get; set; }
        public int TimerValue { get; set; }
        public int SaveLimit { get; set; }

        public Data()
        {
            ProfilePath = string.Empty;
            TimerValue = 1;
            SaveLimit = 10;
        }

        public void InitializeProfilePath(string path)
        {
            ProfilePath = path;
        }

        public void InitializeTimerValue(int value)
        {
            TimerValue = value;
        }

        public void InitializeSaveLimit(int value)
        {
            SaveLimit = value;
        }
    }
}