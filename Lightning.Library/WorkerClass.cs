using System;
using System.Threading.Tasks;

namespace Lightning.Library
{
    public class WorkerClass
    {
        public TimeSpan TimeToWait { get; set; }=TimeSpan.FromSeconds(10);
        public async Task<string>  DoWorkThreadSyncAsync()
        {
            await Task.Delay(TimeToWait);
            return nameof(DoWorkThreadSyncAsync);
        }
        public async Task<string> DoWorkAsync()
        {
            await Task.Delay(TimeToWait).ConfigureAwait(false);
            return nameof(DoWorkAsync);
        }
    }
}