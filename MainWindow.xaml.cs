using Mebel.View.AddItem;
using Mebel.View.EditItem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


namespace Mebel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = "Server=DESKTOP-NFDI8RO;Database=Sklad;Integrated Security=True;";
        private void Восстановить_MouseDown(object sender, RoutedEventArgs e)
        {
            EditPersonal editPersonal = new EditPersonal();
            editPersonal.Show();
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрывает текущее окно
        }

        private void Добавить_Click(object sender, RoutedEventArgs e)

        {
            AddPersonal addPersonal = new AddPersonal();
            addPersonal.Show();
        }


        private void Авторизоваться_Click(object sender, RoutedEventArgs e)
        {
            string name = NamePersonal.Text.Trim();
            string password = PasswordPersonal.Password.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var adapter = new Mebel.SkladDataSetTableAdapters.PersonalTableAdapter();
                var result = adapter.GetData(); // Получаем все данные из таблицы Personals

                // Проверьте, какое имя столбца правильно
                DataRow[] foundRows = result.Select($"[Name] = '{name}'");

                if (foundRows.Length == 0)
                {
                    // Если имя пользователя не найдено
                    MessageBox.Show("Ошибка: Пользователь не существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // Проверяем пароль
                    string storedPassword = foundRows[0]["Password"].ToString(); // Предполагается, что у вас есть колонка Password

                    if (storedPassword != password)
                    {
                        // Если пароль не совпадает
                        MessageBox.Show("Ошибка: Пароль неверен.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        // Если данные совпадают, выводим сообщение о успешной аутентификации
                        MessageBox.Show($"Добро пожаловать, {name}!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        // Очистка полей ввода
                        NamePersonal.Text = string.Empty;
                        PasswordPersonal.Password = string.Empty;

                        MenuWindow menu = new MenuWindow();
                        menu.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
