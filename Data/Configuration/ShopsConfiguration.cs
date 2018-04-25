using System.Data.Entity.ModelConfiguration;

namespace ShopProducts.Data
{
    internal class ShopsConfiguration : EntityTypeConfiguration<Shop>
    {
        public ShopsConfiguration()
        {
            Map(it => it.ToTable("Shops"));

            Property(it => it.Id).HasColumnType("int");
            Property(it => it.Name).IsRequired().HasMaxLength(20).HasColumnType("nvarchar(20)");

            HasKey(it => it.Id);
        }
    }
}
