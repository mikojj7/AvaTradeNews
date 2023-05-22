using AvaTrade.News.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvaTrade.News.Infrastructure.Data.Configuration;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.UserId).IsRequired();
    }
}
