using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturePintSystem.Comm
{  
    public class TempUtil
    {  
        //当前的缓存区域
        private static Dictionary<string, Templete> _templeteCache = new Dictionary<string, Templete>();
        /// <summary>
        /// 渲染模板  cacheKey文件名称
        /// </summary>
        private string RenderUseCache(string cacheKey, object model)
        {  
            string content = string.Empty;
            string contentMD5 = string.Empty;
            lock (_templeteCache)
            {  
                var templatePath = System.AppDomain.CurrentDomain.BaseDirectory+"Temp"+cacheKey;              
                if (_templeteCache.ContainsKey(cacheKey))
                {
                    content = _templeteCache[cacheKey].Content;
                    contentMD5 = _templeteCache[cacheKey].MD5;
                }
                else
                {
                    if (System.IO.File.Exists(templatePath))
                    {
                         content = System.IO.File.ReadAllText(templatePath);
                        _templeteCache.Add(cacheKey, new Templete()
                        {
                            MD5 = contentMD5,
                            Content = content,
                            FileName = templatePath
                        });
                    }
                    else
                    {
                        throw new Exception(string.Format("生成内容失败; 没有找到对应的模板{0}", cacheKey));
                    }
                }
            }

            var renderResult = false;
            var renderMessage = string.Empty;

            var result = string.Empty;

            result = this.Render(content, model.GetType(), model, contentMD5, out renderResult, out renderMessage);

            return result;
        }

        /// <summary>
        /// 将模板进行渲染
        /// </summary>
        public  string Render<T>(string template, Type type, T model, string templateKey, out bool result, out string message)
        {
            try
            {
                string html = Engine.Razor.RunCompile(template, templateKey, type, model, null);
                result = true;
                message = "Successed";
                return html;
            }
            catch (Exception e)
            {
                result = false;
                message = "error";
                throw new Exception(e.Message);
            }
        }
        public static string GetMD5(string inputStr)
        {
            var result = inputStr;
            byte[] result2 = System.Text.Encoding.Default.GetBytes(result);    //tbPass为输入密码的文本框
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result2);
            result = BitConverter.ToString(output).Replace("-", "");
            return result;
        }
    }
    public class Templete
    {   
        public string MD5 { get; set; }
        public string Content { get; set; }
        public string FileName { get; set; }
    }
}
