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
    internal class MemberBookSessionConfigurations : IEntityTypeConfiguration<MemberBookSession>
    {
        public void Configure(EntityTypeBuilder<MemberBookSession> builder)
        {
            builder.Property(x => x.CreatedAt)
                .HasColumnName("BookingDate")
                .HasDefaultValueSql("GETDATE()");

            builder.HasKey(p => new { p.MemberId, p.SessionId });
            builder.Ignore(x => x.Id);
        }
    }
}
