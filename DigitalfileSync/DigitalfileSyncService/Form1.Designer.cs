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
            btnShibie = new Button();
            chkBox1 = new CheckBox();
            tab识别框 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            btnSaveHtml = new Button();
            btnHtmlReg = new Button();
            txtHtmlContent = new TextBox();
            tabPaddleOCRsHARP = new TabPage();
            txtPaddleOCRContent = new TextBox();
            btnPaddleOcr = new Button();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            tab识别框.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPaddleOCRsHARP.SuspendLayout();
            SuspendLayout();
            // 
            // txtContent
            // 
            txtContent.Location = new Point(6, 3);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ScrollBars = ScrollBars.Vertical;
            txtContent.Size = new Size(919, 635);
            txtContent.TabIndex = 6;
            // 
            // picBox
            // 
            picBox.BackColor = SystemColors.AppWorkspace;
            picBox.Location = new Point(12, 12);
            picBox.Name = "picBox";
            picBox.Size = new Size(554, 658);
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.TabIndex = 7;
            picBox.TabStop = false;
            // 
            // btnSelImage
            // 
            btnSelImage.Location = new Point(486, 676);
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
            // btnShibie
            // 
            btnShibie.Location = new Point(128, 640);
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
            chkBox1.Location = new Point(47, 646);
            chkBox1.Name = "chkBox1";
            chkBox1.Size = new Size(75, 21);
            chkBox1.TabIndex = 11;
            chkBox1.Text = "是否换行";
            chkBox1.UseVisualStyleBackColor = true;
            // 
            // tab识别框
            // 
            tab识别框.Controls.Add(tabPage1);
            tab识别框.Controls.Add(tabPage2);
            tab识别框.Controls.Add(tabPaddleOCRsHARP);
            tab识别框.Location = new Point(585, 12);
            tab识别框.Name = "tab识别框";
            tab识别框.SelectedIndex = 0;
            tab识别框.Size = new Size(939, 705);
            tab识别框.TabIndex = 12;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtContent);
            tabPage1.Controls.Add(chkBox1);
            tabPage1.Controls.Add(btnShibie);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(931, 675);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "图片识别文本";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnSaveHtml);
            tabPage2.Controls.Add(btnHtmlReg);
            tabPage2.Controls.Add(txtHtmlContent);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(931, 675);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "图片识别为Html";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSaveHtml
            // 
            btnSaveHtml.Location = new Point(148, 638);
            btnSaveHtml.Name = "btnSaveHtml";
            btnSaveHtml.Size = new Size(75, 31);
            btnSaveHtml.TabIndex = 2;
            btnSaveHtml.Text = "保存文件";
            btnSaveHtml.UseVisualStyleBackColor = true;
            btnSaveHtml.Click += btnSaveHtml_Click;
            // 
            // btnHtmlReg
            // 
            btnHtmlReg.Location = new Point(40, 638);
            btnHtmlReg.Name = "btnHtmlReg";
            btnHtmlReg.Size = new Size(85, 33);
            btnHtmlReg.TabIndex = 1;
            btnHtmlReg.Text = "识别";
            btnHtmlReg.UseVisualStyleBackColor = true;
            btnHtmlReg.Click += btnHtmlReg_Click;
            // 
            // txtHtmlContent
            // 
            txtHtmlContent.Location = new Point(6, 6);
            txtHtmlContent.Multiline = true;
            txtHtmlContent.Name = "txtHtmlContent";
            txtHtmlContent.Size = new Size(919, 626);
            txtHtmlContent.TabIndex = 0;
            // 
            // tabPaddleOCRsHARP
            // 
            tabPaddleOCRsHARP.Controls.Add(btnPaddleOcr);
            tabPaddleOCRsHARP.Controls.Add(txtPaddleOCRContent);
            tabPaddleOCRsHARP.Location = new Point(4, 26);
            tabPaddleOCRsHARP.Name = "tabPaddleOCRsHARP";
            tabPaddleOCRsHARP.Padding = new Padding(3);
            tabPaddleOCRsHARP.Size = new Size(931, 675);
            tabPaddleOCRsHARP.TabIndex = 2;
            tabPaddleOCRsHARP.Text = "飞浆OCR识别";
            tabPaddleOCRsHARP.UseVisualStyleBackColor = true;
            // 
            // txtPaddleOCRContent
            // 
            txtPaddleOCRContent.Location = new Point(24, 20);
            txtPaddleOCRContent.Multiline = true;
            txtPaddleOCRContent.Name = "txtPaddleOCRContent";
            txtPaddleOCRContent.Size = new Size(883, 397);
            txtPaddleOCRContent.TabIndex = 13;
            // 
            // btnPaddleOcr
            // 
            btnPaddleOcr.Location = new Point(47, 482);
            btnPaddleOcr.Name = "btnPaddleOcr";
            btnPaddleOcr.Size = new Size(75, 23);
            btnPaddleOcr.TabIndex = 14;
            btnPaddleOcr.Text = "识别";
            btnPaddleOcr.UseVisualStyleBackColor = true;
            btnPaddleOcr.Click += btnPaddleOcr_Click;
            // 
            // 图片识别工具
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1536, 719);
            Controls.Add(tab识别框);
            Controls.Add(btnSelImage);
            Controls.Add(picBox);
            Name = "图片识别工具";
            Text = "图片识别工具(内部)";
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            tab识别框.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPaddleOCRsHARP.ResumeLayout(false);
            tabPaddleOCRsHARP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox txtContent;
        private PictureBox picBox;
        private Button btnSelImage;
        private OpenFileDialog openFileDialog1;
        private Button btnShibie;
        private CheckBox chkBox1;
        private TabControl tab识别框;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox txtHtmlContent;
        private Button btnHtmlReg;
        private Button btnSaveHtml;
        private TabPage tabPaddleOCRsHARP;
        private TextBox txtPaddleOCRContent;
        private Button btnPaddleOcr;
    }
}
