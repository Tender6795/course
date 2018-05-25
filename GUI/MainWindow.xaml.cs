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
using ClassLibrary;
using ClassLibrary.DataModel;
using System.Threading;
using Library;
using System.IO;
using System.ComponentModel;
using System.ServiceModel.Description;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Armor> armors = new List<Armor>();
        public List<Weapon> weapons = new List<Weapon>();
        public List<EnemyShip> enemyShips = new List<EnemyShip>();
        public List<StarShip> starShips = new List<StarShip>();
        public GameClass gameClass = new GameClass();
        private User user;
        Uri iconUriStart = new Uri("pack://application:,,,/Images/Start.ico", UriKind.RelativeOrAbsolute);
        Uri iconUriStop = new Uri("pack://application:,,,/Images/Stop.ico", UriKind.RelativeOrAbsolute);
       // Uri iconUriSound = new Uri("pack://application:,,,/Images/Sound.ico", UriKind.RelativeOrAbsolute);
      //  Uri iconUriNoSound = new Uri("pack://application:,,,/Images/NoSound.ico", UriKind.RelativeOrAbsolute);
        CancellationTokenSource _cancelTokenSource;
        CancellationToken _token;
        StarShip starShip = new StarShip();
        //public MainWindow()
        //{


        //  //  Filling_from_the_database();

        // //   InitializeComponent();

        //}

        public MainWindow(User user)
        {
            Filling_from_the_database();
           
            InitializeComponent();
            this.user = user;
           
            Title = user.Name;
            _cancelTokenSource = new CancellationTokenSource();
            _token = _cancelTokenSource.Token;
            Closed += (s, e) => _cancelTokenSource.Cancel();
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
                    BtOpen.Set(()=> BtOpen.IsEnabled = true);
                    BtSave.Set(() => BtSave.IsEnabled = true);
                }
                catch (Exception ex)
                {
                    BtOpen.Set(() => BtOpen.IsEnabled = false);
                    BtSave.Set(() => BtSave.IsEnabled = false);
                    this.Set(() => this.Icon = BitmapFrame.Create(iconUriStop));
                }
            }
        }
        public async void Filling_from_the_database()
        {
            try
            {

                var client = new ServiceReference1.CompontsReturnClient("BasicHttpBinding_ICompontsReturn");

                armors = await client.ReturnArmorAsync();
                weapons = await client.ReturnWeaponAsync();
                enemyShips = await client.ReturnEnemyShipAsync();
                starShips = await client.ReturnStarShipAsync();
                #region проверка
                //foreach (var armor in armors)  //проверочка
                //{
                //    MessageBox.Show(armor.Name + " " + armor.Cost);
                //}
                //foreach (var weapon in weapons)
                //{
                //    MessageBox.Show(weapon.Name + " " + weapon.Damage);
                //}
                //foreach (var enemy in enemyShips)
                //{
                //    MessageBox.Show(enemy.Name + " " + enemy.Damage);
                //}
                //foreach (var star in starShips)
                //{
                //    MessageBox.Show(star.Name + " " + star.Coefficient);
                //}
                #endregion

                CreateNewGame();
                client.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CreateNewGame()
        {
            gameClass.UserName = user.Name;
            gameClass.Money = user.Money+10000;

           
            starShip = starShips.FirstOrDefault(a => a.StarShipId == user.StarShipId);
            gameClass.MyShipPicture = convector(starShip.Picture);
            gameClass.MyShipName = starShip.Name;

            // MessageBox.Show(user.StarShipId.ToString());
            gameClass.MyShipPicture = convector(starShips.FirstOrDefault(a => a.StarShipId == user.StarShipId).Picture);//картинка корабля
            gameClass.MyShipName = starShips.FirstOrDefault(a => a.StarShipId == user.StarShipId).Name; //starShips.First().Name;//Имя корабля


            gameClass.WeaponName = weapons.FirstOrDefault(a => a.WeaponId == starShips.FirstOrDefault(b => b.StarShipId == user.StarShipId).WeaponId).Name;             //weapons.First().Name;
            gameClass.WeaponDamage = weapons.FirstOrDefault(a => a.WeaponId == starShips.FirstOrDefault(b => b.StarShipId == user.StarShipId).WeaponId).Damage;
            gameClass.WeaponPicture = convector(weapons.FirstOrDefault(a => a.WeaponId == starShips.FirstOrDefault(b => b.StarShipId == user.StarShipId).WeaponId).Picture);

            gameClass.ArmorName = armors.FirstOrDefault(a => a.ArmorId == starShips.FirstOrDefault(b => b.StarShipId == user.StarShipId).ArmorId).Name;     // armors.First().Name;
            gameClass.ArmorHealth = armors.FirstOrDefault(a => a.ArmorId == starShips.FirstOrDefault(b => b.StarShipId == user.StarShipId).ArmorId).Life;
            gameClass.ArmorPicture = convector(armors.FirstOrDefault(a => a.ArmorId == starShips.FirstOrDefault(b => b.StarShipId == user.StarShipId).ArmorId).Picture);

            gameClass.MyDamage = starShips.First().Coefficient * gameClass.WeaponDamage;// weapons.First().Damage;//Урон
            gameClass.MyHealthMax = starShips.First().Coefficient * gameClass.ArmorHealth;//жизни всего
            gameClass.MyHealthNow = gameClass.MyHealthMax;//жизни на текущий момент


            gameClass.EnemyShipName = enemyShips.First().Name;
            gameClass.EnemyShipPicture = convector(enemyShips.First().Picture);
            gameClass.EnemyDamage = enemyShips.First().Damage;
            gameClass.EnemyHealthMax = enemyShips.First().Health;
            gameClass.EnemyHealthNow = enemyShips.First().Health;
            gameClass.EnemyCost = enemyShips.First().Money;

            this.DataContext = gameClass;
           
        }
     
      public  BitmapImage convector(byte[] Picture)
        {
            BitmapImage image = new BitmapImage();
            using (MemoryStream ms = new MemoryStream(Picture))
            {
                image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                image.StreamSource.Dispose();
            }
            return image;
        }

        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update update = new Update(armors, weapons, starShips, gameClass,this);

            update.Show();
            update.Owner = this;
           
        }

        private void ChangeEnemy_Click(object sender, RoutedEventArgs e)
        {
            Change_enemy change_Enemy = new Change_enemy(enemyShips,gameClass,this);
            change_Enemy.Show();

        }

        private void ButFix_Click(object sender, RoutedEventArgs e)
        {
        if ( gameClass.MyHealthMax-gameClass.MyHealthNow>=gameClass.Money)
            {
                gameClass.Money -= gameClass.MyHealthMax - gameClass.MyHealthNow;
            }
        else
            {
                gameClass.MyHealthNow += gameClass.Money;
                gameClass.Money = 0;
            }
        }

        private async void BtSave_Click(object sender, RoutedEventArgs e)
        {
            user.Name = gameClass.UserName;
            user.Money = gameClass.Money;
            var client = new ServiceReference1.CompontsReturnClient("BasicHttpBinding_ICompontsReturn");
            bool flag = await client.SaveAsync(user, starShip);
            if(flag==true)
            {
                MessageBox.Show("Сохранено");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void BtOpen_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                CreateNewGame();
                MessageBox.Show("Загружено");
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка");
            }
            
        }
    }
}
