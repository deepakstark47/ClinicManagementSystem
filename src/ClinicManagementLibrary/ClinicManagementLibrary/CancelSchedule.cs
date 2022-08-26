﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;

namespace ClinicManagementLibrary
{
    public class CancelSchedule : ICancelSchedule
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



        public List<Appointment> displayAppointmentsOfPatient(int patientId, DateTime cancelDate)
        {
            List<Appointment> Appointments = new List<Appointment>();

            conn = getConnection();
            comm = new SqlCommand("select * from appointments where patient_id=@patientId and date_of_visit=@cancelDate",conn);
            comm.Parameters.AddWithValue("@patientId", patientId);
            comm.Parameters.AddWithValue("@cancelDate", cancelDate);
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Appointments.Add(new Appointment(dr.GetInt32(0), dr.GetInt32(1), dr.GetDateTime(2),
                    dr.GetString(3), dr.GetString(4),dr.GetInt32(5)));
            }

            return Appointments;
        }

        public int cancelAppointment(int appid,int patient_id)
        {
            conn = getConnection();
            comm = new SqlCommand("update appointments set apt_status='Available',patient_id=null where aptId=@appid and patient_id=@patient_id", conn);
            comm.Parameters.AddWithValue("@appid", appid);
            comm.Parameters.AddWithValue("@patient_id", patient_id);
            int success = comm.ExecuteNonQuery();
            if (success == 1)
            {
                return success;
            }
            throw new AppointmentIdNotValidException("Appointment Number Not Valid ");
        }

        public bool ValidatePatientId(int patientId)
        {
            conn = getConnection();
            comm = new SqlCommand("select * from patients where patient_id =@patientId", conn);
            comm.Parameters.AddWithValue("@patientId", patientId);
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            throw new PatientIdDoesNotExistException("Please enter valid patient id");
        }

        public bool ValidateIndianFormatDate(string date1)
        {
            DateTime date;
            if (!DateTime.TryParseExact(date1, "dd'/'MM'/'yyyy",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out date))
            {
                throw new IndianDateFormatException("Please enter valid date dd/mm/yyyy format");
            }


            return true;
        }
    }
}
