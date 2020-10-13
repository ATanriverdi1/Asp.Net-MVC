using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AgriDoktorum.WebApp.Models.Entity;

namespace AgriDoktorum.WebApp.Models.EntityDb
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("migrendo_MdDB")
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<About> About { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PatientReference> PatientReferences { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<AdUser> AdUsers { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<SendMessage> SendMessage { get; set; }
    }
}