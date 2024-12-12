namespace DigitalfileSyncService
{
    partial class 图片识别工具
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
            txtContent = new TextBox();
            picBox = new PictureBox();
            btnSelImage = new Button();
            openFileDialog1 = new OpenFileDialog();
            label3 = new Label();
            btnShibie = new Button();
            chkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            SuspendLayout();
            // 
            // txtContent
            // 
            txtContent.Location = new Point(615, 29);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ScrollBars = ScrollBars.Vertical;
            txtContent.Size = new Size(797, 631);
            txtContent.TabIndex = 6;
            // 
            // picBox
            // 
            picBox.BackColor = SystemColors.AppWorkspace;
            picBox.Location = new Point(12, 12);
            picBox.Name = "picBox";
            picBox.Size = new Size(554, 685);
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.TabIndex = 7;
            picBox.TabStop = false;
            // 
            // btnSelImage
            // 
            btnSelImage.Location = new Point(615, 666);
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
            label3.Location = new Point(615, 9);
            label3.Name = "label3";
            label3.Size = new Size(59, 17);
            label3.TabIndex = 9;
            label3.Text = "识别结果:";
            // 
            // btnShibie
            // 
            btnShibie.Location = new Point(826, 666);
            btnShibie.Name = "btnShibie";
            btnShibie.Size = new Size(75, 31);
            btnShibie.TabIndex = 10;
            btnShibie.Text = "识别";
            btnShibie.UseVisualStyleBackColor = true;
            btnShibie.Click += btnShibie_Click;
            // 
            // chkBox1
            // 
            chkBox1.AutoSize = true;
            chkBox1.Location = new Point(745, 672);
            chkBox1.Name = "chkBox1";
            chkBox1.Size = new Size(75, 21);
            chkBox1.TabIndex = 11;
            chkBox1.Text = "是否换行";
            chkBox1.UseVisualStyleBackColor = true;
            // 
            // 图片识别工具
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 709);
            Controls.Add(chkBox1);
            Controls.Add(btnShibie);
            Controls.Add(label3);
            Controls.Add(btnSelImage);
            Controls.Add(picBox);
            Controls.Add(txtContent);
            Name = "图片识别工具";
            Text = "图片识别工具(内部)";
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox txtContent;
        private PictureBox picBox;
        private Button btnSelImage;
        private OpenFileDialog openFileDialog1;
        private Label label3;
        private Button btnShibie;
        private CheckBox chkBox1;
    }
}
