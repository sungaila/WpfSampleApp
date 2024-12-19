using MaterialDesignThemes.Wpf;
using StarWarsClient.Views;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;

namespace StarWarsClient
{
    public partial class App : Application
    {
        private static readonly CultureInfo _culture = new("en-US");

        public App()
        {
            Thread.CurrentThread.CurrentCulture = _culture;
            Thread.CurrentThread.CurrentUICulture = _culture;
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }

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