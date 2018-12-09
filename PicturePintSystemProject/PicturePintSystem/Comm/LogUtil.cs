using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
namespace PicturePintSystem.Comm
{   
    /// <summary>
    /// 日志Log4
    /// </summary>
    public class LogUtil
    {   
        /// <summary>
        /// 加载Log4
        /// </summary>
        public static void LoadLog()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        public static void WriteLog(string loginfo)
        {
            //获取一个日志记录器
            ILog log =LogManager.GetLogger("testApp.Logging");
            //写入一条新log
            log.Info(DateTime.Now.ToString() + loginfo);
        }
    }
}
