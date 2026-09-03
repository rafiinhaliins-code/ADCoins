using System.Windows;

namespace ADCoins
{
    public partial class MainWindow : Window
    {
        private bool sidebarAberta = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            sidebarAberta = !sidebarAberta;

            if (sidebarAberta)
            {
                // ABRIR SIDEBAR
                SidebarColumn.Width = new GridLength(220);

                LogoPanel.Visibility = Visibility.Visible;

                DashboardText.Visibility = Visibility.Visible;
                ImbuementsText.Visibility = Visibility.Visible;
                HuntText.Visibility = Visibility.Visible;
                ConfigText.Visibility = Visibility.Visible;

                VersionText.Visibility = Visibility.Visible;

                MenuButton.Content = "☰";
            }
            else
            {
                // FECHAR SIDEBAR
                SidebarColumn.Width = new GridLength(70);

                LogoPanel.Visibility = Visibility.Collapsed;

                DashboardText.Visibility = Visibility.Collapsed;
                ImbuementsText.Visibility = Visibility.Collapsed;
                HuntText.Visibility = Visibility.Collapsed;
                ConfigText.Visibility = Visibility.Collapsed;

                VersionText.Visibility = Visibility.Collapsed;

                MenuButton.Content = "☰";
            }
        }
    }
}