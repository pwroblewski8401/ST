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
    /// Logika interakcji dla klasy Shoes.xaml
    /// </summary>
    public partial class Shoes : UserControl
    {
        private int? distanceSUM;
        string name;
        int limit;

        public Shoes(string name, int? distanceSUM, int limit)
        {
            this.name = name;
            this.distanceSUM = distanceSUM;
            this.limit = limit;

            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtDistance.Text = this.distanceSUM.ToString();
            txtLimit.Text = this.limit.ToString();
            txtShoesName.Text = this.name;

            GridMain.Background = setBackground();
        }

        private Brush setBackground()
        {
            double? procent = 0;
            if (this.limit > 0)
            {
                procent = (Convert.ToDouble(this.distanceSUM) / Convert.ToDouble(this.limit)) * 100;
            }
            else
                procent = 100;

            if(procent < 80)
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(97, 177, 90));
                return brush;
            }
            else if(procent > 80 && procent < 100)
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(255, 245, 77));
                return brush;
            }
            else
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(206, 18, 18));
                return brush;
            }


               
        }
    }
}
