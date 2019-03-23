namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Domains;
    using Data.Domains;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext()
            : base("name=MyDbContext")
        {
            ///ConnectionStringini d�zenlemek isterseniz, Webapi katman� i�indeki en alt WebConfig dosyas�ndan de�i�tirebilirsiniz.
            Database.SetInitializer<MyDbContext>(new DropCreateDatabaseIfModelChanges<MyDbContext>());
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public static MyDbContext Create()
        {
            return new MyDbContext();
        }
    }
}