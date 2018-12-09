namespace PicEditNew
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlPicEdit = new PicEditNew.PicEditControl.UserControlPicEdit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1520, 30);
            this.panel1.TabIndex = 0;
            // 
            // userControlPicEdit
            // 
            this.userControlPicEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlPicEdit.ImageSavePath = null;
            this.userControlPicEdit.Location = new System.Drawing.Point(0, 30);
            this.userControlPicEdit.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.userControlPicEdit.Name = "userControlPicEdit";
            this.userControlPicEdit.Size = new System.Drawing.Size(1520, 906);
            this.userControlPicEdit.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 936);
            this.Controls.Add(this.userControlPicEdit);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "图片编辑打印系统-云飞网络科技工作室";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private PicEditControl.UserControlPicEdit userControlPicEdit;
    }
}

