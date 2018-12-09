namespace PicturePintSystem
{
    partial class EditForm1
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
            this.Container = new System.Windows.Forms.SplitContainer();
            this.itemContainer = new System.Windows.Forms.SplitContainer();
            this.picPanel = new System.Windows.Forms.Panel();
            this.logPic = new System.Windows.Forms.PictureBox();
            this.showPic = new System.Windows.Forms.PictureBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.pagePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Container)).BeginInit();
            this.Container.Panel1.SuspendLayout();
            this.Container.Panel2.SuspendLayout();
            this.Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemContainer)).BeginInit();
            this.itemContainer.Panel1.SuspendLayout();
            this.itemContainer.Panel2.SuspendLayout();
            this.itemContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPic)).BeginInit();
            this.bodyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Container
            // 
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.Location = new System.Drawing.Point(0, 0);
            this.Container.Name = "Container";
            // 
            // Container.Panel1
            // 
            this.Container.Panel1.Controls.Add(this.picPanel);
            // 
            // Container.Panel2
            // 
            this.Container.Panel2.Controls.Add(this.itemContainer);
            this.Container.Size = new System.Drawing.Size(1082, 605);
            this.Container.SplitterDistance = 210;
            this.Container.TabIndex = 0;
            // 
            // itemContainer
            // 
            this.itemContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemContainer.Location = new System.Drawing.Point(0, 0);
            this.itemContainer.Name = "itemContainer";
            // 
            // itemContainer.Panel1
            // 
            this.itemContainer.Panel1.Controls.Add(this.bodyPanel);
            // 
            // itemContainer.Panel2
            // 
            this.itemContainer.Panel2.Controls.Add(this.printBtn);
            this.itemContainer.Panel2.Controls.Add(this.saveBtn);
            this.itemContainer.Panel2.Controls.Add(this.showPic);
            this.itemContainer.Panel2.Controls.Add(this.logPic);
            this.itemContainer.Size = new System.Drawing.Size(868, 605);
            this.itemContainer.SplitterDistance = 607;
            this.itemContainer.TabIndex = 0;
            // 
            // picPanel
            // 
            this.picPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPanel.Location = new System.Drawing.Point(0, 0);
            this.picPanel.Name = "picPanel";
            this.picPanel.Size = new System.Drawing.Size(210, 605);
            this.picPanel.TabIndex = 0;
            // 
            // logPic
            // 
            this.logPic.Location = new System.Drawing.Point(34, 22);
            this.logPic.Name = "logPic";
            this.logPic.Size = new System.Drawing.Size(196, 100);
            this.logPic.TabIndex = 0;
            this.logPic.TabStop = false;
            // 
            // showPic
            // 
            this.showPic.Location = new System.Drawing.Point(34, 190);
            this.showPic.Name = "showPic";
            this.showPic.Size = new System.Drawing.Size(196, 265);
            this.showPic.TabIndex = 1;
            this.showPic.TabStop = false;
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.Teal;
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveBtn.ForeColor = System.Drawing.Color.White;
            this.saveBtn.Location = new System.Drawing.Point(34, 516);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(95, 64);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.BackColor = System.Drawing.Color.Teal;
            this.printBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printBtn.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.printBtn.ForeColor = System.Drawing.Color.White;
            this.printBtn.Location = new System.Drawing.Point(135, 516);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(95, 64);
            this.printBtn.TabIndex = 7;
            this.printBtn.Text = "打印";
            this.printBtn.UseVisualStyleBackColor = false;
            // 
            // bodyPanel
            // 
            this.bodyPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bodyPanel.Controls.Add(this.pagePanel);
            this.bodyPanel.Location = new System.Drawing.Point(18, 22);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(570, 558);
            this.bodyPanel.TabIndex = 1;
            // 
            // pagePanel
            // 
            this.pagePanel.BackColor = System.Drawing.Color.White;
            this.pagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pagePanel.Location = new System.Drawing.Point(64, 33);
            this.pagePanel.Name = "pagePanel";
            this.pagePanel.Size = new System.Drawing.Size(462, 483);
            this.pagePanel.TabIndex = 0;
            // 
            // EditForm
            // 
            this.ClientSize = new System.Drawing.Size(1082, 605);
            this.Controls.Add(this.Container);
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑图片";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.Container.Panel1.ResumeLayout(false);
            this.Container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Container)).EndInit();
            this.Container.ResumeLayout(false);
            this.itemContainer.Panel1.ResumeLayout(false);
            this.itemContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemContainer)).EndInit();
            this.itemContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPic)).EndInit();
            this.bodyPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Container;
        private System.Windows.Forms.SplitContainer itemContainer;
        private System.Windows.Forms.Panel picPanel;
        private System.Windows.Forms.PictureBox logPic;
        private System.Windows.Forms.PictureBox showPic;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.Panel pagePanel;
    }
}
