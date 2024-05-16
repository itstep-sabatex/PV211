using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        private void CheckPassword()
        {

                if (Config.DataAdapter.CheckPassword(SelectedUserId, PasswordBox.Password))
                {
                    LoginResult?.Invoke(SelectedUserId, "");
                }
                else
                {
                    passwordCounter--;
                    if (passwordCounter == 0)
                        LoginResult?.Invoke(null, string.Empty);
                    ErrorTextBlock.Text = $"Пароль введено неправильно, спробуйте ще {passwordCounter} раз.";
                    ErrorTextBlock.Visibility = Visibility.Visible;
                }


        }


        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                CheckPassword();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            LoginResult?.Invoke(null, string.Empty);
        }
        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            CheckPassword();
        }


        private void ThisWindow_Loaded(object sender, RoutedEventArgs e)
        {
               var users = Config.DataAdapter.GetUsersAsync();
                userComboBox.ItemsSource = users;
                if ((users?.Count() ?? 0) == 0)
                    throw new Exception("В базі відсутні офіціанти");
                userComboBox.SelectedValue = users.First().Id;

        }
    }
}
