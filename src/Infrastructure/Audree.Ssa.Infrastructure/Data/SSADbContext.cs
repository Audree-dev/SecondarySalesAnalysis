using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Core.Model.Master;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Audree.Ssa.Infrastructure.Data
{
    public class SSADbContext : DbContext, ISSADbContexts
    {
        public SSADbContext(DbContextOptions<SSADbContext> options) : base(options) { }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        //public IDbSet<Country> Countries { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Menu> menus { get; set; }
        public DbSet<Salutation> salutations { get; set; }
        public DbSet<UOM> UOMs { get; set; }

        public DbSet<Passwordpolicy> Passwordpolicies { get; set; }

        public DbSet<Changepassword> Changepasswords { get; set; }
        public DbSet<ProfilesMaster> ProfilesMasters { get; set; }
       public DbSet<ReasonForRejection> ReasonForRejections { get; set; }
       public DbSet<Customer> customers { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet<MenuMaster> MenuMasters { get; set; }
       public DbSet<Submenu> Submenus { get; set; }
       public DbSet<UsersInRoles> UsersInRoleses { get; set; }

    }
}
      
