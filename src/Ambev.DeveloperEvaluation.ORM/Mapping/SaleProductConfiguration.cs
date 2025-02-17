using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleProductConfiguration: IEntityTypeConfiguration<SaleProduct>
{
    public void Configure(EntityTypeBuilder<SaleProduct> builder)
    {
        builder.ToTable("saleproduct");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.ProductId).IsRequired();
        builder.Property(u => u.SaleId).IsRequired();
        builder.Property(u => u.Quantity).IsRequired();
        builder.Property(u => u.UnitPrice).IsRequired();
        builder.Property(u => u.Discounts).IsRequired();
        builder.Property(u => u.TotalAmount).IsRequired();
    }

}
