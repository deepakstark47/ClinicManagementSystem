using System;
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
            comm = new SqlCommand("select * from patients where patient_id =@patientId", conn);
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
            comm = new SqlCommand("select * from doctors where specialization = @specialization", conn);
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
            comm = new SqlCommand("select * from appointments where doctor_id=@docid and apt_status='Available' and date_of_visit =@date");
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@docid", docid);
            comm.Parameters.AddWithValue("@date", date);
            SqlDataReader dr =comm.ExecuteReader();
            while (dr.Read())
            { 
                Appointments.Add(new Appointment(dr.GetInt32(0),dr.GetInt32(1),dr.GetDateTime(2),
                    dr.GetString(3), dr.GetString(4)));
            }

            return Appointments;

        }

        public int bookAppointment(int aptId,int patientId)
        {
            conn = getConnection();
            comm = new SqlCommand("update appointments set apt_status='booked',patient_id=@patientId where aptId=@aptId", conn);
            comm.Parameters.AddWithValue("@aptId",aptId);
            comm.Parameters.AddWithValue("@patientId", patientId);
            int success = comm.ExecuteNonQuery();
            if (success == 1)
            {
                return success;
            }
            throw new AppointmentIdNotValidException("Appointment id not valid pls enter valid id");
        }

    }
}
