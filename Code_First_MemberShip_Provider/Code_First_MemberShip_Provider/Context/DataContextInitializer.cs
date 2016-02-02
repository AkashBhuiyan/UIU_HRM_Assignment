using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Security;


    public class DataContextInitializer:DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            
            WebSecurity.Register("iitmisu@gmail.com", "misu0516", "misu@misu.com", true, "Misu", "beImp");
            Roles.CreateRole("Admin");
            Roles.CreateRole("User");
            Roles.AddUserToRole("iitmisu@gmail.com", "Admin");
        }
    }