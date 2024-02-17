using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BITCollege_NF.Data
{
    public class BITCollege_NFContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BITCollege_NFContext() : base("name=BITCollege_NFContext")
        {
        }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.AcademicProgram> AcademicPrograms { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.GradePointState> GradePointStates { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.Registration> Registrations { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.ProbationState> ProbationStates { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.SuspendedState> SuspendedStates { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.HonoursState> HonoursStates { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.RegularState> RegularStates { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.AuditCourse> AuditCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.GradedCourse> GradedCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.MasteryCourse> MasteryCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.NextUniqueNumber> NextUniqueNumbers { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.NextAuditCourse> NextAuditCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.NextGradedCourse> NextGradedCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.NextMasteryCourse> NextMasteryCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_NF.Models.NextRegistration> NextRegistrations { get; set; }
    }
}
