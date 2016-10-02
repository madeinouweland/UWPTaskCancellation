// Made with ❤ in Berlin by Loek van den Ouweland
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TaskCancellationUWP
{
    public sealed partial class MainPage : Page
    {
        private Caller _caller;

        public MainPage()
        {
            this.InitializeComponent();
            info.Text = "ready";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            info.Text = "starting task";
            _caller = new Caller();
            _caller.Report += _caller_Report;
            await _caller.Start();
            info.Text = "ready";
        }

        private void Cancel()
        {
            _caller.Report -= _caller_Report;
            _caller.Cancel();
        }

        private void _caller_Report(object sender, string e)
        {
            info.Text = e;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            info.Text = "cancelling task";
            Cancel();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _caller = null;
        }
    }
}
