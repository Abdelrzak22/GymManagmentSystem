using GymManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Data.Context
{
    public class GymdbContext:DbContext
    {

        public GymdbContext(DbContextOptions <GymdbContext> options) : base(options) { }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public DbSet<Member> Members { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }  
        public DbSet<Plan> Plans { get; set; }  
        public DbSet<Session>Sessions {  get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<MemberBookSession> memberBookSessions {  get; set; }
        public DbSet<MembePlan> membePlans { get; set; }

    }
}
