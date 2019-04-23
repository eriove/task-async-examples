using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Lightning.Library;

namespace Lightning.Console
{
    class Program
    {
        private readonly WorkerClass _workerClass = new WorkerClass()
        {
            TimeToWait = TimeSpan.FromSeconds(1)
        };
        static async Task Main(string[] args)
        {
            var program = new Program();
            //string time = program.DoWorkAsyncWait();
            //string time = program.DoWorkThreadSyncAsyncWait();
            //string time = await program.DoWorkAsync();
            string time = await program.DoWorkThreadSyncAsync();
            //string time = await program.DoWorkAsyncWaitConfigureAwait();
            System.Console.WriteLine(time);
            System.Console.ReadKey();
        }

        private async Task<string> DoWorkThreadSyncAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _workerClass.DoWorkThreadSyncAsync();
            stopwatch.Stop();
            return $"{stopwatch.Elapsed.TotalSeconds:F6} s";
        }
        private async Task<string> DoWorkAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _workerClass.DoWorkAsync();
            stopwatch.Stop();
            return $"{stopwatch.Elapsed.TotalSeconds:F6} s";
        }
        private string DoWorkThreadSyncAsyncWait()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _workerClass.DoWorkThreadSyncAsync().Wait();
            stopwatch.Stop();
            return $"{stopwatch.Elapsed.TotalSeconds:F6} s";
        }
        private string DoWorkAsyncWait()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _workerClass.DoWorkAsync().Wait();
            stopwatch.Stop();
            return $"{stopwatch.Elapsed.TotalSeconds:F6} s";
        }
        private async Task<string> DoWorkAsyncWaitConfigureAwait()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _workerClass.DoWorkAsync().ConfigureAwait(false);
            stopwatch.Stop();
            return $"{stopwatch.Elapsed.TotalSeconds:F6} s";
        }
    }
}
