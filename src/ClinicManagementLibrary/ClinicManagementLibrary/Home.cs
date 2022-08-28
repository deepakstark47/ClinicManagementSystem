﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ClinicManagementLibrary
{
    public class Home : IHome
    {
        static SqlConnection conn;
        static SqlCommand comm;
        static SqlCommand comm1;

        //get sql connection
        private static SqlConnection getConnection()
        {
            conn = new SqlConnection("Data Source =.; Initial Catalog" +
                " = clinicmanagement; Integrated Security = True");
            conn.Open();
            return conn;
        }

        //method to display all the doctors 
        public List<Doctor> viewDoctors()
        {
            List<Doctor> allDoctors = new List<Doctor>();
            conn = getConnection();
            comm = new SqlCommand("sp_selectAllDoctors", conn);
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = comm.ExecuteReader();
            int doctorId;
            string firstName;
            string lastName;
            string sex;
            string specialization;
            TimeSpan visiting_from;
            TimeSpan visiting_to;
            while (dr.Read())
            {
                    doctorId = dr.GetInt32(0);
                    firstName = dr.GetString(1);
                    lastName = dr.GetString(2);
                    sex = dr.GetString(3);
                    specialization = dr.GetString(4);
                    visiting_from = dr.GetTimeSpan(5);
                    visiting_to = dr.GetTimeSpan(6);
                    Doctor doctor = new Doctor(doctorId, firstName, lastName,
                        sex, specialization, visiting_from, visiting_to);
                    allDoctors.Add(doctor);
                

            }
            return allDoctors;
        }

        //method to validate patient details
        public bool validatePatient( string firstName,
            string lastName, string sex, int age, string dob)
        {
            string NameRegex = "[^A-Za-z0-9]";
            Regex re = new Regex(NameRegex);

            if (re.IsMatch(firstName) || re.IsMatch(lastName))
            {
                throw new FirstLastNameException("Please Enter Valid First Name Or Last Name");
            }

            if(age<0 || age > 120)
            {
                throw new AgeException("Please enter valid age between 0-120");
            }

            DateTime date;
            if (!DateTime.TryParseExact(dob, "dd'/'MM'/'yyyy",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out date))
            {
                throw new IndianDateFormatException("Please enter date in dd/mm/yyyy format");
            }


            return true;

        }

        //method to add new patient to db
        public int addPatient(Patient p,out int patientid)
        {
            conn = getConnection();
            comm = new SqlCommand("sp_addPatients");
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@firstName",p.firstName);
            comm.Parameters.AddWithValue("@lastName", p.lastName);
            comm.Parameters.AddWithValue("@sex", p.sex);
            comm.Parameters.AddWithValue("@age", p.age);
            comm.Parameters.AddWithValue("@dob", p.dob);
            int success = comm.ExecuteNonQuery();
            comm1 = new SqlCommand("select patient_id from patients where firstname=@firstname and lastname=@lastname and sex=@sex and age=@age and dob=@dob",conn);
            comm1.Parameters.AddWithValue("@firstName", p.firstName);
            comm1.Parameters.AddWithValue("@lastName", p.lastName);
            comm1.Parameters.AddWithValue("@sex", p.sex);
            comm1.Parameters.AddWithValue("@age", p.age);
            comm1.Parameters.AddWithValue("@dob", p.dob);
            SqlDataReader sd=comm1.ExecuteReader();
            sd.Read();
            patientid = sd.GetInt32(0);
            return success;
        }


        //method to view all the patients
        public List<Patient> viewPatients()
        {
            List<Patient> allPatients = new List<Patient>();
            conn = getConnection();
            comm = new SqlCommand("select * from patients", conn);
            SqlDataReader dr = comm.ExecuteReader();
            int patientId;
            string firstName;
            string lastName;
            string sex;
            int age;
            DateTime dob;


            while (dr.Read())
            {
                patientId = dr.GetInt32(0);
                firstName = dr.GetString(1);
                lastName = dr.GetString(2);
                sex = dr.GetString(3);
                age = dr.GetInt32(4);
                dob = dr.GetDateTime(5);

                Patient p = new Patient(patientId, firstName, lastName, sex, age, dob);

                allPatients.Add(p);


            }
            return allPatients;
        }
    }
}
