using System.Collections.Generic;
using Volunteers.DataModels;

namespace Volunteers.Importers
{
    interface IVolunteersWorkingHoursImporter
    {
        List<VolunteerWorkingHoursData> GetVolunteersWorkingHours();
    }
}
