using System;
using System.Collections.Generic;

namespace Volunteers.DataModels
{
    public class VolunteerView
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public DateTime StartDate { get; set; }
        public string ClassName { get; set; }
        public double WorkHours{ get; set; }
    }
    
}
