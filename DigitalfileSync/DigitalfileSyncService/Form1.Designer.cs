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
            btnSelectFile = new Button();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 41);
            label1.Name = "label1";
            label1.Size = new Size(103, 17);
            label1.TabIndex = 0;
            label1.Text = "选择pdf文件目录:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(28, 74);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(351, 23);
            textBox1.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(521, 70);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(87, 30);
            btnOk.TabIndex = 2;
            btnOk.Text = "确定";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(405, 70);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(89, 30);
            btnSelectFile.TabIndex = 5;
            btnSelectFile.Text = "选择文件";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // 文件处理程序
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 162);
            Controls.Add(btnSelectFile);
            Controls.Add(btnOk);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "文件处理程序";
            Text = "文件处理程序";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Label label1;
        private TextBox textBox1;
        private Button btnOk;
        private Button btnSelectFile;
        private OpenFileDialog openFileDialog1;
    }
}
