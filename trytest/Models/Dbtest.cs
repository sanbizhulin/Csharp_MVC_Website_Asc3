using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace trytest.Models
{
    public class Dbtest:DbContext
    {
        public DbSet<User> UserTable { get; set; }
        public DbSet<UserRole> UserRoleTable { get; set; }
        public DbSet<Friend> FriendTable { get; set; }
        public DbSet<EventInProject> EventInProjcetTable { get; set; }

        public DbSet<EventInProjectType> EventInProjcetTypeTable { get; set; }
        public DbSet<EventInProjectStatus> EventInProjcetStatusTable { get; set; }
        public DbSet<Contribution> ContributionTable { get; set; }
        public DbSet<ContributionType> ContributionTypeTable { get; set; }

       // public DbSet<FriendRole> FriendRoleTable { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder) { }
       

    }
   
}