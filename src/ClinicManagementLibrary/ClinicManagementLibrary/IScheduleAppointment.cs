using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public interface IScheduleAppointment
    {
        public List<Doctor> displayDoctorsBasedOnSpecialization(string spec);
      
        public List<Appointment> getAllSlotsForDoctor(int docid, DateTime day);

        public int bookAppointment(int aptId,int patientId);

        public bool ValidateScheduleAppointment(int patientId, string spec);

        public bool ValidateIndianFormatDate(string date1);

        }
}
