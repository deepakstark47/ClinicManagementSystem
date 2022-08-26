using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public class Appointment
    {
        public int appId { get; set; }
        public int doctorId { get; set; }
        public DateTime visitingDate { get; set; }
        public string appTime { get; set; }
        public string appStatus { get; set; }

        

        public int? patientId { get; set; }

        public Appointment()
        {

        }

        public Appointment(int appId, int doctorId,DateTime visitingDate, string appTime, string appStatus )
        {
            this.appId = appId;
            this.doctorId = doctorId;
            this.visitingDate = visitingDate;
            this.appTime = appTime;
            this.appStatus = appStatus;
            this.patientId = null;
        }

        public Appointment(int appId, int doctorId, DateTime visitingDate, string appTime, string appStatus,int patientId)
        {
            this.appId = appId;
            this.doctorId = doctorId;
            this.visitingDate = visitingDate;
            this.appTime = appTime;
            this.appStatus = appStatus;
            this.patientId = patientId;
        }
    }
}
