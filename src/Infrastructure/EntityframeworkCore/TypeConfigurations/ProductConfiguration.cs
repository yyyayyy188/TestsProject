using BackEnd.Domain.Domain.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infrastructure.EntityframeworkCore.TypeConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(@"products");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName(@"id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasColumnName(@"name").HasColumnType(@"varchar").IsRequired().HasMaxLength(50);
        builder.Property(x => x.Description).HasColumnName(@"description").HasColumnType(@"varchar").IsRequired().HasMaxLength(200);
        builder.Property(x => x.Price).HasColumnName(@"price").HasColumnType(@"decimal").IsRequired();
    }
}