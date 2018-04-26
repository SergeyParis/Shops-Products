using System.Data.Entity.ModelConfiguration;

namespace ShopsProducts.Data
{
    internal class ItemsConfiguration : EntityTypeConfiguration<SingleItemWrapped>
    {
        public ItemsConfiguration()
        {
            Map(it => it.ToTable("Items"));
            
            Property(it => it.DataBaseId).HasColumnType("int");
            Property(it => it.CurrencyName).IsRequired().HasMaxLength(10).HasColumnType("nvarchar");
            Property(it => it.Price).IsRequired().HasColumnType("money");
            Property(it => it.Id).IsRequired().HasColumnType("bigint");

            Property(it => it.Country).HasMaxLength(20).HasColumnType("nvarchar"); 
            Property(it => it.Location).HasMaxLength(20).HasColumnType("nvarchar");
            Property(it => it.Title).HasMaxLength(30).HasColumnType("nvarchar");
            Property(it => it.Url).HasColumnType("ntext");
            Property(it => it.GalleryUrl).HasColumnType("ntext");

            HasKey(it => it.DataBaseId);
        }
    }
}
