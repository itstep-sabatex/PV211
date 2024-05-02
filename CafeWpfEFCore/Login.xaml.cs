using CafeWpfEFCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace CafeWpfEFCore
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public  int SelectedUserId { get; set; }
        public event Action<int?, string> LoginResult;
        private int passwordCounter { get; set; } = 3;

        public Login()
        {
            InitializeComponent();
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            LoginResult?.Invoke(null, string.Empty);
        }
        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {

        }


        private void ThisWindow_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new CafeDbContext())
            {
                userComboBox.ItemsSource = context.Users.Select(s=>new {s.Id, s.Name}).ToArray();
            }
        }
    }
}
