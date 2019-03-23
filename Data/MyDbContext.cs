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
            ///ConnectionStringini düzenlemek isterseniz, Webapi katmaný içindeki en alt WebConfig dosyasýndan deðiþtirebilirsiniz.
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