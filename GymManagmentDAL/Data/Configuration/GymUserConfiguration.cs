using GymManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Data.Configuration
{
    internal class GymUserConfiguration<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.Name).HasColumnType("varchar")
                 .HasMaxLength(50);
            builder.Property(p => p.Email).HasColumnType("varchar")
                             .HasMaxLength(50);
            builder.ToTable(Tb =>
            {
                Tb.HasCheckConstraint("GymUserEmailCheck", "Email LIKE '_%@_%._%'");
            });

            builder.Property(p => p.Phone).HasColumnType("varchar")
                          .HasMaxLength(50);
            builder.ToTable(Tb =>
            {
                Tb.HasCheckConstraint("GymUserPhoneCheck", "Phone LIKE '01%' and Phone NOT LIKE '%[^0-9]%'");
            });
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(b => b.Phone).IsUnique();

            builder.OwnsOne(x => x.Address, AddressProperty =>
            {
                AddressProperty.Property(y => y.Street).HasColumnName("Street")
                .HasColumnType("varchar")
                .HasMaxLength(50);

                AddressProperty.Property(y => y.City).HasColumnName("City")
               .HasColumnType("varchar")
               .HasMaxLength(50);

                AddressProperty.Property(y => y.BuldingNumber).HasColumnName("BuldingNumber");
              




            });

           
           
        }
    }
}
