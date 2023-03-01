using Konditer_FigmaProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Konditer_FigmaProject.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Reg()
        {
            if (string.IsNullOrEmpty(emailTb.Text) && string.IsNullOrEmpty(phoneTb.Text) && string.IsNullOrEmpty(PassTb1.Text) && string.IsNullOrEmpty(PassTb2.Password) && string.IsNullOrEmpty(firstTb.Text) && string.IsNullOrEmpty(lastTb.Text))
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else if (string.IsNullOrEmpty(emailTb.Text))
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                if (AppConnect.context.Stuff.Count(x => x.email == emailTb.Text) > 0)
                {
                    MessageBox.Show("Пользователь с таким логином уже зарегистрирован!",
                        "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                try
                {
                    Stuff userObj = new Stuff()
                    {
                        email = emailTb.Text,
                        phone = phoneTb.Text,
                        lastname = lastTb.Text,
                        firstname = firstTb.Text,
                        password = PassTb1.Text,
                        permission = 1
                    };
                    AppConnect.context.Stuff.Add(userObj);
                    AppConnect.context.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно!",
                        "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Регистрация прошла успешно!",
                        "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            Reg();
        }

        private void PassTb2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PassTb2.Password != PassTb1.Text)
            {
                regBtn.IsEnabled = false;
                PassTb2.Background = Brushes.LightCoral;
                PassTb2.BorderBrush = Brushes.Red;
            }
            else
            {
                regBtn.IsEnabled = true;
                PassTb2.Background = Brushes.LightGreen;
                PassTb2.BorderBrush = Brushes.Green;
            }
        }

        private void PhoneTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (phoneTb.Text.Length == 11)
                {
                    long number = long.Parse(phoneTb.Text);
                    phoneTb.Text = string.Format("{0:+#(###)-###-##-##}", number);
                }
                else
                {
                    if (phoneTb.Text.Length == 16)
                    {
                        phoneTb.Text = "";
                    }
                }
            }
            catch
            {

            }
        }

        private void EmailTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (phoneTb.Text.Length == 11)
                {
                    long email = long.Parse(emailTb.Text);
                    emailTb.Text = string.Format(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", email);
                }
                else
                {
                    if (phoneTb.Text.Length == 16)
                    {

                        phoneTb.Text = "";
                    }
                }
            }
            catch
            {

            }
        }
    }
}
