using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using PicturePinSystemModel;
using PicturePintSystem.Controllers;

namespace PicturePintSystem.Comm
{
    /// <summary>
    /// 配置文件类
    /// </summary>
    public class ConfigUtil
    {  
        /// <summary>
        /// 默认配置
        /// </summary>
        public static Dictionary<string, string> ConfigData { get; set; }
        /// <summary>
        /// 自定义配置
        /// </summary>
        public static Dictionary<string, string> ConfigDataSet { get; set; }
        /// <summary>
        /// Form内容配置
        /// </summary>
        public static FormConfigModel FormConfig { get; set;}   
    
        /// <summary>
        /// 加载配置文件(默认)
        /// </summary>
        public static void LoadConfigData(){
            string path = Application.StartupPath+ "/Config/ConfigData.json";
            using (System.IO.StreamReader sr = new System.IO.StreamReader(path,Encoding.UTF8))
            {
                var templete = sr.ReadToEnd();
                ConfigData=JsonConvert.DeserializeObject<Dictionary<string, string>>(templete);
            }
        }
        /// <summary>
        /// 加载配置文件(自定义)
        /// </summary>
        public static void LoadConfigDataSet()
        {
            string path = Application.StartupPath + "/Config/ConfigDataSet.json";
            using (System.IO.StreamReader sr = new System.IO.StreamReader(path,Encoding.UTF8))
            {
                var templete = sr.ReadToEnd();
                ConfigDataSet = JsonConvert.DeserializeObject<Dictionary<string, string>>(templete);
            }
        }
        /// <summary>
        /// 加载FormConfig配置文件
        /// </summary>
        public static void LoadFormConfig()
        {
            string path = Application.StartupPath + "/Config/FormConfig.json";
            using (System.IO.StreamReader sr = new System.IO.StreamReader(path, Encoding.UTF8))
            {
                var templete = sr.ReadToEnd();
                FormConfig = JsonConvert.DeserializeObject<FormConfigModel>(templete);
            }
        }

    }
    /// <summary>
    /// 窗体配置
    /// </summary>
    public class FormConfigUtil
    {  
        /// <summary>
        /// MainForm 窗体图片列表最大数量
        /// </summary>
        public static  int? MainPicListCount;
        /// <summary>
        /// 编辑图片窗体最大数量
        /// </summary>
        public static  int? EditPicListCount;
        /// <summary>
        /// 打印图片窗体最大数量
        /// </summary>
        public static  int? PrintPicListCount;
        /// <summary>
        /// 二维码链接地址
        /// </summary>
        public static  string ImageCodeKey;
        /// <summary>
        /// 端口
        /// </summary>
        public static  string Host;

        /// <summary>
        /// Wifi上传图片保存路径
        /// </summary>
        public static  string WifiPath;
        /// <summary>
        /// 图片本地存储地址
        /// </summary>
        public static  string LocationPath;
        /// <summary>
        /// Log路径
        /// </summary>
        public static  string LogPath;
        /// <summary>
        /// Ip路径
        /// </summary>
        public static  string IpPath;
        /// <summary>
        /// 打印份数
        /// </summary>
        public static  int? PrintCount;
        /// <summary>
        /// 图片位置
        /// </summary>
        public static  string ImgLocation;
        /// <summary>
        /// 页面大小
        /// </summary>
        public static string PageSize;
        /// <summary>
        /// 横向纵向
        /// </summary>
        public static bool Landscape;
        /// <summary>
        /// 页面距 左
        /// </summary>
        public static int MarginLeft;
        /// <summary>
        /// 页面距 右
        /// </summary>
        public static int MarginRight;
        /// <summary>
        /// 页面 上
        /// </summary>
        public static int MarginTop;
        /// <summary>
        /// 页面 下
        /// </summary>
        public static int MarginBottom;
        /// <summary>
        /// 打印机名称
        /// </summary>
        public static string PrintName;

        static FormConfigUtil()
        {
            RefConfigData();
        }
        public static void RefConfigData()
        {
            if (ConfigUtil.ConfigData != null)
            {
                var type = "";
                MainPicListCount = Convert.ToInt16(GetConfig("mainFormPicListCount", out type));
                EditPicListCount = Convert.ToInt16(GetConfig("editPicListCount", out type));
                PrintPicListCount = Convert.ToInt16(GetConfig("printPicListCount", out type));
                ImageCodeKey = GetConfig("imageCodeKey", out type);
                Host = GetConfig("host", out type);

                WifiPath = GetConfig("wifiPath", out type);
                if (type == "default")
                {
                    WifiPath = string.Format(WifiPath, Application.StartupPath);
                }
                LocationPath = GetConfig("locationPath", out type);
                if (type == "default")
                {
                    LocationPath = string.Format(LocationPath, Application.StartupPath);
                }
                LogPath = GetConfig("logPath", out type);
                if (type == "default")
                {
                    LogPath = string.Format(LogPath, Application.StartupPath);
                }
                IpPath = GetConfig("ipPath", out type);
                if (type == "default")
                {
                    IpPath = string.Format(IpPath, Controlles.GetIP());
                }
                PrintCount = int.Parse(GetConfig("printCount", out type));
                ImgLocation = GetConfig("imgLocation", out type);
                if (type == "default")
                {
                    ImgLocation = string.Format(ImgLocation, Application.StartupPath);
                }
                PageSize = GetConfig("pageSize", out type);
                Landscape =bool.Parse(GetConfig("landscape",out type));
                MarginLeft = int.Parse(GetConfig("marginLeft",out type));
                MarginRight = int.Parse(GetConfig("marginRight",out type));
                MarginTop = int.Parse(GetConfig("marginTop",out type));
                MarginBottom = int.Parse(GetConfig("marginBottom", out type));
                PrintName = GetConfig("printName", out type);
               
            }
        }
        private static string GetConfig(string key,out string type)
        {
            var defaultConfig = ConfigUtil.ConfigData;
            var config = ConfigUtil.ConfigDataSet;
            var value = "";
            type = "";
            if (config != null && config.ContainsKey(key) && !string.IsNullOrEmpty(config[key]))
            {  
                value = config[key];
                type = "set";
            }
            else if(defaultConfig!=null&&defaultConfig.ContainsKey(key)&& !string.IsNullOrEmpty(defaultConfig[key]))
            {
                value = defaultConfig[key];
                type = "default";
            }
            return value;
        }
       
        /// <summary>
        /// 设置配置
        /// </summary>
        public static void SetConfig(Dictionary<string,string> dic)
        {
            if (ConfigUtil.ConfigDataSet!=null)
            {
                foreach (var item in dic)
                {
                    ConfigUtil.ConfigDataSet[item.Key] = item.Value;
                }
                var text = JsonConvert.SerializeObject(ConfigUtil.ConfigDataSet);
                string path = Application.StartupPath + "/Config/ConfigDataSet.json";
                WriteJson(path,text);
                RefConfigData();
            }
        }
        public static void WriteJson(string path, string text)
        {
            FileStream fs = new FileStream(path, FileMode.Create);//每次覆盖
            StreamWriter write = new StreamWriter(fs, Encoding.Default);
            write.WriteLine(text);
            write.Close();
            fs.Close();
        }

        /// <summary>
        /// 根据字符串获取PaperSize
        /// </summary>
        public static PaperSize GetPaperSize(PrintDocument printDocument, string paperSize)
        {
            var pageSizeEnum = new PaperSize("A3", 297, 420);
            foreach (System.Drawing.Printing.PaperSize pSize in printDocument.PrinterSettings.PaperSizes)
            {
                if (pSize.Kind.ToString() == paperSize)
                {
                    pageSizeEnum = pSize;
                    break;
                }
            }
            return pageSizeEnum;
        }
    }
}
