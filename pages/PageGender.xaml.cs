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
    /// Логика взаимодействия для PageGender.xaml
    /// </summary>
    public partial class PageGender : Page
    {
        public PageGender()
        {
            InitializeComponent();

            dgGender.ItemsSource = MainWindow.baza.Gender.ToList();
        }

        private void bt_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                var deletedGender = dgGender.SelectedItem as Gender;

                if (deletedGender != null)
                {
                    MessageBoxResult result = MessageBox.Show(
                        "Вы точно хотите удалить запись?",
                        "Внимание!",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Error);

                    if (result == MessageBoxResult.Yes)
                    {
                        MainWindow.baza.Gender.Remove(deletedGender);
                        MainWindow.baza.SaveChanges();
                        MessageBox.Show("Запись удалена!");
                        dgGender.ItemsSource = null;
                        dgGender.ItemsSource = MainWindow.baza.Gender.ToList();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_Edit(object sender, RoutedEventArgs e)
        {
            var editButton = sender as Button;
            var selectedGender = editButton.DataContext as Gender;
            windows.WindowGender edit = new windows.WindowGender(selectedGender);
            edit.ShowDialog();
        }

    }
}
