
using Microsoft.EntityFrameworkCore;
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

namespace CafeWpfEFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginFrame.LoginResult += LoginFrame_LoginResult;
        }

        void Refresh()
        {
            //using (var context = new CafeDbContext())
            //{
            //    var data = context.Orders.Where(s => s.UserId == Config.UserId)
            //        .Join(context.ClientTables, ws => ws.ClientTableId, ab => ab.Id, (ws, ab) => new { Id = ws.Id, Abonent = ab.Name, Time_order = ws.Date.ToString("H:mm:ss"), Summ = context.OrderDetails.Where(w => w.OrderId == ws.Id).Sum(sl=>sl.Sum), Bill = ws.Bill }).ToArray();
                
            //    //var data2 = context.Orders.Include(s=>s.ClientTable).Include(d=>d.Details).Where(s => s.UserId == Config.UserId).Select(sl=>new MainWindowViewModelR(sl.Id, sl.ClientTable.Name, sl.Date.ToString("H:mm:ss"),sl.Details.Sum(sum=>sum.Sum), sl.Bill)).ToArray();


            //    dataGrid.ItemsSource = data;
            //}
        }

        private void LoginFrame_LoginResult(int? arg1, string arg2)
        {
            if (arg1 == null)
            {
                Close();
                return;
            }
            Config.UserId = arg1.Value;
            Config.UserName = arg2;
            Title = $"{Config.UserName} : {DateTime.Now}";
            LoginFrame.Visibility = Visibility.Collapsed;
            MainFrame.Visibility = Visibility.Visible;
            Refresh();
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = dataGrid.CurrentItem;
            MainFrame.Visibility = Visibility.Collapsed;
            orderEdit.Visibility = Visibility.Visible;
            var ts = row.GetType().GetProperty("Id");

            orderEdit.OrderId = (int)(ts.GetValue(row));
            orderEdit.Refresh();
        }
    }
}