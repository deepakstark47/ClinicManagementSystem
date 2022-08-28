using System;
using ClinicManagementLibrary;
using System.Data.SqlClient;
namespace ClinicManagementClient
{
    class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("***********************************");
            Console.WriteLine("Welcome to Clinic Management System");
            Console.WriteLine("***********************************");
            Console.WriteLine("-----------------------------------");
            while (true)
            {
            try
                {
                Console.WriteLine("***********************************");
                Console.WriteLine("Login Page");
                Console.WriteLine("***********************************");
                Console.WriteLine("Enter the username:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter the password:");
                string password = Console.ReadLine();
                Login login = new Login();
                IHome home = new Home();
                IScheduleAppointment sa = new ScheduleAppointment();
                ICancelSchedule cs = new CancelSchedule();

                    login.loginUser(username, password);
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Login Successful");
                    Console.WriteLine("-----------------------------------");
                    
                    while (true)
                    {
                        Console.WriteLine("***********************************");
                        Console.WriteLine("Home Page");
                        Console.WriteLine("***********************************");
                        
                        Console.WriteLine("1.View All Doctors");
                        Console.WriteLine("2.Add Patient");
                        Console.WriteLine("3.Schedule Appointment");
                        Console.WriteLine("4.Cancel Appointment");
                        Console.WriteLine("5.View All Patients");
                        Console.WriteLine("6.Logout");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Enter the option");
                        int option = Convert.ToInt32(Console.ReadLine());
                        if (option == 6)
                        {
                            break;
                        }
                        switch (option)
                        {
                            case 1:
                                {
                                    List<Doctor> doc = home.viewDoctors();
                                    Console.WriteLine("-----------------------------------");
                                    Console.WriteLine("Doctors in the clinic");
                                    Console.WriteLine("-----------------------------------");

                                    foreach (Doctor d in doc)
                                    {
                                        Console.WriteLine("-------------------------------------");
                                        Console.WriteLine($"doctor id : {d.doctorId} \nfirstName : {d.firstName}\n" +
                                            $"lastName : {d.lastName} \nsex : {d.sex} \nspecialization : {d.specialization} " +
                                            $"\nvisiting from : {d.visiting_from} \nvisiting to : {d.visiting_to}");

                                        Console.WriteLine("-------------------------------------");
                                    }
                                    break;
                                }

                            case 2:
                                {
                                    try
                                    {
                                     Console.WriteLine("-----------------------------------");
                                     Console.WriteLine("Add new patient");
                                     Console.WriteLine("-----------------------------------");
                                     Console.WriteLine("Enter the firstname:");
                                     string firstName = Console.ReadLine();
                                     Console.WriteLine("Enter the lastname:");
                                     string lastName = Console.ReadLine();
                                     Console.WriteLine("Enter the sex:");
                                     string sex = Console.ReadLine();
                                     Console.WriteLine("Enter the age:");
                                     int age = Convert.ToInt32(Console.ReadLine());
                                     Console.WriteLine("Enter the dob:");
                                     string dob = Console.ReadLine();
                                    
                                     home.validatePatient(firstName, lastName, sex, age, dob);
                                            DateTime dateofbirth = Convert.ToDateTime(dob);
                                            Patient p = new Patient(firstName, lastName, sex, age, dateofbirth);
                                            int returnedid;
                                            int result = home.addPatient(p, out returnedid);
                                            if (result == 1)
                                            {
                                            Console.WriteLine("-----------------------------------");

                                            Console.WriteLine("Patient " + firstName + " was inserted successfully");
                                            
                                            Console.WriteLine("The patient id is :" + returnedid);
                                            Console.WriteLine("-----------------------------------");

                                        }
                                        else
                                            {
                                                Console.WriteLine("Patient is not inserted!! server error");
                                            }

                                        }
                                        catch(Exception ex)
                                     {
                                        Console.WriteLine(ex.Message);
                                     }
                                    Console.WriteLine("-------------------------------------");
                                    break;
                                }

                            case 3:
                                {
                                    try
                                    {
                                    Console.WriteLine("-------------------------------------");
                                    Console.WriteLine("Schedule Appointment");

                                    Console.WriteLine("-------------------------------------");

                                    Console.WriteLine("Enter the patient id");
                                    int pid = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("-------------------------------------");
                                    Console.WriteLine("Available specializations : General , Ortho , Internal Medicine , Pediatrics , Opthalmology");
                                    Console.WriteLine("-------------------------------------");
                                    Console.WriteLine("Enter the specialization");
                                    string spec = Console.ReadLine();
                                    
                                        sa.ValidateScheduleAppointment(pid, spec);
                                        List<Doctor> doc = sa.displayDoctorsBasedOnSpecialization(spec);
                                        List<int> validDocIds = new List<int>();
                                        foreach (Doctor d in doc)
                                        {
                                            validDocIds.Add(d.doctorId);
                                            Console.WriteLine("-------------------------------------");
                                            Console.WriteLine($"doctor id : {d.doctorId} \nfirstName : {d.firstName}\n" +
                                                $"lastName : {d.lastName} \nsex : {d.sex} \nspecialization : {d.specialization} " +
                                                $"\nvisiting from : {d.visiting_from} \nvisiting to : {d.visiting_to}");

                                            Console.WriteLine("-------------------------------------");
                                        }
                                        Console.WriteLine("The available dates for booking are  : [26/08/2022 to 03/08/2022]");
                                        Console.WriteLine("Enter the Date of Appointment");
                                        string dateofapp = Console.ReadLine();
                                        sa.ValidateIndianFormatDate(dateofapp);
                                        sa.ValidateDateForApp(dateofapp);
                                        Console.WriteLine("Enter the Doctor id");
                                        int docid = Convert.ToInt32(Console.ReadLine());
                                        sa.validateDoctorId(docid, validDocIds);
                                        DateTime dateofappointment = DateTime.Parse(dateofapp);
                                        List<Appointment> app = sa.getAllSlotsForDoctor(docid, dateofappointment);
                                        Console.WriteLine("-------------------------------------");
                                        Console.WriteLine("The available slots are");
                                        Console.WriteLine("-------------------------------------");
                                        List<int> validAppointments = new List<int>();
                                        foreach (Appointment a in app)
                                            {
                                                validAppointments.Add(a.appId);
                                                Console.WriteLine("-------------------------------------");
                                                Console.WriteLine($"Appointment id : {a.appId} \nDoctor id : {a.doctorId}\n" +
                                                    $"Date : {a.visitingDate.ToShortDateString()} \nAppointment Time : {a.appTime} \nStatus : {a.appStatus} " +
                                                    $"\nPatient id : {a.patientId} ");

                                                Console.WriteLine("-------------------------------------");
                                            }
                                            Console.WriteLine("-----------------------------------");
                                            Console.WriteLine("Enter the appointmentId");
                                            int appointmentId = Convert.ToInt32(Console.ReadLine());
                                            sa.bookAppointment(appointmentId, pid,validAppointments);
                                            Console.WriteLine("Apoointment successfully booked for patient id " + pid);
                                            Console.WriteLine("Your appointment id is " + appointmentId);
                                            

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }


                                    Console.WriteLine("-------------------------------------");
                                    break;
                                }

                            case 4:
                                {
                                    try
                                    {
                                        Console.WriteLine("-------------------------------------");
                                        Console.WriteLine("Cancel the appointment");
                                        Console.WriteLine("-------------------------------------");

                                        Console.WriteLine("Enter the patient id");
                                        int pid = Convert.ToInt32(Console.ReadLine());
                                
                                        cs.ValidatePatientId(pid);
                                        Console.WriteLine("The available dates for cancellation  are : [26/08/2022 to 03/08/2022]");
                                        Console.WriteLine("Enter the Cancel date");
                                        string date = Console.ReadLine();
                                        cs.ValidateIndianFormatDate(date);
                                        cs.ValidateDateForApp(date);
                                        
                                        DateTime dt = Convert.ToDateTime(date);
                                        List<Appointment> appP = cs.displayAppointmentsOfPatient(pid, dt);
                                        Console.WriteLine("-------------------------------------");
                                        Console.WriteLine("The booked appointments are");
                                        Console.WriteLine("-------------------------------------");
                                        foreach (Appointment a in appP)
                                            {
                                                    Console.WriteLine("-------------------------------------");
                                                    Console.WriteLine($"Appointment id : {a.appId} \nDoctor id : {a.doctorId}\n" +
                                                        $"Date : {a.visitingDate.ToShortDateString()} \nAppointment Time : {a.appTime} \nStatus : {a.appStatus} " +
                                                        $"\nPatient id : {a.patientId} ");

                                                    Console.WriteLine("-------------------------------------");
                                            }
                                        
                                      Console.WriteLine("Enter the appointment id to cancel");
                                      int appid = Convert.ToInt32(Console.ReadLine());
                                      cs.cancelAppointment(appid,pid);
                                      Console.WriteLine("Appointment of id " + appid + " is cancelled successfully");
                                                
                                        
                                       
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    List<Patient> patient = home.viewPatients();
                                    foreach (Patient p in patient)
                                    {
                                        Console.WriteLine("-------------------------------------");
                                        Console.WriteLine($"patient id : {p.patientId} \nfirstName : {p.firstName}\n" +
                                            $"lastName : {p.lastName} \nsex : {p.sex} \nage : {p.age} " +
                                            $"\nDate Of Birth : {p.dob}");

                                        Console.WriteLine("-------------------------------------");
                                    }
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("*****************************");
                                    Console.WriteLine("Please enter valid option");
                                    Console.WriteLine("*****************************");

                                    break;
                                }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                
                
            }
        }
    }
}