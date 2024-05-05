using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetsFederes.Persistence.Config;

public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Client)
            .WithMany(client => client.Orders)
            .HasForeignKey(order => order.ClientId);
    }
}