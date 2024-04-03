using BITCollege_NF.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace BITCollegeWindows
{
    public partial class Grading : Form
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
        public Grading(ConstructorData constructor)
        {
            InitializeComponent();
            constructorData = constructor;

            studentBindingSource.DataSource = constructorData.studentData;
            registrationBindingSource.DataSource = constructorData.registrationData;
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
        /// given:  Always open in this form in the top right corner of the frame.
        /// further code required:
        /// </summary>
        private void Grading_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            courseNumberMaskedLabel.Mask = BusinessRules.CourseFormat(constructorData.registrationData.Course.CourseType);
            switch (constructorData.registrationData.Grade)
            {
                case null:
                    gradeTextBox.Enabled = true;
                    lnkUpdate.Enabled = true;
                    break;

                default:
                    gradeTextBox.Enabled = false;
                    lnkUpdate.Enabled = false;
                    lblExisting.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Handles the logic for updating a student grade
        /// </summary>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String newGrade = Numeric.ClearFormatting(gradeTextBox.Text, "%");
            double numericGrade = 0;

            if (Numeric.IsNumeric(newGrade, System.Globalization.NumberStyles.Number))
            {
                numericGrade = Convert.ToDouble(newGrade) / 100;
                switch (numericGrade)
                {
                    case double i when i > 0 && i <= 1:
                        // Use WCF Web Service to update the grade.
                        BITCollegeServiceReference.CollegeRegistrationClient collegeRegistration = new BITCollegeServiceReference.CollegeRegistrationClient();
                        collegeRegistration.UpdateGrade(numericGrade, constructorData.registrationData.RegstrationId, constructorData.registrationData.Notes);
                        gradeTextBox.Enabled = false;
                        break;
                    default:
                        // Display a messagebox about the error
                        string message = "A grade must be entered as a decimal: 0.## and will be displayed as a percent.";
                        string caption = "Invalid Entry!";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK);
                        break;
                }
            }
            else
            {
                // Display a messagebox about the error
                string message = "Input value is not of a numeric type.";
                string caption = "Invalid Input: Not Numeric";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
        }
    }
}
