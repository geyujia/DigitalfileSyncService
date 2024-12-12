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
            textBox1 = new TextBox();
            btnOk = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            btnSelectFile = new Button();
            txtContent = new TextBox();
            picBox = new PictureBox();
            btnSelImage = new Button();
            openFileDialog1 = new OpenFileDialog();
            label3 = new Label();
            btnShibie = new Button();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 48);
            label1.Name = "label1";
            label1.Size = new Size(83, 17);
            label1.TabIndex = 0;
            label1.Text = "同步文件地址:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(165, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(282, 23);
            textBox1.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(697, 655);
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
            label2.Location = new Point(46, 111);
            label2.Name = "label2";
            label2.Size = new Size(83, 17);
            label2.TabIndex = 3;
            label2.Text = "同步服务地址:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(165, 105);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(282, 23);
            textBox2.TabIndex = 4;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(453, 40);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(75, 26);
            btnSelectFile.TabIndex = 5;
            btnSelectFile.Text = "选择文件";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(46, 193);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(742, 388);
            txtContent.TabIndex = 6;
            // 
            // picBox
            // 
            picBox.BackColor = SystemColors.AppWorkspace;
            picBox.Location = new Point(844, 12);
            picBox.Name = "picBox";
            picBox.Size = new Size(568, 674);
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.TabIndex = 7;
            picBox.TabStop = false;
            // 
            // btnSelImage
            // 
            btnSelImage.Location = new Point(416, 655);
            btnSelImage.Name = "btnSelImage";
            btnSelImage.Size = new Size(80, 31);
            btnSelImage.TabIndex = 8;
            btnSelImage.Text = "选择图片";
            btnSelImage.UseVisualStyleBackColor = true;
            btnSelImage.Click += btnSelImage_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 157);
            label3.Name = "label3";
            label3.Size = new Size(59, 17);
            label3.TabIndex = 9;
            label3.Text = "识别结果:";
            // 
            // btnShibie
            // 
            btnShibie.Location = new Point(523, 655);
            btnShibie.Name = "btnShibie";
            btnShibie.Size = new Size(75, 31);
            btnShibie.TabIndex = 10;
            btnShibie.Text = "识别";
            btnShibie.UseVisualStyleBackColor = true;
            btnShibie.Click += btnShibie_Click;
            // 
            // 文件处理程序
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 709);
            Controls.Add(btnShibie);
            Controls.Add(label3);
            Controls.Add(btnSelImage);
            Controls.Add(picBox);
            Controls.Add(txtContent);
            Controls.Add(btnSelectFile);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(btnOk);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "文件处理程序";
            Text = "文件处理程序";
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Label label1;
        private TextBox textBox1;
        private Button btnOk;
        private Label label2;
        private TextBox textBox2;
        private Button btnSelectFile;
        private TextBox txtContent;
        private PictureBox picBox;
        private Button btnSelImage;
        private OpenFileDialog openFileDialog1;
        private Label label3;
        private Button btnShibie;
    }
}
