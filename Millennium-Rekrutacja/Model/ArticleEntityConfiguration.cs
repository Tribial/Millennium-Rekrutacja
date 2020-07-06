using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Millennium_Rekrutacja.Model
{
    public class ArticleEntityConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(article => article.Id);

            builder.Property(article => article.Content)
                .HasMaxLength(1024);

            builder.Property(article => article.Title)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(article => article.Status)
                .IsRequired();

            builder.Property(article => article.Tags)
                .HasMaxLength(128);
        }
    }
}
