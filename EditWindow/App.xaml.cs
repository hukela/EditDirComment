using System.Windows;

namespace EditWindow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            // 获取命令行参数
            string[] args = e.Args;
            DirPath = args.Length > 0 ? args[0] : string.Empty;
            if (!string.IsNullOrEmpty(DirPath))
                return;
            MessageBox.Show("启动参数缺失");
            Shutdown();
        }

        internal static string DirPath { get; private set; }
    }
}