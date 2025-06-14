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
using Ychet_racxodov.ApplicationData;

namespace Ychet_racxodov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class RacxodMain : Window
    {
        public RacxodMain()
        {
            InitializeComponent();
            ApplicationData.AppConnect.modelOdb = new Ychet_pacxodovEntities();
            ApplicationData.AppFrame.frameMain = framePage;
            framePage.Navigate(new ApplicationData.PageMain.PageLogin());
        }

      
    }
}
