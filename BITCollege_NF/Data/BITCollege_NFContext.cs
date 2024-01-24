using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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
    }
}
