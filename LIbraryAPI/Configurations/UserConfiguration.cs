using LIbraryAPI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LIbraryAPI.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.USER_ID);

            builder.Property(x => x.FIRST_NAME).HasMaxLength(255);

            builder.Property(x => x.LAST_NAME).HasMaxLength(255);

            builder.Property(x => x.ADDRESS).HasMaxLength(255);

            builder.Property(x => x.PHONE_NUMBER).HasMaxLength(8);

            builder.Property(x => x.EMAIL).HasMaxLength(255);
        }
    }
}
