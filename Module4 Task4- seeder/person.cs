using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_Task4__seeder
{
    public class person
    //fields
    {
        private int id;
        private string firstName;
        private string lastName;

        //constructor
        public person(int id, string firstName, string lastName)
        {
            this.id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        //encapsulation {but still use field}
        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
    }
}
