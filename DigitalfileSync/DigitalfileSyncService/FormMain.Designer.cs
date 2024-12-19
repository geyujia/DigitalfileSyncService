namespace DigitalfileSyncService
{
    partial class 文件处理程序
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
            folderBrowserDialog1 = new FolderBrowserDialog();
            label1 = new Label();
            txtSourcePath = new TextBox();
            btnOk = new Button();
            label2 = new Label();
            txt地址 = new TextBox();
            btnSelectFile = new Button();
            openFileDialog1 = new OpenFileDialog();
            label3 = new Label();
            txtTargetPath = new TextBox();
            folderBrowserDialog2 = new FolderBrowserDialog();
            btnSelFile2 = new Button();
            btnUdp1 = new Button();
            label4 = new Label();
            label5 = new Label();
            txtUserName = new TextBox();
            panel1 = new Panel();
            cmbBoxSingle = new ComboBox();
            label7 = new Label();
            cmbBoxProject = new ComboBox();
            btnLogin = new Button();
            label6 = new Label();
            txtPwd = new TextBox();
            progressBar = new ProgressBar();
            btnSync = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 12);
            label1.Name = "label1";
            label1.Size = new Size(83, 17);
            label1.TabIndex = 0;
            label1.Text = "同步文件地址:";
            // 
            // txtSourcePath
            // 
            txtSourcePath.Location = new Point(126, 6);
            txtSourcePath.Name = "txtSourcePath";
            txtSourcePath.Size = new Size(282, 23);
            txtSourcePath.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(327, 393);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(91, 31);
            btnOk.TabIndex = 2;
            btnOk.Text = "确定";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 121);
            label2.Name = "label2";
            label2.Size = new Size(83, 17);
            label2.TabIndex = 3;
            label2.Text = "同步服务地址:";
            // 
            // txt地址
            // 
            txt地址.Location = new Point(126, 115);
            txt地址.Name = "txt地址";
            txt地址.Size = new Size(282, 23);
            txt地址.TabIndex = 4;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(424, 7);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(93, 26);
            btnSelectFile.TabIndex = 5;
            btnSelectFile.Text = "选择文件位置";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 64);
            label3.Name = "label3";
            label3.Size = new Size(107, 17);
            label3.TabIndex = 6;
            label3.Text = "文件临时存放目录:";
            // 
            // txtTargetPath
            // 
            txtTargetPath.Location = new Point(126, 64);
            txtTargetPath.Name = "txtTargetPath";
            txtTargetPath.Size = new Size(282, 23);
            txtTargetPath.TabIndex = 7;
            // 
            // btnSelFile2
            // 
            btnSelFile2.Location = new Point(425, 64);
            btnSelFile2.Name = "btnSelFile2";
            btnSelFile2.Size = new Size(93, 23);
            btnSelFile2.TabIndex = 8;
            btnSelFile2.Text = "选择文件位置";
            btnSelFile2.UseVisualStyleBackColor = true;
            btnSelFile2.Click += btnSelFile2_Click;
            // 
            // btnUdp1
            // 
            btnUdp1.Location = new Point(524, 6);
            btnUdp1.Name = "btnUdp1";
            btnUdp1.Size = new Size(54, 26);
            btnUdp1.TabIndex = 9;
            btnUdp1.Text = "修改";
            btnUdp1.UseVisualStyleBackColor = true;
            btnUdp1.Click += btnUdp1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 14);
            label4.Name = "label4";
            label4.Size = new Size(47, 17);
            label4.TabIndex = 10;
            label4.Text = "用户名:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(250, 17);
            label5.Name = "label5";
            label5.Size = new Size(35, 17);
            label5.TabIndex = 11;
            label5.Text = "密码:";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(126, 11);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(120, 23);
            txtUserName.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbBoxSingle);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(cmbBoxProject);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtPwd);
            panel1.Controls.Add(txtUserName);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(12, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(595, 147);
            panel1.TabIndex = 13;
            // 
            // cmbBoxSingle
            // 
            cmbBoxSingle.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxSingle.FormattingEnabled = true;
            cmbBoxSingle.Location = new Point(126, 93);
            cmbBoxSingle.Name = "cmbBoxSingle";
            cmbBoxSingle.Size = new Size(282, 25);
            cmbBoxSingle.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 101);
            label7.Name = "label7";
            label7.Size = new Size(59, 17);
            label7.TabIndex = 17;
            label7.Text = "选择单体:";
            // 
            // cmbBoxProject
            // 
            cmbBoxProject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxProject.FormattingEnabled = true;
            cmbBoxProject.Location = new Point(126, 53);
            cmbBoxProject.Name = "cmbBoxProject";
            cmbBoxProject.Size = new Size(282, 25);
            cmbBoxProject.TabIndex = 16;
            cmbBoxProject.SelectedIndexChanged += cmbBoxProject_SelectedIndexChanged;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(443, 11);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 15;
            btnLogin.Text = "登录";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 56);
            label6.Name = "label6";
            label6.Size = new Size(59, 17);
            label6.TabIndex = 14;
            label6.Text = "选择项目:";
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(291, 11);
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new Size(117, 23);
            txtPwd.TabIndex = 13;
            txtPwd.UseSystemPasswordChar = true;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 350);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(595, 23);
            progressBar.TabIndex = 14;
            // 
            // btnSync
            // 
            btnSync.Location = new Point(447, 393);
            btnSync.Name = "btnSync";
            btnSync.Size = new Size(82, 31);
            btnSync.TabIndex = 15;
            btnSync.Text = "同步";
            btnSync.UseVisualStyleBackColor = true;
            btnSync.Click += btnSync_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtTargetPath);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtSourcePath);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnUdp1);
            panel2.Controls.Add(txt地址);
            panel2.Controls.Add(btnSelFile2);
            panel2.Controls.Add(btnSelectFile);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(12, 167);
            panel2.Name = "panel2";
            panel2.Size = new Size(595, 161);
            panel2.TabIndex = 16;
            // 
            // 文件处理程序
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(619, 448);
            Controls.Add(panel2);
            Controls.Add(btnSync);
            Controls.Add(progressBar);
            Controls.Add(panel1);
            Controls.Add(btnOk);
            Name = "文件处理程序";
            StartPosition = FormStartPosition.Manual;
            Text = "文件处理程序";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Label label1;
        private TextBox txtSourcePath;
        private Button btnOk;
        private Label label2;
        private TextBox txt地址;
        private Button btnSelectFile;
        private OpenFileDialog openFileDialog1;
        private Label label3;
        private TextBox txtTargetPath;
        private FolderBrowserDialog folderBrowserDialog2;
        private Button btnSelFile2;
        private Button btnUdp1;
        private Label label4;
        private Label label5;
        private TextBox txtUserName;
        private Panel panel1;
        private TextBox txtPwd;
        private ComboBox cmbBoxSingle;
        private Label label7;
        private ComboBox cmbBoxProject;
        private Button btnLogin;
        private Label label6;
        private ProgressBar progressBar;
        private Button btnSync;
        private Panel panel2;
    }
}
