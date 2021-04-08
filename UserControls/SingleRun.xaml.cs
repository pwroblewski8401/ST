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

namespace ST.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy SingleRun.xaml
    /// </summary>
    public partial class SingleRun : UserControl
    {
        DateTime date;
        string shoes;
        int distance;
        TimeSpan time;

        public SingleRun(DateTime date, string shoes, int distance, TimeSpan time)
        {
            this.date = date;
            this.time = time;
            this.distance = distance;
            this.shoes = shoes;
            InitializeComponent();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lb_date.Content = date;
            lb_time.Content = time;
            lb_shoes.Content = shoes;
            lb_distance.Content = distance;
            lb_avg.Content = new TimeSpan(time.Ticks / distance);
        }
    }
}
