using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayDisability
{
    struct Employes
    {
        private string Name;
        private double Salary;
        private int Experience;

        public string name { get { return Name; } set { Name = value; } }
        public double salary { get { return Salary; } set { Salary = value; } }
        public int experience { get { return Experience; } set { Experience = value; } }

        public Employes(string _name, double _salary, int _experience)
        {
            Name = _name;
            Salary = _salary;
            Experience = _experience;
        }
    }
}
