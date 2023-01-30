using Konditer_FigmaProject.AppData;
using Konditer_FigmaProject.Model;
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
                    MessageBox.Show("Данного пользователя не существует!", "Ошибка при авторизации!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (user.permission)
                    {
                        case 1:
                            AppFrame.Main.Navigate(new WelcomePage());
                            break;
                        case 2:
                            AppFrame.Main.Navigate(new WelcomePage());
                            break;
                        case 3:
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
