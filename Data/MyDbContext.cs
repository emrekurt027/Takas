namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Domains;

    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyDbContext")
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Image> Images { get; set; }
    }
}