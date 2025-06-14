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
    /// Логика взаимодействия для VidRacxodov.xaml
    /// </summary>
    public partial class VidRacxodov : Page
    {
        ApplicationData.Ychet_pacxodovEntities db;
        public VidRacxodov()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            ApplicationData.AppFrame.frameMain.Navigate(new AdminMenu());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cellInfo = AllVidracxodov.SelectedCells[0];
                Vid_racxodov enVid_racxodov = cellInfo.Item as Vid_racxodov;

                int kod = enVid_racxodov.kod_vida;
                var uRow = db.Vid_racxodov.Where(w => w.kod_vida == kod).FirstOrDefault();
                if (uRow != null)
                {
                    MessageBox.Show("Такой вид расхода уже есть", "Невозможно добавить", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                db.Vid_racxodov.Add(enVid_racxodov);
                db.SaveChanges();
                MessageBox.Show("Выполнено", "Успешная операция", MessageBoxButton.OK, MessageBoxImage.Information);
                AllVidracxodov.ItemsSource = db.Vid_racxodov.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так. Ошибка: " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnTransf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cellInfo = AllVidracxodov.SelectedCells[0];
                Vid_racxodov enVid_racxodov = cellInfo.Item as Vid_racxodov;

                int kod_vida = enVid_racxodov.kod_vida;
                var uRow = db.Vid_racxodov.Where(w => w.kod_vida == kod_vida).FirstOrDefault();

                db.Vid_racxodov.Remove(uRow);
                db.SaveChanges();
                db.Vid_racxodov.Add(enVid_racxodov);
                db.SaveChanges();
                MessageBox.Show("Выполнено", "Успешная операция", MessageBoxButton.OK, MessageBoxImage.Information);
                AllVidracxodov.ItemsSource = db.Vid_racxodov.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так. Ошибка: " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы подтверждаете удаление?", "Удаление строки", MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK)
                try
                {
                    var cellInfo = AllVidracxodov.SelectedCells[0];
                    Vid_racxodov enVid_racxodov = cellInfo.Item as Vid_racxodov;

                    db.Vid_racxodov.Remove(enVid_racxodov);
                    db.SaveChanges();
                    MessageBox.Show("Выполнено", "Успешная операция", MessageBoxButton.OK, MessageBoxImage.Information);
                    AllVidracxodov.ItemsSource = db.Vid_racxodov.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Что-то пошло не так. Ошибка: " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            AllVidracxodov.ItemsSource = db.Vid_racxodov.ToList();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbFind.Text == "")
                {
                    AllVidracxodov.ItemsSource = db.Vid_racxodov.ToList();
                    return;
                }

                var cellInfo = AllVidracxodov.SelectedCells[0];
                string namecol = cellInfo.Column.Header.ToString();
                VidRacxodov enVid_racxodov = cellInfo.Item as VidRacxodov;
                
                switch (namecol)
                {
                    case "Код вида":
                        int vid = Convert.ToInt32(tbFind.Text);
                        var uRow1 = db.Vid_racxodov.Where(w => w.kod_vida == vid).ToList();
                        AllVidracxodov.ItemsSource = uRow1;
                        break;
                    case "Название":
                        string nam = tbFind.Text;
                        var uRow2 = db.Vid_racxodov.Where(w => w.name == nam).ToList();
                        AllVidracxodov.ItemsSource = uRow2;
                        break;
                    case "Описание":
                        string opic = tbFind.Text;
                        var uRow3 = db.Vid_racxodov.Where(w => w.opicanie == opic).ToList();
                        AllVidracxodov.ItemsSource = uRow3;
                        break;
                    case "Предельная норма":
                        double prnor = Convert.ToDouble(tbFind.Text);
                        var uRow4 = db.Vid_racxodov.Where(w => w.predel_norma == prnor).ToList();
                        AllVidracxodov.ItemsSource = uRow4;
                        break;
                    default:
                        MessageBox.Show("По этому полю поиск невозможен или ошибка поиска");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так. Ошибка: " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AllVidracxodov_Loaded(object sender, RoutedEventArgs e)
        {
            db = AppConnect.modelOdb;
            AllVidracxodov.ItemsSource = db.Vid_racxodov.ToList();
        }
    }
}
