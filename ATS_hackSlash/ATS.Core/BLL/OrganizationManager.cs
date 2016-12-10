using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Core.DAL;

namespace ATS.Core.BLL
{
    public class OrganizationManager
    {
        OrganizationRepository repository = new OrganizationRepository();

        public bool Add(Organization organization)
        {
            if (organization == null)
                return false;

            if (organization.Code.Length != 3)
            {
                return false;
            }

            return repository.Add(organization);

        }

        public Organization GetById(int id)
        {
            var organization = repository.GetById(id);

            return organization;
        }


        public bool Update(Organization organization)
        {
            // logical checking area 

            // is code exists 

            bool isUpated = repository.Update(organization);
            return isUpated;
            ;
        }

        public List<Organization> Search(OrganizationSearchCriteria organizationSearchCriteria)
        {
            return repository.Search(organizationSearchCriteria);
        }
    }
}
