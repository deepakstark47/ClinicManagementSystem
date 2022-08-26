using System;

namespace ClinicManagementLibrary
{
    public class User
    {
        string userName { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string password { get; set; }

        public User()
        {

        }
        public User(string userName, string firstName, string lastName, string password)
        {
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
        }

    }
}