using BackEnd.Domain.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infrastructure.EntityframeworkCore.TypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(@"users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName(@"id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasColumnName(@"name").HasColumnType(@"varchar").IsRequired().HasMaxLength(50);
        builder.Property(x => x.Email).HasColumnName(@"email").HasColumnType(@"varchar").IsRequired().HasMaxLength(100);
        builder.Property(x => x.Password).HasColumnName(@"password").HasColumnType(@"varchar").IsRequired().HasMaxLength(100);
    }
}