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

namespace Ychet_racxodov.ApplicationData.PageMain
{
    /// <summary>
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Page
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void btnOtd_Click(object sender, RoutedEventArgs e)
        {
           AppFrame.frameMain.Navigate(new Otdels());
        }

        private void btnRacx_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Racxods());
        }

        private void btnVid_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new VidRacxodov());
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Users());
        }

        private void btnRol_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Rols());
        }
    }
}
