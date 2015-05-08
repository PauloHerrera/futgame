using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FutGame.Model.Entities;

namespace FutGame.Model.Queries
{
    public interface IUserRepository
    {
        User Authenticate(User user);
    }
}
