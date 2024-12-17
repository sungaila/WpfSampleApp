using MaterialDesignThemes.Wpf;
using StarWarsClient.Views;
using System.Windows;
using System.Windows.Threading;

namespace StarWarsClient
{
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if ((MainWindow as MainWindow)?.Snackbar?.MessageQueue is SnackbarMessageQueue queue)
            {
                queue.Enqueue(e.Exception, new PackIcon() { Kind = PackIconKind.Close }, _ => { }, null, true, true, TimeSpan.FromSeconds(10));
                e.Handled = true;
            }
        }
    }
}