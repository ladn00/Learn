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

namespace Learndb.pages
{
    /// <summary>
    /// Логика взаимодействия для Service.xaml
    /// </summary>
    public partial class PageService : Page
    {
        public PageService()
        {
            InitializeComponent();

            dgService.ItemsSource = MainWindow.baza.Service.ToList();
        }

        private void Service_Edit(object sender, RoutedEventArgs e)
        {
            var editButton = sender as Button;
            var selectedService = editButton.DataContext as Service;
            windows.WindowEditService edit = new windows.WindowEditService(selectedService);
            edit.ShowDialog();
        }
    }
}

