using System.Data.Entity.ModelConfiguration;

namespace ShopsProducts.Data
{
    internal sealed class ItemDetailsConfiguration : EntityTypeConfiguration<DetailsSingleItemWrapped>
    {
        public ItemDetailsConfiguration()
        {
            Map(it => it.ToTable("Items"));

            Property(it => it.Id).IsRequired().HasColumnType("bigint");
            Property(it => it.ImagesUrlString).HasColumnType("ntext");

            HasKey(it => it.Id);
        }
    }
}
