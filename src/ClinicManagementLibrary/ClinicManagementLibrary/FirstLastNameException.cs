using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public class FirstLastNameException:ApplicationException
    {
        public FirstLastNameException(string message) : base(message)
        {

        }
    }
}
