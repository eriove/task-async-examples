using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Lightning.Library;
using Xunit;
using Xunit.Abstractions;

namespace Lightning.Tests
{
    public class UnitTests
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly WorkerClass _workerClass = new WorkerClass()
        {
            TimeToWait = TimeSpan.FromSeconds(1)
        };
        public UnitTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;

        }

        [Fact]
        public async void DoWorkThreadSyncAsyncVoid()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _workerClass.DoWorkThreadSyncAsync();
            stopwatch.Stop();
            _outputHelper.WriteLine($"{stopwatch.Elapsed.TotalSeconds:F6} s");
        }
        [Fact]
        public async void DoWorkAsyncVoid()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _workerClass.DoWorkAsync();
            stopwatch.Stop();
            _outputHelper.WriteLine($"{stopwatch.Elapsed.TotalSeconds:F6} s");
        }
        [Fact]
        public async void DoWorkAsyncWaitConfigureAwaitVoid()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _workerClass.DoWorkAsync().ConfigureAwait(false);
            stopwatch.Stop();
            _outputHelper.WriteLine($"{stopwatch.Elapsed.TotalSeconds:F6} s");
        }

        [Fact]
        public async Task DoWorkThreadSyncAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _workerClass.DoWorkThreadSyncAsync();
            stopwatch.Stop();
            _outputHelper.WriteLine($"{stopwatch.Elapsed.TotalSeconds:F6} s");
        }
        [Fact]
        public async Task DoWorkAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _workerClass.DoWorkAsync();
            stopwatch.Stop();
            _outputHelper.WriteLine($"{stopwatch.Elapsed.TotalSeconds:F6} s");
        }
        [Fact]
        public async Task DoWorkAsyncWaitConfigureAwait()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _workerClass.DoWorkAsync().ConfigureAwait(false);
            stopwatch.Stop();
            _outputHelper.WriteLine($"{stopwatch.Elapsed.TotalSeconds:F6} s");
        }

        [Fact]
        public void DoWorkThreadSyncAsyncWait()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _workerClass.DoWorkThreadSyncAsync().Wait();
            stopwatch.Stop();
            _outputHelper.WriteLine($"{stopwatch.Elapsed.TotalSeconds:F6} s");
        }

        [Fact]
        public void DoWorkAsyncWait()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _workerClass.DoWorkAsync().Wait();
            stopwatch.Stop();
            _outputHelper.WriteLine($"{stopwatch.Elapsed.TotalSeconds:F6} s");
        }

    }
}
