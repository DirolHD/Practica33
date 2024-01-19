using Practica;
using System;
using pr.Class;
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
using Practica_3_kurs.Windows;

namespace Practica_3_kurs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static void UpdateUser()
        {
            var userId = 1;

            var context = new AppDbContext();

            var update_user = new User { Id = userId, Login = "admin", Password = "admin" };

            context.Users.Update(update_user);
            context.SaveChanges();
        }
 

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            Registration main = new Registration();

            main.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            string password = passwordBox.Password;

            var context = new AppDbContext();
            var user_exists = context.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (user_exists is null)
            {
                errorTextBlock.Text = "Логин или пароль введены неверно!";
                errorTextBlock.Visibility = Visibility.Visible;

                // Подсветка контура TextBox красным цветом
                loginTextBox.BorderBrush = Brushes.Red;
                passwordBox.BorderBrush = Brushes.Red;

                return;
            }

            string log = loginTextBox.Text;
            new personalAccount(log).ShowDialog();
            MessageBox.Show("Вы успешно вошли в аккаунт!");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
        private bool isPasswordVisible = false;

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Visibility == Visibility.Visible)
            {
                passwordBox.Visibility = Visibility.Hidden;
                passsss.Text = passwordBox.Password;
                passsss.Visibility = Visibility.Visible;
            }
            else
            {
                passsss.Visibility = Visibility.Hidden;
                passwordBox.Visibility = Visibility.Visible;
            }
        }
    }
}
 