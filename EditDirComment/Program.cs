using System;
using System.Diagnostics;
using System.Security.Principal;

namespace EditDirComment
{
internal static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Work.Run();
        }
        catch (Exception e)
        {
            LogForConsole.PrintException(e);
        }
        if (Debugger.IsAttached)
            return;
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}

internal class Work
{
    public static void Run()
    {
        if (!IsAdmin())
        {
            Console.WriteLine("没有管理员权限，无法修改注册表，添加文件夹右键菜单。");
            return;
        }
        Console.WriteLine("1: 添加文件夹右键菜单，2: 删除文件夹右键菜单，其他输入: 退出");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                AddMenu();
                break;
            case "2":
                MenuEdit.DeleteMenu();
                break;
            default:
                return;
        }
    }

    private static bool IsAdmin()
    {
        WindowsIdentity id = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(id);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }

    private static void AddMenu()
    {
        string editWindowPath = FileIo.EditWindowPath;
        if (!FileIo.IsFileExist(editWindowPath))
        {
            Console.WriteLine("无法找到编辑窗口程序，path: " + editWindowPath);
            return;
        }
        Console.WriteLine("找到编辑窗口绝对路径，path: " + editWindowPath);
        MenuEdit.AddMenu(editWindowPath);
    }
} }