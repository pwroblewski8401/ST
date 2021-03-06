using System;
using System.Windows;
using System.Windows.Controls;


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
            if(distance >= 1000)
                lb_avg.Content = new TimeSpan(time.Ticks / (distance / 1000)).ToString(@"hh\:mm\:ss");
            else
                lb_avg.Content = new TimeSpan(time.Ticks / (distance)).ToString(@"hh\:mm\:ss"); 

        }
    }
}
