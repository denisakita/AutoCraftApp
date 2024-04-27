using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Database;

public class EngineEntityConfiguration : IEntityTypeConfiguration<EngineEntity>
{
    public void Configure(EntityTypeBuilder<EngineEntity> builder)
    {
        builder.ToTable(nameof(EngineEntity)).HasKey(f => f.Id);
    }
}

public class ChassisEntityConfiguration : IEntityTypeConfiguration<ChassisEntity>
{
    public void Configure(EntityTypeBuilder<ChassisEntity> builder)
    {
        builder.ToTable(nameof(ChassisEntity)).HasKey(f => f.Id);
    }
}

public class OptionPackEntityConfiguration : IEntityTypeConfiguration<OptionPackEntity>
{
    public void Configure(EntityTypeBuilder<OptionPackEntity> builder)
    {
        builder.ToTable(nameof(OptionPackEntity)).HasKey(f => f.Id);
    }
}

public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable(nameof(OrderEntity)).HasKey(f => f.Id);
    }
}

public class ComponentEntityConfiguration : IEntityTypeConfiguration<ComponentEntity>
{
    public void Configure(EntityTypeBuilder<ComponentEntity> builder)
    {
        builder.ToTable(nameof(ComponentEntity)).HasKey(f => f.Id);

        builder.Ignore(f => f.Blueprint);
        builder.Ignore(f => f.Order);
        
        builder.HasOne(f => f.OptionPack)
            .WithMany()
            .HasForeignKey(f => f.OptionPackId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(f => f.Chassis)
            .WithMany()
            .HasForeignKey(f => f.ChassisId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(f => f.Engine)
            .WithMany()
            .HasForeignKey(f => f.EngineId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(f => f.OrderEntity)
            .WithMany(f => f.ComponentEntities)
            .HasForeignKey(f => f.OrderEntityId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}