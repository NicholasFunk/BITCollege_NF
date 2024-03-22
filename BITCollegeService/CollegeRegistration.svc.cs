using BITCollege_NF.Data;
using BITCollege_NF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Security;
using Utility;

namespace BITCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CollegeRegistration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CollegeRegistration.svc or CollegeRegistration.svc.cs at the Solution Explorer and start debugging.
    public class CollegeRegistration : ICollegeRegistration
    {
        BITCollege_NFContext db = new BITCollege_NFContext();

        public void DoWork()
        {
        }

        /// <summary>
        /// Drops a course from a Students Registration
        /// </summary>
        /// <param name="registrationId">Registration Id</param>
        /// <returns>Returns a success value of True or False.</returns>
        public bool DropCourse(int registrationId)
        {
            // Queries for one registrationId.
            Registration registration = db.Registrations.Where(x => x.RegstrationId == registrationId).SingleOrDefault();
            try
            {
                if (registration != null)
                {
                    db.Registrations.Remove(registration);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if a Student is eligible to register for a course.
        /// </summary>
        /// <param name="studentId">Student Id</param>
        /// <param name="courseId">Course Id</param>
        /// <param name="notes">Notes</param>
        /// <returns>Returns the approriate code value.</returns>
        public int RegisterCourse(int studentId, int courseId, string notes)
        {
            int codeValue = 0;
            int maximumAttempts = 0;
            int numberOfRegistrations = 0;
            double courseTuition = 0;


            IQueryable<Registration> registrations = db.Registrations.Where(x => x.StudentId == studentId && x.CourseId == courseId);

            Course courseRecord = db.Courses.Where(c => c.CourseId == courseId).SingleOrDefault();
            Student studentRecord = db.Students.Where(s => s.StudentId == studentId).SingleOrDefault();

            foreach (Registration record in registrations.ToList())
            {
                if (record.Grade == null)
                {
                    codeValue = -100;
                }
                numberOfRegistrations += 1;
            }

            if (BusinessRules.CourseTypeLookup(courseRecord.CourseType) == CourseType.MASTERY)
            {
                MasteryCourse masteryCourse = (MasteryCourse)courseRecord;
                maximumAttempts = masteryCourse.MaximumAttempts;
            }

            if (numberOfRegistrations >= maximumAttempts)
            {
                codeValue = -200;
            }

            try
            {
                Registration registration = new Registration();
                registration.StudentId = studentId;
                registration.CourseId = courseId;
                registration.Notes = notes;
                registration.RegistrationDate = DateTime.Today;
                registration.RegistrationNumber = NextRegistration.GetInstance().NextAvailableNumber;
                db.Registrations.AddOrUpdate(registration);
                db.SaveChanges();

                courseTuition = courseRecord.TuitionAmount;
                studentRecord.OutstandingFees = courseTuition;

                studentRecord.GradePointState.TuitionRateAdjustment(studentRecord);

                db.Students.AddOrUpdate(studentRecord);
                db.SaveChanges();

            }
            catch (Exception)
            {
                codeValue = -300;
            }

            return codeValue;
        }

        public double? UpdateGrade(double grade, int registrationId, string notes)
        {
            Registration registration = db.Registrations.Where(x => x.RegstrationId == registrationId).SingleOrDefault();

            registration.Grade = grade;
            registration.Notes = notes;
            db.Registrations.AddOrUpdate(registration);
            db.SaveChanges();
            double? GradePointAverage = CalculateGradePointAverage(registration.StudentId);

            return GradePointAverage;
        }

        /// <summary>
        /// Calculates the Grade Point Average of a Student.
        /// </summary>
        /// <param name="studentId">Student Id</param>
        /// <returns>Returns the calculated GPA of a Student.</returns>
        private double? CalculateGradePointAverage(int studentId)
        {
            double grade = 0;
            CourseType courseType;
            double gradePoint = 0;
            double gradePointValue = 0;
            double totalCreditHours = 0;
            double totalGradePointValues = 0;
            Double? calculatedGradePointAverage = 0;

            IQueryable<Registration> registrations = db.Registrations.Where(x => x.Grade != null && x.StudentId == studentId);

            foreach (Registration record in registrations.ToList())
            {
                grade = (double)record.Grade;
                courseType = BusinessRules.CourseTypeLookup(record.Course.CourseType);
                // If course type is of the audit type, exclude it from the calculation.
                // GPA formula
                if (courseType != CourseType.AUDIT)
                {
                    gradePoint = BusinessRules.GradeLookup(grade, courseType);
                    gradePointValue = (double)(gradePoint * getCreditHours(record));
                    totalGradePointValues += gradePointValue;
                    totalCreditHours += (double)getCreditHours(record);
                }

            }

            if (totalCreditHours == 0)
            {
                calculatedGradePointAverage = null;
            }

            calculatedGradePointAverage = totalGradePointValues / totalCreditHours;

            Student student = db.Students.Where(s => s.StudentId == studentId).SingleOrDefault();
            student.GradePointAverage = calculatedGradePointAverage;
            db.Students.AddOrUpdate(student);
            db.SaveChanges();

            return calculatedGradePointAverage;
        }

        /// <summary>
        /// Gets the total Credit Hours of a registered course.
        /// </summary>
        /// <param name="record">record</param>
        /// <returns>Returns the number of credit hours for a course record.</returns>
        double getCreditHours(Registration record)
        {
            return record.Course.CreditHours;
        }
    }
}
