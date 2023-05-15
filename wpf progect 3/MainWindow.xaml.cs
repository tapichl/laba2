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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_progect_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static public bool ExaminationPassword(string str)
        {
            bool have = false;
            bool haveNumber = false;
            bool haveCapitalLetter = false;
            int count = 0;
            char[] c = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (IsLatinLetterOrNumber(c[i]) == true)
                    count++;
                if (c[i] >= 'A' && c[i] <= 'Z')
                    haveCapitalLetter = true;
                if (c[i] >= '0' && c[i] <= '9')
                    haveNumber = true;
            }
            if (haveCapitalLetter && haveNumber && (count == str.Length))
            {
                have = true;
            }
            return have;

        }

        static public bool user_serch(string str, string[] stri)
        {
            bool have = false;
            int k = 0;
            for (int i = 0; i < stri.Length; i++)
            {
                if (stri[i] == str) k++;
            }
            if (k != 0)
            {
                have=true;
            }
            return have;
        }


        static public bool ExaminationLogin(string str)
        {
            bool have = false;
            int count = 0;
            char[] c = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (IsLatinLetterOrNumber(c[i]) == true)
                    count++;
            }
            if (count == str.Length)
                have = true;
            return have;
        }

        private static bool IsLatinLetterOrNumber(char c)
        {
            return (c >= 'a' && c <= 'z') ||
            (c >= 'A' && c <= 'Z') ||
            (c >= '0' && c <= '9');
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string[] file = File.ReadAllLines("user_info.txt");
            string login = loginBox.Text.Trim();
            string password = passwordBox.Password.Trim();
            string password2 = passwordBox_2.Password.Trim();
            string email = EmailBox.Text.Trim().ToLower();
            int proverka = 4;

            if (login.Length < 5 || ExaminationLogin(login) == false)
            {
                loginBox.ToolTip = "Логин не может быть короче 5 символов и должен включать только латинские буквы, цифры и символы!";
                loginBox.Background = Brushes.DarkRed;
            }
            else if (user_serch(login, file) == true)
            {
                loginBox.ToolTip = "Такой логин уже существует!";
                loginBox.Background = Brushes.DarkRed;
            }
            else
            {
                loginBox.ToolTip = "";
                loginBox.Background = Brushes.Transparent;
                proverka = proverka-1;
            }
            if (password.Length < 8 || ExaminationPassword(password) == false) 
            {
                passwordBox.ToolTip = "Длина пароля должнa составлять от 8 до 16 символов. Он должен содержать латинские буквы и иметь хотя бы одну цифру и одну заглавную букву!";
                passwordBox.Background = Brushes.DarkRed;
            }
            else
            {
                passwordBox.ToolTip = "";
                passwordBox.Background = Brushes.Transparent;
                proverka = proverka-1;
            }
            if (password != password2)
            {
                passwordBox_2.ToolTip = "Пороли не совпадают!";
                passwordBox_2.Background = Brushes.DarkRed;
            }
            else
            {
                passwordBox_2.ToolTip = "";
                passwordBox_2.Background = Brushes.Transparent;
                proverka = proverka - 1;
            }
            if (email.Length < 5 || !email.Contains("@") || !email.Contains(".")) 
            {
                EmailBox.ToolTip = "Это поле заполнено не корректно!";
                EmailBox.Background = Brushes.DarkRed;
            }
            else
            {
                EmailBox.ToolTip = "";
                EmailBox.Background = Brushes.Transparent;
                proverka = proverka - 1;
            }
            if (proverka == 0)
            {
                //string[] columsUsers = { "UserName", "Password" };
                //Table user = new Table("Name",columsUsers); 
                StreamWriter sw = new StreamWriter("user_info.txt", true);
                sw.WriteLine(login);
                sw.WriteLine(password);
                sw.Close();
                MessageBox.Show("Вы зарегистрировались!");
                Window1 authWindow = new Window1();
                authWindow.Show();
                Hide();
            }
        }

        private void Button_Auth_Wind_Click(object sender, RoutedEventArgs e)
        {
            Window1 authWindow = new Window1();
            authWindow.Show();
            Hide();
        }
    }
}
