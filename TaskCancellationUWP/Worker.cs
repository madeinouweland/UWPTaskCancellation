// Made with ❤ in Berlin by Loek van den Ouweland
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancellationUWP
{
    public class Worker
    {
        public async Task Foo(CancellationTokenSource cancel, IProgress<string> status)
        {
            while (!cancel.IsCancellationRequested)
            {
                status.Report(DateTime.Now.Ticks + "");
                await Task.Delay(2000);
            }
            status.Report("cancelled");
        }
    }
}
