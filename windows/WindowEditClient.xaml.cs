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
    /// Логика взаимодействия для WindowEditClient.xaml
    /// </summary>
    public partial class WindowEditClient : Window
    {
        private Client client;

        public WindowEditClient(Client client)
        {
            InitializeComponent();
            this.client = client;
            DataContext = client;
            cbGender.ItemsSource = MainWindow.baza.Gender.ToList();
        }

        private void bt_SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (client.ID == 0)
                {
                    MainWindow.baza.Client.Add(client);
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
