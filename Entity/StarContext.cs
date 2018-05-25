namespace Entity
{
    using ClassLibrary.DataModel;
    using System;
    using System.Data.Entity;
    using System.Linq;
   


    public class StarContext : DbContext
    {
        
        public StarContext()
            : base("StarContext")
        {
            
        }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<EnemyShip> EnemyShips { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<StarShip> StarShips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<ResultTable> ResultTables { get; set; }


    }


}