using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Core.Context
{
    public class AssetDBContext : DbContext
    {
        public AssetDBContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationBranch> OrganizationBranches { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<GeneralCategory> GeneralCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
    }
}
