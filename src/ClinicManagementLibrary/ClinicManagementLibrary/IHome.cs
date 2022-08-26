using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public interface IHome
    {
        public List<Doctor> viewDoctors();

        public int addPatient(Patient p,out int patientid);

        public bool validatePatient( string firstName,
            string lastName, string sex, int age, string dob);


    }
}
