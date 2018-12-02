using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteers.DataModels;

namespace Volunteers.Converter
{
    class VolunteerDataToViewConverter
    {
        public static List<VolunteerView> Convert(List<VolunteerData> dataList)
        {
            List<VolunteerView> viewList = new List<VolunteerView>();
            foreach (var data in dataList)
            {
                var view = new VolunteerView();
                view.Id = data.Id;
                view.FullName = $"{data.Surname} {data.Name}";
                view.ClassName = data.ClassName;
                view.StartDate = data.StartDate;

                //To implement
                view.WorkHours = 0;

                viewList.Add(view);
            }
            return viewList;
        }
    }
}
