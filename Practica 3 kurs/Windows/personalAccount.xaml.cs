﻿using Microsoft.Data.SqlClient;
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

namespace Practica_3_kurs.Windows
{
    /// <summary>
    /// Логика взаимодействия для personalAccount.xaml
    /// </summary>
    public partial class personalAccount : Window
    {
        public personalAccount()
        {
            InitializeComponent();

        }

        public personalAccount (string log)
        {
            InitializeComponent();
            WelcomeLabel.Content = "Здравствуйте, " + log;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();  

        }
    }
}
