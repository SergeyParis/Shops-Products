using System.Data.Entity.ModelConfiguration;

namespace ShopsProducts.Data
{
    internal class QueriesConfiguration : EntityTypeConfiguration<Query>
    {
        public QueriesConfiguration()
        {
            Map(it => it.ToTable("Queries"));

            Property(it => it.Id).IsRequired().HasColumnType("int");
            Property(it => it.Text).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");

            HasKey(it => it.Id);
        }
    }
}
