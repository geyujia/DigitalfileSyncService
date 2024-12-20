using DigitalfileSyncService.Common;
using DigitalfileSyncService.Model;
using DigitalfileSyncService.Properties;
using Newtonsoft.Json;
using System.Text;

namespace DigitalfileSyncService
{
    public partial class 文件处理程序 : Form
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
        //初始化定时器
        System.Timers.Timer timer1 = new System.Timers.Timer();
        public 文件处理程序()
        {
            InitializeComponent();
            starget = Settings.Default.targetFilePath;
            ssource = Settings.Default.sourceFilePath;

            this.txtTargetPath.Text = starget;
            this.txtSourcePath.Text = ssource;
            this.txtPwd.Text = "666666";
            this.txtUserName.Text = "姜毅";
            this.txt地址.Text = apiUrl;

            //初始化ProgressBar1
            this.progressBar.Location = new Point(this.progressBar.Location.X, this.progressBar.Location.Y + 30);
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = 100;
            this.progressBar.Step = 1;
            this.progressBar.Visible = false;
            this.progressBar.Value = 1;
            this.Controls.Add(this.progressBar);

            //按钮状态控制
            this.btnEnd.Enabled = false;

        }
        /// <summary>
        /// 定时器事件
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
                        //上传成功
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
                                   MessageBox.Show($"上传成功:"+file.fileName);
                                }
                            }
                            else
                            {
                                MessageBox.Show($"上传失败:{response.StatusCode}");
                            }

                        }

                        File.Delete(item);
                    }
                    

                   
                }
                
                //MessageBox.Show($"定时器触发:{JsonConvert.SerializeObject(files)}" + DateTime.Now.ToString("yyyyMMddHHmmss"));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"定时器触发事件异常:{ex}");
            }
           
        }

        /// <summary>
        /// 确定事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnOk_Click(object sender, EventArgs e)
        {
            sourceFolder = txtSourcePath.Text ?? ssource;
            targetFolder = txtTargetPath.Text ?? starget;
            if (sourceFolder == string.Empty || targetFolder == string.Empty)
            {
                MessageBox.Show("请先选择源文件夹和目标文件夹");
                return;
            }
            DialogResult res = MessageBox.Show("确认进行同步操作吗？", "提示", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                this.btnOk.Enabled = false;
                #region  进度条
                this.progressBar.Visible = true;
                //for (int i = 1; i <= 100; i++)
                //{
                //    progressBar.Value = i;

                //    progressBar.Refresh();

                //    Thread.Sleep(50);
                //}
                //this.progressBar.Visible = false;
                //var sue = MessageBox.Show("同步完成", "提示", MessageBoxButtons.OK);
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
                //获取源文件夹下所有文件
                string[] files = Directory.GetFiles(sourceFolder);
                //判断目标文件夹是否存在，不存在则创建
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }
                progressBar.Value = 20;
                StringBuilder sb = new StringBuilder();
                foreach (string file in files)
                {
                    //获取文件名
                    string fileName = Path.GetFileName(file);
                    if (picList.Exists(s => s == fileName))
                    {
                        continue;
                    }
                    //去掉记录文件
                    if (fileName.Equals("Remark.txt", StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }
                    //拼接目标文件夹路径和文件名
                    string targetFilePath = Path.Combine(targetFolder, fileName);
                    //判断目标文件是否存在，不存在则复制文件
                    if (!File.Exists(targetFilePath))
                    {
                        File.Copy(file, targetFilePath);
                        sb.AppendLine(fileName);
                    }
                }
                progressBar.Value = 50;
                //记录已复制文件
                await File.AppendAllTextAsync(jiluFilepath, sb.ToString());
                progressBar.Value = 60;

                //压缩文件
                string destinationZipFile = @$"{zipFilePath}\output_{DateTime.Now.ToString("yyyyMMddHHmmss")}.zip";
                if (sb.ToString().Length > 0)
                {
                    progressBar.Value = 70;
                    ZipHelper.CreateZip(targetFolder, destinationZipFile);
                    //删除临时文件
                    DeleteFilesExceptZip(targetFolder);
                    MessageBox.Show("同步完成", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    progressBar.Value = 70;
                    MessageBox.Show("没有需要同步的文件", "提示", MessageBoxButtons.OK);
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
        /// 选择文件
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
        /// 同步原文件地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUdp1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            //Resources.ResourceManager.GetString("sourceFilePath");

           // MessageBox.Show("aaaaa：" + Settings.Default.aaaaa);
        }
        /// <summary>
        /// 登录按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtUserName.Text.Length == 0 || txtPwd.Text.Length == 0)
                {
                    MessageBox.Show("请输入用户名或密码!", "提示");
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
                        MessageBox.Show("登录失败!");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
        /// <summary>
        /// 项目选择事件
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
        /// 同步按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            if (cmbBoxProject.DataSource == null)
            {
                DialogResult result = MessageBox.Show("请先选择项目!", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                //赋值
                projectId = this.cmbBoxProject.SelectedValue?.ToString();
                singleId = this.cmbBoxSingle.SelectedValue?.ToString();
                timer1.Enabled = true;//开启
                timer1.Interval =Settings.Default.uploadTimeInterval * 1000;//设置时间间隔 毫秒
                timer1.AutoReset = false;//设置执行次数，true为无限循环，false为只执行一次
                timer1.Elapsed += Timer1_Tick;
                this.timer1.Start();//开始执行
                //按钮状态控制
                this.btnSync.Enabled = false;
                this.btnEnd.Enabled = true;
            }
        }

        /// <summary>
        /// 结束按钮事件
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
        /// 删除文件夹中的非zip文件
        /// </summary>
        /// <param name="folderPath"></param>
        static void DeleteFilesExceptZip(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("指定的文件夹不存在！");
                return;
            }

            // 处理当前文件夹中的文件
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
            {
                string fileExtension = Path.GetExtension(file).ToLower();
                if (fileExtension != ".zip")
                {
                    try
                    {
                        File.Delete(file);
                        Console.WriteLine($"已删除文件: {file}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"删除文件 {file} 时出错: {ex.Message}");
                    }
                }
            }

            // 递归处理子文件夹
            string[] subDirectories = Directory.GetDirectories(folderPath);
            foreach (string subDir in subDirectories)
            {
                DeleteFilesExceptZip(subDir);
            }
        }
    }

}




