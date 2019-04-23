using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lightning.Library;

namespace Lightning.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WorkerClass _workerClass;

        public MainWindow()
        {
            InitializeComponent();
            _workerClass = new WorkerClass()
            {
                TimeToWait = TimeSpan.FromSeconds(1)
            };
        }

        private async void DoWorkThreadSyncAsync(object sender, RoutedEventArgs e)
        {
            Cursor lastCursor = Cursor;
            Cursor = Cursors.Wait;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _workerClass.DoWorkThreadSyncAsync();
            stopwatch.Stop();
            Label.Content = $"{stopwatch.Elapsed.TotalSeconds:F6} s\n";
            Cursor = lastCursor;
        }
        private async void DoWorkAsync(object sender, RoutedEventArgs e)
        {
            Cursor lastCursor = Cursor;
            Cursor = Cursors.Wait;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _workerClass.DoWorkAsync();
            stopwatch.Stop();
            Label.Content = $"{stopwatch.Elapsed.TotalSeconds:F6} s\n";
            Cursor = lastCursor;
        }
        private void DoWorkThreadSyncAsyncWait(object sender, RoutedEventArgs e)
        {
            Cursor lastCursor = Cursor;
            Cursor = Cursors.Wait;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _workerClass.DoWorkThreadSyncAsync().Wait();
            stopwatch.Stop();
            Label.Content = $"{stopwatch.Elapsed.TotalSeconds:F6} s\n";
            Cursor = lastCursor;
        }
        private void DoWorkAsyncWait(object sender, RoutedEventArgs e)
        {
            Cursor lastCursor = Cursor;
            Cursor = Cursors.Wait;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _workerClass.DoWorkAsync().Wait();
            stopwatch.Stop();
            Label.Content = $"{stopwatch.Elapsed.TotalSeconds:F6} s\n";
            Cursor = lastCursor;
        }
        private async void DoWorkAsyncWaitConfigureAwait(object sender, RoutedEventArgs e)
        {
            Cursor lastCursor = Cursor;
            Cursor = Cursors.Wait;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _workerClass.DoWorkAsync().ConfigureAwait(false);
            stopwatch.Stop();
            Label.Content = $"{stopwatch.Elapsed.TotalSeconds:F6} s\n";
            Cursor = lastCursor;
        }
    }
}
