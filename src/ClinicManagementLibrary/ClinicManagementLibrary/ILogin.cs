using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementLibrary
{
    public interface ILogin
    {
        public bool loginUser(string username, string passsword);
    }
}
