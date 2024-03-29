using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BITCollege_NF.Data;
using BITCollege_NF.Models;

namespace BITCollegeWindows
{
    public partial class History : Form
    {
        BITCollege_NFContext db = new BITCollege_NFContext();

        ///given:  student and registration data will passed throughout 
        ///application. This object will be used to store the current
        ///student and selected registration
        ConstructorData constructorData;

        /// <summary>
        /// given:  This constructor will be used when called from the
        /// Student form.  This constructor will receive 
        /// specific information about the student and registration
        /// further code required:  
        /// </summary>
        /// <param name="constructorData">constructorData object containing
        /// specific student and registration data.</param>
        public History(ConstructorData constructorData)
        {
            InitializeComponent();
            this.constructorData = constructorData;
            studentNumberMaskedTextBox.Text = this.constructorData.studentData.StudentNumber.ToString();
            descriptionLabel1.Text = this.constructorData.studentData.AcademicProgram.Description.ToString();
            fullNameLabel1.Text = this.constructorData.studentData.FullName;
        }


        /// <summary>
        /// given: This code will navigate back to the Student form with
        /// the specific student and registration data that launched
        /// this form.
        /// </summary>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //return to student with the data selected for this form
            StudentData student = new StudentData(constructorData);
            student.MdiParent = this.MdiParent;
            student.Show();
            this.Close();
        }

        /// <summary>
        /// given:  Open this form in top right corner of the frame.
        /// further code required:
        /// </summary>
        private void History_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            var query = from registrations in db.Registrations
                        join courses in db.Courses
                        on registrations.CourseId equals courses.CourseId
                        where registrations.StudentId == constructorData.studentData.StudentId
                        select registrations;

            registrationBindingSource.DataSource = query.ToList();
        }
    }
}
