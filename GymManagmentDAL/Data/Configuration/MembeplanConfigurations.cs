using GymManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Data.Configuration
{
    internal class MembeplanConfigurations : IEntityTypeConfiguration<MembePlan>
    {
        public void Configure(EntityTypeBuilder<MembePlan> builder)
        {
            builder.Property(x => x.CreatedAt)
                 .HasColumnName("StartDate")
                 .HasDefaultValueSql("GETDATE()");

            builder.HasKey(p => new { p.MemberId, p.PlanId });
            builder.Ignore(x => x.Id);
        }
    }
}
