using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstMembership.Repository
{
    public class UserRepository
    {

        private DataContext DbContext;
        public UserRepository()
        {
            this.DbContext = new DataContext();
        }

        public Guid FindUserIdByEmail(String Email)
        {
            return DbContext.Users.FirstOrDefault(x=> x.Username== Email).UserId;
            
        }

    }
}