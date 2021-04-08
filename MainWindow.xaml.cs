using System;
using System.Windows;


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
        }
    }
}
