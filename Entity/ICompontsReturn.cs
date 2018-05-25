using ClassLibrary.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [ServiceContract]
    public interface ICompontsReturn
    {


        [OperationContract]
        List<Armor> ReturnArmor();
        [OperationContract]
        List<Weapon> ReturnWeapon();
        [OperationContract]
        List<EnemyShip> ReturnEnemyShip();
        [OperationContract]
        List<StarShip> ReturnStarShip();
        [OperationContract]
        bool Is_successful_registration(string login, string password);
        [OperationContract]
        User ReturnUser(string login, string password);
        [OperationContract]
        bool UserRegestration(string login, string password);
        [OperationContract]
        List<User> ReturnAllUser();
        [OperationContract]
        bool Save(User user,StarShip starShip);
    }
}
