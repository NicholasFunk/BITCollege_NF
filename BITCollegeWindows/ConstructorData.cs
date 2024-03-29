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
        public Student studentData { get; set; }

        public IQueryable<Registration> registrationData { get; set; }

    }
}
