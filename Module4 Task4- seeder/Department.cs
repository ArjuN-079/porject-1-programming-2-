using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_Task4__seeder
{
    public class Department
    {
        //fields
        private Institution institution;   
        private string name;

        //constructor
        public Department(Institution institution, string name)
        {
            this.institution = institution;
            this.name = name;
        }

        //encapsulation {but still use field}
        public Institution Institution { get => institution; set => institution = value; }
        public string Name { get => name; set => name = value; }

        public  string DisplayInfo() => $"Department:{institution.Name}\nname:{name}";
                
    }
}
