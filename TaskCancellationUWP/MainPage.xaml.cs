using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TaskCancellationUWP
{
    public sealed partial class MainPage : Page
    {
        private CancellationTokenSource _cancel;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async Task Foo(CancellationTokenSource cancel)
        {
            while (!cancel.IsCancellationRequested)
            {
                info.Text = DateTime.Now.Ticks + "";
                await Task.Delay(2000);
            }
            info.Text = "cancelled";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            info.Text = "starting task";

            _cancel = new CancellationTokenSource();
            await Foo(_cancel);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            info.Text = "cancelling task";
            _cancel.Cancel();
        }
    }

}
