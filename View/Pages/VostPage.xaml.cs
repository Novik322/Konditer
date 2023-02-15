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
    /// Логика взаимодействия для VostPage.xaml
    /// </summary>
    public partial class VostPage : Page
    {
        public VostPage()
        {
            InitializeComponent();
        }

        private void EnterVost_Click(object sender, RoutedEventArgs e)
        {
            Enter();
        }

        private void Enter()
        {
            try
            {
                var user = AppConnect.context.Stuff.FirstOrDefault(i => i.email == EmailVostPassTb.Text);
                if (user == null)
                {
                    MessageBox.Show("Данного пользователя не существует! Убедитесь в правильности ввода почты и повторите ввод данных снова!", "Предупреждение",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (user.permission)
                    {
                        case 1:
                            AppFrame.Main.Navigate(new NewPassPage());
                            break;
                        case 2:
                            MessageBox.Show("Данные не обнаружены. Убедитесь в правильности ввода Email!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }
}
