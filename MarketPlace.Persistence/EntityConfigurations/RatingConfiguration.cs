using MarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Persistence.EntityConfigurations;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.Property(r => r.Stars)
               .IsRequired();

        builder.HasOne(r => r.User)
               .WithMany(u => u.Ratings)
               .HasForeignKey(r => r.UserId);

        builder.HasOne(r => r.Product)
               .WithMany(p => p.Ratings)
               .HasForeignKey(r => r.ProductId);
    }
}
