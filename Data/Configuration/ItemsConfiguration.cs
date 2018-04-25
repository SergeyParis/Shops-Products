using System.Data.Entity.ModelConfiguration;

namespace ShopProducts.Data
{
    internal class ItemsConfiguration : EntityTypeConfiguration<SingleItemWrapped>
    {
        public ItemsConfiguration()
        {
            Map(it => it.ToTable("Items"));
            
            Property(it => it.DataBaseId).HasColumnType("int");
            Property(it => it.CurrencyName).IsRequired().HasMaxLength(20).HasColumnType("nchar(10)");
            Property(it => it.Price).IsRequired().HasColumnType("money");
            Property(it => it.Id).IsRequired().HasColumnType("bigint");

            Property(it => it.Country).HasColumnType("nvarchar(20)"); 
            Property(it => it.Location).HasColumnType("nvarchar(20)");
            Property(it => it.Title).HasColumnType("nvarchar(30)");
            Property(it => it.Url).HasColumnType("tinytext");
            Property(it => it.GalleryUrl).HasColumnType("tinytext");

            HasKey(it => it.DataBaseId);
        }
    }
}
