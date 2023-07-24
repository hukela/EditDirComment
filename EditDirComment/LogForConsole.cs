using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace EditDirComment
{
public class LogForConsole
{
    /// <summary>
    /// 添加错误级别的日志信息
    /// </summary>
    /// <param name="e">异常</param>
    /// <param name="i">堆栈回溯</param>
    public static void PrintException(Exception e, int i = 0)
    {
        StringBuilder builder = new StringBuilder();
        do
        {
            builder.AppendLine(e.Message + " (" + e.GetType() + ")")
                .AppendLine(e.StackTrace);
            e = e.InnerException;
        } while (e != null);
        AddLog(builder.ToString(), "error", i + 2);
    }
    // i: 回溯堆栈的索引
    private static void AddLog(string message, string type, int i)
    {
        DateTime now = DateTime.Now;
        string time = now.ToString("hh:mm:ss.fff");
        //获取添加日志的类的路径
        StackTrace trace = new StackTrace(true);
        MethodBase method = trace.GetFrame(i).GetMethod();
        string classPath = method.DeclaringType?.FullName;
        message = time + " " + type + " " + classPath + " [" + method + "]: " + message;
        Console.WriteLine(message);
    }
} }