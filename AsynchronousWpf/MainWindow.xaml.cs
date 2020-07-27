using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace AsynchronousWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string _url = "https://docs.microsoft.com/en-in/dotnet/csharp/getting-started/introduction-to-the-csharp-language-and-the-net-framework";
        public MainWindow()
        {
            InitializeComponent();
        }

        // Synchronous calling
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DownloadHtml(this._url);

            var html = GetHtml(this._url);
            MessageBox.Show(html.Substring(0, 10));
        }

        // Asynchronous calling
        private async void ButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            await DownloadHtmlAsync(this._url);

            var html = await GetHtmlAsync(this._url);
            MessageBox.Show(html.Substring(0, 10));

            // Now we don't always have to await an async method/operation
            // We can also do something like this (getHtmlTask will be immediately assigned Task<string> here and program goes to next line of execution)
            var getHtmlTask = GetHtmlAsync(this._url);
            MessageBox.Show("Message");
            // Hence we can perform any steps here in between that we want to perform immediately
            // ..

            // and after that, we can await this method so that the call can go immediately to the caller and this two lines will be executed asynchronously
            var htmlTwo = await getHtmlTask;
            MessageBox.Show(htmlTwo.Substring(0, 10));
        }

        // This method will take some time and hence till this method completes, our UI will be unresponsive till that time
        public void DownloadHtml(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            using (var streamWriter = new StreamWriter(@"E:\Computer Science\C#\TempFilesUsedForExercises\result.html"))
            {
                streamWriter.Write(html);
            }
        }

        public string GetHtml(string url)
        {
            var webClient = new WebClient();
            return webClient.DownloadString(url);
        }

        public async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            // Seeing await keyword, the program immediately returns to the caller and hence not blocking the thread
            var html = await webClient.DownloadStringTaskAsync(url);

            #region so this region is like callback method which will be executed after the upper line is executed
            using (var streamWriter = new StreamWriter(@"E:\Computer Science\C#\TempFilesUsedForExercises\result.html"))
            {
                await streamWriter.WriteAsync(html);
            }
            #endregion
        }

        public async Task<string> GetHtmlAsync(string url)
        {
            var webClient = new WebClient();

            return await webClient.DownloadStringTaskAsync(url);
        }
    }
}
