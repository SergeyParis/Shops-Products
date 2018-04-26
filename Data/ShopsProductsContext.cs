using System.Data.Entity;

namespace ShopsProducts.Data
{
    public sealed class ShopsProductsContext : DbContext
    {
        static ShopsProductsContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ShopsProductsContext>());
        }

        public ShopsProductsContext() : base("ShopsProductsConnection") {  }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<SingleItemWrapped> Items { get; set; }
        public DbSet<DetailsSingleItemWrapped> ItemDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ShopsConfiguration());
            modelBuilder.Configurations.Add(new ItemsConfiguration());
            modelBuilder.Configurations.Add(new QueriesConfiguration());
            modelBuilder.Configurations.Add(new ItemDetailsConfiguration());
        }
    }
}
