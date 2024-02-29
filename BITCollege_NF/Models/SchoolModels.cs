using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.ComponentModel.Design.Serialization;
using System.Data.SqlClient;

// Recovered from clone


namespace BITCollege_NF.Models
{
    #region Student
    /// <summary>
    /// Student Model
    /// Represents the Student table in the database
    /// </summary>
    public class Student
    {

        private Data.BITCollege_NFContext db = new Data.BITCollege_NFContext();

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        [ForeignKey("GradePointState")]
        public int GradePointStateId { get; set; }

        [ForeignKey("AcademicProgram")]
        public int? AcademicProgramId { get; set; }

        [Required]
        [Range(10000000, 99999999)]
        [Display(Name = "Student\nNumber")]
        public long StudentNumber { get; set; }

        [Required]
        [Display(Name = "First\nName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last\nName")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }


        [Required]
        [RegularExpression("^(N[BLSTU]|[AMN]B|[BQ]C|ON|PE|SK|YT)", ErrorMessage = "Please enter a valid 2 Character Province.")]
        public string Province { get; set; }


        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateCreated { get; set; }


        [Display(Name = "Grade Point\nAverage")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        [Range(0, 4.5)]
        public double? GradePointAverage { get; set; }

        [Required]
        [Display(Name = "Fees")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double OutstandingFees { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        [Display(Name = "Address")]
        public string FullAddress
        {
            get
            {
                return String.Format("{0} {1} {2}", Address, City, Province);
            }
        }

        public void ChangeState()
        {
            // Ask current state, if it needs to change.
            // Comparing Student GradePointStateId in database to the new one on Edit or Create Post.
            // Repeatedly Check, until it is done changing.
            // Temp store state id and compare to the state id after the check
            // If we check and find that we need to change

            while (this.GradePointStateId != GradePointState.GradePointStateId)
            {
                int tempId = GradePointStateId;
                GradePointState.StateChangeCheck(this);
            }
        }

        public void SetNextStudentNumber()
        {
            StudentNumber = (long)StoredProcedure.NextNumber("NextStudentNumber");
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
    #endregion 

    #region AcademicProgram
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
    #endregion

    #region GradePointStates
    /// <summary>
    /// GradePointState Model 
    /// Represents the GradePointState table in the database
    /// </summary>
    public abstract class GradePointState
    {

        protected static Data.BITCollege_NFContext db = new Data.BITCollege_NFContext();

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GradePointStateId { get; set; }

        [Required]
        [Display(Name = "Lower\nLimit")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double LowerLimit { get; set; }

        [Required]
        [Display(Name = "Upper\nLimit")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double UpperLimit { get; set; }

        [Required]
        [Display(Name = "Tuition Rate\nFactor")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double TuitionRateFactor { get; set; }

        [Display(Name = "State")]
        public string Description
        {
            get
            {
                string input = GetType().Name;

                string output = String.Format("{0}", input.Substring(0, input.Length - 5));
                output = output.Trim(' ');

                return output;

            }
        }

        public abstract double TuitionRateAdjustment(Student student);

        public abstract void StateChangeCheck(Student student);

        /// <summary>
        /// Navigation Property
        /// Represent * or 0-* or 1-* cardinality with the Student table in the database.
        /// Virtual allows the navigation property to support lazy loading
        /// </summary>

        public virtual ICollection<Student> Student { get; set; }

    }

    public class SuspendedState : GradePointState
    {
        private static SuspendedState suspendedState;

        private SuspendedState() { this.LowerLimit = 0.00; this.UpperLimit = 1.00; this.TuitionRateFactor = 1.10; }

        public static SuspendedState GetInstance()
        {
            if (suspendedState == null)
            {
                suspendedState = db.SuspendedStates.SingleOrDefault();
                if (suspendedState == null)
                {
                    suspendedState = new SuspendedState();
                    db.SuspendedStates.Add(suspendedState);
                    db.SaveChanges();
                }
            }
            return suspendedState;
        }

        public override double TuitionRateAdjustment(Student student)
        {

            double tuition = 1000;
            double adjustedTuition = 0;

            if (student.GradePointAverage < 0.75)
            {
                adjustedTuition = tuition * 1.02; // 2% increase
            }
            else
            {
                adjustedTuition = tuition * 1.01; // 1% increase
            }

            return adjustedTuition;
        }

        // When we edit a student, invoke student.
        public override void StateChangeCheck(Student student)
        {
            if (student.GradePointAverage > this.UpperLimit)
            {
                student.GradePointStateId = SuspendedState.GetInstance().GradePointStateId;
            }
            db.SaveChanges();
        }

    }

    public class ProbationState : GradePointState
    {
        private static ProbationState probationState;

        private ProbationState()
        {
            this.LowerLimit = 1.00;
            this.UpperLimit = 2.00;
            this.TuitionRateFactor = 1.075;
        }

        public static ProbationState GetInstance()
        {
            if (probationState == null)
            {
                probationState = db.ProbationStates.SingleOrDefault();
                if (probationState == null)
                {
                    probationState = new ProbationState();
                    db.ProbationStates.Add(probationState);
                    db.SaveChanges();
                }
            }

            return probationState;
        }

        public override double TuitionRateAdjustment(Student student)
        {
            // For Students with a Probation GradePointState, the TuitionRateFactor for each newly registered course has already been defined as 1.075. As such, all ProbationState students will pay an additional 7.5% for each newly registered course.
            // If the Student has completed 5 or more courses, tuition for each newly registered course is increased by only 3.5
            double adjustedTuition = 0;
            // If student has completed 5 or more courses
            //      Tuition adjustment is 3.5%
            // Else
            //      Tuition adjustment is 7.5%

            return adjustedTuition;
        }

        public override void StateChangeCheck(Student student)
        {
            if (student.GradePointAverage > this.UpperLimit)
            {
                student.GradePointStateId = RegularState.GetInstance().GradePointStateId;
            }
            else if (student.GradePointAverage < this.LowerLimit)
            {
                student.GradePointStateId = SuspendedState.GetInstance().GradePointStateId;
            }

            db.SaveChanges();
        }
    }

    public class HonoursState : GradePointState
    {
        private static HonoursState honoursState;
        private HonoursState()
        {
            this.LowerLimit = 3.70;
            this.UpperLimit = 4.5;
            this.TuitionRateFactor = 0.90;
        }
        public static HonoursState GetInstance()
        {
            if (honoursState == null)
            {
                honoursState = db.HonoursStates.SingleOrDefault();

                if (honoursState == null)
                {
                    honoursState = new HonoursState();
                    db.HonoursStates.Add(honoursState);
                    db.SaveChanges();
                }
            }

            return honoursState;
        }

        public override double TuitionRateAdjustment(Student student)
        {
            /* For Students with an Honours GradePointState, the TuitionRateFactor for each newly registered course has already  been defined as 0.90. As such, all Honours students will pay 10% less for each newly registered course.
               If the Student has achieved an Honours GradePointState after having completed 5 or more courses, tuition for each newly registered course is discounted by an additional 5 %.
               Programming 3 Assignment 3
               11
                Note: a completed course is defined as a Registration in which the Grade property is not NULL.
                If the Student’s GradePointAverage is above 4.25, the student will receive an additional 2 % discount.
                Note: The above scenarios are mutually exclusive.As such, a student can be eligible for both discounts.
            */

            // Pseudo code
            // if student has an honours grade point state
            //      tuition adjustment pay 10% less
            // if student has an honours grade point state and completed 5 or more courses
            //      tuition adjustment pay 15% less
            // if student GPA is greater than 4.25
            //      tuition adjusment additional 2% discount

            return 0;
        }

        public override void StateChangeCheck(Student student)
        {
            if (student.GradePointAverage < this.LowerLimit)
            {
                student.GradePointStateId = RegularState.GetInstance().GradePointStateId;
            }
            db.SaveChanges();
        }
    }

    public class RegularState : GradePointState
    {
        private static RegularState regularState;

        private RegularState()
        {
            this.LowerLimit = 2.00;
            this.UpperLimit = 3.70;
            this.TuitionRateFactor = 1.0;
        }

        public static RegularState GetInstance()
        {
            if (regularState == null)
            {
                regularState = db.RegularStates.SingleOrDefault();
                if (regularState == null)
                {
                    regularState = new RegularState();
                    db.RegularStates.Add(regularState);
                    db.SaveChanges();
                }
            }

            return regularState;
        }

        public override double TuitionRateAdjustment(Student student)
        {
            // For Students with a Regular GradePointState, the TuitionRateFactor for each newly registered course has already been defined as 1. As such, there will be no adjustments made to the cost of tuition for all RegularState students.
            return 0;
        }

        public override void StateChangeCheck(Student student)
        {
            if (student.GradePointAverage > this.UpperLimit)
            {
                student.GradePointStateId = HonoursState.GetInstance().GradePointStateId;
            }
            else if (student.GradePointAverage < this.LowerLimit)
            {
                student.GradePointStateId = ProbationState.GetInstance().GradePointStateId;
            }
            db.SaveChanges();
        }
    }
    #endregion

    #region Courses
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

        [Display(Name = "Course\nType")]
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

        public void SetNextCourseNumber()
        {
            // Used for later implementation...
        }

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
        [Display(Name = "Assignments")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public double AssignmentWeight { get; set; }

        [Required]
        [Display(Name = "Exams")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public double ExamWeight { get; set; }

        new public void SetNextCourseNumber()
        {
            CourseNumber = "G- " + StoredProcedure.NextNumber("NextGradedCourse");
        }
    }

    public class MasteryCourse : Course
    {
        [Required]
        [Display(Name = "Maximum\nAttempts")]
        public int MaximumAttempts { get; set; }

        new public void SetNextCourseNumber()
        {
            CourseNumber = "M- " + StoredProcedure.NextNumber("NextMasteryCourse");
        }
    }

    public class AuditCourse : Course
    {
        new public void SetNextCourseNumber()
        {
            CourseNumber = "A- " + StoredProcedure.NextNumber("NextAuditCourse");
        }
    }
    #endregion

    #region Registration
    /// <summary>
    /// Registration Model 
    /// Represents the Registration table in the database
    /// </summary>
    public class Registration
    {
        [Key]
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

        public void SetNextRegistrationNumber()
        {
            RegistrationNumber = (long)StoredProcedure.NextNumber("NextRegistration");
        }

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
    #endregion

    #region Procedures
    static class StoredProcedure
    {
        public static long? NextNumber(String discriminator)
        {
            try
            {
                long? returnValue = 0;

                SqlConnection connection = new SqlConnection("Data Srouce=localhost; " + "Initial Catalog=BITCollege_NFContext; Integrated Security=True");
                SqlCommand storedProcedure = new SqlCommand("next_number", connection);
                storedProcedure.CommandType = System.Data.CommandType.StoredProcedure;
                storedProcedure.Parameters.AddWithValue("@Discriminator", discriminator);
                SqlParameter outputParameter = new SqlParameter("@NewVal", System.Data.SqlDbType.BigInt) { Direction = System.Data.ParameterDirection.Output };
                storedProcedure.Parameters.Add(outputParameter);
                connection.Open();
                storedProcedure.ExecuteNonQuery();
                connection.Close();
                returnValue = (long?)outputParameter.Value;
                return returnValue;
            }
            catch (ArgumentNullException)
            {
                throw null;
            }
        }
    }
    #endregion

    #region NextUniqueNumber & Subclasses

    public abstract class NextUniqueNumber
    {
        protected static Data.BITCollege_NFContext db = new Data.BITCollege_NFContext();

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextUniqueNumberId { get; set; }

        [Required]
        public long NextAvailableNumber { get; set; }
    }

    public class NextStudent : NextUniqueNumber
    {
        private static NextStudent nextStudent;

        private NextStudent()
        {
            this.NextAvailableNumber = 20000000;
        }

        public static NextStudent GetInstance()
        {
            return nextStudent;
        }
    }

    public class NextRegistration : NextUniqueNumber
    {
        private static NextRegistration nextRegistration;

        private NextRegistration()
        {
            this.NextAvailableNumber = 700;
        }

        public static NextRegistration GetInstance()
        {
            return nextRegistration;
        }
    }

    public class NextGradedCourse : NextUniqueNumber
    {
        private static NextGradedCourse nextGradedCourse;

        private NextGradedCourse()
        {
            this.NextAvailableNumber = 200000;
        }

        public static NextGradedCourse GetInstance()
        {
            return nextGradedCourse;
        }
    }

    public class NextAuditCourse : NextUniqueNumber
    {
        private static NextAuditCourse nextAuditCourse;

        private NextAuditCourse()
        {
            this.NextAvailableNumber = 2000;
        }

        public static NextAuditCourse GetInstance()
        {
            return nextAuditCourse;
        }
    }

    public class NextMasteryCourse : NextUniqueNumber
    {
        private static NextMasteryCourse nextMasteryCourse;

        private NextMasteryCourse()
        {
            this.NextAvailableNumber = 20000;
        }

        public static NextMasteryCourse GetInstance()
        {
            return nextMasteryCourse;
        }
    }
    #endregion
}
