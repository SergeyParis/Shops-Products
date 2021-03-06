﻿using System.Data.Entity.ModelConfiguration;

namespace ShopsProducts.Data
{
    internal class SearchResultsConfiguration : EntityTypeConfiguration<SearchResultsWrapped>
    {
        public SearchResultsConfiguration()
        {
            Map(it => it.ToTable("SearchResults"));

            Property(it => it.Id).IsRequired().HasColumnType("int");
            Property(it => it.PageIndex).HasColumnType("int");
            Property(it => it.Text).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
            
            HasKey(it => it.Id);
        }
    }
}
