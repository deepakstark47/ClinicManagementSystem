using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public class ValidDateException:ApplicationException
    {
        public ValidDateException(string message) : base(message) { }
    }
}
