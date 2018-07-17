using BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Seeder.Seeders
{
    public class UserSeeder
    {
        public static User[] GetUsers()
        {
            User[] users = new User[]
            {
                new User(){ FirstName="Ivan", LastName="Ivanov", Email="ivan.ivan@ivan.ivan", Password="bacenikoinemiznaeparolata" },
                new User(){ FirstName="Gosho", LastName="Goshev", Email="goshkata@gosho.com", Password="123parola" },
                new User(){ FirstName="Stavri", LastName="Metodiev", Email="stavri@metodiev.com", Password="nabacestavriparolata" },
                new User(){ FirstName="Stamat", LastName="Prakashov", Email="st@amat.com", Password="nastamatparolataestamat" },
                new User(){ FirstName="Pesho", LastName="Peshov", Email="peshoni99@peshkata.com", Password="peshobosa_99" },
                new User(){ FirstName="Genadi", LastName="Alirazakov", Email="genadi@gencho.com", Password="megabesnataparolabace" },
                new User(){ FirstName="Miumiun", LastName="Hasanov", Email="bularina_04@bulgaria.bg", Password="amanesymciganin" },
                new User(){ FirstName="Haralampi", LastName="Strandjamiev", Email="bogahara89@opop.bg", Password="naiqkotoimeimam" }
            };

            return users;
        }
    }
}
