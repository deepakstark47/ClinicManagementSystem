using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public class Doctor
    {
       public int doctorId { get; set; }
       public string firstName { get; set; }
       public string lastName { get; set; }
       public string sex { get; set; }
        public string specialization { get; set; }
        public TimeSpan visiting_from { get; set; }
        public TimeSpan visiting_to { get; set; }

        public Doctor()
        {

        }
        public Doctor(int doctorId, string firstName, string lastName, 
            string sex, string specialization, TimeSpan visiting_from, TimeSpan visiting_to)
        {
            this.doctorId = doctorId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.sex = sex;
            this.specialization = specialization;
            this.visiting_from = visiting_from;
            this.visiting_to = visiting_to;
        }
    }
}
