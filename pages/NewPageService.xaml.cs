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
    /// Логика взаимодействия для NewPageService.xaml
    /// </summary>
    public partial class NewPageService : Page
    {
        public NewPageService()
        {
            InitializeComponent();

            ListService.ItemsSource = MainWindow.baza.Service.ToList();
        }

        private void Service_Edit(object sender, RoutedEventArgs e)
        {
            var editButton = sender as Button;
            var selectedService = editButton.DataContext as Service;
            windows.WindowEditService edit = new windows.WindowEditService(selectedService);
            edit.ShowDialog();
        }

        private void bt_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                var deletedService = ListService.SelectedItem as Service;

                if (deletedService != null)
                {
                    MessageBoxResult result = MessageBox.Show(
                        "Вы точно хотите удалить запись?",
                        "Внимание!",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Error);

                    if (result == MessageBoxResult.Yes)
                    {
                        MainWindow.baza.Service.Remove(deletedService);
                        MainWindow.baza.SaveChanges();
                        MessageBox.Show("Запись удалена!");
                        ListService.ItemsSource = null;
                        ListService.ItemsSource = MainWindow.baza.Service.ToList();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void bt_Add(object sender, RoutedEventArgs e)
        {
            Service service = new Service();
            service.ID = 0;
            windows.WindowEditService edit = new windows.WindowEditService(service);
            edit.ShowDialog();
            ListService.ItemsSource = null;
            ListService.ItemsSource = MainWindow.baza.Service.ToList();
        }
    }
}
