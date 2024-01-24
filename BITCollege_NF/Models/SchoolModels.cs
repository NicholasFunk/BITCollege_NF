using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.ComponentModel.Design.Serialization;

namespace BITCollege_NF.Models
{
    /// <summary>
    /// Student Model
    /// Represents the Student table in the database
    /// </summary>
    public class Student
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        [ForeignKey("GradePointState")]
        public int GradePointStateId { get; set; }

        [ForeignKey("AcademicProgram")]
        public int? AcademicProgramId { get; set; }

        [Required]
        [MinLength(10000000)]
        [MaxLength(99999999)]
        [Display(Name ="Student\nNumber")]
        public string StudentNumber { get; set; }

        [Required]
        [Display(Name ="First\nName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last\nName")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }


        [Required]
        [RegularExpression("^(N[BLSTU]|[AMN]B|[BQ]C|ON|PE|SK|YT)", ErrorMessage ="Please enter a valid 2 Character Province.")]
        public string Province { get; set; }


        [Required]
        [Display(Name ="Date")]
        [DisplayFormat(DataFormatString ="{0:d}")]
        public DateTime DateCreated { get; set; }


        [Display(Name ="Grade Point\nAverage")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        [Range(0, 4.5)]
        public double? GradePointAverage { get; set; }

        [Required]
        [Display(Name ="Fees")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        public double OutstandingFees { get; set; }

        public string Notes { get; set; }

        [Display(Name ="Name")]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        [Display(Name ="Address")]
        public string FullAdress
        {
            get
            {
                return String.Format("{0} {1} {2}", Address, City, Province);
            }
        }

        /// <summary>
        /// Navigation Property
        /// Represents a 1 or 0-1 Cardinality with the GradePointState table in the database
        /// Virtual allows the navigation property to support lazy loading
        /// </summary>
        public virtual GradePointState GradePointState { get; set; }

        /// <summary>
        /// Navigation Property.
        /// Represents a 1 or 0-1 Cardinality with the AcademicProgram table in the database
        /// Virtual allows the navigation property to support lazy loading
        /// </summary>
        public virtual AcademicProgram AcademicProgram { get; set; }

        /// <summary>
        /// Navigation Property. 
        /// Represent * or 0-* or 1-* cardinality with the Registration table in the database
        /// Virtual allows the navigation property to support lazy loading
        /// </summary>
        public virtual ICollection<Registration> Registration { get; set; }
    }

    /// <summary>
    /// AcademicProgram Model
    /// Represents the AcademicProgram table in the database
    /// </summary>
    public class AcademicProgram
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AcademicProgramId { get; set; }

        [Required]
        [Display(Name = "Program")]
        public string ProgramAcronym { get; set; }

        [Required]
        [Display(Name = "Program\nName")]
        public string Description { get; set; }

        /// <summary>
        /// Navigation Property
        /// Represent * or 0-* or 1-* cardinality with the Student table in the database
        /// Virtual allows the navigation property to support lazy loading
        /// 
        /// </summary>
        public virtual ICollection<Student> Student { get; set; }

        /// <summary>
        /// Navigation Property 
        /// Represent * or 0-* or 1-* cardinality with the Course table in the database
        /// Virtual allows the navigation property to support lazy loading
        /// </summary>
        public virtual ICollection<Course> Course { get; set; }
    }

    /// <summary>
    /// GradePointState Model 
    /// Represents the GradePointState table in the database
    /// </summary>
    public abstract class GradePointState
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GradePointStateId { get; set; }

        [Required]
        [Display(Name ="Lower\nLimit")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double LowerLimit { get; set; }

        [Required]
        [Display(Name ="Upper\nLimit")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double UpperLimit { get; set; }

        [Required]
        [Display(Name ="Tuition Rate\nFactor")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double TuitionRateFactor { get; set; }

        [Display(Name ="State")]
        public string Description
        {
            get
            {
                string input = GetType().Name;
                string digits = string.Concat(input.Where(char.IsDigit));
                string state = "State";
                string output = String.Format("{0}", input.Substring(0, input.Length - digits.Length - state.Length));
                output = output.Trim(' ');

                return output;

            }
        }

        /// <summary>
        /// Navigation Property
        /// Represent * or 0-* or 1-* cardinality with the Student table in the database.
        /// Virtual allows the navigation property to support lazy loading
        /// </summary>

        public virtual ICollection<Student> Student { get; set; }

    }

    public class SuspendedState : GradePointState
    {
        private SuspendedState suspendedState;
    }

    public class ProbationState : GradePointState
    {
        private ProbationState probationState;
    }

    public class HonoursState : GradePointState
    {
        private HonoursState honoursState;
    }

    public class RegularState : GradePointState
    {
        private RegularState regularState;
    }

    /// <summary>
    /// Registration Model 
    /// Represents the Registration table in the database
    /// </summary>
    public class Registration
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RegstrationId { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Required]
        [Display(Name = "Registration\nNumber")]
        public long RegistrationNumber { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime RegistrationDate { get; set; }

        [Range(0, 1)]
        [DisplayFormat(NullDisplayText = "Ungraded")]
        public double? Grade { get; set; }

        public string Notes { get; set; }

        /// <summary>
        /// Navigation Property.
        /// Represents an exactly 1 Cardinality with the Student table in the database.
        /// </summary>
        public virtual Student Student { get; set; }

        /// <summary>
        /// Navigation Property.
        /// Represents an exactly 1 Cardinality with the Student table in the database.
        /// </summary>
        public virtual Course Course { get; set; }
    }

    /// <summary>
    /// Course Model 
    /// Represents the Course table in the database
    /// </summary>
    public abstract class Course
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [ForeignKey("AcademicProgram")]
        public int? AcademicProgramId { get; set; }

        [Required]
        [Display(Name = "Course\nNumber")]
        public string CourseNumber { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Credit\nHours")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double CreditHours { get; set; }

        [Required]
        [Display(Name = "Tuition")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double TuitionAmount { get; set; }

        [Display(Name ="Course\nType")]
        public string CourseType 
        { 
            get 
            {
         
                    string input = GetType().Name;
                    string digits = string.Concat(input.Where(char.IsDigit));
                    string state = "State";
                    string output = String.Format("{0}", input.Substring(0, input.Length - digits.Length - state.Length));
                    output = output.Trim(' ');

                    return output;

                
            } 
        }

        public string Notes { get; set; }

        /// <summary>
        /// Navigation Property
        /// Represents a 1 or 0-1 Cardinality with the Student table in the database
        /// Virtual allows the navigation property to support lazy loading
        /// </summary>
        public virtual AcademicProgram AcademicProgram { get; set; }

        /// <summary>
        /// Navigation Property
        /// Represent * or 0-* or 1-* cardinality with the Course table in the database
        /// Virtual allows the navigation property to support lazy loading
        /// </summary>
        public virtual ICollection<Registration> Registration { get; set; }
    }

    public class GradedCourse : Course
    {
        [Required]
        [Display(Name ="Assignments")]
        [DisplayFormat(DataFormatString = "{0:%%}")]
        public double AssignmentWeight { get; set; }

        [Required]
        [Display(Name ="Exams")]
        [DisplayFormat(DataFormatString = "{0:%%}")]
        public double ExamWeight { get; set; }
    }
    
    public class MasteryCourse : Course
    {
        [Required]
        [Display(Name ="Maximum\nAttempts")]
        public int MaximumAttempts { get; set; }
    }

    public class AuditCourse : Course
    {

    }

}
