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
    /// Логика взаимодействия для Rols.xaml
    /// </summary>
    public partial class Rols : Page
    {
        ApplicationData.Ychet_pacxodovEntities db;
        public Rols()
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
                var cellInfo = AllRols.SelectedCells[0];
                Role enRole = cellInfo.Item as Role;

                int kod = enRole.id;
                var uRow = db.Role.Where(w => w.id == kod).FirstOrDefault();
                if (uRow != null)
                {
                    MessageBox.Show("Такой расход уже есть", "Невозможно добавить", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                db.Role.Add(enRole);
                db.SaveChanges();
                MessageBox.Show("Выполнено", "Успешная операция", MessageBoxButton.OK, MessageBoxImage.Information);
                AllRols.ItemsSource = db.Role.ToList();
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
                var cellInfo = AllRols.SelectedCells[0];
                Role enRole = cellInfo.Item as Role;

                int id = enRole.id;
                var uRow = db.Role.Where(w => w.id == id).FirstOrDefault();

                db.Role.Remove(uRow);
                db.SaveChanges();
                db.Role.Add(enRole);
                db.SaveChanges();
                MessageBox.Show("Выполнено", "Успешная операция", MessageBoxButton.OK, MessageBoxImage.Information);
                AllRols.ItemsSource = db.Role.ToList();
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
                    var cellInfo = AllRols.SelectedCells[0];
                    Role enRole = cellInfo.Item as Role;

                    db.Role.Remove(enRole);
                    db.SaveChanges();
                    MessageBox.Show("Выполнено", "Успешная операция", MessageBoxButton.OK, MessageBoxImage.Information);
                    AllRols.ItemsSource = db.Role.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Что-то пошло не так. Ошибка: " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            AllRols.ItemsSource = db.Role.ToList();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllRols_Loaded(object sender, RoutedEventArgs e)
        {
            db = AppConnect.modelOdb;
            AllRols.ItemsSource = db.Role.ToList();
        }
    }
}
