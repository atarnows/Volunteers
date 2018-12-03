using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteers.DataModels;

namespace Volunteers.Converter
{
    class VolunteerToClassConventer
    {
        public static List<ClassView> Convert(List<VolunteerView> dataList)
        {
            List<ClassView> listClassView = new List<ClassView>();
            foreach (var data in dataList)
            {
                var el = listClassView.FirstOrDefault(a => a.Name == data.ClassName);
                if (el == null)
                {
                    var classView = new ClassView();
                    classView.Name = data.ClassName;
                    classView.WorkingHours = data.WorkHours;
                    listClassView.Add(classView);
                }
                else
                {
                    el.WorkingHours += data.WorkHours;
                }

            }
            return listClassView;
        }
    }
}
