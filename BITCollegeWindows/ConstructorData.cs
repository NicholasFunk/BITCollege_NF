using BITCollege_NF.Models;
using BITCollege_NF.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BITCollegeWindows
{
    /// <summary>
    /// ConstructorData:  This class is used to capture data to be passed
    /// among the windows forms.
    /// Further code to be added.
    /// </summary>
    public class ConstructorData
    {


        // Pass student related information to the form.
        public int StudentId { get; set; }

        public int GradePointStateId { get; set; }

        public int? AcademicProgramId { get; set; }

        public long StudentNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public DateTime DateCreated { get; set; }
        public double? GradePointAverage { get; set; }
        public double OutstandingFees { get; set; }
        public string Notes { get; set; }

        public string FullName { get; }

        public string FullAddress { get; }

        // Pass registration related information to the form.
        public int RegstrationId { get; set; }

        public int RegistrationStudentId { get; set; }

        public int CourseId { get; set; }

        public long RegistrationNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public double? Grade { get; set; }

        public string RegistrationNotes { get; set; }

    }
}
