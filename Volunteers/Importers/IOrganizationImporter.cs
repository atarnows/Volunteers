using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteers.DataModels;

namespace Volunteers.Importers
{
    interface IOrganizationImporter
    {
        List<OrganizationData> GetOrganizations();
    }
}
