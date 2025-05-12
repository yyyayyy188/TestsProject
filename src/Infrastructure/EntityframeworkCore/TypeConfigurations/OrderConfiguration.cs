using BackEnd.Domain.Domain.Order;
using BackEnd.Domain.Domain.Product;
using BackEnd.Domain.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infrastructure.EntityframeworkCore.TypeConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(@"orders");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName(@"id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd();
        builder.Property(x => x.CustomerName).HasColumnName(@"customer_name").HasColumnType(@"varchar").IsRequired().HasMaxLength(50);
        builder.Property(x => x.TotalAmount).HasColumnName(@"total_amount").HasColumnType(@"decimal").IsRequired();
        builder.Property(x => x.ProductId).HasColumnName(@"product_id").HasColumnType(@"int").IsRequired();
        builder.Property(x => x.UserId).HasColumnName(@"user_id").HasColumnType(@"int").IsRequired();

        builder.HasOne<User>()         
            .WithMany()                   
            .HasForeignKey(o => o.UserId)
            .HasConstraintName("FK_Order_User");

        builder.HasOne<Product>()         
            .WithMany()                   
            .HasForeignKey(o => o.ProductId)
            .HasConstraintName("FK_Order_Product");
    }
}