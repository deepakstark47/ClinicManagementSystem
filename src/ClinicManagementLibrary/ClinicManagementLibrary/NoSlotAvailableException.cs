using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public class NoSlotAvailableException:ApplicationException
    {
        public NoSlotAvailableException(string message) : base(message)
        {

        }
    }
}
