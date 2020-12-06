using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Threading;
using System.Windows.Threading;

namespace _27._11._20_Zoo
{
   
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        static private Button btn;
        public MainWindow()
        {
            InitializeComponent();
            mainGrid.Visibility = Visibility.Visible;
            mainScroll.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            mainScroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            buttonLoading.Visibility = Visibility.Hidden;
        }

        private void MainWindow_Initialized(object sender, EventArgs e)
        {
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
           
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            
        }

        private void buttonLoading_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Visible;
            mainScroll.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            mainScroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            buttonLoading.Visibility = Visibility.Hidden;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            buttonLoading.IsEnabled = true;
            timer.Stop();
        }

        private void aviaryBtn_Click(object sender, RoutedEventArgs e)
        {
            btn = (Button)sender;
            

            double left = btn.Margin.Left;
            double top = btn.Margin.Top;
            double right = btn.Margin.Right;
            double bottom = btn.Margin.Bottom;
            Thickness thicknessLeft = new Thickness(left + btn.Width + 10, top, right, bottom);
            comboBoxAviaries.Margin = thicknessLeft;
            comboBoxAviaries.Visibility = Visibility.Visible;
        }

        private void comboBoxAviary_Click(object sender, RoutedEventArgs e)
        {
            //при выборе вольера пропадает comboBoxAviaries
            //и картинка разрушенного здания заменяеться на выбранную
            comboBoxAviaries.Visibility = Visibility.Hidden;

            //не находит картинку и виснит... Нашла как сделать с битмап, но картинки в пнг
            //btn.Background = new ImageBrush(new BitmapImage(new Uri(@"Locations\forest.png")));
        }
    }
}
