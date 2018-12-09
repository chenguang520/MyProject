namespace PicturePintSystem
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.detailPanel = new System.Windows.Forms.Panel();
            this.detailPic = new System.Windows.Forms.PictureBox();
            this.logPanel = new System.Windows.Forms.Panel();
            this.logPic = new System.Windows.Forms.PictureBox();
            this.imageCodePanel = new System.Windows.Forms.Panel();
            this.createBtn = new System.Windows.Forms.Button();
            this.ipTxt = new System.Windows.Forms.TextBox();
            this.tipLab = new System.Windows.Forms.Label();
            this.ImageCodeBox = new System.Windows.Forms.PictureBox();
            this.printPanel = new System.Windows.Forms.Panel();
            this.printBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.picPanel = new System.Windows.Forms.Panel();
            this.picMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPanel = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel.SuspendLayout();
            this.detailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailPic)).BeginInit();
            this.logPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logPic)).BeginInit();
            this.imageCodePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCodeBox)).BeginInit();
            this.printPanel.SuspendLayout();
            this.picMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.11494F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.88506F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 263F));
            this.tableLayoutPanel.Controls.Add(this.detailPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.logPanel, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.imageCodePanel, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.printPanel, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.picPanel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.btnPanel, 1, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(21, 30);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.14286F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.85714F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1047, 638);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // detailPanel
            // 
            this.detailPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.detailPanel.Controls.Add(this.detailPic);
            this.detailPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailPanel.Location = new System.Drawing.Point(3, 3);
            this.detailPanel.Name = "detailPanel";
            this.tableLayoutPanel.SetRowSpan(this.detailPanel, 2);
            this.detailPanel.Size = new System.Drawing.Size(543, 446);
            this.detailPanel.TabIndex = 5;
            // 
            // detailPic
            // 
            this.detailPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.detailPic.Location = new System.Drawing.Point(66, 13);
            this.detailPic.Name = "detailPic";
            this.detailPic.Size = new System.Drawing.Size(420, 420);
            this.detailPic.TabIndex = 1;
            this.detailPic.TabStop = false;
            this.detailPic.Click += new System.EventHandler(this.detailPic_Click);
            // 
            // logPanel
            // 
            this.logPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logPanel.BackColor = System.Drawing.Color.Transparent;
            this.logPanel.Controls.Add(this.logPic);
            this.logPanel.Location = new System.Drawing.Point(786, 3);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(258, 106);
            this.logPanel.TabIndex = 0;
            // 
            // logPic
            // 
            this.logPic.Location = new System.Drawing.Point(35, 3);
            this.logPic.Name = "logPic";
            this.logPic.Size = new System.Drawing.Size(189, 100);
            this.logPic.TabIndex = 1;
            this.logPic.TabStop = false;
            // 
            // imageCodePanel
            // 
            this.imageCodePanel.Controls.Add(this.createBtn);
            this.imageCodePanel.Controls.Add(this.ipTxt);
            this.imageCodePanel.Controls.Add(this.tipLab);
            this.imageCodePanel.Controls.Add(this.ImageCodeBox);
            this.imageCodePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageCodePanel.Location = new System.Drawing.Point(786, 125);
            this.imageCodePanel.Name = "imageCodePanel";
            this.imageCodePanel.Size = new System.Drawing.Size(258, 324);
            this.imageCodePanel.TabIndex = 1;
            // 
            // createBtn
            // 
            this.createBtn.BackColor = System.Drawing.Color.Red;
            this.createBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.createBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.createBtn.Location = new System.Drawing.Point(35, 276);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(189, 32);
            this.createBtn.TabIndex = 6;
            this.createBtn.Text = "更新IP";
            this.createBtn.UseVisualStyleBackColor = false;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // ipTxt
            // 
            this.ipTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipTxt.Location = new System.Drawing.Point(35, 245);
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.Size = new System.Drawing.Size(189, 25);
            this.ipTxt.TabIndex = 4;
            // 
            // tipLab
            // 
            this.tipLab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tipLab.AutoSize = true;
            this.tipLab.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tipLab.Location = new System.Drawing.Point(32, 212);
            this.tipLab.Name = "tipLab";
            this.tipLab.Size = new System.Drawing.Size(98, 15);
            this.tipLab.TabIndex = 3;
            this.tipLab.Text = "手动设置IP:";
            // 
            // ImageCodeBox
            // 
            this.ImageCodeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageCodeBox.Location = new System.Drawing.Point(35, 3);
            this.ImageCodeBox.Name = "ImageCodeBox";
            this.ImageCodeBox.Size = new System.Drawing.Size(189, 189);
            this.ImageCodeBox.TabIndex = 2;
            this.ImageCodeBox.TabStop = false;
            // 
            // printPanel
            // 
            this.printPanel.Controls.Add(this.printBtn);
            this.printPanel.Controls.Add(this.editBtn);
            this.printPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printPanel.Location = new System.Drawing.Point(786, 455);
            this.printPanel.Name = "printPanel";
            this.printPanel.Size = new System.Drawing.Size(258, 180);
            this.printPanel.TabIndex = 2;
            // 
            // printBtn
            // 
            this.printBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printBtn.BackColor = System.Drawing.Color.Red;
            this.printBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printBtn.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.printBtn.ForeColor = System.Drawing.Color.Black;
            this.printBtn.Location = new System.Drawing.Point(136, 40);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(107, 100);
            this.printBtn.TabIndex = 7;
            this.printBtn.Text = "打印";
            this.printBtn.UseVisualStyleBackColor = false;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editBtn.BackColor = System.Drawing.Color.Red;
            this.editBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editBtn.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editBtn.ForeColor = System.Drawing.Color.Black;
            this.editBtn.Location = new System.Drawing.Point(15, 40);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(100, 100);
            this.editBtn.TabIndex = 6;
            this.editBtn.Text = "编辑";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // picPanel
            // 
            this.picPanel.AutoScroll = true;
            this.tableLayoutPanel.SetColumnSpan(this.picPanel, 2);
            this.picPanel.ContextMenuStrip = this.picMenu;
            this.picPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPanel.Location = new System.Drawing.Point(3, 455);
            this.picPanel.Name = "picPanel";
            this.picPanel.Size = new System.Drawing.Size(777, 180);
            this.picPanel.TabIndex = 3;
            // 
            // picMenu
            // 
            this.picMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.picMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.删除ToolStripMenuItem1});
            this.picMenu.Name = "picMenu";
            this.picMenu.Size = new System.Drawing.Size(109, 52);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.删除ToolStripMenuItem.Text = "操作";
            // 
            // 删除ToolStripMenuItem1
            // 
            this.删除ToolStripMenuItem1.Name = "删除ToolStripMenuItem1";
            this.删除ToolStripMenuItem1.Size = new System.Drawing.Size(108, 24);
            this.删除ToolStripMenuItem1.Text = "删除";
            this.删除ToolStripMenuItem1.Click += new System.EventHandler(this.删除ToolStripMenuItem1_Click);
            // 
            // btnPanel
            // 
            this.btnPanel.AutoScroll = true;
            this.btnPanel.BackColor = System.Drawing.Color.Transparent;
            this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPanel.Location = new System.Drawing.Point(552, 3);
            this.btnPanel.Name = "btnPanel";
            this.tableLayoutPanel.SetRowSpan(this.btnPanel, 2);
            this.btnPanel.Size = new System.Drawing.Size(228, 446);
            this.btnPanel.TabIndex = 6;
            // 
            // openFileDialog
            // 
            this.openFileDialog.InitialDirectory = "c:\\\\";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "MainForm";
            this.Text = "图片编辑打印系统-云飞网络科技工作室";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            this.tableLayoutPanel.ResumeLayout(false);
            this.detailPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailPic)).EndInit();
            this.logPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logPic)).EndInit();
            this.imageCodePanel.ResumeLayout(false);
            this.imageCodePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCodeBox)).EndInit();
            this.printPanel.ResumeLayout(false);
            this.picMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.PictureBox logPic;
        private System.Windows.Forms.Panel imageCodePanel;
        public System.Windows.Forms.PictureBox ImageCodeBox;
        private System.Windows.Forms.Label tipLab;
        private System.Windows.Forms.TextBox ipTxt;
        private System.Windows.Forms.Panel printPanel;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Panel picPanel;
        private System.Windows.Forms.Panel detailPanel;
        private System.Windows.Forms.PictureBox detailPic;
        private System.Windows.Forms.Panel btnPanel;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.ContextMenuStrip picMenu;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
