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
        private string orcUrl = "http://localhost:8080";

        public 文件处理程序()
        {
            InitializeComponent();
            starget = Resources.ResourceManager.GetString("targetFilePath");
            ssource = Resources.ResourceManager.GetString("sourceFilePath");

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

            //初始化定时器
            //this.timer1.Enabled = true;
            //this.timer1.Interval = 3000;
            //this.timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            //Task task= new Task(() =>
            //{

            //});

            MessageBox.Show("定时器触发:" + DateTime.Now.ToString("yyyyMMddHHmmss"));

        }

        /// <summary>
        /// 确定事件处理
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
            //    MessageBox.Show("请先选择项目!");
            //    return;
            //}
            //DialogResult res = MessageBox.Show("确认进行同步操作吗？", "提示", MessageBoxButtons.YesNo);
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
            //    var sue = MessageBox.Show("同步完成", "提示", MessageBoxButtons.OK);
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
                MessageBox.Show("请先选择源文件夹和目标文件夹");
                return;
            }
            //获取源文件夹下所有文件
            string[] files = Directory.GetFiles(sourceFolder);
            //判断目标文件夹是否存在，不存在则创建
            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }
            StringBuilder sb = new StringBuilder();
            foreach (string file in files)
            {
                //获取文件名
                string fileName = Path.GetFileName(file);
                //string appendText = fileName + Environment.NewLine;
                sb.AppendLine(fileName);
                //拼接目标文件夹路径和文件名
                string targetFilePath = Path.Combine(targetFolder, fileName);
                //判断目标文件是否存在，不存在则复制文件
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

            MessageBox.Show("aaaaa：" + Settings.Default.aaaaa);
            //Properties.Settings.Default["bbbb"] = "aaaaadddddddddddddddddccccccccccccc";
            //Properties.Settings.Default["ccccc"] = "ffffffffffffffffffffffffffffff";
            //Properties.Settings.Default.Save();

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
            System.Timers.Timer timer1 = new System.Timers.Timer();
            timer1.Enabled = true;//开启
            timer1.Interval = 3000;//设置时间间隔
            timer1.AutoReset = true;//设置执行次数，true为无限循环，false为只执行一次
            timer1.Elapsed += Timer1_Tick;
            timer1.Start();//开始执行
            this.btnSync.Enabled = false;
        }
    }
}




