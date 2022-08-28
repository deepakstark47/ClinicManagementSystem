using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public class PatientHasNoAppointmentException:ApplicationException
    {
        public PatientHasNoAppointmentException(string message) : base(message)
        {

        }
    }

}
