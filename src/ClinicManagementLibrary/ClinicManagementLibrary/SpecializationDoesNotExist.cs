using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public class SpecializationDoesNotExist:ApplicationException
    {
        public SpecializationDoesNotExist(string message):base(message){}
    }
}
