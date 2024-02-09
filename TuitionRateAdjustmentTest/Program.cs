using BITCollege_NF.Data;
using BITCollege_NF.Models;




namespace BITCollege_NF
{
    class Program
    {
        private static BITCollege_NFContext db;

        static void Main(string[] args) 
        {
            suspendedState_TuitionRateAdjustment_Test();
        }

        static void suspendedState_TuitionRateAdjustment_Test()
        {
            db = new BITCollege_NFContext();

            double newTuition = 0;

            Student student = new Student();
            student.AcademicProgramId = 1;
            student.GradePointStateId = 1;
            student.GradePointAverage = 1;

            SuspendedState suspendedState;

            suspendedState = SuspendedState.GetInstance();
            newTuition = suspendedState.TuitionRateAdjustment(student);

            Console.WriteLine("Student Tuition: ", newTuition);
        }
    }
}