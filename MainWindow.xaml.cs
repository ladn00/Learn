﻿using System;
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

namespace Learndb
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    

    public partial class MainWindow : Window
    {
       public static LearnEntities baza = new LearnEntities();

       public MainWindow()
        {
            InitializeComponent();

            frame.NavigationService.Navigate(new pages.Menu());
        }

        private void btBack(object sender, RoutedEventArgs e)
        {
            if (frame.CanGoBack) frame.GoBack();
        }
    }
}
