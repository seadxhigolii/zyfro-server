using Zyfro.Pro.Server.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Zyfro.Pro.Server.Persistence.Configurations.Base
{
    public static class BaseEntityConfiguration
    {
        public static void UseBaseConfigurations<T, TKey>(this EntityTypeBuilder<T> builder)
            where T : BaseEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(e => e.CreatedAtUtc)
                .HasColumnName("CreatedAtUtc")
                .IsRequired();

            builder.Property(e => e.UpdatedAtUtc)
                .HasColumnName("UpdatedAtUtc")
                .IsRequired();

            builder.Property(e => e.DeletedAtUtc)
                .HasColumnName("DeletedAtUtc")
                .IsRequired(false);

            builder.Property(e => e.CurrentStatus)
                .HasColumnName("CurrentStatus")
                .IsRequired();

            builder.Property(e => e.CreatedBy)
                .HasColumnName("CreatedBy")
                .IsRequired(false);

            builder.Property(e => e.CurrentStateUser)
                .HasColumnName("CurrentStateUser")
                .IsRequired(false);
        }
    }
}
