using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_124_S23_L14_CSVReadWrite
{
    internal class Student
    {

        string _firstName;
        string _lastName;
        int csiGrade;
        int genEdGrade;

        public Student(string firstName, string lastName, int csiGrade, int genEdGrade)
        {
            _firstName = firstName;
            _lastName = lastName;
            this.csiGrade = csiGrade;
            this.genEdGrade = genEdGrade;
        }

        // WE NEED OUR FIELDS OR PROPERTIES TO BE PUBLIC TO WORK WITH CSV
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public int CsiGrade { get => csiGrade; set => csiGrade = value; }
        public int GenEdGrade { get => genEdGrade; set => genEdGrade = value; }

        public override string ToString()
        {
            return $"{_firstName},{_lastName},{csiGrade},{genEdGrade}";
        }
    }
}
