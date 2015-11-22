using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HHLoggerUtil
{
    public class LoggerUtil
    {
        //当前dll的根目录
        private static String rootPath = Assembly.GetExecutingAssembly().Location.Substring(0, Assembly.GetExecutingAssembly().Location.LastIndexOf('\\')+1);
        #region 请求内容日志，用来记录客户端发过来的请求内容
        public static void WriteRequestLog(string text)
        {
            DateTime nowDate = DateTime.Now;
            //创建文件夹
            Directory.CreateDirectory(rootPath + "\\Log\\Request\\");
            string logFile = rootPath + "\\Log\\Request\\" + +nowDate.Year + '-' + nowDate.Month + '-' + nowDate.Day + "_RequestLog.log";
            using (StreamWriter sw = new StreamWriter(logFile, true))
            {
                sw.WriteLine("<!-------------------------------------------------------------------------------->");
                sw.WriteLine(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]"));
                sw.WriteLine(text);
                sw.WriteLine();
            }
        }
        #endregion
        #region 响应内容日志，用来记录返回给客户端的响应内容
        public static void WriteResponseLog(string text)
        {
            DateTime nowDate = DateTime.Now;
            //创建文件夹
            Directory.CreateDirectory(rootPath + "\\Log\\Response\\");
            string logFile = rootPath + "\\Log\\Response\\" + +nowDate.Year + '-' + nowDate.Month + '-' + nowDate.Day + "_ResponseLog.log";
            using (StreamWriter sw = new StreamWriter(logFile, true))
            {
                sw.WriteLine("<!-------------------------------------------------------------------------------->");
                sw.WriteLine(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]"));
                sw.WriteLine(text);
                sw.WriteLine();
            }
        }
        #endregion
        #region 异常记录日志，用来记录系统发生的异常信息
        public static void WriteExceptionLog(Exception ex)
        {
            DateTime nowDate = DateTime.Now;
            //创建文件夹
            Directory.CreateDirectory(rootPath + "\\Log\\Exception\\");
            string logFile = rootPath + "\\Log\\Exception\\" + +nowDate.Year + '-' + nowDate.Month + '-' + nowDate.Day + "_ExceptionLog.log";
            //循环查看StreamWriter是否实例化成功，异常的话代表文件被占用，线程休眠等待进入下一次循环
            StreamWriter sw = null;
            while(sw==null)
            {    
                try
                {
                    sw = new StreamWriter(logFile, true);
                }
                catch (Exception)
                {
                    Thread.Sleep(1000);
                }
            }
            //把异常信息输出到文件
            sw.WriteLine("<!-------------------------------------------------------------------------------->");
            sw.WriteLine("当前时间：" + DateTime.Now.ToString());
            sw.WriteLine("异常信息：" + ex.Message);
            sw.WriteLine("异常对象：" + ex.Source);
            sw.WriteLine("异常类型：" + ex.GetType().ToString());
            sw.WriteLine("触发方法：" + ex.TargetSite);
            sw.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
            sw.WriteLine();
            sw.Close();
        }
        #endregion
        #region 异常记录日志，用来记录系统发生的异常信息
        public static void WriteExceptionLog(Exception ex, String text)
        {
            DateTime nowDate = DateTime.Now;
            //创建文件夹
            Directory.CreateDirectory(rootPath + "\\Log\\Exception\\");
            string logFile = rootPath + "\\Log\\Exception\\" + nowDate.Year + '-' + nowDate.Month + '-' + nowDate.Day + "_ExceptionLog.log";
            //循环查看StreamWriter是否实例化成功，异常的话代表文件被占用，线程休眠等待进入下一次循环
            StreamWriter sw = null;
            while (sw == null)
            {
                try
                {
                    sw = new StreamWriter(logFile, true);
                }
                catch (Exception)
                {
                    Thread.Sleep(1000);
                }
            }
            //把异常信息输出到文件
            sw.WriteLine("<!-------------------------------------------------------------------------------->");
            sw.WriteLine("当前时间：" + DateTime.Now.ToString());
            sw.WriteLine("错误信息：" + text);
            sw.WriteLine("异常信息：" + ex.Message);
            sw.WriteLine("异常对象：" + ex.Source);
            sw.WriteLine("异常类型：" + ex.GetType().ToString());
            sw.WriteLine("触发方法：" + ex.TargetSite);
            sw.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
            sw.WriteLine();
            sw.Close();
        }
        #endregion
        #region 输出消息日志（可用于程序调试或消息的输出）
        public static void WriteMsgLog(string text)
        {
            DateTime nowDate = DateTime.Now;
            //创建文件夹
            Directory.CreateDirectory(rootPath + "\\Log\\Message\\");
            string logFile = rootPath + "\\Log\\Message\\" + +nowDate.Year + '-' + nowDate.Month + '-' + nowDate.Day + "_MessageLog.log";
            using (StreamWriter sw = new StreamWriter(logFile, true))
            {
                sw.WriteLine("<!-------------------------------------------------------------------------------->");
                sw.WriteLine(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]"));
                sw.WriteLine(text);
                sw.WriteLine();
            }
        }
        #endregion
    }
}
