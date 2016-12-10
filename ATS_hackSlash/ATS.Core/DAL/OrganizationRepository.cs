using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Core.Context;



namespace ATS.Core.DAL
{
  public class OrganizationRepository
  {
      IList<Organization> organizations = new List<Organization>();

      public bool Add(Organization organization)
      {
          AssetDBContext db = new AssetDBContext();

          db.Organizations.Add(organization);

          int rowAffected = db.SaveChanges();

          return rowAffected > 0;
      }

      public bool Update(Organization organization)
      {
          AssetDBContext db = new AssetDBContext();

          db.Organizations.Attach(organization);

          db.Entry(organization).State = EntityState.Modified;


          int rowAffected = db.SaveChanges();

          return rowAffected > 0;
      }

      public bool Remove(Organization organization)
      {
          return true;
      }

      public IList<Organization> GetAll()
      {
          AssetDBContext db = new AssetDBContext();
          var organizations = db.Organizations.Include((string) (c => c.OrganizationBranches)).ToList();

          return organizations;
      }

      public Organization GetById(int id)
      {
          AssetDBContext db = new AssetDBContext();

          var organization = db.Organizations.Include((string) (c => c.OrganizationBranches))
                               .FirstOrDefault(c => c.Id == id);

          return organization;
      }

      public List<Organization> Search(OrganizationSearchCriteria searchCriteria)
      {
          AssetDBContext db = new AssetDBContext();

          var organizations = db.Organizations.Include((string) (c => c.OrganizationBranches)).AsQueryable();

          if (!String.IsNullOrEmpty(searchCriteria.Name))
          {
              organizations = organizations.Where(c => c.Name.Contains(searchCriteria.Name));
          }

          if (!String.IsNullOrEmpty(searchCriteria.Code))
          {
              organizations = organizations.Where(c => c.Code.Equals(searchCriteria.Code));
          }


          if (!String.IsNullOrEmpty(searchCriteria.Location))
          {
              organizations = organizations.Where(c => c.Location.Contains(searchCriteria.Location));
          }

          if (!String.IsNullOrEmpty(searchCriteria.BranchName))
          {
              organizations =
                  organizations.Where(c => c.OrganizationBranches.Any(d => d.Name.Contains(searchCriteria.BranchName)));
          }


          return organizations.Include(c => c.OrganizationBranches).ToList();





      }




  }
}
