// Made with ❤ in Berlin by Loek van den Ouweland
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancellationUWP
{
    public class Worker
    {
        public async Task Foo(CancellationToken cancel, IProgress<string> status)
        {
            while (!cancel.IsCancellationRequested)
            {
                // after cancelling, this code will not be executed anymore
                // but when setting the caller to null, this code keeps executing.
                // test it by putting a breakpoint on the next line
                status.Report(DateTime.Now.Ticks + "");
                await Task.Delay(2000);
            }
            status.Report("cancelled");
        }
    }
}
