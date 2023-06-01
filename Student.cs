using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_124_S23_L14_CSVReadWrite
{
    public class Student
    {

        string _firstName;
        string _lastName;
        int csiGrade;
        int genEdGrade;

        // To LOAD from a csv, you need to have a DEFAULT CONSTRUCTOR
        public Student() // Default Constructor
        {

        }
        
        
        public Student(string firstName, string lastName, int csiGrade, int genEdGrade)
        {
            _firstName = firstName;
            _lastName = lastName;
            this.csiGrade = csiGrade;
            this.genEdGrade = genEdGrade;
        }

        // WE NEED OUR FIELDS OR PROPERTIES TO BE PUBLIC TO Save WITH CSV
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public int CsiGrade { get => csiGrade; set => csiGrade = value; }
        public int GenEdGrade { get => genEdGrade; set => genEdGrade = value; }
        public double Average { get => (CsiGrade + genEdGrade) / 2.0; }



        public override string ToString()
        {
            return $"{_firstName},{_lastName},{csiGrade},{genEdGrade}";
        }
    }
}
