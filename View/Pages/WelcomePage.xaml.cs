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
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        AuthPage authPage = new AuthPage();
        public WelcomePage()
        {
            InitializeComponent();
            TableGrid.ItemsSource = AppConnect.context.Account.ToList();
        }

        private void AddIzdBtn_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Main.Navigate(new AddAccountPage());
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppFrame.Main.Navigate(new WelcomePage());
        }
    }
}
