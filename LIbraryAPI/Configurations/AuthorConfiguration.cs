using LIbraryAPI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LIbraryAPI.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");

            builder.HasKey(x => x.AUTHOR_ID);

            builder.Property(x => x.AUTHOR_NAME).HasMaxLength(255);

            builder.Property(x => x.AUTHOR_NAME).HasMaxLength(255);

            builder.Property(x=>x.AUTHOR_SURNAME).HasMaxLength(255);    

            builder.Property(x=>x.AUTHOR_NAME).IsRequired();

            builder.Property(x=>x.AUTHOR_SURNAME).IsRequired();
        }
    }
}
