using System;
using System.Collections.Generic;
using System.IO;
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

namespace wpf_progect_3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string[] user = File.ReadAllLines("user_info.txt");
            string login = loginBox2.Text.Trim();
            string password = passwordBox2.Password.Trim();
            int k = 0;
            for (int i = 0; i < user.Length-1; i=i+2) 
            {
                if (user[i] == login && user[i + 1] == password)
                {
                    k++;
                }
            }
            if (k == 0)
            {
                MessageBox.Show("Данные не корректны!");
            }
            else
            {
                UserCorner UserWindow = new UserCorner();
                UserWindow.Show();
                Hide();

            }
        }

        private void Button_Reg_Wind_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
