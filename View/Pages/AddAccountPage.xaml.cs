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
    /// Логика взаимодействия для AddAccountPage.xaml
    /// </summary>
    public partial class AddAccountPage : Page
    {
        Account account = new Account();
        public AddAccountPage()
        {
            InitializeComponent();

            IdPrdCmb.SelectedValuePath = "IdProduct";
            IdPrdCmb.DisplayMemberPath = "NameProduct";
            IdPrdCmb.ItemsSource = AppConnect.context.Products.ToList();

            IdPackCmb.SelectedValuePath = "IdPack";
            IdPackCmb.DisplayMemberPath = "NamePack";
            IdPackCmb.ItemsSource = AppConnect.context.ViewPack.ToList();

            IdUnitCmb.SelectedValuePath = "IDUnit";
            IdUnitCmb.DisplayMemberPath = "NameUnit";
            IdUnitCmb.ItemsSource = AppConnect.context.Units.ToList();
        }

        private void AddIzdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CountTb.Text) && (IdPrdCmb.SelectedItem == null))
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else if (IdPrdCmb.SelectedItem == null || (string.IsNullOrEmpty(CountTb.Text)))
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                account.Count = Convert.ToInt32(CountTb.Text);
                account.Products = IdPrdCmb.SelectedItem as Products;
                account.ViewPack = IdPackCmb.SelectedItem as ViewPack;
                account.Units = IdUnitCmb.SelectedItem as Units;
                account.Weight = WeightTb.Text.ToString();
                account.Price = Convert.ToInt32(PriceTb.Text);
                account.DateManufact = DateManDp.SelectedDate.Value;
                account.DateReal = DateRealDp.SelectedDate.Value;
                account.DateOtgruz = DateOtgruzDp.SelectedDate.Value;
                account.IdOptSalers = 1;

                AppConnect.context.Account.Add(account);
                AppConnect.context.SaveChanges();
                IdPrdCmb.SelectedIndex = -1;
                IdPackCmb.SelectedIndex = -1;

                MessageBox.Show("Данные успешно добавлены в базу данных!", "Уведомление",
                       MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.Main.Navigate(new WelcomePage());
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppFrame.Main.Navigate(new WelcomePage());
        }
    }
}
