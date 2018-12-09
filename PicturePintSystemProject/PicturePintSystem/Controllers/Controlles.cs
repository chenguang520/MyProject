using Newtonsoft.Json;
using PicturePintSystem.Comm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePintSystem.Controllers
{
    /// <summary>
    /// 支持Http请求的控制器类
    /// </summary>
    public class Controlles
    {   
        private static readonly object padlock = new object();
        private static Controlles controlles;
        /// <summary>
        /// 获取单例
        /// </summary>
        public static Controlles GetControlles(MainForm form=null)
        {
            lock(padlock)
                {
                if (controlles == null)
                {
                    var host = FormConfigUtil.IpPath;
                    var port = FormConfigUtil.Host;
                    var imagePath = "/UpLoadFile";
                    controlles = new Controlles(host, port, null, imagePath, form);
                }
            }
            return controlles;
        }

        /// <summary>
        /// Ip地址
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public string port { get; set; }
        /// <summary>
        /// 默认当前路径下
        /// </summary>
        private string _webHomeDir = Application.StartupPath;
        /// <summary>
        /// Http服务处理类
        /// </summary>
        private HttpListener listener;
        private Thread listenThread;
        private string directorySeparatorChar = Path.DirectorySeparatorChar.ToString();
        public string ImageUploadPath =Application.StartupPath;
        public string WebHomeDir
        {
            get { return this._webHomeDir; }
            set
            {
                if (!Directory.Exists(value))
                {
                    throw new Exception("http服务器设置的根目录不存在!");
                }
                this._webHomeDir = value;
            }
        }
        public MainForm form;
        /// <summary>  
        /// 服务器是否在运行  
        /// </summary>  
        public bool IsRunning
        {
            get { return (listener == null) ? false : listener.IsListening; }
        }
        #region
        private Controlles(string host, string port, string webHomeDir, string imageUploadPath, MainForm form)
        {
            this.Host = host;
            this.port = port;
            if (!string.IsNullOrEmpty(webHomeDir))
            {
                this._webHomeDir = webHomeDir;
            }
            if (!string.IsNullOrEmpty(imageUploadPath))
            {
                this.ImageUploadPath = this.ImageUploadPath + imageUploadPath;
            }
            if (form!=null)
            {
                this.form = form;
            }
            listener = new HttpListener();
        }
        /// <summary>
        /// 设置服务器Ip+端口
        /// </summary>
        public bool AddPrefixes(string uriPrefix,string port)
        {
            if (!string.IsNullOrEmpty(port))
            {
                this.port = port;
            }
            string uri = "http://" + uriPrefix + ":" + this.port + "/";
            if (listener.Prefixes.Contains(uri)) {
                return false;
            }
            listener.Prefixes.Add(uri);
            return true;
        }
        /// <summary>
        /// 清空服务器地址
        /// </summary>
        public void ClearPrefixes()
        {
            this.listener.Prefixes.Clear();
        }
        /// <summary>  
        /// 启动服务  
        /// </summary>  
        public void Start()
        {
            if (listener.IsListening)
            {
                return;
            }
            if (!string.IsNullOrEmpty(Host) && Host.Length > 0)
            {
                var path = "http://" +this.Host + ":" + this.port + "/";
                if (!listener.Prefixes.Contains(path))
                {
                    listener.Prefixes.Add(path);
                }
            }
            else if (listener.Prefixes == null || listener.Prefixes.Count == 0)
            {
                listener.Prefixes.Add("http://localhost:" + this.port + "/");
            }
            try
            {
                listener.Start();
                listenThread = new Thread(AcceptClient);
                listenThread.Name = "httpserver";
                listenThread.Start();
            }
            catch (Exception ex)
            {
                listener.Close();
                listener = new HttpListener();
                throw ex;
            }
        }
        /// <summary>
        /// 重启服务器
        /// </summary>
        public void Reload(string ip,string port=null)
        {
            this.Stop();
            this.ClearPrefixes();
            this.AddPrefixes(ip, port);
            this.Start();
        }
        /// <summary>  
        /// 停止服务  
        /// </summary>  
        public void Stop()
        {
            try
            {
                if (listener != null)
                {
                    //listener.Close();
                    //listener.Abort();
                    listener.Stop();

                }
            }
            catch (Exception ex)
            {
               LogUtil.WriteLog(ex.StackTrace+"="+DateTime.Now);
            }
        }
        /// <summary>  
        /// /接受客户端请求  
        /// </summary>  
        public void AcceptClient()
        {
            while (listener.IsListening)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                    ThreadPool.QueueUserWorkItem(new WaitCallback(HandleRequest), context);
                }
                catch
                {

                }
            }

        }
        #endregion
        //处理客户端请求  
        private async void HandleRequest(object ctx)
        {
            HttpListenerContext context = ctx as HttpListenerContext;
            HttpListenerResponse response = context.Response;
            HttpListenerRequest request = context.Request;
            try
            {
                string rawUrl = System.Web.HttpUtility.UrlDecode(request.RawUrl);
                int paramStartIndex = rawUrl.IndexOf('?');
                if (paramStartIndex > 0)
                {
                    rawUrl = rawUrl.Substring(0, paramStartIndex);
                }
                else if (paramStartIndex == 0)
                {
                    rawUrl = "";
                }
                if (string.Compare(rawUrl, "/ImageUpload", true) == 0)
                {
                    var result = new ResoponseResult() {Count=0};
                    var count = 0;
                    #region 上传图片
                    using (var stream = request.InputStream)
                    {
                        using (System.IO.StreamReader reader = new System.IO.StreamReader(stream, request.ContentEncoding))
                        {
                            var content = await reader.ReadToEndAsync();
                            var param = JsonConvert.DeserializeObject<RequestParam>(content);
                            if (param!=null)
                            {
                                param.Images.ForEach(x=> {
                                    var base64Pic = x.pic;
                                    var fileName = Guid.NewGuid().ToString("N") + "." +x.Type;
                                    string filePath = FormConfigUtil.WifiPath + "\\" + fileName;
                                    byte[] bt = Convert.FromBase64String(base64Pic.Substring(base64Pic.IndexOf(',') + 1));
                                    var picStream = new System.IO.MemoryStream(bt);
                                    var bitmap = new Bitmap(picStream);
                                    bitmap.Save(filePath);
                                    picStream.Close();
                                    form.PushImages(bitmap, filePath,x.Type, result);               
                                });
                            }
                        }
                    }
                    response.ContentType = "text/html;charset=utf-8";

                    using (StreamWriter writer = new StreamWriter(response.OutputStream, Encoding.UTF8))
                    {
                        writer.Write(JsonConvert.SerializeObject(result));
                    }

                    #endregion
                }
                else
                {
                    #region 网页请求
                    string InputStream = "";
                    using (var streamReader = new StreamReader(request.InputStream))
                    {
                        InputStream = streamReader.ReadToEnd();
                    }
                    string filePath = "";
                    if (string.IsNullOrEmpty(rawUrl) || rawUrl.Length == 0 || rawUrl == "/")
                    {
                        filePath = WebHomeDir + directorySeparatorChar + "Index.html";
                    }
                    else
                    {
                        filePath = WebHomeDir + rawUrl.Replace("/", directorySeparatorChar);
                    }
                    if (!File.Exists(filePath))
                    {
                        response.ContentLength64 = 0;
                        response.StatusCode = 404;
                        response.Abort();
                    }
                    else
                    {
                        response.StatusCode = 200;
                        string exeName = Path.GetExtension(filePath);
                        response.ContentType = GetContentType(exeName);
                        FileStream fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
                        int byteLength = (int)fileStream.Length;
                        byte[] fileBytes = new byte[byteLength];
                        fileStream.Read(fileBytes, 0, byteLength);
                        fileStream.Close();
                        fileStream.Dispose();
                        response.ContentLength64 = byteLength;
                        response.OutputStream.Write(fileBytes, 0, byteLength);
                        response.OutputStream.Close();
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 200;
                response.ContentType = "text/plain";
                using (StreamWriter writer = new StreamWriter(response.OutputStream, Encoding.UTF8))
                {
                    writer.WriteLine("500");
                }
            }
            try
            {
                response.Close();
            }
            catch (Exception ex)
            {
                throw;
                //LogHelper.WriteLog(typeof(HttpServerBLL), ex);
            }
        }
        /// <summary>  
        /// 获取文件对应MIME类型  
        /// </summary>  
        /// <param name="fileExtention">文件扩展名,如.jpg</param>  
        protected string GetContentType(string fileExtention)
        {
            if (string.Compare(fileExtention, ".html", true) == 0
                        || string.Compare(fileExtention, ".htm", true) == 0)
                return "text/html;charset=utf-8";
            else if (string.Compare(fileExtention, ".js", true) == 0)
                return "application/javascript";
            else if (string.Compare(fileExtention, ".css", true) == 0)
                return "application/javascript";
            else if (string.Compare(fileExtention, ".png", true) == 0)
                return "image/png";
            else if (string.Compare(fileExtention, ".jpg", true) == 0 || string.Compare(fileExtention, ".jpeg", true) == 0)
                return "image/jpeg";
            else if (string.Compare(fileExtention, ".gif", true) == 0)
                return "image/gif";
            else if (string.Compare(fileExtention, ".swf", true) == 0)
                return "application/x-shockwave-flash";
            else
                return "";//application/octet-stream
        }
        /// <summary>
        /// 获取本机Ip地址
        /// </summary>
        public static string GetIP()
        {
            //本机名  
            string hostName = Dns.GetHostName();
            //会返回所有地址，包括IPv4和IPv6   
            System.Net.IPAddress[] addressList = Dns.GetHostAddresses(hostName);
            var ip = addressList.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
            return ip.ToString();
        }
    }
    public class ResoponseResult {
        public string Message { get; set;}
        public string Code { get; set;}
        public int Count { get; set; }
    }
    /// <summary>
    /// 请求实体
    /// </summary>
    public class RequestParam {
        public  List<ImageDetailParam> Images{ get; set; }
    }
    public class ImageDetailParam{
        /// <summary>
        /// Base64图片
        /// </summary>
        public String pic { get; set; }
        /// <summary>
        /// 图片类型
        /// </summary>
        public string Type { get; set; }
    }
}
