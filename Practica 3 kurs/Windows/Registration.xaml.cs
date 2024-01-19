using Practica;
using pr.Class;
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
using System.Windows.Shapes;
using Practica_3_kurs;

namespace Practica
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void reg_Click_1(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;
            var email = emailTextBox.Text;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exists != null)
            {
                errorTextBlock.Text = "Такой пользователь уже существует!";

                // Подсветка контура TextBox красным цветом
                loginTextBox.BorderBrush = Brushes.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            {
                errorTextBlock.Text = "Не все поля заполнены";

                // Подсветка контура TextBox красным цветом
                if (string.IsNullOrWhiteSpace(login))
                    loginTextBox.BorderBrush = Brushes.Red;
                if (string.IsNullOrWhiteSpace(password))
                    passwordTextBox.BorderBrush = Brushes.Red;
                if (string.IsNullOrWhiteSpace(email))
                    emailTextBox.BorderBrush = Brushes.Red;

                return;
            }
            else if (!password.Contains('+') && !password.Contains('$') && !password.Contains('-') && !password.Contains('#'))
            {
                errorTextBlock.Text = "Введите специальные символы";

                // Подсветка контура TextBox красным цветом
                passwordTextBox.BorderBrush = Brushes.Red;

                return;
            }
            else if (password.Length < 8)
            {
                errorTextBlock.Text = "Пароль должен содержать не менее 8 символов";

                // Подсветка контура TextBox красным цветом
                passwordTextBox.BorderBrush = Brushes.Red;

                return;
            }
            else if (password != passwordTextBoxAgain.Text)
            {
                errorTextBlock.Text = "Пароли не совпадают";

                // Подсветка контура TextBox красным цветом
                passwordTextBox.BorderBrush = Brushes.Red;
                passwordTextBoxAgain.BorderBrush = Brushes.Red;

                return;
            }

            if (!email.EndsWith(".com") && !email.EndsWith(".ru"))
            {
                errorTextBlock.Text = "Email введен некорректно";

                // Подсветка контура TextBox красным цветом
                emailTextBox.BorderBrush = Brushes.Red;

                return;
            }

            var user = new User { Login = login, Password = password, Email = email };

            context.Users.Add(user);
            context.SaveChanges();

            successTextBlock.Text = "Вы успешно зарегистрировались :)";

            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void backLogIn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
        private void ShowError(Control control, string message)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.Content = message;
            control.ToolTip = toolTip;

            control.ClearValue(ToolTipService.ShowOnDisabledProperty);
            control.BorderBrush = Brushes.Red;
            control.BorderThickness = new Thickness(2);
        }
    }
}