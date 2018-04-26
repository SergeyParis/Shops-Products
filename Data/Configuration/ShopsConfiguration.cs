using System.Data.Entity.ModelConfiguration;

namespace ShopsProducts.Data
{
    internal class ShopsConfiguration : EntityTypeConfiguration<Shop>
    {
        public ShopsConfiguration()
        {
            Map(it => it.ToTable("Shops"));

            Property(it => it.Id).IsRequired().HasColumnType("int");
            Property(it => it.Name).IsRequired().HasMaxLength(20).HasColumnType("nvarchar");

            HasKey(it => it.Id);
        }
    }
}
