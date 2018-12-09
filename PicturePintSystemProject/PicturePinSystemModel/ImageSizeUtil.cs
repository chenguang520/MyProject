using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturePinSystemModel
{   
    /// <summary>
    /// 图片尺寸转换
    /// </summary>
    public  class ImageSizeUtil
    {  
        /// <summary>
        ///纸张大小映射  单位cm
        /// </summary>
        public static Dictionary<string, string> PaperSizeMapping;
        static ImageSizeUtil()
        {
            PaperSizeMapping = new Dictionary<string, string>
            {
                {"A0","84.1,118.9"},
                {"A1","59.4,84.1"},
                {"A2","42.0,59.4"},
                {"A3","29.7,42.0"},
                {"A4","21.0,29.0"},
                {"A5","14.8,21.0"},
                {"A6","10.5,14.8"},
                {"A7","7.4,10.5"},
                {"A8","5.2,7.4"}
            };
        }
        /// <summary>
        /// 根据A3名称,转换为
        /// (长*宽 cm)  10,5
        /// </summary>
        public static string ConverntPaperSize(string paperSize)
        {
            var size ="29.7,21.0";
            if (!string.IsNullOrEmpty(paperSize))
            {
                var key = paperSize;
                if (PaperSizeMapping.ContainsKey(key))
                {
                    var mapping = PaperSizeMapping[key];
                    var setts = mapping.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (setts != null&&setts.Length>=2)
                    {
                        size = $"{setts[0]},{setts[1]}";
                    }
                }
            }
            return size;
        }
        /// <summary>
        /// 将实际尺寸转换成名称
        /// </summary>
        /// <param name="size">A3,A4</param>
        /// <returns></returns>
        public static string ConverntPaperSizeName(string size) {
            var name = "A4";
            if (!string.IsNullOrEmpty(size))
            {
              var key=PaperSizeMapping.FirstOrDefault(x => x.Value.Contains(size));
                if (!string.IsNullOrEmpty(key.Key))
                {
                    name = key.Key;
                }  
            }
            return name;
        }
    }
    public class SizeParam {
        /// <summary>
        /// DPI  72像素/英寸,
        /// </summary>
        private const int DPI = 72;
        public SizeParam(string size)
        {
            if (!string.IsNullOrEmpty(size))
            {
               var sizes=size.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries);
               if (sizes!=null&&sizes.Length>=2)
                {  
                    //每立方米涵盖的像素
                    var dpiCm = 72 / 2.54;
                    var width =double.Parse(sizes[0]);
                    var height =double.Parse(sizes[1]);
                    this.Width =Convert.ToInt32(width*dpiCm);
                    this.Height =Convert.ToInt32(height*dpiCm);
                }
            }
        }
        /// <summary>
        /// 像素宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 像素高度
        /// </summary>
        public int Height { get; set; }
    }
}
