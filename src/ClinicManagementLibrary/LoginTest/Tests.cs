using ClinicManagementLibrary;
namespace TestingLibrary
{
    public class Tests
    {
        ILogin ilog;
        IHome ihome;
        IScheduleAppointment iapp;
        ICancelSchedule ican;
        [SetUp]
        public void Setup()
        {
            ilog= new Login();
            ihome = new Home();
            iapp=new ScheduleAppointment();
            ican = new CancelSchedule();
        }

        [Test]
        public void testLogin()
        {
            bool actualValue = ilog.loginUser("basid2","basid@12345");
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void testGetAllDoctors()
        {
            int actualValue = ihome.viewDoctors().Count;
            int expectedValue = 5;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void testAddPatient()
        {
            int a;
            int actualValue = ihome.addPatient(new Patient("Madan","Gowri","M",29,Convert.ToDateTime("11/10/2000")),out a );
            int expectedValue = 1;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void testValidatePatient()
        {
            bool actualValue = ihome.validatePatient( "Madan", "Gowri", "M", 21, "12/12/2000");
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);

        }

        [Test]
        public void testGetAllDoctorsOnSpec()
        {
            int actualValue = iapp.displayDoctorsBasedOnSpecialization("General").Count;
            int expectedValue = 1;
            Assert.AreEqual(expectedValue, actualValue);
        }


        [Test]
        public void testGetAllSlots()
        {
            int actualValue = iapp.getAllSlotsForDoctor(1002,DateTime.Parse("27/08/2022")).Count();
            int expectedValue = 2; 
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void testBookAppointment()
        {
            int actualValue = iapp.bookAppointment(502,10);
            int expectedValue = 1;
            Assert.AreEqual(expectedValue, actualValue);
        }


        [Test]
        public void testValidateScheduleApp()
        {
            bool actualValue = iapp.ValidateScheduleAppointment(10,"General");
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void testValidateIndianFormatDate()
        {
            bool actualValue = iapp.ValidateIndianFormatDate("21/11/2000");
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void testdisplayAppointmentsOfPatient()
        {
            int actualValue = ican.displayAppointmentsOfPatient(10, DateTime.Parse("26/08/2022")).Count();
            int expectedValue = 1;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void testCancelAppointment()
        {
            int actualValue = ican.cancelAppointment(502, 10);
            int expectedValue = 1;
            Assert.AreEqual(expectedValue, actualValue);
        }

    }
}