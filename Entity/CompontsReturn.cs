using ClassLibrary.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Entity
{
    public class CompontsReturn : ICompontsReturn
    {
        public List<Armor> ReturnArmor()
        {
            List<Armor> armors = new List<Armor>();
            using (StarContext context = new StarContext())
            {
                armors.AddRange(context.Armors);
            }
            return armors;
        }
        public List<Weapon> ReturnWeapon()
        {
            List<Weapon> weapons = new List<Weapon>();
            using (StarContext context = new StarContext())
            {
                weapons.AddRange(context.Weapons);
            }
            return weapons;
        }
        public List<EnemyShip> ReturnEnemyShip()
        {
            List<EnemyShip> enemyShips = new List<EnemyShip>();
            using (StarContext context = new StarContext())
            {
                enemyShips.AddRange(context.EnemyShips);
            }
            return enemyShips;
        }
        public List<StarShip> ReturnStarShip()
        {
            List<StarShip> starShips = new List<StarShip>();
            using (StarContext context = new StarContext())
            {

                starShips.AddRange(context.StarShips);
            }
            return starShips;
        }
        public List<User> ReturnAllUser()
        {
            List<User> Users = new List<User>();
            using (StarContext context = new StarContext())
            {
                Users.AddRange(context.Users);
            }
            return Users;
        }

        public bool Is_successful_registration(string login, string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            using (StarContext context = new StarContext())
            {
                byte[] pass = md5.ComputeHash(Encoding.Default.GetBytes(password));
                User user = context.Users.FirstOrDefault(a => a.Name == login && a.Password == pass);
                if (user != null)
                {
                    return true;
                }
                else
                    return false;
            }


        }

        public User ReturnUser(string login, string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            using (StarContext context = new StarContext())
            {
                byte[] pass = md5.ComputeHash(Encoding.Default.GetBytes(password));
                User user = context.Users.FirstOrDefault(a => a.Name == login && a.Password == pass);
                return user;
            }

        }

        public bool UserRegestration(string login, string password)
        {
            bool flag = false;
            try
            {
                flag = Is_successful_registration(login, password);
                var md5 = new MD5CryptoServiceProvider();
                using (StarContext context = new StarContext())
                {
                    if (flag == true)
                    {
                        byte[] pass = md5.ComputeHash(Encoding.Default.GetBytes(password));
                        User tmpUser = new User
                        {
                            Name = login,
                            RoleId = context.Roles.First(a => a.Name == "user").RoleId,
                            Password = md5.ComputeHash(Encoding.Default.GetBytes(password)),
                            Money = 10000,
                            StarShipId = context.StarShips.First().StarShipId,
                            Role = context.Roles.First(a => a.Name == "user")

                        };

                        context.Users.Add(tmpUser);
                        context.SaveChanges();
                    }

                    return flag;
                }

            }
            catch (Exception ex)
            {
                return flag;
            }
        }

        public bool Save(User user, StarShip starShip)
        {
            try
            {
                using (StarContext starBattleDB = new StarContext())
                {
                    starBattleDB.StarShips.Add(starShip);
                    starBattleDB.SaveChanges();
                    //user.StarShipId = starBattleDB.StarShips.FirstOrDefault(a => a.Name == starShip.Name).StarShipId;
                    user.StarShipId = starBattleDB.StarShips.ToList().LastOrDefault(a => a.Name == starShip.Name).StarShipId;
                   
                    User userDelete = new User();
                    userDelete = starBattleDB.Users.FirstOrDefault(a => a.Name == user.Name && a.Password == user.Password);
                    starBattleDB.Users.Remove(userDelete);
                    starBattleDB.SaveChanges();
                    starBattleDB.Users.Add(user);
                    starBattleDB.SaveChanges();
                  
                    //var myUser = starBattleDB.Users
                    //     .Where(a => a.Name == user.Name && a.Password == user.Password)
                    //     .FirstOrDefault();
                    //myUser = user;
                   // starBattleDB.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
           
        }
    }
}
