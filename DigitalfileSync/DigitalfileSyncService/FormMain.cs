using DigitalfileSyncService.Common;
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
        private string zipFilePath = Settings.Default.zipFilePath;
        private string projectId = string.Empty;
        private string singleId = string.Empty;
        //��ʼ����ʱ��
        System.Timers.Timer timer1 = new System.Timers.Timer();
        public �ļ��������()
        {
            InitializeComponent();
            starget = Settings.Default.targetFilePath;
            ssource = Settings.Default.sourceFilePath;

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

            //��ť״̬����
            this.btnEnd.Enabled = false;

        }
        /// <summary>
        /// ��ʱ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Timer1_Tick(object? sender, EventArgs e)
        {
            try
            {
                List<ZipFileInfo> files = new List<ZipFileInfo>();
                string[] zipfiles = Directory.GetFiles(zipFilePath);
                foreach (var item in zipfiles)
                {
                    if (File.Exists(item))
                    {
                        var file = new ZipFileInfo();
                        file.fileName = Path.GetFileName(item);
                        file.filePath = item;
                        file.fileSize = (int)new FileInfo(item).Length;
                        file.lastWriteTime = File.GetLastAccessTime(item);
                        file.creationTime = File.GetCreationTime(item);
                        files.Add(file);
                        //�ϴ��ɹ�
                        using (var client = new HttpClient())
                        {

                            var request = new HttpRequestMessage(HttpMethod.Post, $"{apiUrl}/Web/DigitalProcess/DPImportScanFile");
                            var content = new MultipartFormDataContent();
                            content.Add(new StringContent(projectId), "ProjectId");
                            content.Add(new StringContent(singleId), "SingleId");
                            content.Add(new StreamContent(File.OpenRead(item)), "file", file.fileName);
                            request.Content = content;
                            var response = await client.SendAsync(request);
                            if (response.IsSuccessStatusCode)
                            {
                                
                                var result = await response.Content.ReadAsStringAsync();
                                var resultRsp = JsonConvert.DeserializeObject<Result<string>>(result);
                                if (resultRsp.data == "1")
                                {
                                   MessageBox.Show($"�ϴ��ɹ�:"+file.fileName);
                                }
                            }
                            else
                            {
                                MessageBox.Show($"�ϴ�ʧ��:{response.StatusCode}");
                            }

                        }

                        File.Delete(item);
                    }
                    

                   
                }
                
                //MessageBox.Show($"��ʱ������:{JsonConvert.SerializeObject(files)}" + DateTime.Now.ToString("yyyyMMddHHmmss"));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"��ʱ�������¼��쳣:{ex}");
            }
           
        }

        /// <summary>
        /// ȷ���¼�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnOk_Click(object sender, EventArgs e)
        {
            sourceFolder = txtSourcePath.Text ?? ssource;
            targetFolder = txtTargetPath.Text ?? starget;
            if (sourceFolder == string.Empty || targetFolder == string.Empty)
            {
                MessageBox.Show("����ѡ��Դ�ļ��к�Ŀ���ļ���");
                return;
            }
            DialogResult res = MessageBox.Show("ȷ�Ͻ���ͬ��������", "��ʾ", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                this.btnOk.Enabled = false;
                #region  ������
                this.progressBar.Visible = true;
                //for (int i = 1; i <= 100; i++)
                //{
                //    progressBar.Value = i;

                //    progressBar.Refresh();

                //    Thread.Sleep(50);
                //}
                //this.progressBar.Visible = false;
                //var sue = MessageBox.Show("ͬ�����", "��ʾ", MessageBoxButtons.OK);
                //{
                //    if (DialogResult.OK == sue)
                //    {
                //        this.Close();
                //    }
                //}
                #endregion

                List<string> picList = new List<string>();
                var str = "";
                string jiluFilepath = sourceFolder + @"\Remark.txt";
                if (File.Exists(jiluFilepath))
                {
                    str = await File.ReadAllTextAsync(jiluFilepath);
                }
                else
                {
                    await File.AppendAllTextAsync(jiluFilepath, "");
                }
                progressBar.Value = 5;
                var group = str.Split('\n');
                foreach (var item in group)
                {
                    picList.Add(item.Replace("\r", "").ToString());
                }
                progressBar.Value = 10;
                //��ȡԴ�ļ����������ļ�
                string[] files = Directory.GetFiles(sourceFolder);
                //�ж�Ŀ���ļ����Ƿ���ڣ��������򴴽�
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }
                progressBar.Value = 20;
                StringBuilder sb = new StringBuilder();
                foreach (string file in files)
                {
                    //��ȡ�ļ���
                    string fileName = Path.GetFileName(file);
                    if (picList.Exists(s => s == fileName))
                    {
                        continue;
                    }
                    //ȥ����¼�ļ�
                    if (fileName.Equals("Remark.txt", StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }
                    //ƴ��Ŀ���ļ���·�����ļ���
                    string targetFilePath = Path.Combine(targetFolder, fileName);
                    //�ж�Ŀ���ļ��Ƿ���ڣ������������ļ�
                    if (!File.Exists(targetFilePath))
                    {
                        File.Copy(file, targetFilePath);
                        sb.AppendLine(fileName);
                    }
                }
                progressBar.Value = 50;
                //��¼�Ѹ����ļ�
                await File.AppendAllTextAsync(jiluFilepath, sb.ToString());
                progressBar.Value = 60;

                //ѹ���ļ�
                string destinationZipFile = @$"{zipFilePath}\output_{DateTime.Now.ToString("yyyyMMddHHmmss")}.zip";
                if (sb.ToString().Length > 0)
                {
                    progressBar.Value = 70;
                    ZipHelper.CreateZip(targetFolder, destinationZipFile);
                    //ɾ����ʱ�ļ�
                    DeleteFilesExceptZip(targetFolder);
                    MessageBox.Show("ͬ�����", "��ʾ", MessageBoxButtons.OK);
                }
                else
                {
                    progressBar.Value = 70;
                    MessageBox.Show("û����Ҫͬ�����ļ�", "��ʾ", MessageBoxButtons.OK);
                }
                progressBar.Value = 100;
                this.progressBar.Visible = false;
                this.btnOk.Enabled = true;
            }
            else
            {
                this.btnOk.Enabled = true;
                this.Close();
            }
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

           // MessageBox.Show("aaaaa��" + Settings.Default.aaaaa);
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
            if (cmbBoxProject.DataSource == null)
            {
                DialogResult result = MessageBox.Show("����ѡ����Ŀ!", "��ʾ", MessageBoxButtons.OK);
                return;
            }
            else
            {
                //��ֵ
                projectId = this.cmbBoxProject.SelectedValue?.ToString();
                singleId = this.cmbBoxSingle.SelectedValue?.ToString();
                timer1.Enabled = true;//����
                timer1.Interval =Settings.Default.uploadTimeInterval * 1000;//����ʱ���� ����
                timer1.AutoReset = false;//����ִ�д�����trueΪ����ѭ����falseΪִֻ��һ��
                timer1.Elapsed += Timer1_Tick;
                this.timer1.Start();//��ʼִ��
                //��ť״̬����
                this.btnSync.Enabled = false;
                this.btnEnd.Enabled = true;
            }
        }

        /// <summary>
        /// ������ť�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.btnSync.Enabled = true;
            this.btnEnd.Enabled = false;
        }
        /// <summary>
        /// ɾ���ļ����еķ�zip�ļ�
        /// </summary>
        /// <param name="folderPath"></param>
        static void DeleteFilesExceptZip(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("ָ�����ļ��в����ڣ�");
                return;
            }

            // ����ǰ�ļ����е��ļ�
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
            {
                string fileExtension = Path.GetExtension(file).ToLower();
                if (fileExtension != ".zip")
                {
                    try
                    {
                        File.Delete(file);
                        Console.WriteLine($"��ɾ���ļ�: {file}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ɾ���ļ� {file} ʱ����: {ex.Message}");
                    }
                }
            }

            // �ݹ鴦�����ļ���
            string[] subDirectories = Directory.GetDirectories(folderPath);
            foreach (string subDir in subDirectories)
            {
                DeleteFilesExceptZip(subDir);
            }
        }
    }

}




