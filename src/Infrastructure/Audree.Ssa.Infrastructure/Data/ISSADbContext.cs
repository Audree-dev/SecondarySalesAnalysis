using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Core.Model.Master;
using Microsoft.EntityFrameworkCore;

namespace Audree.Ssa.Infrastructure.Data
{
   
    public interface ISSADbContexts
    {
        int SaveChanges();
        //DbEntityEntry Entry(object entity);
        void Dispose();
        DbSet<Country> Countries { get; set; }
        DbSet<Material> Materials { get; set; }
        DbSet<Role> roles { get; set; }
        DbSet<Menu> menus { get; set; }
        DbSet<Salutation> salutations { get; set; }
        DbSet<UOM> UOMs { get; set; }
        DbSet<Passwordpolicy> Passwordpolicies { get; set; }
        DbSet<Changepassword> Changepasswords { get; set; }
        DbSet<ProfilesMaster> ProfilesMasters { get; set; }
        DbSet<Customer> customers { get; set; }
        DbSet<ReasonForRejection> ReasonForRejections { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<MenuMaster> MenuMasters { get; set; }
         DbSet<Submenu> Submenus { get; set; }
         DbSet<UsersInRoles> UsersInRoleses { get; set; }
    }

}