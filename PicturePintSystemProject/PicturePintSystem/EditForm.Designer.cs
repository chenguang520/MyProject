namespace PicturePintSystem
{
    partial class EditForm
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
            this.logPanel = new System.Windows.Forms.Panel();
            this.logPic = new System.Windows.Forms.PictureBox();
            this.showPanel = new System.Windows.Forms.Panel();
            this.showPic = new System.Windows.Forms.PictureBox();
            this.setPanel = new System.Windows.Forms.Panel();
            this.printBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.picPanel = new System.Windows.Forms.Panel();
            this.pagePanel = new System.Windows.Forms.Panel();
            this.aPanel = new System.Windows.Forms.Panel();
            this.detailPic = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel.SuspendLayout();
            this.logPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logPic)).BeginInit();
            this.showPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showPic)).BeginInit();
            this.setPanel.SuspendLayout();
            this.pagePanel.SuspendLayout();
            this.aPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailPic)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.81106F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.18894F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.tableLayoutPanel.Controls.Add(this.logPanel, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.showPanel, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.setPanel, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.picPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.pagePanel, 1, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 50);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.11111F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.88889F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1076, 638);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.logPic);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logPanel.Location = new System.Drawing.Point(871, 3);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(202, 132);
            this.logPanel.TabIndex = 0;
            // 
            // logPic
            // 
            this.logPic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logPic.Location = new System.Drawing.Point(3, 3);
            this.logPic.Name = "logPic";
            this.logPic.Size = new System.Drawing.Size(202, 100);
            this.logPic.TabIndex = 2;
            this.logPic.TabStop = false;
            // 
            // showPanel
            // 
            this.showPanel.Controls.Add(this.showPic);
            this.showPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showPanel.Location = new System.Drawing.Point(871, 141);
            this.showPanel.Name = "showPanel";
            this.showPanel.Size = new System.Drawing.Size(202, 406);
            this.showPanel.TabIndex = 1;
            // 
            // showPic
            // 
            this.showPic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showPic.Location = new System.Drawing.Point(3, 43);
            this.showPic.Name = "showPic";
            this.showPic.Size = new System.Drawing.Size(196, 265);
            this.showPic.TabIndex = 2;
            this.showPic.TabStop = false;
            // 
            // setPanel
            // 
            this.setPanel.Controls.Add(this.printBtn);
            this.setPanel.Controls.Add(this.saveBtn);
            this.setPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setPanel.Location = new System.Drawing.Point(871, 553);
            this.setPanel.Name = "setPanel";
            this.setPanel.Size = new System.Drawing.Size(202, 82);
            this.setPanel.TabIndex = 2;
            // 
            // printBtn
            // 
            this.printBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printBtn.BackColor = System.Drawing.Color.Teal;
            this.printBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printBtn.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.printBtn.ForeColor = System.Drawing.Color.White;
            this.printBtn.Location = new System.Drawing.Point(104, 15);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(95, 64);
            this.printBtn.TabIndex = 8;
            this.printBtn.Text = "打印";
            this.printBtn.UseVisualStyleBackColor = false;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.BackColor = System.Drawing.Color.Teal;
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveBtn.ForeColor = System.Drawing.Color.White;
            this.saveBtn.Location = new System.Drawing.Point(3, 15);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(95, 64);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // picPanel
            // 
            this.picPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPanel.AutoScroll = true;
            this.picPanel.Location = new System.Drawing.Point(3, 3);
            this.picPanel.Name = "picPanel";
            this.tableLayoutPanel.SetRowSpan(this.picPanel, 3);
            this.picPanel.Size = new System.Drawing.Size(192, 632);
            this.picPanel.TabIndex = 3;
            // 
            // pagePanel
            // 
            this.pagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pagePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pagePanel.Controls.Add(this.aPanel);
            this.pagePanel.Location = new System.Drawing.Point(201, 3);
            this.pagePanel.Name = "pagePanel";
            this.tableLayoutPanel.SetRowSpan(this.pagePanel, 3);
            this.pagePanel.Size = new System.Drawing.Size(664, 632);
            this.pagePanel.TabIndex = 4;
            // 
            // aPanel
            // 
            this.aPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aPanel.BackColor = System.Drawing.Color.White;
            this.aPanel.Controls.Add(this.detailPic);
            this.aPanel.Location = new System.Drawing.Point(102, 23);
            this.aPanel.Name = "aPanel";
            this.aPanel.Size = new System.Drawing.Size(464, 583);
            this.aPanel.TabIndex = 0;
            // 
            // detailPic
            // 
            this.detailPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailPic.Location = new System.Drawing.Point(4, 3);
            this.detailPic.Name = "detailPic";
            this.detailPic.Size = new System.Drawing.Size(457, 577);
            this.detailPic.TabIndex = 0;
            this.detailPic.TabStop = false;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.Controls.SetChildIndex(this.headPanel, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            this.tableLayoutPanel.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logPic)).EndInit();
            this.showPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showPic)).EndInit();
            this.setPanel.ResumeLayout(false);
            this.pagePanel.ResumeLayout(false);
            this.aPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.PictureBox logPic;
        private System.Windows.Forms.Panel showPanel;
        private System.Windows.Forms.PictureBox showPic;
        private System.Windows.Forms.Panel setPanel;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Panel picPanel;
        private System.Windows.Forms.Panel pagePanel;
        private System.Windows.Forms.Panel aPanel;
        private System.Windows.Forms.PictureBox detailPic;
    }
}
