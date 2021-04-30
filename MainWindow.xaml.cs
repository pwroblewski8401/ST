using System;
using System.Windows;
using System.Windows.Controls;

namespace ST
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShoesEntities context = new ShoesEntities();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refreshMainPanel();
            refreshShoesPanel();

        }

        private void btn_AddNew_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddNewActivity addNew = new Windows.AddNewActivity(this);
            addNew.ShowDialog();

        }

        public void refreshMainPanel()
        {
            StackPanelMain.Children.Clear();

            int sum = 0;
            var st_results = context.SP_SelectAllRuns_WithShouesName();
            foreach (SP_SelectAllRuns_WithShouesName_Result line in st_results)
            {
                sum = sum + line.Distance;
                UserControls.SingleRun run = new UserControls.SingleRun(line.Date, line.Name, line.Distance, line.Time);
                StackPanelMain.Children.Add(run);
            }

            text_Sum.Text = String.Format("Total distance: {0}", sum.ToString());

        }

        public void refreshShoesPanel()
        {
            StackPanelShoes.Children.Clear();

            var st_shoes = context.SP_SelectAllShoesToShoesPanel();
            foreach (SP_SelectAllShoesToShoesPanel_Result line in st_shoes)
            {
                UserControls.Shoes shoes = new UserControls.Shoes(line.Name, (line.DistanceSUM), line.Limit);
                StackPanelShoes.Children.Add(shoes);
            }

            addButtonAddNewShoes();

        }

        private void addButtonAddNewShoes()
        {
            Button button = new Button();
            button.Height = 35;
            button.Width = 140;
            button.Content = "Add new shoes";
            StackPanelShoes.Children.Add(button);
        }

        private void DEBUG_btn_add_fake_act_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            UserControls.SingleRun sr = new UserControls.SingleRun(DateTime.Now, "Fake shoes", rnd.Next(1000, 12000), TimeSpan.FromMinutes(rnd.Next(45, 120)));
            StackPanelMain.Children.Add(sr);
        }

        private void DEBUG_btn_add_fake_act_x5_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0; i < 6; i++)
            {
                Random rnd = new Random();
                UserControls.SingleRun sr = new UserControls.SingleRun(DateTime.Now, "Fake shoes", rnd.Next(1000, 12000), TimeSpan.FromMinutes(rnd.Next(45, 120)));
                StackPanelMain.Children.Add(sr);
            }
        }
    }
}
