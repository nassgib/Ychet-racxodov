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
    /// Логика взаимодействия для Racxods.xaml
    /// </summary>
    public partial class Racxods : Page
    {
        ApplicationData.Ychet_pacxodovEntities db;
        public Racxods()
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
                var cellInfo = AllRacxods.SelectedCells[0];
                Racxod enRacxod = cellInfo.Item as Racxod;

                int kod = enRacxod.kod_racxoda;
                var uRow = db.Racxod.Where(w => w.kod_racxoda == kod).FirstOrDefault();
                if (uRow != null)
                {
                    MessageBox.Show("Такой расход уже есть", "Невозможно добавить", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                db.Racxod.Add(enRacxod);
                db.SaveChanges();
                MessageBox.Show("Выполнено", "Успешная операция", MessageBoxButton.OK, MessageBoxImage.Information);
                AllRacxods.ItemsSource = db.Racxod.ToList();
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
                var cellInfo = AllRacxods.SelectedCells[0];
                Racxod enRacxod = cellInfo.Item as Racxod;

                int kod_racxoda = enRacxod.kod_racxoda;
                var uRow = db.Racxod.Where(w => w.kod_racxoda == kod_racxoda).FirstOrDefault();

                db.Racxod.Remove(uRow);
                db.SaveChanges();
                db.Racxod.Add(enRacxod);
                db.SaveChanges();
                MessageBox.Show("Выполнено", "Успешная операция", MessageBoxButton.OK, MessageBoxImage.Information);
                AllRacxods.ItemsSource = db.Racxod.ToList();
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
                    var cellInfo = AllRacxods.SelectedCells[0];
                    Racxod enRacxod = cellInfo.Item as Racxod;

                    db.Racxod.Remove(enRacxod);
                    db.SaveChanges();
                    MessageBox.Show("Выполнено", "Успешная операция", MessageBoxButton.OK, MessageBoxImage.Information);
                    AllRacxods.ItemsSource = db.Racxod.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Что-то пошло не так. Ошибка: " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            AllRacxods.ItemsSource = db.Racxod.ToList();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllRacxods_Loaded(object sender, RoutedEventArgs e)
        {
            db = AppConnect.modelOdb;
            AllRacxods.ItemsSource = db.Racxod.ToList();
        }
    }
}
