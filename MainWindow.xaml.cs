using System.Windows;

namespace ADCoins
{
    public partial class MainWindow : Window
    {
        private bool sidebarAberta = true;

        public MainWindow()
        {
            InitializeComponent();

            // Abre o Dashboard ao iniciar
            MainFrame.Navigate(new Pages.DashboardPage());
        }


        // =========================================
        // BOTÃO DO MENU
        // =========================================

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            sidebarAberta = !sidebarAberta;

            if (sidebarAberta)
            {
                SidebarColumn.Width =
                    new GridLength(220);

                LogoPanel.Visibility =
                    Visibility.Visible;

                DashboardText.Visibility =
                    Visibility.Visible;

                ImbuementsText.Visibility =
                    Visibility.Visible;

                HuntText.Visibility =
                    Visibility.Visible;

                ConfigText.Visibility =
                    Visibility.Visible;

                VersionText.Visibility =
                    Visibility.Visible;

                DashboardButton.HorizontalContentAlignment =
                    HorizontalAlignment.Left;

                ImbuementsButton.HorizontalContentAlignment =
                    HorizontalAlignment.Left;

                HuntButton.HorizontalContentAlignment =
                    HorizontalAlignment.Left;

                ConfigButton.HorizontalContentAlignment =
                    HorizontalAlignment.Left;

                DashboardButton.Padding =
                    new Thickness(15, 0, 0, 0);

                ImbuementsButton.Padding =
                    new Thickness(15, 0, 0, 0);

                HuntButton.Padding =
                    new Thickness(15, 0, 0, 0);

                ConfigButton.Padding =
                    new Thickness(15, 0, 0, 0);
            }
            else
            {
                SidebarColumn.Width =
                    new GridLength(70);

                LogoPanel.Visibility =
                    Visibility.Collapsed;

                DashboardText.Visibility =
                    Visibility.Collapsed;

                ImbuementsText.Visibility =
                    Visibility.Collapsed;

                HuntText.Visibility =
                    Visibility.Collapsed;

                ConfigText.Visibility =
                    Visibility.Collapsed;

                VersionText.Visibility =
                    Visibility.Collapsed;

                DashboardButton.HorizontalContentAlignment =
                    HorizontalAlignment.Center;

                ImbuementsButton.HorizontalContentAlignment =
                    HorizontalAlignment.Center;

                HuntButton.HorizontalContentAlignment =
                    HorizontalAlignment.Center;

                ConfigButton.HorizontalContentAlignment =
                    HorizontalAlignment.Center;

                DashboardButton.Padding =
                    new Thickness(0);

                ImbuementsButton.Padding =
                    new Thickness(0);

                HuntButton.Padding =
                    new Thickness(0);

                ConfigButton.Padding =
                    new Thickness(0);
            }
        }


        // =========================================
        // DASHBOARD
        // =========================================

        private void DashboardButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            MainFrame.Navigate(
                new Pages.DashboardPage());
        }


        // =========================================
        // IMBUEMENTS
        // =========================================

        private void ImbuementsButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            MainFrame.Navigate(
                new Pages.ImbuementsPage());
        }


        // =========================================
        // HUNT ANALYZER
        // =========================================

        private void HuntButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            // Página será criada posteriormente.
        }


        // =========================================
        // CONFIGURAÇÕES
        // =========================================

        private void ConfigButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            // Página será criada posteriormente.
        }
    }
}