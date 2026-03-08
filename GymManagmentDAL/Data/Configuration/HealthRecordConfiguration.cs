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
    internal class HealthRecordConfiguration : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
            builder.ToTable("Members")
                .HasKey(x=>x.Id);
            builder.HasOne<Member>()
                .WithOne(x => x.HealthRecord)
                .HasForeignKey<HealthRecord>(x => x.Id);

            builder.Ignore(x=>x.CreatedAt);
            builder.Ignore(x=>x.UpdateAt);
        }
    }
}
