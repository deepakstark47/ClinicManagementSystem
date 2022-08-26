using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public class IndianDateFormatException:ApplicationException
    {
        public IndianDateFormatException(string message):base(message){}
    }
}
