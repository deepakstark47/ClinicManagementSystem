using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public interface ICancelSchedule
    {
        public List<Appointment> displayAppointmentsOfPatient(int patientId,DateTime CancelDate);

        public int cancelAppointment(int appid,int patient_id);

        public bool ValidatePatientId(int patientId);

        public bool ValidateIndianFormatDate(string date1);
    }
}
