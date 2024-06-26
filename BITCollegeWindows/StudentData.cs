﻿using BITCollege_NF.Data;
using BITCollege_NF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BITCollegeWindows
{
    public partial class StudentData : Form
    {
        ///Given: Student and Registration data will be retrieved
        ///in this form and passed throughout application
        ///These variables will be used to store the current
        ///Student and selected Registration
        ConstructorData constructorData = new ConstructorData();


        /// <summary>
        /// Used to Retrieve Student and Registration records.
        /// </summary>
        BITCollege_NFContext db = new BITCollege_NFContext();

        /// <summary>
        /// This constructor will be used when this form is opened from
        /// the MDI Frame.
        /// </summary>
        public StudentData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given:  This constructor will be used when returning to StudentData
        /// from another form.  This constructor will pass back
        /// specific information about the student and registration
        /// based on activites taking place in another form.
        /// </summary>
        /// <param name="constructorData">constructorData object containing
        /// specific student and registration data.</param>
        public StudentData(ConstructorData constructor)
        {
            InitializeComponent();
            constructorData = constructor;
            studentNumberMaskedTextBox.Text = constructorData.studentData.StudentNumber.ToString();
            studentNumberMaskedTextBox_Leave(null, null);
        }

        /// <summary>
        /// given: Open grading form passing constructor data.
        /// </summary>
        private void lnkUpdateGrade_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Querry the current registration selection
            Registration registrationGrade = db.Registrations.Where(r => r.RegistrationNumber.ToString() == registrationNumberComboBox.SelectedValue.ToString()).SingleOrDefault();
            constructorData.registrationData = registrationGrade;
            Grading grading = new Grading(constructorData);
            grading.MdiParent = this.MdiParent;
            grading.Show();
            this.Close();
        }


        /// <summary>
        /// given: Open history form passing constructor data.
        /// </summary>
        private void lnkViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            constructorData.selectedRegistration = registrationNumberComboBox.SelectedIndex;
            History history = new History(constructorData);
            history.MdiParent = this.MdiParent;
            history.Show();
            this.Close();
        }

        /// <summary>
        /// given:  Opens the form in top right corner of the frame.
        /// </summary>
        private void StudentData_Load(object sender, EventArgs e)
        {
            //keeps location of form static when opened and closed
            this.Location = new Point(0, 0);
        }

        private void studentNumberMaskedTextBox_Leave(object sender, EventArgs e)
        {

            // Define a LINQ to SQL query selecting data from the Students table whose StudentNumber matches the value in the MaskedTextBox
            studentRecordQuery();
            studentDataCheck();

            if (constructorData.studentData != null)
            {
                registrationRecordsQuery();
                registrationsDataCheck();
            }

            // Grade point state changes when we update the registration grades.
        }

        public void studentRecordQuery()
        {
            Student studentRecord = db.Students.Where(s => s.StudentNumber.ToString() == studentNumberMaskedTextBox.Text).SingleOrDefault();
            constructorData.studentData = studentRecord;
        }

        public void registrationRecordsQuery()
        {
            IQueryable<Registration> registrationRecords = db.Registrations.Where(r => r.StudentId == constructorData.studentData.StudentId);
            constructorData.registrations = registrationRecords;
        }

        public void studentDataCheck()
        {
            switch (constructorData.studentData)
            {
                case null:
                    // Disable links
                    lnkUpdateGrade.Enabled = false;
                    lnkViewDetails.Enabled = false;
                    studentNumberMaskedTextBox.Focus();
                    studentBindingSource.DataSource = typeof(Student);

                    // Display a messagebox about the error
                    string message = "Student " + studentNumberMaskedTextBox.Text + " does not exist.";
                    string caption = "Invalid Student Number";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    break;

                default:
                    // Establishes a new datasource from the successful student query.
                    if (constructorData.studentData != null)
                    {
                        studentBindingSource.DataSource = constructorData.studentData;
                    }
                    break;
            }
        }

        public void registrationsDataCheck()
        {
            if (constructorData.registrations.Count() < 1)
            {
                fullNameLabel1.Text = "";
                fullAddressLabel1.Text = "";
                dateCreatedLabel1.Text = "";
                descriptionLabel1.Text = "";
                gradePointAverageLabel1.Text = "";
                outstandingFeesLabel1.Text = "";
                lnkUpdateGrade.Enabled = false;
                lnkViewDetails.Enabled = false;
                studentNumberMaskedTextBox.Focus();
                registrationBindingSource.DataSource = typeof(Registration);

                // Display a messagebox about the error
                string message = "Student " + studentNumberMaskedTextBox.Text + " does not have any registrations.";
                string caption = "No Registered Courses Available";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
            else
            {
                registrationBindingSource.DataSource = constructorData.registrations.ToList();
                lnkUpdateGrade.Enabled = true;
                lnkViewDetails.Enabled = true;
            }
        }

    }
}
