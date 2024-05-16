using Cafe.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OrderEdit.xaml
    /// </summary>
    public partial class OrderEdit : UserControl
    {
        public int OrderId { get; set; }
        public Cafe.Models.Order Order { get; set; }
        public ObservableCollection<OrderDetail> OrderDetails { get; set; }
        public ClientTable[] ClientTables { get; set; }
        public OrderEdit()
        {
            InitializeComponent();
        }
        public void Refresh()
        {
            //using (var context = new CafeDbContext())
            //{
            //    ClientTables = context.ClientTables.ToArray();
            //    clientSelect.ItemsSource = ClientTables;
            //    Order = context.Orders.Find(OrderId);
            //    if (Order == null) { throw new Exception("Не знайдено ордер"); }
            //    clientSelect.SelectedItem = Order.Id;
            //    OrderDetails = new ObservableCollection<OrderDetail>(context.OrderDetails.Where(s=>s.OrderId==OrderId).ToList() );
            //    dataGrid.ItemsSource = OrderDetails;
            //}
        }
    }
}
