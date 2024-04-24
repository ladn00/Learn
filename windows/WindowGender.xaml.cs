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
    /// Логика взаимодействия для WindowGender.xaml
    /// </summary>
    public partial class WindowGender : Window
    {
        private Gender gender;

        public WindowGender(Gender gender)
        {
            InitializeComponent();
            this.gender = gender;
            DataContext = gender;
        }

        private void bt_SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gender.Code == null)
                {
                    MainWindow.baza.Gender.Add(gender);
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
