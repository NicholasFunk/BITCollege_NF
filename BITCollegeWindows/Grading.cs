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
            /*Discussion
            • When the user enters a Grade (e.g. 0.50), the TextBox (if formatted correctly – see
            above) will correctly display the Grade as 50.00%. However, the entered grade must be
            updated as 0.50 according to the rules placed on the field when the model was
            designed. Therefore, the percent formatting must be stripped and the Grade value
            must be divided by 100 (getting it back to the original 0.50 value) before capturing that
            value for database update.
            Requirement
            • Use given functionality in the Utility project to define a String which will contain the
            value from the TextBox without the percent formatting.
            • Use given functionality in the Utility project to ensure that the above value is numeric.
            o If non-numeric:
            ▪ Display an appropriate MessageBox to the end user and do not proceed
            with the update.
            o If numeric:
            ▪ Divide the above value by 100 and ensure this value is within the 0 - 1
            range of numeric values.
            ▪ If not within the range, display an appropriate MessageBox to the end
            user and do not proceed with the update.
            • Ensure the Messagebox explains that the grade must be entered
            as a decimal value such that it appropriately displays when
            formatted as a percent.
            ▪ If the data is within the proper range of values, use the Client Endpoint of
            the WCF Web Service (created in an earlier assignment) to update the
            Grade, the Student’s GradePointAverage and corresponding Grade Point
            State.
            • Disable the Grade TextBox so that no further Grade modification can be made. This will
            also give the user a visual cue that the update has completed.
            */
        }

    }
}
