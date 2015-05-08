using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FutGame.Data.Config;
using FutGame.Model.Entities;
using FutGame.Model.Queries;

namespace FutGame.Data.Queries
{
    public class UserRepository : IUserRepository
    {
        public AppContext db = new AppContext();

        public User Authenticate(User user)
        {
            var entity = db.Set<User>().Where(x => x.Username == user.Username && x.Password == user.Password);

            return entity.FirstOrDefault();
        }
    }
}
