using LIbraryAPI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LIbraryAPI.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(x => x.ORDER_ID);

            
            builder.HasOne<Book>()
                .WithMany()
                .HasForeignKey(x => x.BOOK_ID).HasPrincipalKey(b => b.BOOK_ID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x=>x.USER_ID).HasPrincipalKey(u=>u.USER_ID)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
