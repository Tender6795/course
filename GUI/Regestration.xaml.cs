using ClassLibrary.DataModel;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для Regestration.xaml
    /// </summary>
    public partial class Regestration : Window
    {
        public User user = new User();
        Uri iconUriStart = new Uri("pack://application:,,,/Images/Start.ico", UriKind.RelativeOrAbsolute);
        Uri iconUriStop = new Uri("pack://application:,,,/Images/Stop.ico", UriKind.RelativeOrAbsolute);
        CancellationTokenSource _cancelTokenSource;
        CancellationToken _token;
        public Regestration()
        {
            InitializeComponent();
            _cancelTokenSource = new CancellationTokenSource();
            _token = _cancelTokenSource.Token;
            // Closed += (s, e) => _cancelTokenSource.Cancel();
            Task.Factory.StartNew(() =>
            {
                IsServiceAlive();
            }, _token);
        }
        private void IsServiceAlive()
        {
            while (true)
            {
                if (_token.IsCancellationRequested)
                {
                    Environment.Exit(1);
                }

                try
                {
                    MetadataExchangeClient mexClient = new MetadataExchangeClient(new Uri("http://localhost/ComponentsReturn"), MetadataExchangeClientMode.HttpGet);
                    MetadataSet metadata = mexClient.GetMetadata();
                    this.Set(() => this.Icon = BitmapFrame.Create(iconUriStart));
                    ButOk.Set(() => ButOk.IsEnabled = true);
                    ButOk.Set(() => ButRegistr.IsEnabled = true);

                }
                catch (Exception ex)
                {
                    ButOk.Set(() => ButOk.IsEnabled = false);
                    ButOk.Set(() => ButRegistr.IsEnabled = false);
                    this.Set(() => this.Icon = BitmapFrame.Create(iconUriStop));
                }
            }
        }
        private void CbShow_Checked(object sender, RoutedEventArgs e)
        {
            if (CbShow.IsChecked == true)
            {
                PbPassword.Visibility = Visibility.Hidden;
                TbPassword.Visibility = Visibility.Visible;
                TbPassword.Text = PbPassword.Password;
            }
            else
            {
                PbPassword.Visibility = Visibility.Visible;
                TbPassword.Visibility = Visibility.Hidden;
                PbPassword.Password = TbPassword.Text;
            }
        }



        private void PbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PbPassword.Password != TbPassword.Text)
            {
                TbPassword.Text = PbPassword.Password;
            }
        }

        private void TbPassword_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (PbPassword.Password != TbPassword.Text)
            {
                PbPassword.Password = TbPassword.Text;
            }
        }

        private async void ButOk_Click(object sender, RoutedEventArgs e)
        {
          //  ButOk.Set(() => ButOk.IsEnabled = false);
            try
            {

                if (!string.IsNullOrWhiteSpace(TbLogin.Text.Trim()) &&
                    (!string.IsNullOrWhiteSpace(PbPassword.Password.Trim())) ||
                    (!string.IsNullOrWhiteSpace(TbPassword.Text.Trim())))
                {
                    var client = new ServiceReference1.CompontsReturnClient("BasicHttpBinding_ICompontsReturn");
                   // bool res = await client.Is_successful_registrationAsync(TbLogin.Text, TbPassword.Text.Trim());
                    //if (!res)
                    //{
                    //    ButOk.Set(() => ButOk.IsEnabled = true);
                    //    MessageBox.Show("Ошибка логин/пароль");
                    //}
                    //else
                    //{

                        user = await client.ReturnUserAsync(TbLogin.Text.Trim(), TbPassword.Text.Trim());
                        if(user==null)
                        {
                            MessageBox.Show("Неправильный пароль/логин");
                        }

                        else
                        {
                            MainWindow mainWindow = new MainWindow(user);

                            mainWindow.Show();
                            this.Close();
                        }
                        
                    //}
                }
                else
                {
                    ButOk.Set(() => ButOk.IsEnabled = true);
                    MessageBox.Show("Не все поля заполнены");

                }
                //var client = new ServiceReference1.CompontsReturnClient("BasicHttpBinding_ICompontsReturn");
                //List<User> users = new List<User>();
                //users = await client.ReturnAllUserAsync();
                //foreach(var u in users)
                //{
                //    MessageBox.Show(u.Name + " " + u.Password + " " + u.StarShipId);
                //}
            }
            catch (Exception ex)
            {
                ButOk.Set(() => ButOk.IsEnabled = true);
                MessageBox.Show(ex.Message);
            }
        }
        List<User> Users = new List<User>();
        private async void ButRegistr_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (!string.IsNullOrWhiteSpace(TbLogin.Text.Trim()) &&
                    (!string.IsNullOrWhiteSpace(PbPassword.Password.Trim())) ||
                    (!string.IsNullOrWhiteSpace(TbPassword.Text.Trim())))
                {
                    var client = new ServiceReference1.CompontsReturnClient("BasicHttpBinding_ICompontsReturn");
                    bool flag = await client.UserRegestrationAsync(TbLogin.Text.Trim(), PbPassword.Password.Trim());
                   
                    if (!flag == true)
                    {
                        user =await client.ReturnUserAsync(TbLogin.Text.Trim(), PbPassword.Password.Trim());
                        MessageBox.Show("Регистрация успешна");

                        MainWindow mainWindow = new MainWindow(user);

                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Такой пользователь уже есть");
                    }

                }
                else
                {
                    MessageBox.Show("Не все поля заполнены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
