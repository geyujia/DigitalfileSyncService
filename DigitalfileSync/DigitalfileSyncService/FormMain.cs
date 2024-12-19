using DigitalfileSyncService.Model;
using DigitalfileSyncService.Properties;
using Newtonsoft.Json;
using System.Text;

namespace DigitalfileSyncService
{
    public partial class �ļ�������� : Form
    {
        private string pathname = string.Empty;
        private string sourceFolder = string.Empty;
        private string targetFolder = string.Empty;
        private string starget = string.Empty;
        private string ssource = string.Empty;
        private string apiUrl = Settings.Default.apiUrl;
        private string orcUrl = "http://localhost:8080";

        public �ļ��������()
        {
            InitializeComponent();
            starget = Resources.ResourceManager.GetString("targetFilePath");
            ssource = Resources.ResourceManager.GetString("sourceFilePath");

            this.txtTargetPath.Text = starget;
            this.txtSourcePath.Text = ssource;
            this.txtPwd.Text = "666666";
            this.txtUserName.Text = "����";
            this.txt��ַ.Text = apiUrl;

            //��ʼ��ProgressBar1
            this.progressBar.Location = new Point(this.progressBar.Location.X, this.progressBar.Location.Y + 30);
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = 100;
            this.progressBar.Step = 1;
            this.progressBar.Visible = false;
            this.progressBar.Value = 1;
            this.Controls.Add(this.progressBar);

            //��ʼ����ʱ��
            //this.timer1.Enabled = true;
            //this.timer1.Interval = 3000;
            //this.timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            //Task task= new Task(() =>
            //{

            //});

            MessageBox.Show("��ʱ������:" + DateTime.Now.ToString("yyyyMMddHHmmss"));

        }

        /// <summary>
        /// ȷ���¼�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            sourceFolder = txtSourcePath.Text ?? ssource;
            targetFolder = txtTargetPath.Text ?? starget;
            string jiluFilepath = sourceFolder + @"\MyTest.txt";

            //if (cmbBoxProject.DataSource == null)
            //{
            //    MessageBox.Show("����ѡ����Ŀ!");
            //    return;
            //}
            //DialogResult res = MessageBox.Show("ȷ�Ͻ���ͬ��������", "��ʾ", MessageBoxButtons.YesNo);
            //if (res == DialogResult.Yes)
            //{
            //    this.progressBar.Visible = true;
            //    for (int i = 1; i <= 100; i++)
            //    {
            //        progressBar.Value = i;

            //        progressBar.Refresh();

            //        Thread.Sleep(50);
            //    }
            //    this.progressBar.Visible = false;
            //    var sue = MessageBox.Show("ͬ�����", "��ʾ", MessageBoxButtons.OK);
            //    {
            //        if (DialogResult.OK == sue)
            //        {
            //            this.Close();
            //        }
            //    }

            //}
            //else
            //{
            //    this.Close();
            //}
            if (sourceFolder == string.Empty || targetFolder == string.Empty)
            {
                MessageBox.Show("����ѡ��Դ�ļ��к�Ŀ���ļ���");
                return;
            }
            //��ȡԴ�ļ����������ļ�
            string[] files = Directory.GetFiles(sourceFolder);
            //�ж�Ŀ���ļ����Ƿ���ڣ��������򴴽�
            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }
            StringBuilder sb = new StringBuilder();
            foreach (string file in files)
            {
                //��ȡ�ļ���
                string fileName = Path.GetFileName(file);
                //string appendText = fileName + Environment.NewLine;
                sb.AppendLine(fileName);
                //ƴ��Ŀ���ļ���·�����ļ���
                string targetFilePath = Path.Combine(targetFolder, fileName);
                //�ж�Ŀ���ļ��Ƿ���ڣ������������ļ�
                if (!File.Exists(targetFilePath))
                {
                    File.Copy(file, targetFilePath);
                }
            }
            var a = sb.ToString();
            File.AppendAllText(jiluFilepath, a);

            //string destinationZipFile = @$"D:\TestFileScanProjectCopyZip\output_{DateTime.Now.ToString("yyyyMMddHHmmss")}.zip";
            //ZipHelper.CreateZip(targetFolder, destinationZipFile);

        }
        /// <summary>
        /// ѡ���ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtSourcePath.Text = this.folderBrowserDialog1.SelectedPath;
        }


        private void btnSelFile2_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog2.ShowDialog();
            this.txtTargetPath.Text = this.folderBrowserDialog2.SelectedPath;
        }
        /// <summary>
        /// ͬ��ԭ�ļ���ַ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUdp1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            //Resources.ResourceManager.GetString("sourceFilePath");

            MessageBox.Show("aaaaa��" + Settings.Default.aaaaa);
            //Properties.Settings.Default["bbbb"] = "aaaaadddddddddddddddddccccccccccccc";
            //Properties.Settings.Default["ccccc"] = "ffffffffffffffffffffffffffffff";
            //Properties.Settings.Default.Save();

        }
        /// <summary>
        /// ��¼��ť�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtUserName.Text.Length == 0 || txtPwd.Text.Length == 0)
                {
                    MessageBox.Show("�������û���������!", "��ʾ");
                    return;
                }

                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{apiUrl}/Web/ProjectSingle/GetProjectByUser?UserName={this.txtUserName.Text}&UserPwd={this.txtPwd.Text}");
                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var resJson = JsonConvert.DeserializeObject<Result<List<Project>>>(result);
                        this.cmbBoxProject.Items.Clear();
                        cmbBoxProject.DataSource = resJson.data;
                        cmbBoxProject.DisplayMember = "ProjectName";
                        cmbBoxProject.ValueMember = "Id";
                        this.cmbBoxProject.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("��¼ʧ��!");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
        /// <summary>
        /// ��Ŀѡ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void cmbBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbBoxSingle.Items.Clear();
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{apiUrl}/Web/ProjectSingle/GetSingleListById?ProjectId={this.cmbBoxProject.SelectedValue}");
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var resJson = JsonConvert.DeserializeObject<Result<List<SingleProjectRsp>>>(result);
                    cmbBoxSingle.DataSource = resJson.data;
                    cmbBoxSingle.DisplayMember = "SingleName";
                    cmbBoxSingle.ValueMember = "Id";
                }

            }
        }
        /// <summary>
        /// ͬ����ť�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            System.Timers.Timer timer1 = new System.Timers.Timer();
            timer1.Enabled = true;//����
            timer1.Interval = 3000;//����ʱ����
            timer1.AutoReset = true;//����ִ�д�����trueΪ����ѭ����falseΪִֻ��һ��
            timer1.Elapsed += Timer1_Tick;
            timer1.Start();//��ʼִ��
            this.btnSync.Enabled = false;
        }
    }
}




