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
    /// Логика взаимодействия для ClientServicePage.xaml
    /// </summary>
    public partial class ClientServicePage : Page
    {
        public ClientServicePage()
        {
            InitializeComponent();

            dgClientService.ItemsSource = MainWindow.baza.ClientService.ToList();
        }

        private void bt_Edit(object sender, RoutedEventArgs e)
        {
            var editButton = sender as Button;
            var selectedClientService = editButton.DataContext as ClientService;
            windows.WindowEditClientService edit = new windows.WindowEditClientService(selectedClientService);
            edit.ShowDialog();
        }

        private void bt_Add(object sender, RoutedEventArgs e)
        {
            ClientService clientService = new ClientService();
            clientService.ID = 0;
            windows.WindowEditClientService edit = new windows.WindowEditClientService(clientService);
            edit.ShowDialog();
            dgClientService.ItemsSource = null;
            dgClientService.ItemsSource = MainWindow.baza.Client.ToList();
        }

        private void bt_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                var deletedClientService = dgClientService.SelectedItem as ClientService;

                if (deletedClientService != null)
                {
                    MessageBoxResult result = MessageBox.Show(
                        "Вы точно хотите удалить запись?",
                        "Внимание!",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Error);

                    if (result == MessageBoxResult.Yes)
                    {
                        MainWindow.baza.ClientService.Remove(deletedClientService);
                        MainWindow.baza.SaveChanges();
                        MessageBox.Show("Запись удалена!");
                        dgClientService.ItemsSource = null;
                        dgClientService.ItemsSource = MainWindow.baza.ClientService.ToList();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
