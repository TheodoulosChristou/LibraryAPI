using LIbraryAPI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LIbraryAPI.Configurations
{
    public class PublishConfiguration : IEntityTypeConfiguration<Publish>
    {
        public void Configure(EntityTypeBuilder<Publish> builder)
        {
            builder.ToTable("Publish");

            builder.HasKey(x => x.PUBLISH_ID);

            builder.HasOne<Author>()
                .WithMany()
                .HasForeignKey(x=>x.AUTHOR_ID).HasPrincipalKey(a=>a.AUTHOR_ID);

            builder.HasOne<Book>()
                .WithMany()
                .HasForeignKey(x => x.BOOK_ID).HasPrincipalKey(b => b.BOOK_ID);
        }
    }
}
