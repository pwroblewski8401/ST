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
using System.Windows.Shapes;

namespace ST.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddNewActivity.xaml
    /// </summary>
    public partial class AddNewActivity : Window
    {
        MainWindow parentWindow;
        ShoesEntities context = new ShoesEntities();
        public AddNewActivity(MainWindow parentWindow)
        {
            InitializeComponent();
            DataContext = this;
            this.parentWindow = parentWindow;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var shoes = context.SP_SelectAllShoes();
            foreach(var line in shoes)
            {
                ComboBoxItem i = new ComboBoxItem();
                i.Content = line.Name;
                i.Tag = line.Id;
                combo_shoes.Items.Add(i);
            }

            combo_shoes.SelectedIndex = 1;
        }

        private void combo_shoes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = combo_shoes.SelectedItem;
            var b = combo_shoes.SelectedValue;
        }

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            var b = TimeSpan.Parse(txt_time.Text);
            var result = context.SP_AddNewRun(DatePicker_date.SelectedDate, Convert.ToInt32(txt_Distance.Text), Convert.ToInt32(combo_shoes.SelectedValue), TimeSpan.Parse(txt_time.Text));
            parentWindow.refreshMainPanel();
            parentWindow.refreshShoesPanel();
            this.Close();
        }
    }
}
