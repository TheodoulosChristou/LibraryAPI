using LIbraryAPI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LIbraryAPI.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.HasKey(b => b.BOOK_ID);

            builder.Property(b=>b.BOOK_NAME).IsRequired();

            builder.Property(b => b.DATE_PUBLISHED).IsRequired();

            builder.Property(b => b.BOOK_NAME).HasMaxLength(255);
        }
    }
}
