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

        public int RegisterCourse(int studentId, int courseId, string notes)
        {
            // This method will make use of various return codes to indicate success or failure. In the
            // event that the course registration fails, the return code will indicate the reason



            throw new NotImplementedException();
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

        double getCreditHours(Registration record) {
            return record.Course.CreditHours;
        }
    }
}
