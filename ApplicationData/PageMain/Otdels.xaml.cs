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
    /// Логика взаимодействия для Otdels.xaml
    /// </summary>
    public partial class Otdels : Page
    {
        ApplicationData.Ychet_pacxodovEntities db;
        public Otdels()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e) // Обработчик события нажатия на кнопку "Меню" - переходит к главному меню
        {
           ApplicationData.AppFrame.frameMain.Navigate(new AdminMenu());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) // Обработчик события нажатия на кнопку "Добавить" - добавляет новый отдел
        {
            try
            {
                var cellInfo = AllOtdel.SelectedCells[0];
                Otdel enOtdel = cellInfo.Item as Otdel;

                int kod = enOtdel.kod_otdela;
                var uRow = db.Otdel.Where(w => w.kod_otdela == kod).FirstOrDefault();
                if (uRow != null)
                {
                    MessageBox.Show("Такой отдел уже есть", "Невозможно добавить", MessageBoxButton.OK, MessageBoxImage.Warning); // Если отдел уже есть, выводим предупреждение
                    return;
                }
                db.Otdel.Add(enOtdel);
                db.SaveChanges();
                MessageBox.Show("Выполнено", "Успешная операция", MessageBoxButton.OK, MessageBoxImage.Information); // Если отдел уже есть, выводим предупреждение
                AllOtdel.ItemsSource = db.Otdel.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так. Ошибка: " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); // Обработка ошибок
            }

            }

        private void btnTransf_Click(object sender, RoutedEventArgs e) // Обработчик события нажатия на кнопку "Изменить" - редактирует выбранный отдел
        {
            try
            {
                var cellInfo = AllOtdel.SelectedCells[0];
                Otdel enOtdel = cellInfo.Item as Otdel;

                int kod_otdela = enOtdel.kod_otdela;
                var uRow = db.Otdel.Where(w => w.kod_otdela == kod_otdela).FirstOrDefault();

                db.Otdel.Remove(uRow);
                db.SaveChanges();
                db.Otdel.Add(enOtdel);
                db.SaveChanges();
                MessageBox.Show("Выполнено", "Успешная операция", MessageBoxButton.OK, MessageBoxImage.Information);
                AllOtdel.ItemsSource = db.Otdel.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так. Ошибка: " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
                
        }

        private void btnDel_Click(object sender, RoutedEventArgs e) // Обработчик события нажатия на кнопку "Удалить" - удаляет выбранный отдел
        {
            if (MessageBox.Show("Вы подтверждаете удаление?", "Удаление строки", MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK) // Подтверждение удаления
                try
                {
                    var cellInfo = AllOtdel.SelectedCells[0];
                    Otdel enOtdel = cellInfo.Item as Otdel;

                    // Удаление выбранного отдела из базы данных
                    db.Otdel.Remove(enOtdel);
                    db.SaveChanges();
                    MessageBox.Show("Выполнено", "Успешная операция", MessageBoxButton.OK, MessageBoxImage.Information); // Уведомление об успешном удалении
                    AllOtdel.ItemsSource = db.Otdel.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Что-то пошло не так. Ошибка: " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); // Обработка ошибок
                }

            AllOtdel.ItemsSource = db.Otdel.ToList();  // Обновление таблицы после удаления
        }

        private void btnFind_Click(object sender, RoutedEventArgs e) 
        {

        }

        private void AllOtdel_Loaded(object sender, RoutedEventArgs e)
        {
            db = AppConnect.modelOdb;
            AllOtdel.ItemsSource = db.Otdel.ToList();
        }
    }
}
