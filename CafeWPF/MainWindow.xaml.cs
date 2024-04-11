using Cafe.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CafeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IConfigurationRoot? Configuration;

        public MainWindow()
        {
            InitializeComponent();
            
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddUserSecrets<MainWindow>().Build();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var connection = new Microsoft.Data.Sqlite.SqliteConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                dg.ItemsSource = connection.Query<Role>("select * from role");
            }
        }
    }
}