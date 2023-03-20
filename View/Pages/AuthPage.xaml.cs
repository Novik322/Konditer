using Konditer_FigmaProject.AppData;
using Konditer_FigmaProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Konditer_FigmaProject.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();

        }
        private void Enter()
        {
            try
            {
                var user = AppConnect.context.Stuff.FirstOrDefault(i => i.email == emailTb.Text && i.password == passPb.Password);
                if (user == null)
                {
                    PloxPassTbl.Text = "Данные введены некорректно";
                    passPb.BorderBrush = Brushes.Red;
                    emailTb.BorderBrush = Brushes.Red;
                }
                else
                {
                    switch (user.permission)
                    {
                        case 1:
                            MessageBox.Show(
                                "Вы успешно вошли в систему!",
                                "Добро пожаловать",
                                MessageBoxButton.OK,
                                MessageBoxImage.Asterisk,
                                MessageBoxResult.OK,
                                MessageBoxOptions.DefaultDesktopOnly);
                            AppFrame.Main.Navigate(new WelcomePage());
                            break;
                        case 2:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая работа приложения!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            Enter();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Main.Navigate(new RegistrationPage());
        }
    }
}
