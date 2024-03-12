using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BITCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CollegeRegistration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CollegeRegistration.svc or CollegeRegistration.svc.cs at the Solution Explorer and start debugging.
    public class CollegeRegistration : ICollegeRegistration
    {
        public void DoWork()
        {
        }

        public bool DropCourse(int registrationId)
        {
            throw new NotImplementedException();
        }

        public int RegisterCourse(int studentId, int courseId, string notes)
        {
            throw new NotImplementedException();
        }

        public double? UpdateGrade(double grade, int registrationId, string notes)
        {
            throw new NotImplementedException();
        }

        private double? CalculateGradePointAverage(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
