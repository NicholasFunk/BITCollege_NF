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
using Microsoft.Ajax.Utilities;
using System.EnterpriseServices;
using BITCollege_NF.Data;
using BITCollege_NF.Models;
using WebGrease.Css.Extensions;

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
            GradePointState gps = db.GradePointStates.Find(GradePointStateId);

            int tempId = -1;

            while (tempId != GradePointStateId)
            {
                tempId = GradePointStateId;
                gps.StateChangeCheck(this);
            }
        }

        public void SetNextStudentNumber()
        {
            StudentNumber = (long)StoredProcedure.NextNumber("NextStudent");
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

        private SuspendedState()
        {
            this.LowerLimit = 0.00;
            this.UpperLimit = 1.00;
            this.TuitionRateFactor = 1.10;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
            // Automatically adds 10% to a Suspended Student's Tuition.
            double adjustedTuition = student.OutstandingFees * this.TuitionRateFactor;

            if (student.GradePointAverage < 0.50)
            {
                adjustedTuition *= 1.05; // 5% increase
            }
            else if (student.GradePointAverage < 0.75)
            {
                adjustedTuition *= 1.02; // 2% increase
            }

            return adjustedTuition;
        }

        // When we edit a student, invoke student.
        public override void StateChangeCheck(Student student)
        {
            if (student.GradePointAverage > this.UpperLimit)
            {
                student.GradePointStateId = ProbationState.GetInstance().GradePointStateId;
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
            // Automatically adds 7.5% to a Probation Student's Tuition.
            int completedCoursesCount = 0;
            double adjustedTuition = 0;

            // Get a collection of all registered courses by a particular student.
            IQueryable<Registration> registrations = db.Registrations.Where(x => x.StudentId == student.StudentId);

            // Count each course the student has a grade for. These are completed courses.
            foreach (Registration record in registrations.ToList())
            {
                if (record.Grade != null)
                {
                    completedCoursesCount += 1;
                }
            }

            if (completedCoursesCount >= 5)
            {
                adjustedTuition *= 1.035;
            }
            else
            {
                adjustedTuition *= this.TuitionRateFactor;
            }

            return adjustedTuition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
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

    /// <summary>
    /// GradedCourse Model
    /// Represents the GradedCourse subclass table in the database
    /// </summary>
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

    /// <summary>
    /// MasteryCourse Model
    /// Represents the MasteryCourse subclass table in the database
    /// </summary>
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

    /// <summary>
    /// AuditCourse Model
    /// Represents the AuditCourse subclass table in the database
    /// </summary>
    public class AuditCourse : Course
    {
        /// <summary>
        /// Sets the CourseNumber property to the next available 
        /// </summary>
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
        /// Sets the RegistrationNumber property to the next available registration number.
        /// </summary>
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
    /// <summary>
    /// StoredProcedures Model
    /// Represents the StoredProcedures class table in the database
    /// </summary>
    static class StoredProcedure
    {
        /// <summary>
        /// Used to find the next available number for a table PK.
        /// The discriminator is used to filter out the type of course/state.
        /// </summary>
        /// <param name="discriminator">Used to select a row in the database.</param>
        /// <returns>long? returnValue, the next number in the database.</returns>
        /// <exception cref="NullReferenceException">Throw if null is detected.</exception>
        public static long? NextNumber(String discriminator)
        {
            try
            {
                long? returnValue = 0;

                SqlConnection connection = new SqlConnection("Data Source=LAPTOP-KBQF560I\\MARS; " + "Initial Catalog=BITCollege_NF; Integrated Security=True");
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
    /// <summary>
    /// NextUniqueNumber Model
    /// Represents the NextUniqueNumber class table in the database
    /// </summary>
    public abstract class NextUniqueNumber
    {
        protected static Data.BITCollege_NFContext db = new Data.BITCollege_NFContext();

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextUniqueNumberId { get; set; }

        [Required]
        public long NextAvailableNumber { get; set; }
    }

    /// <summary>
    /// NextStudent Model
    /// Represents the NextStudent subclass table in the database
    /// </summary>
    public class NextStudent : NextUniqueNumber
    {
        private static NextStudent nextStudent;

        private NextStudent()
        {
            this.NextAvailableNumber = 20000000;
        }

        /// <summary>
        /// Represents a single instance of the NextStudent class
        /// </summary>
        /// <returns>Returns a single object of the NextStudent class</returns>
        public static NextStudent GetInstance()
        {
            if (nextStudent == null)
            {
                nextStudent = db.NextStudents.SingleOrDefault();
                if (nextStudent == null)
                {
                    nextStudent = new NextStudent();
                    db.NextStudents.Add(nextStudent);
                    db.SaveChanges();
                }
            }
            return nextStudent;
        }
    }

    /// <summary>
    /// NextRegistration Model
    /// Represents the NextRegistration subclass table in the database
    /// </summary>
    public class NextRegistration : NextUniqueNumber
    {
        private static NextRegistration nextRegistration;

        private NextRegistration()
        {
            this.NextAvailableNumber = 700;
        }

        /// <summary>
        /// Represents a single instance of the NextRegistration class
        /// </summary>
        /// <returns>Returns a single object of the NextRegistration class</returns>
        public static NextRegistration GetInstance()
        {
            if (nextRegistration == null)
            {
                nextRegistration = db.NextRegistrations.SingleOrDefault();
                if (nextRegistration == null)
                {
                    nextRegistration = new NextRegistration();
                    db.NextRegistrations.Add(nextRegistration);
                    db.SaveChanges();
                }
            }
            return nextRegistration;
        }

    }

    /// <summary>
    /// NextGradedCourse Model
    /// Represents the NextGradedCourse subclass table in the database
    /// </summary>
    public class NextGradedCourse : NextUniqueNumber
    {
        private static NextGradedCourse nextGradedCourse;

        private NextGradedCourse()
        {
            this.NextAvailableNumber = 200000;
        }

        /// <summary>
        /// Represents a single instance of the NextGradedCourse class
        /// </summary>
        /// <returns>Returns a single object of the NextGradedCourse class</returns>
        public static NextGradedCourse GetInstance()
        {
            if (nextGradedCourse == null)
            {
                nextGradedCourse = db.NextGradedCourses.SingleOrDefault();
                if (nextGradedCourse == null)
                {
                    nextGradedCourse = new NextGradedCourse();
                    db.NextGradedCourses.Add(nextGradedCourse);
                    db.SaveChanges();
                }
            }
            return nextGradedCourse;
        }
    }

    /// <summary>
    /// NextAuditCourse Model
    /// Represents the NextAuditCourse subclass table in the database
    /// </summary>
    public class NextAuditCourse : NextUniqueNumber
    {
        private static NextAuditCourse nextAuditCourse;

        private NextAuditCourse()
        {
            this.NextAvailableNumber = 2000;
        }

        /// <summary>
        /// Represents a single instance of the NextAuditCourse class
        /// </summary>
        /// <returns>Returns a single object of the NextAuditCourse class</returns>
        public static NextAuditCourse GetInstance()
        {
            if (nextAuditCourse == null)
            {
                nextAuditCourse = db.NextAuditCourses.SingleOrDefault();
                if (nextAuditCourse == null)
                {
                    nextAuditCourse = new NextAuditCourse();
                    db.NextAuditCourses.Add(nextAuditCourse);
                    db.SaveChanges();
                }
            }
            return nextAuditCourse;
        }
    }

    /// <summary>
    /// NextMasteryCourse Model
    /// Represents the NextMasteryCourse subclass table in the database
    /// </summary>
    public class NextMasteryCourse : NextUniqueNumber
    {
        private static NextMasteryCourse nextMasteryCourse;

        private NextMasteryCourse()
        {
            this.NextAvailableNumber = 20000;
        }

        /// <summary>
        /// Represents a single instance of the NextMasterCourse class
        /// </summary>
        /// <returns>Returns a single object of the NextMasteryCourse class</returns>
        public static NextMasteryCourse GetInstance()
        {
            if (nextMasteryCourse == null)
            {
                nextMasteryCourse = db.NextMasteryCourses.SingleOrDefault();
                if (nextMasteryCourse == null)
                {
                    nextMasteryCourse = new NextMasteryCourse();
                    db.NextMasteryCourses.Add(nextMasteryCourse);
                    db.SaveChanges();
                }
            }
            return nextMasteryCourse;
        }
    }
    #endregion
}
