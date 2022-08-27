using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public class Patient
    {
        public int patientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public DateTime dob { get; set; }

        public Patient()
        {

        }
        public Patient(int patientId, string firstName, 
            string lastName, string sex, int age, DateTime dob)
        {
            this.patientId = patientId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.sex = sex;
            this.age = age;
            this.dob = dob;
        }

        public Patient(string firstName,
            string lastName, string sex, int age, DateTime dob)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.sex = sex;
            this.age = age;
            this.dob = dob;
        }
    }
}
