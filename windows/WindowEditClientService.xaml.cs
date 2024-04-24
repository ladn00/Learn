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

namespace Learndb.windows
{
    /// <summary>
    /// Логика взаимодействия для WindowEditClientService.xaml
    /// </summary>
    public partial class WindowEditClientService : Window
    {
        private ClientService clientService;
        public WindowEditClientService(ClientService clientService)
        {
            InitializeComponent();
            this.clientService = clientService;
            DataContext = clientService;
            cb_Clients.ItemsSource = MainWindow.baza.Client.ToList();
            cb_Services.ItemsSource = MainWindow.baza.Service.ToList();
        }

        private void bt_SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clientService.ID == 0)
                {
                    MainWindow.baza.ClientService.Add(clientService);
                }
                MainWindow.baza.SaveChanges();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
