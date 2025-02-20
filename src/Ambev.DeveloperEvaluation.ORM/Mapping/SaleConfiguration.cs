using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration: IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("sale");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Date).IsRequired();
        builder.Property(u => u.UserId).IsRequired();
        builder.Property(u => u.TotalSaleAmount).IsRequired();
        builder.Property(u => u.Branch).IsRequired();
        builder.Property(u => u.SaleNumber).HasDefaultValueSql("NEXT VALUE FOR SaleSequence");
    }
}
