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
using System.Windows.Shapes;
using ClassLibrary.DataModel;
using Library;
using System.Threading;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        public GameClass gameClass;
        public List<Armor> armors;
        public List<Weapon> weapons;
        public List<StarShip> starShips;
        private MainWindow mainWindow;

     //   public string ReturnString { get; set; }
        public Update()
        {
            InitializeComponent();

        }



        public Update(List<Armor> armors, List<Weapon> weapons, List<StarShip> starShips, GameClass gameClass)
        {
            InitializeComponent();
            this.armors = armors;
            this.weapons = weapons;
            this.starShips = starShips;
            this.gameClass = gameClass;
            // Thread.Sleep(1000);
            //MainWindow mainWindow = new MainWindow();
            //  mainWindow.Owner = this;

            CreateList();
            
        }

        public Update(List<Armor> armors, List<Weapon> weapons, List<StarShip> starShips, GameClass gameClass, MainWindow mainWindow) : this(armors, weapons, starShips, gameClass)
        {
            this.mainWindow = mainWindow;
        }

        public void CreateList()
        {
            ListViewShips.Set(() => ListViewShips.ItemsSource = starShips);
            ListViewWeapon.Set(() => ListViewWeapon.ItemsSource = weapons);
            ListViewArmor.Set(() => ListViewArmor.ItemsSource = armors);
            UpdateWindow.Title = gameClass.Money.ToString();

        }

        private void ButBuyArmor_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;//нашёл нажатую кнопку

            StackPanel stackPanel = button.Parent as StackPanel;

            DockPanel dockPanelName = stackPanel.Children[1] as DockPanel;//док панель с именем
            string name = (dockPanelName.Children[1] as Label).Content.ToString();
            DockPanel dockPanelCost = stackPanel.Children[3] as DockPanel;//док панель со стоимостью
            int cost = Convert.ToInt32((dockPanelCost.Children[1] as Label).Content.ToString());
            if (gameClass.Money < cost)
            {
                MessageBox.Show("Вам не хватает " + (cost - gameClass.Money).ToString());

            }

          
            else
            {
                gameClass.Money = gameClass.Money - cost;
                gameClass.ArmorName = name;
                gameClass.ArmorHealth = armors.First(a => a.Name == name).Life;
                gameClass.MyHealthMax = starShips.First(a => a.Name == gameClass.MyShipName).Coefficient * gameClass.ArmorHealth;
                gameClass.ArmorPicture = mainWindow.convector(armors.First(a => a.Name == name).Picture);
                gameClass.MyHealthNow = gameClass.MyHealthMax;
                gameClass.NotifyPropertyChanged();
                Close();
            }
        }

        private void ButBuyWeapon_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            StackPanel stackPanel = button.Parent as StackPanel;

            DockPanel dockPanelName = stackPanel.Children[1] as DockPanel;
            string name = (dockPanelName.Children[1] as Label).Content.ToString();
            DockPanel dockPanelCost = stackPanel.Children[3] as DockPanel;
            int cost = Convert.ToInt32((dockPanelCost.Children[1] as Label).Content.ToString());

            if (gameClass.Money < cost)
            {
                MessageBox.Show("Вам не хватает " + (cost - gameClass.Money).ToString());

            }
            else
            {
                gameClass.Money = gameClass.Money - cost;
                gameClass.WeaponName = name;
                gameClass.WeaponDamage = weapons.First(a => a.Name == name).Damage;
                gameClass.MyDamage = starShips.First(a => a.Name == gameClass.MyShipName).Coefficient * gameClass.WeaponDamage;
                gameClass.WeaponPicture = mainWindow.convector(weapons.First(a => a.Name == name).Picture);
                gameClass.NotifyPropertyChanged();
                Close();
            }
            // MessageBox.Show(name + " " + cost);
        }

        private void ButBuyShip_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            StackPanel stackPanel = button.Parent as StackPanel;

            DockPanel dockPanelName = stackPanel.Children[1] as DockPanel;
            string name = (dockPanelName.Children[1] as Label).Content.ToString();
            DockPanel dockPanelCost = stackPanel.Children[2] as DockPanel;
            int cost = Convert.ToInt32((dockPanelCost.Children[1] as Label).Content.ToString());

            if (gameClass.Money < cost)
            {
                MessageBox.Show("Вам не хватает " + (cost - gameClass.Money).ToString());

            }
            else
            {
                gameClass.MyShipName = name;
                gameClass.Money = gameClass.Money - cost;
                gameClass.MyShipPicture =mainWindow.convector(starShips.First(a => a.Name == name).Picture);

                gameClass.MyDamage = starShips.First(a => a.Name == name).Coefficient * gameClass.WeaponDamage;
                gameClass.MyHealthMax = starShips.First(a => a.Name == name).Coefficient * gameClass.ArmorHealth;
                gameClass.MyHealthNow = gameClass.MyHealthMax;
                //  mainWindow.ResetForm();
                gameClass.NotifyPropertyChanged();
                Close();
            }
            // MessageBox.Show(name + " " + cost);
        }
       
    }
}
