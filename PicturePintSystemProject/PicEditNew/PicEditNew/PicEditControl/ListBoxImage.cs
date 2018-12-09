using DrawCoreLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicEditNew.PicEditControl
{
    class ListBoxImage : ListBox
    {
        //item大小
        public int ListBoxItemSize { get; set; } = 180;

        private const int distanceBetweenImages = 7;
        public ListBoxImage()
        {
            // SetStyle(ControlStyles.UserPaint, true);
            // SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
                                                        // InitializeComponent();
            this.DrawMode = DrawMode.OwnerDrawVariable;
        }

        public void ClearItems()
        {
            Items.Clear();
        }

        public void AddImage(ImageProperty image)
        {
            Items.Add(image);
            Invalidate();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.DrawBackground();
            if (e.Index < 0 || e.Index >= Items.Count)
            {
                return;
            }
            Brush brush = new SolidBrush(Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247))))));

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.DrawFocusRectangle();
                e.Graphics.FillRectangle(brush, e.Bounds);
                e.Graphics.DrawRectangle(new Pen(Color.Black), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))))), e.Bounds);
            }
            Graphics g = e.Graphics;
            Matrix oldTransform = g.Transform;
            Matrix newTransform = (Matrix)oldTransform.Clone();
            newTransform.Translate(e.Bounds.X, e.Bounds.Y);
            g.Transform = newTransform;
            ImageProperty item = (ImageProperty)Items[e.Index];
            if (item.EditImage != null)
            {
                if (item.EditImage.Width <= ListBoxItemSize
                    && item.EditImage.Height <= ListBoxItemSize)
                {
                    g.DrawImage(item.EditImage, new Rectangle(distanceBetweenImages, distanceBetweenImages,
                        item.EditImage.Width, item.EditImage.Height));
                }
                else
                {
                    double scale = (double)ListBoxItemSize / Math.Max(item.EditImage.Width, item.EditImage.Height);
                    g.DrawImage(item.EditImage, new Rectangle(distanceBetweenImages, distanceBetweenImages,
                        (int)(item.EditImage.Width * scale), (int)(item.EditImage.Height * scale)));
                }
            }
            g.Transform = oldTransform;
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
            e.ItemHeight = 2 * distanceBetweenImages + ListBoxItemSize;
        }
    }
}
