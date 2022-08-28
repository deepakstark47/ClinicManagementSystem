﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;

namespace ClinicManagementLibrary
{
    public class ScheduleAppointment:IScheduleAppointment
    {
        static SqlConnection conn;
        static SqlCommand comm;
        private static SqlConnection getConnection()
        {
            conn = new SqlConnection("Data Source =.; Initial Catalog" +
                " = clinicmanagement; Integrated Security = True");
            conn.Open();
            return conn;
        }

        public bool ValidateScheduleAppointment(int patientId,string spec)
        {
            conn = getConnection();
            comm = new SqlCommand("sp_selectPatientById", conn);
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@patientId", patientId);
            SqlDataReader dr = comm.ExecuteReader();
            if (!dr.HasRows)
            {
                throw new PatientIdDoesNotExistException("Patient id does not exist pls recheck");
            }

            List<string> specs = new List<string>();


            specs.Add("Ortho");
            specs.Add("Pediatrics");
            specs.Add("General");
            specs.Add("Internal Medicine");
            specs.Add("Opthalmology");
            
            
            if (!specs.Contains(spec))
            {
                throw new SpecializationDoesNotExist("Specialization does not exist");
            }



            return true;

        }

        public bool ValidateIndianFormatDate(string date1)
        {
            DateTime date;
            if (!DateTime.TryParseExact(date1, "dd'/'MM'/'yyyy",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out date))
            {
                throw new IndianDateFormatException("Pls enter date in dd/mm/yyyy format");
            }


            return true;
        }



        public List<Doctor> displayDoctorsBasedOnSpecialization(string spec)
        {
            List<Doctor> Doctors = new List<Doctor>();

            conn = getConnection();
            comm = new SqlCommand("sp_selectDoctorsSpec", conn);
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@specialization",spec);
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
                Doctors.Add(doctor);


            }
            return Doctors;
        }

        public List<Appointment> getAllSlotsForDoctor(int docid,DateTime date)
        {
            List<Appointment> Appointments = new List<Appointment>();

            conn = getConnection();
            comm = new SqlCommand("sp_selectFreeAppointments");
            comm.Connection = conn;
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@docid", docid);
            comm.Parameters.AddWithValue("@date", date);
            SqlDataReader dr =comm.ExecuteReader();
            if (!dr.HasRows)
            {
                throw new NoSlotAvailableException("No free slots are avilable for the doctor on this date!!");
            }
            while (dr.Read())
            { 
                Appointments.Add(new Appointment(dr.GetInt32(0),dr.GetInt32(1),dr.GetDateTime(2),
                    dr.GetString(3), dr.GetString(4)));
            }

            return Appointments;

        }

        public int bookAppointment(int aptId,int patientId,List<int> validAppointmentIds)
        {
            if (!validAppointmentIds.Contains(aptId))
            {
                throw new AppointmentIdNotValidException("Appointment id not valid pls enter valid id");
            }
            conn = getConnection();
            comm = new SqlCommand("sp_updateAppointmentStatusBooked", conn);
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@aptId",aptId);
            comm.Parameters.AddWithValue("@patientId", patientId);
            int success = comm.ExecuteNonQuery();
            if (success == 1)
            {
                return success;
            }
            throw new AppointmentIdNotValidException("Appointment id not valid pls enter valid id");
        }

        public bool ValidateDateForApp(string date)
        {
            List<string> ValidDates = new List<string>() { "26/08/2022","27/08/2022" ,"28/08/2022", 
                "29/08/2022", "30/08/2022", "31/08/2022","01/09/2022","02/09/2022","03/09/2022" };
            if (ValidDates.Contains(date))
            {
                return true;
            }
            throw new ValidDateException("Pls Enter Date Between 26/08/2022 - 03/09/2022");
        }

        public bool validateDoctorId(int docid,List<int> validDocIds)
        {
            if (validDocIds.Contains(docid))
            {
                return true;
            }
            throw new ValidDoctorIdException("Doctor id is not under given specialization or doctor id does not exist");  
        }

    }
}
