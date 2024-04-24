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
    /// Логика взаимодействия для PageClient.xaml
    /// </summary>
    public partial class PageClient : Page
    {
        public PageClient()
        {
            InitializeComponent();

            dgClient.ItemsSource = MainWindow.baza.Client.ToList();
        }

        private void bt_Edit(object sender, RoutedEventArgs e)
        {
            var editButton = sender as Button;
            var selectedClient = editButton.DataContext as Client;
            windows.WindowEditClient edit = new windows.WindowEditClient(selectedClient);
            edit.ShowDialog();
        }

        private void bt_Add(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            client.ID = 0;
            windows.WindowEditClient edit = new windows.WindowEditClient(client);
            edit.ShowDialog();
            dgClient.ItemsSource = null;
            dgClient.ItemsSource = MainWindow.baza.Client.ToList();
        }

        private void bt_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                var deletedClient = dgClient.SelectedItem as Client;

                if (deletedClient != null)
                {
                    MessageBoxResult result = MessageBox.Show(
                        "Вы точно хотите удалить запись?",
                        "Внимание!",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Error);

                    if (result == MessageBoxResult.Yes)
                    {
                        MainWindow.baza.Client.Remove(deletedClient);
                        MainWindow.baza.SaveChanges();
                        MessageBox.Show("Запись удалена!");
                        dgClient.ItemsSource = null;
                        dgClient.ItemsSource = MainWindow.baza.Client.ToList();

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
