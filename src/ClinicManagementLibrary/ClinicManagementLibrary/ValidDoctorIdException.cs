using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public class ValidDoctorIdException:ApplicationException
    {
        public ValidDoctorIdException(string message) : base(message)
        {

        }
        
    }
}
