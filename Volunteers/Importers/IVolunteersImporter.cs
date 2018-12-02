using System.Collections.Generic;
using Volunteers.DataModels;

namespace Volunteers.Importers
{
    public interface IVolunteersImporter
    {
        List<VolunteerData> GetVolunteers();
    }
}
