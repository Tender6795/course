using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClassLibrary.DataModel;
using Library;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для Change_enemy.xaml
    /// </summary>
    public partial class Change_enemy : Window
    {
        private List<EnemyShip> enemyShips;
        private GameClass gameClass;
        private MainWindow mainWindow;

        public Change_enemy()
        {
            InitializeComponent();
        }

        public Change_enemy(List<EnemyShip> enemyShips)
        {
            InitializeComponent();
            this.enemyShips = enemyShips;

            CreateList();
        }

        public Change_enemy(List<EnemyShip> enemyShips, GameClass gameClass) : this(enemyShips)
        {
            this.gameClass = gameClass;
        }

        public Change_enemy(List<EnemyShip> enemyShips, GameClass gameClass, MainWindow mainWindow) : this(enemyShips, gameClass)
        {
            this.mainWindow = mainWindow;
        }

        public void CreateList()
        {
            ListViewEnemyShips.Set(() => ListViewEnemyShips.ItemsSource = enemyShips);
            //if(gameClass.UserName!="Admin")
            //{
            //    var el = (DockPanel)ListViewEnemyShips.Items.FindName("AdminDockPanel");
            //    el.Visibility = Visibility.Collapsed;
            //}
            //foreach (StackPanel item in ListViewEnemyShips.Items)
            //{
            //    if (gameClass.UserName != "Admin")
            //    {
            //     ( (DockPanel) item.Children[5]).IsVisible = Visibility.Collapsed;
            //    }
            //}


            //var elements= ListViewEnemyShips.Items;
            //foreach(var el in elements )
            //{
            //var tmp=    ((StackPanel)el).Children[0];
            //    ((StackPanel)tmp).Children[5].Visibility = Visibility.Collapsed;
            //}
          
        }

        private void ButChangeShip_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            StackPanel stackPanel = button.Parent as StackPanel;
            DockPanel dockPanelName = stackPanel.Children[1] as DockPanel;
            string name = (dockPanelName.Children[1] as Label).Content.ToString();
            //MessageBox.Show(name);

            gameClass.EnemyShipName = name;
            gameClass.EnemyCost = enemyShips.First(a => a.Name == name).Money;
            gameClass.EnemyDamage = enemyShips.First(a => a.Name == name).Damage;
            gameClass.EnemyHealthMax = enemyShips.First(a => a.Name == name).Health;
            gameClass.EnemyHealthNow = gameClass.EnemyHealthMax;
            gameClass.EnemyShipPicture = mainWindow.convector(enemyShips.First(a => a.Name == name).Picture);
            gameClass.NotifyPropertyChanged();
            Close();
        }
    }
}
