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
using System.Timers;

namespace Slider_ProgressBar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private Timer timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void add_1_5(object sender, RoutedEventArgs e)
        {

            if (bar_task1.Value != bar_task1.Maximum)
            {
                bar_task1.Value += bar_task1.Maximum / 5;
            }
            else
            {
                bar_task1.Foreground = Brushes.Green;
                MessageBox.Show("Maximum value reached!");
            }

        }

        private void add_20(object sender, RoutedEventArgs e)
        {
            timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(Tick);
            timer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (bar_task2.Value < bar_task2.Maximum)
                {
                    bar_task2.Value += bar_task2.Maximum / 20;
                }
                else
                {
                    timer.Stop();
                    bar_task2.Foreground = Brushes.Green;
                    MessageBox.Show("Maximum value reached!");
                }
            });
        }

        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Title = $"Value: {Math.Floor(slider.Value)}";
        }

        private void selectDate(object sender, SelectionChangedEventArgs e)
        {
            string str = calendar.SelectedDate.ToString();
            string[] arr = str.Split(' ');
            dateOutput.Content = arr[0];
        }
    }
}
