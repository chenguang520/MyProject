namespace PicturePintSystem
{
    partial class PrintForm
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.picPanel = new System.Windows.Forms.Panel();
            this.logPanel = new System.Windows.Forms.Panel();
            this.logPic = new System.Windows.Forms.PictureBox();
            this.selectPanel = new System.Windows.Forms.Panel();
            this.countTxt = new System.Windows.Forms.TextBox();
            this.countLabel = new System.Windows.Forms.Label();
            this.removeBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.selPrintBtn = new System.Windows.Forms.Button();
            this.setPanel = new System.Windows.Forms.Panel();
            this.zhanBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.detailPanel = new System.Windows.Forms.Panel();
            this.detailPic = new System.Windows.Forms.PictureBox();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.tableLayoutPanel.SuspendLayout();
            this.logPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logPic)).BeginInit();
            this.selectPanel.SuspendLayout();
            this.setPanel.SuspendLayout();
            this.detailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailPic)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.58883F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.41117F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 287F));
            this.tableLayoutPanel.Controls.Add(this.picPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.logPanel, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.selectPanel, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.setPanel, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.detailPanel, 1, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 50);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.16851F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.83148F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1076, 638);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // picPanel
            // 
            this.picPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPanel.AutoScroll = true;
            this.picPanel.Location = new System.Drawing.Point(3, 3);
            this.picPanel.Name = "picPanel";
            this.tableLayoutPanel.SetRowSpan(this.picPanel, 3);
            this.picPanel.Size = new System.Drawing.Size(172, 632);
            this.picPanel.TabIndex = 0;
            // 
            // logPanel
            // 
            this.logPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logPanel.Controls.Add(this.logPic);
            this.logPanel.Location = new System.Drawing.Point(791, 3);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(282, 114);
            this.logPanel.TabIndex = 1;
            // 
            // logPic
            // 
            this.logPic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logPic.Location = new System.Drawing.Point(3, 3);
            this.logPic.Name = "logPic";
            this.logPic.Size = new System.Drawing.Size(276, 100);
            this.logPic.TabIndex = 3;
            this.logPic.TabStop = false;
            // 
            // selectPanel
            // 
            this.selectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectPanel.Controls.Add(this.countTxt);
            this.selectPanel.Controls.Add(this.countLabel);
            this.selectPanel.Controls.Add(this.removeBtn);
            this.selectPanel.Controls.Add(this.cancelBtn);
            this.selectPanel.Controls.Add(this.nextBtn);
            this.selectPanel.Controls.Add(this.prevBtn);
            this.selectPanel.Controls.Add(this.addBtn);
            this.selectPanel.Controls.Add(this.selPrintBtn);
            this.selectPanel.Location = new System.Drawing.Point(794, 123);
            this.selectPanel.Name = "selectPanel";
            this.selectPanel.Size = new System.Drawing.Size(279, 371);
            this.selectPanel.TabIndex = 2;
            // 
            // countTxt
            // 
            this.countTxt.Location = new System.Drawing.Point(96, 264);
            this.countTxt.Name = "countTxt";
            this.countTxt.Size = new System.Drawing.Size(169, 25);
            this.countTxt.TabIndex = 7;
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.countLabel.Location = new System.Drawing.Point(3, 267);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(71, 15);
            this.countLabel.TabIndex = 6;
            this.countLabel.Text = "打印份数";
            // 
            // removeBtn
            // 
            this.removeBtn.BackColor = System.Drawing.Color.Red;
            this.removeBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.removeBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeBtn.Location = new System.Drawing.Point(138, 180);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(138, 53);
            this.removeBtn.TabIndex = 5;
            this.removeBtn.Text = "移除";
            this.removeBtn.UseVisualStyleBackColor = false;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Red;
            this.cancelBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelBtn.Location = new System.Drawing.Point(3, 180);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(129, 53);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.Red;
            this.nextBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nextBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nextBtn.Location = new System.Drawing.Point(138, 121);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(138, 53);
            this.nextBtn.TabIndex = 3;
            this.nextBtn.Text = "队列后移";
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // prevBtn
            // 
            this.prevBtn.BackColor = System.Drawing.Color.Red;
            this.prevBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.prevBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.prevBtn.Location = new System.Drawing.Point(3, 121);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(129, 53);
            this.prevBtn.TabIndex = 2;
            this.prevBtn.Text = "队列前移";
            this.prevBtn.UseVisualStyleBackColor = false;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.Red;
            this.addBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addBtn.Location = new System.Drawing.Point(3, 62);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(273, 53);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "加入打印列";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // selPrintBtn
            // 
            this.selPrintBtn.BackColor = System.Drawing.Color.Red;
            this.selPrintBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selPrintBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.selPrintBtn.Location = new System.Drawing.Point(3, 3);
            this.selPrintBtn.Name = "selPrintBtn";
            this.selPrintBtn.Size = new System.Drawing.Size(273, 53);
            this.selPrintBtn.TabIndex = 0;
            this.selPrintBtn.Text = "选择打印机";
            this.selPrintBtn.UseVisualStyleBackColor = false;
            this.selPrintBtn.Click += new System.EventHandler(this.selPrintBtn_Click);
            // 
            // setPanel
            // 
            this.setPanel.Controls.Add(this.zhanBtn);
            this.setPanel.Controls.Add(this.saveBtn);
            this.setPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setPanel.Location = new System.Drawing.Point(791, 500);
            this.setPanel.Name = "setPanel";
            this.setPanel.Size = new System.Drawing.Size(282, 135);
            this.setPanel.TabIndex = 3;
            // 
            // zhanBtn
            // 
            this.zhanBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zhanBtn.BackColor = System.Drawing.Color.Red;
            this.zhanBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zhanBtn.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zhanBtn.ForeColor = System.Drawing.Color.Black;
            this.zhanBtn.Location = new System.Drawing.Point(150, 3);
            this.zhanBtn.Name = "zhanBtn";
            this.zhanBtn.Size = new System.Drawing.Size(100, 100);
            this.zhanBtn.TabIndex = 9;
            this.zhanBtn.Text = "暂停";
            this.zhanBtn.UseVisualStyleBackColor = false;
            this.zhanBtn.Click += new System.EventHandler(this.zhanBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.BackColor = System.Drawing.Color.Red;
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveBtn.ForeColor = System.Drawing.Color.Black;
            this.saveBtn.Location = new System.Drawing.Point(35, 3);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(100, 100);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "开始";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // detailPanel
            // 
            this.detailPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.detailPanel.Controls.Add(this.detailPic);
            this.detailPanel.Location = new System.Drawing.Point(181, 3);
            this.detailPanel.Name = "detailPanel";
            this.tableLayoutPanel.SetRowSpan(this.detailPanel, 3);
            this.detailPanel.Size = new System.Drawing.Size(604, 632);
            this.detailPanel.TabIndex = 4;
            // 
            // detailPic
            // 
            this.detailPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailPic.Location = new System.Drawing.Point(14, 55);
            this.detailPic.Name = "detailPic";
            this.detailPic.Size = new System.Drawing.Size(494, 494);
            this.detailPic.TabIndex = 0;
            this.detailPic.TabStop = false;
            // 
            // printDocument
            // 
            this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
            this.printDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_EndPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "PrintForm";
            this.Text = "图片编辑打印系统-云飞网络科技工作室";
            this.Load += new System.EventHandler(this.PrintForm_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            this.tableLayoutPanel.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logPic)).EndInit();
            this.selectPanel.ResumeLayout(false);
            this.selectPanel.PerformLayout();
            this.setPanel.ResumeLayout(false);
            this.detailPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel picPanel;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.PictureBox logPic;
        private System.Windows.Forms.Panel selectPanel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button selPrintBtn;
        private System.Windows.Forms.TextBox countTxt;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Panel setPanel;
        private System.Windows.Forms.Button zhanBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Panel detailPanel;
        private System.Windows.Forms.PictureBox detailPic;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}
