using Grpc.Net.Client;
using Protobuf;
using System.Windows;

namespace StarWarsClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7232");
            var client = new StarWarsGrpc.StarWarsGrpcClient(channel);

            try
            {
                var reply = await client.GetPeopleAsync(new GetPeopleRequest());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}