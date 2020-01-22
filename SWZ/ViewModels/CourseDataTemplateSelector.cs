using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SWZ.ViewModels
{   
   
    class CourseDataTemplateSelector: DataTemplateSelector
    {
        public DataTemplate Course { set; get; }
        public DataTemplate CoursesGroup { set; get; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if(item is CoursesGroupViewModel)
            {
                return CoursesGroup;
            }
            else
            {
                return Course;
            }
        }
    }
}
