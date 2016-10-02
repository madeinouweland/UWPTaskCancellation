// Made with ❤ in Berlin by Loek van den Ouweland
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancellationUWP
{
    public class Caller
    {
        public event EventHandler<string> Report;

        private CancellationTokenSource _cancel = new CancellationTokenSource();
        private Progress<string> _progress = new Progress<string>();

        public async Task Start()
        {
            var worker = new Worker();
            _progress.ProgressChanged += _progress_ProgressChanged;
            await worker.Foo(_cancel, _progress);
        }

        private void _progress_ProgressChanged(object sender, string e)
        {
            Report?.Invoke(this, e);
        }

        public void Cancel()
        {
            _progress.ProgressChanged -= _progress_ProgressChanged;
            _cancel.Cancel();
        }
    }
}
