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
using System.IO;

namespace Learndb.windows
{
    /// <summary>
    /// Логика взаимодействия для WindowEditService.xaml
    /// </summary>
    public partial class WindowEditService : Window
    {
        private Service service;

        public WindowEditService(Service service)
        {
            InitializeComponent();
            this.service = service;
            DataContext = service;

            cbImagePath.ItemsSource = null;
            cbImagePath.ItemsSource = MainWindow.baza.Service.ToList();
            
        }

        private void bt_SaveClick(object sender, RoutedEventArgs e)
        {
            if (service.ID == 0)
            {
                MainWindow.baza.Service.Add(service);
            }
            MainWindow.baza.SaveChanges();
            this.Close();
        }

        private void bt_files(object sender, RoutedEventArgs e)
        {
            try
            {
                string filename = "";
                var dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.DefaultExt = ".jpg";
                dialog.Filter = "Images (*.png;*.jpg;*jpeg)|*.png;*.jpg;*jpeg";

                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    filename = dialog.FileName;
                    string fileTitle = System.IO.Path.GetFileName(filename);
                    string path = @"D:\Ну типа\3 курс\уп\Лапухина\Learndb\bin\Debug\Услуги школы\" + fileTitle;
                    if (!File.Exists(path))
                        File.Copy(filename, path, true);
                    
                    service.MainImagePath = path;
                    MainWindow.baza.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
