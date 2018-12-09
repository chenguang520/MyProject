using PicturePintSystem.Comm;
using PicturePintSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturePintSystem
{   
    /// <summary>
    /// 程序启动配置
    /// </summary>
    public  class WinApplication
    {  
        /// <summary>
        /// 程序初始时调用
        /// </summary>
        public static void  StartConfig()
        {
            try
            {  
                //注册配置字典
                ConfigUtil.LoadConfigData();
                ConfigUtil.LoadConfigDataSet();
                ConfigUtil.LoadFormConfig();
                //注册Log4
                LogUtil.LoadLog();
            }
            catch (Exception e)
            {
                LogUtil.WriteLog("应用程序启动发生错误,错误信息: "+e.Message);
            }
        }
    }
}
