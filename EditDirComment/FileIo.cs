using System;
using System.Diagnostics;

namespace EditDirComment
{
public class FileIo
{
    static FileIo()
    {
        string currentPath = System.Environment.CurrentDirectory;
        if (Debugger.IsAttached)
        {
            // 开发阶段 为当前项目根目录
            int i = currentPath.IndexOf("EditDirComment", StringComparison.Ordinal);
            LocalPath = currentPath.Substring(0, i + 14);
        }
        else
        {
            // 发布阶段 为当前程序根目录
            LocalPath = currentPath;
        }
    }

    /// <summary>
    /// 当前路径
    /// </summary>
    public static readonly string LocalPath;

    /// <summary>
    /// 查看文件是否存在
    /// </summary>
    public static bool IsFileExist(string path)
    {
        return System.IO.File.Exists(path);
    }

    /// <summary>
    /// 获取编辑窗口路径
    /// </summary>
    public static string EditWindowPath
    {
        get
        {
            if (Debugger.IsAttached)
                return LocalPath + @"\EditWindow\bin\Debug\EditWindow.exe";
            return LocalPath + @"\EditWindow.exe";
        }
    }
} }