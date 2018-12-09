using DrawCoreLib;

namespace PicEditNew.PicEditControl
{
    partial class UserControlPicEdit
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonLayerDown = new System.Windows.Forms.Button();
            this.buttonLayerUp = new System.Windows.Forms.Button();
            this.buttonLayerBottom = new System.Windows.Forms.Button();
            this.buttonLayerTop = new System.Windows.Forms.Button();
            this.textBoxPicWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPicHieght = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPicY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPicX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxLockRate = new System.Windows.Forms.CheckBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.listBoxImage = new PicEditNew.PicEditControl.ListBoxImage();
            this.panelTop = new System.Windows.Forms.Panel();
            this.checkBoxShowImageTip = new System.Windows.Forms.CheckBox();
            this.buttonSetProperty = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonSavePic = new System.Windows.Forms.Button();
            this.contextMenuOfPrintAreaPic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuShowInCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemShowRate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.旋转度数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSetRotationBase = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelRotationBase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDeletePic = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripPintArea = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemPintInCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMiddle = new DrawCoreLib.DoubleBufferPanel();
            this.panelEditPaper = new DrawCoreLib.DoubleBufferPanel();
            this.panelPrintArea = new DrawCoreLib.DoubleBufferPanel();
            this.panelLeft.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.contextMenuOfPrintAreaPic.SuspendLayout();
            this.contextMenuStripPintArea.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelEditPaper.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(709, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "图层操作:";
            // 
            // buttonLayerDown
            // 
            this.buttonLayerDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonLayerDown.BackColor = System.Drawing.Color.Red;
            this.buttonLayerDown.Location = new System.Drawing.Point(1019, 8);
            this.buttonLayerDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLayerDown.Name = "buttonLayerDown";
            this.buttonLayerDown.Size = new System.Drawing.Size(57, 29);
            this.buttonLayerDown.TabIndex = 12;
            this.buttonLayerDown.Text = "下移";
            this.buttonLayerDown.UseVisualStyleBackColor = false;
            this.buttonLayerDown.Click += new System.EventHandler(this.buttonLayerAdjust_Click);
            // 
            // buttonLayerUp
            // 
            this.buttonLayerUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonLayerUp.BackColor = System.Drawing.Color.Red;
            this.buttonLayerUp.Location = new System.Drawing.Point(944, 8);
            this.buttonLayerUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLayerUp.Name = "buttonLayerUp";
            this.buttonLayerUp.Size = new System.Drawing.Size(57, 29);
            this.buttonLayerUp.TabIndex = 11;
            this.buttonLayerUp.Text = "上移";
            this.buttonLayerUp.UseVisualStyleBackColor = false;
            this.buttonLayerUp.Click += new System.EventHandler(this.buttonLayerAdjust_Click);
            // 
            // buttonLayerBottom
            // 
            this.buttonLayerBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonLayerBottom.BackColor = System.Drawing.Color.Red;
            this.buttonLayerBottom.Location = new System.Drawing.Point(869, 8);
            this.buttonLayerBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLayerBottom.Name = "buttonLayerBottom";
            this.buttonLayerBottom.Size = new System.Drawing.Size(57, 29);
            this.buttonLayerBottom.TabIndex = 10;
            this.buttonLayerBottom.Text = "底层";
            this.buttonLayerBottom.UseVisualStyleBackColor = false;
            this.buttonLayerBottom.Click += new System.EventHandler(this.buttonLayerAdjust_Click);
            // 
            // buttonLayerTop
            // 
            this.buttonLayerTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonLayerTop.BackColor = System.Drawing.Color.Red;
            this.buttonLayerTop.Location = new System.Drawing.Point(795, 8);
            this.buttonLayerTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLayerTop.Name = "buttonLayerTop";
            this.buttonLayerTop.Size = new System.Drawing.Size(57, 29);
            this.buttonLayerTop.TabIndex = 9;
            this.buttonLayerTop.Text = "顶层";
            this.buttonLayerTop.UseVisualStyleBackColor = false;
            this.buttonLayerTop.Click += new System.EventHandler(this.buttonLayerAdjust_Click);
            // 
            // textBoxPicWidth
            // 
            this.textBoxPicWidth.Location = new System.Drawing.Point(392, 9);
            this.textBoxPicWidth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPicWidth.Name = "textBoxPicWidth";
            this.textBoxPicWidth.Size = new System.Drawing.Size(61, 25);
            this.textBoxPicWidth.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "宽：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPicHieght
            // 
            this.textBoxPicHieght.Location = new System.Drawing.Point(512, 9);
            this.textBoxPicHieght.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPicHieght.Name = "textBoxPicHieght";
            this.textBoxPicHieght.Size = new System.Drawing.Size(61, 25);
            this.textBoxPicHieght.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "长：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPicY
            // 
            this.textBoxPicY.Location = new System.Drawing.Point(272, 9);
            this.textBoxPicY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPicY.Name = "textBoxPicY";
            this.textBoxPicY.Size = new System.Drawing.Size(61, 25);
            this.textBoxPicY.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPicX
            // 
            this.textBoxPicX.Location = new System.Drawing.Point(165, 9);
            this.textBoxPicX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPicX.Name = "textBoxPicX";
            this.textBoxPicX.Size = new System.Drawing.Size(61, 25);
            this.textBoxPicX.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "X：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxLockRate
            // 
            this.checkBoxLockRate.AutoSize = true;
            this.checkBoxLockRate.Location = new System.Drawing.Point(25, 15);
            this.checkBoxLockRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLockRate.Name = "checkBoxLockRate";
            this.checkBoxLockRate.Size = new System.Drawing.Size(89, 19);
            this.checkBoxLockRate.TabIndex = 0;
            this.checkBoxLockRate.Text = "比例锁定";
            this.checkBoxLockRate.UseVisualStyleBackColor = true;
            this.checkBoxLockRate.CheckedChanged += new System.EventHandler(this.checkBoxLockRate_CheckedChanged);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.listBoxImage);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 49);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(281, 879);
            this.panelLeft.TabIndex = 6;
            // 
            // listBoxImage
            // 
            this.listBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxImage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxImage.FormattingEnabled = true;
            this.listBoxImage.ListBoxItemSize = 180;
            this.listBoxImage.Location = new System.Drawing.Point(0, 0);
            this.listBoxImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxImage.Name = "listBoxImage";
            this.listBoxImage.Size = new System.Drawing.Size(281, 879);
            this.listBoxImage.TabIndex = 0;
            this.listBoxImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxImage_MouseDoubleClick);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.checkBoxShowImageTip);
            this.panelTop.Controls.Add(this.buttonSetProperty);
            this.panelTop.Controls.Add(this.label5);
            this.panelTop.Controls.Add(this.buttonLayerDown);
            this.panelTop.Controls.Add(this.buttonLayerUp);
            this.panelTop.Controls.Add(this.buttonLayerBottom);
            this.panelTop.Controls.Add(this.buttonLayerTop);
            this.panelTop.Controls.Add(this.textBoxPicWidth);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.textBoxPicHieght);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.textBoxPicY);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.textBoxPicX);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.checkBoxLockRate);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1283, 49);
            this.panelTop.TabIndex = 7;
            // 
            // checkBoxShowImageTip
            // 
            this.checkBoxShowImageTip.AutoSize = true;
            this.checkBoxShowImageTip.Location = new System.Drawing.Point(1100, 11);
            this.checkBoxShowImageTip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxShowImageTip.Name = "checkBoxShowImageTip";
            this.checkBoxShowImageTip.Size = new System.Drawing.Size(119, 19);
            this.checkBoxShowImageTip.TabIndex = 15;
            this.checkBoxShowImageTip.Text = "显示图片信息";
            this.checkBoxShowImageTip.UseVisualStyleBackColor = true;
            this.checkBoxShowImageTip.CheckedChanged += new System.EventHandler(this.checkBoxShowImageTip_CheckedChanged);
            // 
            // buttonSetProperty
            // 
            this.buttonSetProperty.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSetProperty.BackColor = System.Drawing.Color.Red;
            this.buttonSetProperty.Location = new System.Drawing.Point(597, 8);
            this.buttonSetProperty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSetProperty.Name = "buttonSetProperty";
            this.buttonSetProperty.Size = new System.Drawing.Size(79, 29);
            this.buttonSetProperty.TabIndex = 14;
            this.buttonSetProperty.Text = "设置";
            this.buttonSetProperty.UseVisualStyleBackColor = false;
            this.buttonSetProperty.Click += new System.EventHandler(this.buttonSetProperty_Click);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.buttonPrint);
            this.panelRight.Controls.Add(this.buttonSavePic);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(1283, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(180, 928);
            this.panelRight.TabIndex = 8;
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.Red;
            this.buttonPrint.Location = new System.Drawing.Point(29, 135);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(127, 61);
            this.buttonPrint.TabIndex = 0;
            this.buttonPrint.Text = "打印图片";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonSavePic_Click);
            // 
            // buttonSavePic
            // 
            this.buttonSavePic.BackColor = System.Drawing.Color.Red;
            this.buttonSavePic.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSavePic.Location = new System.Drawing.Point(29, 64);
            this.buttonSavePic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSavePic.Name = "buttonSavePic";
            this.buttonSavePic.Size = new System.Drawing.Size(127, 61);
            this.buttonSavePic.TabIndex = 0;
            this.buttonSavePic.Text = "保存图片";
            this.buttonSavePic.UseVisualStyleBackColor = false;
            this.buttonSavePic.Click += new System.EventHandler(this.buttonSavePic_Click);
            // 
            // contextMenuOfPrintAreaPic
            // 
            this.contextMenuOfPrintAreaPic.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuOfPrintAreaPic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowInCenter,
            this.ToolStripMenuItemShowRate,
            this.toolStripSeparator1,
            this.旋转度数ToolStripMenuItem,
            this.ToolStripMenuItemSetRotationBase,
            this.ToolStripMenuItemDelRotationBase,
            this.toolStripSeparator2,
            this.menuDeletePic});
            this.contextMenuOfPrintAreaPic.Name = "contextMenuStrip1";
            this.contextMenuOfPrintAreaPic.Size = new System.Drawing.Size(169, 160);
            // 
            // menuShowInCenter
            // 
            this.menuShowInCenter.Name = "menuShowInCenter";
            this.menuShowInCenter.Size = new System.Drawing.Size(168, 24);
            this.menuShowInCenter.Text = "居中显示";
            this.menuShowInCenter.Click += new System.EventHandler(this.menuShowInCenter_Click);
            // 
            // ToolStripMenuItemShowRate
            // 
            this.ToolStripMenuItemShowRate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.ToolStripMenuItemShowRate.Name = "ToolStripMenuItemShowRate";
            this.ToolStripMenuItemShowRate.Size = new System.Drawing.Size(168, 24);
            this.ToolStripMenuItemShowRate.Text = "显示比例";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 26);
            this.toolStripMenuItem2.Tag = "100";
            this.toolStripMenuItem2.Text = "100%";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItemShowRate_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(124, 26);
            this.toolStripMenuItem3.Tag = "50";
            this.toolStripMenuItem3.Text = "50%";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItemShowRate_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(124, 26);
            this.toolStripMenuItem4.Tag = "30";
            this.toolStripMenuItem4.Text = "30%";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItemShowRate_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(124, 26);
            this.toolStripMenuItem5.Tag = "20";
            this.toolStripMenuItem5.Text = "20%";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItemShowRate_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(124, 26);
            this.toolStripMenuItem6.Tag = "150";
            this.toolStripMenuItem6.Text = "150%";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItemShowRate_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(124, 26);
            this.toolStripMenuItem7.Tag = "200";
            this.toolStripMenuItem7.Text = "200%";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItemShowRate_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(124, 26);
            this.toolStripMenuItem8.Tag = "300";
            this.toolStripMenuItem8.Text = "300%";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItemShowRate_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(124, 26);
            this.toolStripMenuItem9.Tag = "500";
            this.toolStripMenuItem9.Text = "500%";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItemShowRate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // 旋转度数ToolStripMenuItem
            // 
            this.旋转度数ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14,
            this.toolStripMenuItem15});
            this.旋转度数ToolStripMenuItem.Name = "旋转度数ToolStripMenuItem";
            this.旋转度数ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.旋转度数ToolStripMenuItem.Text = "旋转度数";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem10.Tag = "0";
            this.toolStripMenuItem10.Text = "0°";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItemRotationDegree_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem11.Tag = "30";
            this.toolStripMenuItem11.Text = "30°";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItemRotationDegree_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem12.Tag = "45";
            this.toolStripMenuItem12.Text = "45°";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItemRotationDegree_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem13.Tag = "90";
            this.toolStripMenuItem13.Text = "90°";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItemRotationDegree_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem14.Tag = "180";
            this.toolStripMenuItem14.Text = "180°";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItemRotationDegree_Click);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem15.Tag = "270";
            this.toolStripMenuItem15.Text = "270°";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.toolStripMenuItemRotationDegree_Click);
            // 
            // ToolStripMenuItemSetRotationBase
            // 
            this.ToolStripMenuItemSetRotationBase.Name = "ToolStripMenuItemSetRotationBase";
            this.ToolStripMenuItemSetRotationBase.Size = new System.Drawing.Size(168, 24);
            this.ToolStripMenuItemSetRotationBase.Tag = "add";
            this.ToolStripMenuItemSetRotationBase.Text = "设置旋转基点";
            this.ToolStripMenuItemSetRotationBase.Click += new System.EventHandler(this.ToolStripMenuItemSetRotationBase_Click);
            // 
            // ToolStripMenuItemDelRotationBase
            // 
            this.ToolStripMenuItemDelRotationBase.Name = "ToolStripMenuItemDelRotationBase";
            this.ToolStripMenuItemDelRotationBase.Size = new System.Drawing.Size(168, 24);
            this.ToolStripMenuItemDelRotationBase.Tag = "del";
            this.ToolStripMenuItemDelRotationBase.Text = "删除旋转基点";
            this.ToolStripMenuItemDelRotationBase.Click += new System.EventHandler(this.ToolStripMenuItemSetRotationBase_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // menuDeletePic
            // 
            this.menuDeletePic.Name = "menuDeletePic";
            this.menuDeletePic.Size = new System.Drawing.Size(168, 24);
            this.menuDeletePic.Text = "删除此图片";
            this.menuDeletePic.Click += new System.EventHandler(this.menuDeletePic_Click);
            // 
            // contextMenuStripPintArea
            // 
            this.contextMenuStripPintArea.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripPintArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemPintInCenter});
            this.contextMenuStripPintArea.Name = "contextMenuStrip1";
            this.contextMenuStripPintArea.Size = new System.Drawing.Size(139, 28);
            // 
            // ToolStripMenuItemPintInCenter
            // 
            this.ToolStripMenuItemPintInCenter.Name = "ToolStripMenuItemPintInCenter";
            this.ToolStripMenuItemPintInCenter.Size = new System.Drawing.Size(138, 24);
            this.ToolStripMenuItemPintInCenter.Text = "居中显示";
            this.ToolStripMenuItemPintInCenter.Click += new System.EventHandler(this.ToolStripMenuItemPintInCenter_Click);
            // 
            // panelMiddle
            // 
            this.panelMiddle.AutoScroll = true;
            this.panelMiddle.BackColor = System.Drawing.Color.LightGray;
            this.panelMiddle.Controls.Add(this.panelEditPaper);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(281, 49);
            this.panelMiddle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.panelMiddle.Size = new System.Drawing.Size(1002, 879);
            this.panelMiddle.TabIndex = 9;
            // 
            // panelEditPaper
            // 
            this.panelEditPaper.BackColor = System.Drawing.Color.White;
            this.panelEditPaper.Controls.Add(this.panelPrintArea);
            this.panelEditPaper.Location = new System.Drawing.Point(53, 29);
            this.panelEditPaper.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelEditPaper.Name = "panelEditPaper";
            this.panelEditPaper.Size = new System.Drawing.Size(955, 842);
            this.panelEditPaper.TabIndex = 1;
            this.panelEditPaper.Paint += new System.Windows.Forms.PaintEventHandler(this.panelEditPaper_Paint);
            this.panelEditPaper.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelEditPaper_MouseDown);
            this.panelEditPaper.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEditPaper_MouseMove);
            this.panelEditPaper.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelEditPaper_MouseUp);
            // 
            // panelPrintArea
            // 
            this.panelPrintArea.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPrintArea.Location = new System.Drawing.Point(51, 49);
            this.panelPrintArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelPrintArea.Name = "panelPrintArea";
            this.panelPrintArea.Size = new System.Drawing.Size(849, 720);
            this.panelPrintArea.TabIndex = 0;
            this.panelPrintArea.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPrintArea_Paint);
            this.panelPrintArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelPrintArea_MouseDown);
            this.panelPrintArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelPrintArea_MouseMove);
            this.panelPrintArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelPrintArea_MouseUp);
            // 
            // UserControlPicEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelRight);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserControlPicEdit";
            this.Size = new System.Drawing.Size(1463, 928);
            this.panelLeft.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.contextMenuOfPrintAreaPic.ResumeLayout(false);
            this.contextMenuStripPintArea.ResumeLayout(false);
            this.panelMiddle.ResumeLayout(false);
            this.panelEditPaper.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

       
      
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonLayerDown;
        private System.Windows.Forms.Button buttonLayerUp;
        private System.Windows.Forms.Button buttonLayerBottom;
        private System.Windows.Forms.Button buttonLayerTop;
        private System.Windows.Forms.TextBox textBoxPicWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPicHieght;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPicY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPicX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxLockRate;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelRight;
        private ListBoxImage listBoxImage;

        private DoubleBufferPanel panelMiddle;
        private DoubleBufferPanel panelEditPaper;
        private DoubleBufferPanel panelPrintArea;
        private System.Windows.Forms.Button buttonSetProperty;
        private System.Windows.Forms.ContextMenuStrip contextMenuOfPrintAreaPic;
        private System.Windows.Forms.ToolStripMenuItem menuDeletePic;
        private System.Windows.Forms.ToolStripMenuItem menuShowInCenter;
        private System.Windows.Forms.Button buttonSavePic;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShowRate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPintArea;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPintInCenter;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetRotationBase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelRotationBase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 旋转度数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.CheckBox checkBoxShowImageTip;
        private System.Windows.Forms.Button buttonPrint;
    }
}
