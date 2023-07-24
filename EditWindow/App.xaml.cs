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
            var args = e.Args;
            MessageBox.Show(args[0]);
            this.Shutdown();
        }
    }
}