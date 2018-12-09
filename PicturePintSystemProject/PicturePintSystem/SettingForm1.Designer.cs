namespace PicturePintSystem
{
    partial class SettingForm1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm1));
            this.headPanel = new System.Windows.Forms.Panel();
            this.setbtn = new System.Windows.Forms.Button();
            this.maxBtn = new System.Windows.Forms.Button();
            this.minBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.bodyTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnPanel = new System.Windows.Forms.Panel();
            this.startBtn = new System.Windows.Forms.Button();
            this.zhanBtn = new System.Windows.Forms.Button();
            this.setPanel = new System.Windows.Forms.Panel();
            this.selPrintBtn = new System.Windows.Forms.Button();
            this.addPrint = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.picPanel = new System.Windows.Forms.Panel();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.countLab = new System.Windows.Forms.Label();
            this.countTxt = new System.Windows.Forms.TextBox();
            this.detailPanel = new System.Windows.Forms.Panel();
            this.detailPic = new System.Windows.Forms.PictureBox();
            this.headPanel.SuspendLayout();
            this.bodyTableLayout.SuspendLayout();
            this.btnPanel.SuspendLayout();
            this.setPanel.SuspendLayout();
            this.detailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailPic)).BeginInit();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headPanel.Controls.Add(this.closeBtn);
            this.headPanel.Controls.Add(this.minBtn);
            this.headPanel.Controls.Add(this.maxBtn);
            this.headPanel.Controls.Add(this.setbtn);
            this.headPanel.Location = new System.Drawing.Point(-2, -3);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(1082, 42);
            this.headPanel.TabIndex = 0;
            // 
            // setbtn
            // 
            this.setbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setbtn.Location = new System.Drawing.Point(786, 14);
            this.setbtn.Name = "setbtn";
            this.setbtn.Size = new System.Drawing.Size(53, 25);
            this.setbtn.TabIndex = 0;
            this.setbtn.Text = "设置";
            this.setbtn.UseVisualStyleBackColor = true;
            // 
            // maxBtn
            // 
            this.maxBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxBtn.Location = new System.Drawing.Point(923, 14);
            this.maxBtn.Name = "maxBtn";
            this.maxBtn.Size = new System.Drawing.Size(72, 25);
            this.maxBtn.TabIndex = 1;
            this.maxBtn.Text = "最大化";
            this.maxBtn.UseVisualStyleBackColor = true;
            // 
            // minBtn
            // 
            this.minBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minBtn.Location = new System.Drawing.Point(845, 14);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(72, 25);
            this.minBtn.TabIndex = 2;
            this.minBtn.Text = "最小化";
            this.minBtn.UseVisualStyleBackColor = true;
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.Location = new System.Drawing.Point(1001, 14);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 25);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "关闭";
            this.closeBtn.UseVisualStyleBackColor = true;
            // 
            // bodyTableLayout
            // 
            this.bodyTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bodyTableLayout.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bodyTableLayout.ColumnCount = 3;
            this.bodyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.32735F));
            this.bodyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.67265F));
            this.bodyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 229F));
            this.bodyTableLayout.Controls.Add(this.picPanel, 0, 0);
            this.bodyTableLayout.Controls.Add(this.btnPanel, 2, 2);
            this.bodyTableLayout.Controls.Add(this.setPanel, 2, 1);
            this.bodyTableLayout.Controls.Add(this.detailPanel, 1, 0);
            this.bodyTableLayout.Location = new System.Drawing.Point(-2, 42);
            this.bodyTableLayout.Name = "bodyTableLayout";
            this.bodyTableLayout.RowCount = 3;
            this.bodyTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.47262F));
            this.bodyTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.52738F));
            this.bodyTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.bodyTableLayout.Size = new System.Drawing.Size(1082, 562);
            this.bodyTableLayout.TabIndex = 1;
            // 
            // btnPanel
            // 
            this.btnPanel.Controls.Add(this.zhanBtn);
            this.btnPanel.Controls.Add(this.startBtn);
            this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPanel.Location = new System.Drawing.Point(855, 496);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(224, 63);
            this.btnPanel.TabIndex = 0;
            // 
            // startBtn
            // 
            this.startBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startBtn.Location = new System.Drawing.Point(21, 3);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(85, 52);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "开始";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // zhanBtn
            // 
            this.zhanBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zhanBtn.Location = new System.Drawing.Point(120, 3);
            this.zhanBtn.Name = "zhanBtn";
            this.zhanBtn.Size = new System.Drawing.Size(85, 52);
            this.zhanBtn.TabIndex = 1;
            this.zhanBtn.Text = "暂停";
            this.zhanBtn.UseVisualStyleBackColor = true;
            // 
            // setPanel
            // 
            this.setPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setPanel.Controls.Add(this.countTxt);
            this.setPanel.Controls.Add(this.countLab);
            this.setPanel.Controls.Add(this.button6);
            this.setPanel.Controls.Add(this.button5);
            this.setPanel.Controls.Add(this.nextBtn);
            this.setPanel.Controls.Add(this.prevBtn);
            this.setPanel.Controls.Add(this.addPrint);
            this.setPanel.Controls.Add(this.selPrintBtn);
            this.setPanel.Location = new System.Drawing.Point(855, 99);
            this.setPanel.Name = "setPanel";
            this.setPanel.Size = new System.Drawing.Size(224, 391);
            this.setPanel.TabIndex = 1;
            // 
            // selPrintBtn
            // 
            this.selPrintBtn.Location = new System.Drawing.Point(0, 17);
            this.selPrintBtn.Name = "selPrintBtn";
            this.selPrintBtn.Size = new System.Drawing.Size(221, 46);
            this.selPrintBtn.TabIndex = 0;
            this.selPrintBtn.Text = "选择打印机";
            this.selPrintBtn.UseVisualStyleBackColor = true;
            this.selPrintBtn.Click += new System.EventHandler(this.selPrintBtn_Click);
            // 
            // addPrint
            // 
            this.addPrint.Location = new System.Drawing.Point(0, 69);
            this.addPrint.Name = "addPrint";
            this.addPrint.Size = new System.Drawing.Size(221, 46);
            this.addPrint.TabIndex = 1;
            this.addPrint.Text = "加入打印列";
            this.addPrint.UseVisualStyleBackColor = true;
            // 
            // prevBtn
            // 
            this.prevBtn.Location = new System.Drawing.Point(0, 121);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(106, 46);
            this.prevBtn.TabIndex = 2;
            this.prevBtn.Text = "队列前移";
            this.prevBtn.UseVisualStyleBackColor = true;
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(112, 121);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(109, 46);
            this.nextBtn.TabIndex = 3;
            this.nextBtn.Text = "队列后移";
            this.nextBtn.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 173);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 46);
            this.button5.TabIndex = 4;
            this.button5.Text = "取消";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(115, 173);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(106, 46);
            this.button6.TabIndex = 5;
            this.button6.Text = "移除";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // picPanel
            // 
            this.picPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picPanel.AutoScroll = true;
            this.picPanel.Location = new System.Drawing.Point(3, 3);
            this.picPanel.Name = "picPanel";
            this.bodyTableLayout.SetRowSpan(this.picPanel, 3);
            this.picPanel.Size = new System.Drawing.Size(201, 556);
            this.picPanel.TabIndex = 3;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // pageSetupDialog
            // 
            this.pageSetupDialog.Document = this.printDocument;
            // 
            // countLab
            // 
            this.countLab.AutoSize = true;
            this.countLab.Location = new System.Drawing.Point(3, 254);
            this.countLab.Name = "countLab";
            this.countLab.Size = new System.Drawing.Size(67, 15);
            this.countLab.TabIndex = 6;
            this.countLab.Text = "打印份数";
            // 
            // countTxt
            // 
            this.countTxt.Location = new System.Drawing.Point(91, 251);
            this.countTxt.Name = "countTxt";
            this.countTxt.Size = new System.Drawing.Size(126, 25);
            this.countTxt.TabIndex = 7;
            // 
            // detailPanel
            // 
            this.detailPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.detailPanel.Controls.Add(this.detailPic);
            this.detailPanel.Location = new System.Drawing.Point(210, 3);
            this.detailPanel.Name = "detailPanel";
            this.bodyTableLayout.SetRowSpan(this.detailPanel, 3);
            this.detailPanel.Size = new System.Drawing.Size(639, 556);
            this.detailPanel.TabIndex = 4;
            // 
            // detailPic
            // 
            this.detailPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailPic.Location = new System.Drawing.Point(26, 23);
            this.detailPic.Name = "detailPic";
            this.detailPic.Size = new System.Drawing.Size(587, 510);
            this.detailPic.TabIndex = 0;
            this.detailPic.TabStop = false;
            // 
            // SettingForm
            // 
            this.ClientSize = new System.Drawing.Size(1082, 605);
            this.Controls.Add(this.bodyTableLayout);
            this.Controls.Add(this.headPanel);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.headPanel.ResumeLayout(false);
            this.bodyTableLayout.ResumeLayout(false);
            this.btnPanel.ResumeLayout(false);
            this.setPanel.ResumeLayout(false);
            this.setPanel.PerformLayout();
            this.detailPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Button minBtn;
        private System.Windows.Forms.Button maxBtn;
        private System.Windows.Forms.Button setbtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.TableLayoutPanel bodyTableLayout;
        private System.Windows.Forms.Panel btnPanel;
        private System.Windows.Forms.Button zhanBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Panel setPanel;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button addPrint;
        private System.Windows.Forms.Button selPrintBtn;
        private System.Windows.Forms.Panel picPanel;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
        private System.Windows.Forms.TextBox countTxt;
        private System.Windows.Forms.Label countLab;
        private System.Windows.Forms.Panel detailPanel;
        private System.Windows.Forms.PictureBox detailPic;
    }
}
