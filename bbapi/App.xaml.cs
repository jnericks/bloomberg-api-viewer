using System;
using System.Windows;
using System.Windows.Threading;

namespace bbapi
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Action<string> Log;

        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Process unhandled exception
            if (Log != null) Log(e.Exception.ToString());

            // Prevent default unhandled exception processing
            e.Handled = true;
        }
    }
}