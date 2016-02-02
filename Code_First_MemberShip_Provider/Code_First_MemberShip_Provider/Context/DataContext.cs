using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Code_First_MemberShip_Provider.Models;

public class DataContext : DbContext
{
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<EducationalInformation> EducationalInformations { get; set; }
}