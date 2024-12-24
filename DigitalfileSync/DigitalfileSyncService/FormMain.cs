using DigitalfileSyncService.Common;
using DigitalfileSyncService.Model;
using DigitalfileSyncService.Properties;
using Newtonsoft.Json;
using Serilog;
using System.Text;

namespace DigitalfileSyncService
{
    public partial class FormMain : Form
    {
        private string sourceFolder = string.Empty;
        private string targetFolder = string.Empty;
        private string zipFilePathFolder = string.Empty;
        private string apiUrl = string.Empty;
        private decimal uploadTimeInterval = 0;

        private string projectId = string.Empty;
        private string singleId = string.Empty;
        private string accord = "0";
        //初始化定时器
        System.Timers.Timer timer1 = new System.Timers.Timer();
        public FormMain()
        {
            InitializeComponent();
            this.txtSourcePath.Text = Settings.Default.sourceFilePath;
            this.txtZipFilePath.Text = Settings.Default.zipFilePath;
            this.numuploadTimeInterval.Value = Settings.Default.uploadTimeInterval;
            this.txtAddress.Text = Settings.Default.apiUrl;

            
            this.txtPwd.Text = Settings.Default.userPwd;
            this.txtUserName.Text = Settings.Default.userName;

            //初始化ProgressBar1
            this.progressBar.Location = new Point(this.progressBar.Location.X, this.progressBar.Location.Y + 30);
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = 100;
            this.progressBar.Step = 1;
            this.progressBar.Visible = false;
            this.progressBar.Value = 1;
            this.Controls.Add(this.progressBar);

            //初始化进度百分比标签
            this.lblProgressPercentage.Text = "0%";
            this.lblProgressPercentage.Visible = false;
            this.Controls.Add(this.lblProgressPercentage);

            //按钮状态控制
            this.btnEnd.Enabled = false;

            //加载列表
            if (!this.txtUserName.Text.IsNullOrEmpty() && !this.txtPwd.Text.IsNullOrEmpty() && !this.txtAddress.Text.IsNullOrEmpty())
            {
                LoadProjectList(this.txtUserName.Text, this.txtPwd.Text);
                LoadZujuanyijuList();
            }
           
        }

        #region 其它事件实现
        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 文件处理程序_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确定要退出吗,还有未进行完的操作？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
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
                zipFilePathFolder = txtZipFilePath.Text ?? Settings.Default.zipFilePath;
                apiUrl = txtAddress.Text ?? Settings.Default.apiUrl;

                List<string> zipFileList = new List<string>();
                var str = "";
                string zipFilepath = zipFilePathFolder + @"\zipRemark.txt";
                if (File.Exists(zipFilepath))
                {
                    str = await File.ReadAllTextAsync(zipFilepath);
                }
                else
                {
                    await File.AppendAllTextAsync(zipFilepath, "");
                }
                //UpdateProgressBar(5);
                var group = str.Split('\n');
                foreach (var item in group)
                {
                    zipFileList.Add(item.Replace("\r", "").ToString());
                }

                List<ZipFileInfo> files = new List<ZipFileInfo>();
                string[] zipfiles = Directory.GetFiles(zipFilePathFolder);
                var sb = new StringBuilder();
                foreach (var item in zipfiles)
                {
                    var fileName = Path.GetFileName(item);
                    if (fileName.Equals("zipRemark.txt", StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }
                    if (zipFileList.Exists(x => x == fileName))
                    {
                        continue;
                    }
                    if (File.Exists(item))
                    {
                        var file = new ZipFileInfo();
                        file.fileName = fileName;
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
                            content.Add(new StringContent(accord), "accord");
                            content.Add(new StreamContent(File.OpenRead(item)), "file", file.fileName);
                            request.Content = content;
                            var response = await client.SendAsync(request);
                            if (response.IsSuccessStatusCode)
                            {

                                var result = await response.Content.ReadAsStringAsync();
                                var resultRsp = JsonConvert.DeserializeObject<Result<string>>(result);
                                if (resultRsp.data == "1")
                                {
                                    sb.AppendLine(file.fileName);
                                    MessageBox.Show($"上传成功:" + file.fileName, "提示");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"上传失败:{response.StatusCode}", "提示");
                            }

                        }

                        //File.Delete(item);
                    }
                }
                //记录已复制文件
                await File.AppendAllTextAsync(zipFilepath, sb.ToString());
            }
            catch (Exception ex)
            {
                Log.Error($"上传文件异常:{ex}");
                MessageBox.Show($"上传文件异常:{ex}");
            }

        }

        #endregion

        #region 按钮事件
        /// <summary>
        /// 确定事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnOk_Click(object sender, EventArgs e)
        {
            //需要做一个大小判断
            try
            {
                Log.Information("btnOk_Click 事件触发");
                sourceFolder = txtSourcePath.Text ?? Settings.Default.sourceFilePath;
                zipFilePathFolder = txtZipFilePath.Text ?? Settings.Default.zipFilePath;
                targetFolder = zipFilePathFolder + "/Temp";
                if (sourceFolder == string.Empty || targetFolder == string.Empty)
                {
                    MessageBox.Show("请先选择源文件夹和目标文件夹");
                    return;
                }
                DialogResult res = MessageBox.Show("确认进行同步操作吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    #region  进度条
                    this.btnOk.Enabled = false;
                    this.progressBar.Visible = true;
                    this.lblProgressPercentage.Visible = true;
                    #endregion
                    UpdateProgressBar(1);
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
                    UpdateProgressBar(5);
                    var group = str.Split('\n');
                    foreach (var item in group)
                    {
                        picList.Add(item.Replace("\r", "").ToString());
                    }
                    UpdateProgressBar(10);
                    //获取源文件夹下所有文件
                    string[] files = Directory.GetFiles(sourceFolder);
                    //判断目标文件夹是否存在，不存在则创建
                    if (!Directory.Exists(targetFolder))
                    {
                        Directory.CreateDirectory(targetFolder);
                    }
                    UpdateProgressBar(20);
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
                    UpdateProgressBar(50);
                    //记录已复制文件
                    await File.AppendAllTextAsync(jiluFilepath, sb.ToString());
                    UpdateProgressBar(60);

                    //压缩文件
                    string destinationZipFile = @$"{zipFilePathFolder}\output_{DateTime.Now.ToString("yyyyMMddHHmmss")}.zip";
                    if (sb.ToString().Length > 0)
                    {
                        UpdateProgressBar(70);
                        ZipHelper.CreateZip(targetFolder, destinationZipFile);
                        //删除临时文件
                        DeleteFilesExceptZip(targetFolder);
                        UpdateProgressBar(100);
                        EndResetProgressBar();
                        MessageBox.Show("同步完成", "提示", MessageBoxButtons.OK);
                    }
                    else
                    {
                        UpdateProgressBar(100);
                        EndResetProgressBar();
                        MessageBox.Show("没有需要同步的文件", "提示", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    UpdateProgressBar(100);
                    EndResetProgressBar();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                this.btnOk.Enabled = true;
                this.progressBar.Visible = false;
                this.lblProgressPercentage.Visible = false;
                UpdateProgressBar(100);
                Log.Error(ex, "btnOk_Click 事件处理失败");
                MessageBox.Show($"btnOk_Click 事件处理失败: {ex.Message}");
            }
        }
        /// <summary>
        /// 进度条结束状态
        /// </summary>
        private void EndResetProgressBar()
        {
            this.progressBar.Visible = false;
            this.lblProgressPercentage.Visible = false;
            this.btnOk.Enabled = true;
        }

        /// <summary>
        /// 登录按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            apiUrl = this.txtAddress.Text ?? Settings.Default.apiUrl;
            var name = this.txtUserName.Text ?? Settings.Default.userName;
            var pwd = this.txtPwd.Text ?? Settings.Default.userPwd;
            Settings.Default.userName = name;
            Settings.Default.userPwd = pwd;
            Settings.Default.Save();
            try
            {
                if (txtUserName.Text.Length == 0 || txtPwd.Text.Length == 0)
                {
                    MessageBox.Show("请输入用户名或密码!", "提示");
                    return;
                }

                await LoadProjectList(name, pwd);
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
            apiUrl = this.txtAddress.Text ?? Settings.Default.apiUrl;
            //this.cmbBoxSingle.Items.Clear();

            await LoadSingleProjectList();
        }


        /// <summary>
        /// 同步按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("同步功能暂未开放，敬请期待！"+ this.cmbBoxzujuanYijun.SelectedValue);
            uploadTimeInterval = (this.numuploadTimeInterval.Value == 0) ? Settings.Default.uploadTimeInterval : this.numuploadTimeInterval.Value;
            if (cmbBoxProject.DataSource == null || cmbBoxSingle.DataSource == null)
            {
                DialogResult result = MessageBox.Show("请先选择项目和单体信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (string.IsNullOrEmpty(this.txtZipFilePath.Text))
            {
                MessageBox.Show("目标地址不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            DialogResult dialog = MessageBox.Show("请确认选择项目、单体、组卷依据信息是否正确，进行该同步操作？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                //赋值
                projectId = this.cmbBoxProject.SelectedValue?.ToString();
                singleId = this.cmbBoxSingle.SelectedValue?.ToString();
                accord = this.cmbBoxzujuanYijun.SelectedValue?.ToString();
                timer1.Enabled = true;//开启
                timer1.Interval = (double)(uploadTimeInterval * 1000);//设置时间间隔 毫秒
                timer1.AutoReset = false;//设置执行次数，true为无限循环，false为只执行一次
                timer1.Elapsed += Timer1_Tick;
                this.timer1.Start();//开始执行
                                    //按钮状态控制
                this.btnSync.Enabled = false;
                this.btnEnd.Enabled = true;
            }
            else
            {
                return;
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
        /// 保存配置按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUdp3_Click(object sender, EventArgs e)
        {

            UpdateSourceFilePath();
            MessageBox.Show("保存成功！", "提示");

        }
        #endregion

        #region 选择文件按钮事件
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

        /// <summary>
        /// 选择文件按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile3_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog3.ShowDialog();
            this.txtZipFilePath.Text = this.folderBrowserDialog3.SelectedPath;
        }
        #endregion

        #region 私有方法体
        /// <summary>
        /// 获取单体列表
        /// </summary>
        /// <returns></returns>
        private async Task LoadSingleProjectList()
        {
            try
            {
                apiUrl = this.txtAddress.Text ?? Settings.Default.apiUrl;
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
            catch (Exception ex)
            {
                var e = $"加载单体信息出错:{ex.Message}";
                Log.Error(e);
                MessageBox.Show(e);
            }

        }
        /// <summary>
        /// 删除文件夹中的非zip文件
        /// </summary>
        /// <param name="folderPath"></param>
        static void DeleteFilesExceptZip(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Log.Warning("指定的文件夹不存在！");
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
                        Log.Information($"已删除文件: {file}");
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"删除文件 {file} 时出错: {ex.Message}");
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

        /// <summary>
        /// 更新配置文件
        /// </summary>
        private void UpdateSourceFilePath()
        {
            Settings.Default.sourceFilePath = this.txtSourcePath.Text;
            Settings.Default.zipFilePath = this.txtZipFilePath.Text;
            Settings.Default.apiUrl = this.txtAddress.Text;
            Settings.Default.uploadTimeInterval = this.numuploadTimeInterval.Value;
            Settings.Default.Save();
            Settings.Default.Reload();
        }
        /// <summary>
        /// 更新进度条
        /// </summary>
        /// <param name="value"></param>
        private void UpdateProgressBar(int value)
        {
            if (this.progressBar.InvokeRequired)
            {
                this.progressBar.Invoke(new Action<int>(UpdateProgressBar), value);
            }
            else
            {
                this.progressBar.Value = value;
                this.lblProgressPercentage.Text = $"{value}%";
            }
        }
        /// <summary>
        /// 加载施工依据列表
        /// </summary>
        /// <returns></returns>
        private async Task LoadZujuanyijuList()
        {
            try
            {
                apiUrl = this.txtAddress.Text ?? Settings.Default.apiUrl;
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{apiUrl}/Common/Common/GetDictListById?sortId=73");
                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var resJson = JsonConvert.DeserializeObject<Result<List<DictRsp>>>(result);
                        cmbBoxzujuanYijun.DataSource = resJson.data;
                        cmbBoxzujuanYijun.DisplayMember = "kName";
                        cmbBoxzujuanYijun.ValueMember = "dictKey";
                    }
                }
            }
            catch (Exception ex)
            {
                var e = $"加载组件依据信息出错:{ex.Message}";
                Log.Error(e);
                MessageBox.Show(e);
            }

        }
        private async Task LoadProjectList(string name, string pwd)
        {
            apiUrl = this.txtAddress.Text ?? Settings.Default.apiUrl;
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{apiUrl}/Web/ProjectSingle/GetProjectByUser?UserName={name}&UserPwd={pwd}");
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var resJson = JsonConvert.DeserializeObject<Result<List<Project>>>(result);
                    //this.cmbBoxProject.Items.Clear();
                    cmbBoxProject.DataSource = resJson.data;
                    cmbBoxProject.DisplayMember = "ProjectName";
                    cmbBoxProject.ValueMember = "Id";
                    this.cmbBoxProject.SelectedIndex = 0;
                    // 加载单体列表
                    await LoadSingleProjectList();
                }
                else
                {
                    MessageBox.Show("登录失败!");
                }
            }
        }

        #endregion

    }

}




