namespace Entity.Migrations
{
    using ClassLibrary.DataModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Entity.StarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Entity.StarContext context)
        {
            int basis = 5;//�������� ����� �� �������� �� �������������
            using (StarContext starBattleDB = new StarContext())
            {
                //������� ����
                Role admin = new Role { Name = "admin" }; //���� ����
                Role user = new Role { Name = "user" };
                starBattleDB.Roles.Add(admin);
                starBattleDB.Roles.Add(user);
                starBattleDB.SaveChanges();


                //������� ������
                var md5 = new MD5CryptoServiceProvider();

                User Admin = new User
                {
                    Name = "Admin",
                    RoleId = context.Roles.First(a => a.Name == "admin").RoleId,
                    Password = md5.ComputeHash(Encoding.Default.GetBytes("123456")),
                    StarShipId = 1,
                    Money = 1000
                };
                User User1 = new User
                {
                    Name = "User1",
                    RoleId = context.Roles.First(a => a.Name == "user").RoleId,
                    Password = md5.ComputeHash(Encoding.Default.GetBytes("123456")),
                    StarShipId = 1,
                    Money = 1000
                };
                User User2 = new User
                {
                    Name = "User2",
                    RoleId = context.Roles.First(a => a.Name == "user").RoleId,
                    Password = md5.ComputeHash(Encoding.Default.GetBytes("123456")),
                    StarShipId = 1,
                    Money = 1000
                };
                User User3 = new User
                {
                    Name = "User3",
                    RoleId = context.Roles.First(a => a.Name == "user").RoleId,
                    Password = md5.ComputeHash(Encoding.Default.GetBytes("123456")),
                    StarShipId = 1,
                    Money = 1000
                };
                starBattleDB.Users.Add(Admin);
                starBattleDB.Users.Add(User1);
                starBattleDB.Users.Add(User2);
                starBattleDB.Users.Add(User3);
                starBattleDB.SaveChanges();

                //������� ������
                Weapon gravitongun = new Weapon
                {
                    Name = "�������������� �����",
                    Damage = basis,
                    Cost = basis * 1000,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\Weapon\gravitongun.gif")
                };
                Weapon gun_ionpulse = new Weapon
                {
                    Name = "������ �����",
                    Damage = basis * 2,
                    Cost = basis * 2000,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\Weapon\gun_ionpulse.gif")
                };
                Weapon gun_railgun = new Weapon
                {
                    Name = "������� �����",
                    Damage = basis * 3,
                    Cost = basis * 3000,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\Weapon\gun_railgun.gif")
                };
                Weapon laser = new Weapon
                {
                    Name = "�����",
                    Damage = basis * 4,
                    Cost = basis * 4000,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\Weapon\laser.gif")
                };
                Weapon turr_laser = new Weapon
                {
                    Name = "�������� ������",
                    Damage = basis * 5,
                    Cost = basis * 5000,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\Weapon\turr_laser.gif")
                };
                starBattleDB.Weapons.Add(gravitongun);
                starBattleDB.Weapons.Add(gun_ionpulse);
                starBattleDB.Weapons.Add(gun_railgun);
                starBattleDB.Weapons.Add(laser);
                starBattleDB.Weapons.Add(turr_laser);
                starBattleDB.SaveChanges();

                //������� �����
                Armor armor_1 = new Armor
                {
                    Name = "����� 1 ������",
                    Life = basis * 1000,
                    Cost = basis * 1000,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\Armor\Shield_1.png")
                };
                Armor armor_2 = new Armor
                {
                    Name = "����� 2 ������",
                    Life = basis * 2000,
                    Cost = basis * 2000,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\Armor\Shield_2.png")
                };
                Armor armor_3 = new Armor
                {
                    Name = "����� 3 ������",
                    Life = basis * 3000,
                    Cost = basis * 3000,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\Armor\Shield_3.png")
                };
                starBattleDB.Armors.Add(armor_1);
                starBattleDB.Armors.Add(armor_2);
                starBattleDB.Armors.Add(armor_3);
                starBattleDB.SaveChanges();

                //���������� �������
                EnemyShip enemyShip_1 = new EnemyShip
                {
                    Name = "��������� ������� 1 ������",
                    Damage = basis * 10,
                    Health = basis * 100,
                    Money = basis * 100,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\EnemyShip\Ship_1.jpg")
                };
                EnemyShip enemyShip_2 = new EnemyShip
                {
                    Name = "��������� ������� 2 ������",
                    Damage = basis * 20,
                    Health = basis * 200,
                    Money = basis * 200,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\EnemyShip\Ship_2.jpg")
                };
                EnemyShip enemyShip_3 = new EnemyShip
                {
                    Name = "��������� ������� 3 ������",
                    Damage = basis * 30,
                    Health = basis * 300,
                    Money = basis * 300,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\EnemyShip\Ship_3.jpg")
                };
                EnemyShip enemyShip_4 = new EnemyShip
                {
                    Name = "��������� ������� 4 ������",
                    Damage = basis * 40,
                    Health = basis * 400,
                    Money = basis * 400,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\EnemyShip\Ship_4.jpg")
                };
                EnemyShip enemyShip_5 = new EnemyShip
                {
                    Name = "��������� ������� 5 ������",
                    Damage = basis * 50,
                    Health = basis * 500,
                    Money = basis * 500,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\EnemyShip\Ship_5.jpg")
                };
                EnemyShip enemyShip_6 = new EnemyShip
                {
                    Name = "��������� ������� 6 ������",
                    Damage = basis * 60,
                    Health = basis * 600,
                    Money = basis * 600,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\EnemyShip\Ship_6.jpg")
                };
                EnemyShip enemyShip_7 = new EnemyShip
                {
                    Name = "��������� ������� 7 ������",
                    Damage = basis * 70,
                    Health = basis * 700,
                    Money = basis * 700,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\EnemyShip\Ship_2.jpg")
                };
                starBattleDB.EnemyShips.Add(enemyShip_1);
                starBattleDB.EnemyShips.Add(enemyShip_2);
                starBattleDB.EnemyShips.Add(enemyShip_3);
                starBattleDB.EnemyShips.Add(enemyShip_4);
                starBattleDB.EnemyShips.Add(enemyShip_5);
                starBattleDB.EnemyShips.Add(enemyShip_6);
                starBattleDB.EnemyShips.Add(enemyShip_7);
                starBattleDB.SaveChanges();

                //���������������� �������
                StarShip Abadon = new StarShip
                {
                    Name = "������",
                    Cost = basis * 1000,
                    Coefficient = 1,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\StarShip\Abaddon.jpg"),
                    WeaponId = 1,
                    ArmorId = 1
                };
                StarShip Absolution = new StarShip
                {
                    Name = "��������",
                    Cost = basis * 2000,
                    Coefficient = 2,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\StarShip\Absolution.jpg"),
                    WeaponId = 1,
                    ArmorId = 1
                };
                StarShip Aeon = new StarShip
                {
                    Name = "����",
                    Cost = basis * 3000,
                    Coefficient = 3,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\StarShip\Aeon.jpg"),
                    WeaponId = 1,
                    ArmorId = 1
                };
                StarShip Archon = new StarShip
                {
                    Name = "�����",
                    Cost = basis * 4000,
                    Coefficient = 4,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\StarShip\Archon.jpg"),
                    WeaponId = 1,
                    ArmorId = 1
                };
                StarShip Magnate = new StarShip
                {
                    Name = "������",
                    Cost = basis * 5000,
                    Coefficient = 5,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\StarShip\Magnate.jpg"),
                    WeaponId = 1,
                    ArmorId = 1
                };
                StarShip Oracle = new StarShip
                {
                    Name = "�����",
                    Cost = basis * 6000,
                    Coefficient = 6,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\StarShip\Oracle.jpg"),
                    WeaponId = 1,
                    ArmorId = 1
                };
                StarShip Revelation = new StarShip
                {
                    Name = "����������",
                    Cost = basis * 7000,
                    Coefficient = 7,
                    Picture = File.ReadAllBytes(@"C:\Users\��\source\repos\StarBattle_V2\ClassLibrary\Images\StarShip\Revelation.jpg"),
                    WeaponId = 1,
                    ArmorId = 1
                };
                starBattleDB.StarShips.Add(Abadon);
                starBattleDB.StarShips.Add(Absolution);
                starBattleDB.StarShips.Add(Aeon);
                starBattleDB.StarShips.Add(Archon);
                starBattleDB.StarShips.Add(Magnate);
                starBattleDB.StarShips.Add(Oracle);
                starBattleDB.StarShips.Add(Revelation);
                starBattleDB.SaveChanges();
            }
        }
    }
}
