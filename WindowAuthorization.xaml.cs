using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_18
{
    /// <summary>
    /// Логика взаимодействия для WindowAuthorization.xaml
    /// </summary>
    public partial class WindowAuthorization : Window
    {
        public WindowAuthorization()
        {
            InitializeComponent();
        }

        DispatcherTimer _timer;

        int _countLogin = 1;
        bd18Entities _db = bd18Entities.GetContext();

        void GetCaptcha()
        {
            string masChar = "QWERTYUIOPLKJHGFDSAZXCVBNMmnbcxzasdfghjk" + "lpoiuytrewq1234567890";
            string captcha = "";
            Random rnd = new Random();
            for (int i = 1; i < 6; i++)
            {
                captcha = captcha + masChar[rnd.Next(0, masChar.Length)];
            }
            grid.Visibility = Visibility.Visible;
            txtCaprcha.Text = captcha;
            tbCaptcha.Text = null;
            txtCaprcha.LayoutTransform = new RotateTransform(rnd.Next(-15, 15));
            line.X1 = 10;
            line.Y1 = rnd.Next(10, 40);
            line.X2 = 280;
            line.Y2 = rnd.Next(10, 40);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            tbLogin.Focus();
            Data.Login = false;
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 10);
            _timer.Tick += new EventHandler(Timer_Tick);

            GetCaptcha();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            grid.IsEnabled = true;
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            var user = from p in _db.Authorizations
                     where p.UserLogin == tbLogin.Text &&
                     p.UserPassword == tbPas.Password
                     select p;

            if (user.Count() == 1 && txtCaprcha.Text == tbCaptcha.Text)
            {
                Data.Login = true;
                Data.Familia = user.First().USerSurname;
                Data.Name = user.First().UserName;
                Data.Otchestvo = user.First().UserPatronymic;
                Data.Right = user.First().Role.RoleName;

                if (tbLogin.Text == "admin")
                {
                    Data.IsAdmin = true;
                }

                Close();
            }
            else
            {
                if (user.Count() == 1)
                {
                    MessageBox.Show("Капча неверна! Повторите ввод!");
                }
                else
                {
                    MessageBox.Show("Логин, пароль неверны! Повторите ввод");
                }
                GetCaptcha();

                if (_countLogin >= 2)
                {
                    grid.IsEnabled = false;
                    _timer.Start();
                }
                _countLogin++;
                tbLogin.Focus();
            }
        }

        private void BtnEsc_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnGuest_Click(object sender, RoutedEventArgs e)
        {
            Data.Login = true;
            Data.Familia = "Гость";
            Data.Name = "";
            Data.Otchestvo = "";
            Data.Right = "Клиент";
            Data.IsAdmin= false;
            Close();
        }
    }
}