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
using System.Windows.Threading;

namespace WpfMonitorDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer a;
        Timer b;
        Thread matrinOneThread;

        public MainWindow()
        {
            InitializeComponent();
            matrinOneThread = new Thread(() => {
                var m = new MatrixLib.Matrix();
                var a = m.CreateMatrix(1000);
                var b = m.CreateMatrix(1000);

                var c = m.MultipleMatrix(1000, a, b, (n) =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        prBar.Value = n / 10 + 1;
                    });


                });


            });
            matrinOneThread.IsBackground = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            a = new DispatcherTimer();
            a.Interval = TimeSpan.FromSeconds(1); 
            a.Tick += A_Tick;
            a.Start();


            //b = new Timer(TimerElapsed,null, 2000, 1000);


        }

        private void A_Tick(object? sender, EventArgs e)
        {
            //label1.Content = DateTime.Now.ToString();
        }

        private void TimerElapsed(object? sender)
        {
            Dispatcher.Invoke(new Action(() => {label1.Content = DateTime.Now.ToString(); }));
            Thread.Sleep(900); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             matrinOneThread.Start();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            matrinOneThread?.Abort();

        }
    }
}