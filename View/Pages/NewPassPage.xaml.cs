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
    /// Логика взаимодействия для NewPassPage.xaml
    /// </summary>
    public partial class NewPassPage : Page
    {
        Stuff stuff = new Stuff();
        public NewPassPage()
        {
            InitializeComponent();
        }

        private void SavePassBtn_Click(object sender, RoutedEventArgs e)
        {
           // var user = AppConnect.context.Stuff.FirstOrDefault(i => i.email == .Text);
            if (NewPassTwoTb.Password != NewPassTb.Text)
            {
                SavePassBtn.IsEnabled = false;
                NewPassTwoTb.Background = Brushes.LightCoral;
                NewPassTwoTb.BorderBrush = Brushes.Red;
            }
            else
            {
                SavePassBtn.IsEnabled = true;
                NewPassTwoTb.Background = Brushes.LightGreen;
                NewPassTwoTb.BorderBrush = Brushes.Green;
            }

            stuff.password = (this.NewPassTb.Text);
            AppConnect.context.Stuff.Add(stuff);
            AppConnect.context.SaveChanges();
            MessageBox.Show("Пароль сменен!");
            AppFrame.Main.Navigate(new AuthPage());
        }
    }
}
