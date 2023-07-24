using System;
using Microsoft.Win32;

namespace EditDirComment
{
/// <summary>
/// 用于编辑右键菜单
/// </summary>
internal static class MenuEdit
{
    public static void AddMenu(string editWindowPath)
    {
        RegistryKey shellKey = Registry.ClassesRoot.OpenSubKey(@"Directory\shell", true);
        if (shellKey == null)
            throw new ApplicationException(@"注册表异常，没有找到：\HKEY_CLASSES_ROOT\Directory\shell");
        RegistryKey editDirCommentKey = shellKey.OpenSubKey("EditDirComment", true);
        if (editDirCommentKey != null)
        {
            Console.WriteLine("已经存在右键菜单");
            return;
        }
        editDirCommentKey = shellKey.CreateSubKey("EditDirComment");
        if (editDirCommentKey == null)
            throw new ApplicationException(@"注册表异常，key创建失败：\HKEY_CLASSES_ROOT\Directory\shell\EditDirComment");
        editDirCommentKey.SetValue("", "编辑备注");
        editDirCommentKey.SetValue("Icon", @"C:\Windows\System32\SHELL32.dll,110");
        RegistryKey commandKey = editDirCommentKey.CreateSubKey("command");
        if (commandKey == null)
            throw new ApplicationException(@"注册表异常，key创建失败：\HKEY_CLASSES_ROOT\Directory\shell\EditDirComment\command");
        commandKey.SetValue("", editWindowPath + " \"%1\"");
        Console.WriteLine(@"已添加：\HKEY_CLASSES_ROOT\Directory\shell\EditDirComment");
        Console.WriteLine("菜单添加成功，对应右键名称：编辑备注");
    }

    public static void DeleteMenu()
    {
        RegistryKey shellKey = Registry.ClassesRoot.OpenSubKey(@"Directory\shell", true);
        if (shellKey == null)
            throw new ApplicationException(@"注册表异常，没有找到：\HKEY_CLASSES_ROOT\Directory\shell");
        RegistryKey editDirCommentKey = shellKey.OpenSubKey("EditDirComment", true);
        if (editDirCommentKey == null)
        {
            Console.WriteLine(@"没有找到该程序创建的key：\HKEY_CLASSES_ROOT\Directory\shell\EditDirComment");
            return;
        }
        shellKey.DeleteSubKeyTree("EditDirComment");
        Console.WriteLine(@"已删除：\HKEY_CLASSES_ROOT\Directory\shell\EditDirComment");
        return;
    }
} }