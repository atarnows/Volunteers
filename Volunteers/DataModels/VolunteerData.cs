using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteers.DataModels
{
    public class VolunteerData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime StartDate { get; set; }
        public string ClassName { get; set; }
    }
}
