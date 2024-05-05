using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetsFederes.Persistence.Config;

public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(line => line.Product)
            .WithMany()
            .HasForeignKey(line => line.ProductId);

        builder.HasOne(line => line.Order)
            .WithMany(order => order.OrderLines)
            .HasForeignKey(line => line.OrderId);
    }
}