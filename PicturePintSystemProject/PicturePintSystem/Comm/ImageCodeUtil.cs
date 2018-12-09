using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorks.QRCode.Codec;

namespace PicturePintSystem.Comm
{  
    /// <summary>
    /// 二维码帮助类
    /// </summary>
    public static class ImageCodeUtil
    {  
        /// <summary>
        ///生产二维码
        /// </summary>
        public static Image CreateImageCode(string Content, int Size)
        {
            ThoughtWorks.QRCode.Codec.QRCodeEncoder encoder = new QRCodeEncoder();
            encoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;//编码方式(注意：BYTE能支持中文，ALPHA_NUMERIC扫描出来的都是数字)
            encoder.QRCodeScale =Size;//大小(值越大生成的二维码图片像素越高)
            encoder.QRCodeVersion = 0;//版本(注意：设置为0主要是防止编码的字符串太长时发生错误)
            encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;//错误效验、错误更正(有4个等级)
            String qrdata =Content;
            System.Drawing.Bitmap bp = encoder.Encode(qrdata.ToString(), Encoding.GetEncoding("GB2312"));
            return bp;
        }
    }
    /// <summary>
    /// 图片片帮助类
    /// </summary>
    public class ImageUtil
    {   
        /// <summary>
        /// 获取缩略图
        /// </summary>
        public static Image CreateThumbnailImage(Image img, int width, int height)
        {
            Func<bool> methood =()=> {
                return true;
            };
            Image thumbnailImage = img.GetThumbnailImage(width, height, new Image.GetThumbnailImageAbort(methood), IntPtr.Zero);
            return thumbnailImage;
        }
    }
  
}
