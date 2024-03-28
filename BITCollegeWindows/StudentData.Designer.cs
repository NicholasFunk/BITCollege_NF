namespace BITCollegeWindows
{
    partial class StudentData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label studentNumberLabel;
            System.Windows.Forms.Label fullAddressLabel;
            System.Windows.Forms.Label dateCreatedLabel;
            System.Windows.Forms.Label gradePointAverageLabel;
            System.Windows.Forms.Label outstandingFeesLabel;
            System.Windows.Forms.Label courseNumberLabel;
            System.Windows.Forms.Label registrationNumberLabel;
            System.Windows.Forms.Label creditHoursLabel;
            System.Windows.Forms.Label titleLabel;
            this.grpStudent = new System.Windows.Forms.GroupBox();
            this.grpRegistration = new System.Windows.Forms.GroupBox();
            this.lnkUpdateGrade = new System.Windows.Forms.LinkLabel();
            this.lnkViewDetails = new System.Windows.Forms.LinkLabel();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.studentNumberTextBox = new System.Windows.Forms.TextBox();
            this.fullAddressTextBox = new System.Windows.Forms.TextBox();
            this.dateCreatedTextBox = new System.Windows.Forms.TextBox();
            this.gradePointAverageTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.outstandingFeesTextBox = new System.Windows.Forms.TextBox();
            this.registrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courseNumberTextBox = new System.Windows.Forms.TextBox();
            this.registrationNumberComboBox = new System.Windows.Forms.ComboBox();
            this.creditHoursTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            fullNameLabel = new System.Windows.Forms.Label();
            studentNumberLabel = new System.Windows.Forms.Label();
            fullAddressLabel = new System.Windows.Forms.Label();
            dateCreatedLabel = new System.Windows.Forms.Label();
            gradePointAverageLabel = new System.Windows.Forms.Label();
            outstandingFeesLabel = new System.Windows.Forms.Label();
            courseNumberLabel = new System.Windows.Forms.Label();
            registrationNumberLabel = new System.Windows.Forms.Label();
            creditHoursLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            this.grpStudent.SuspendLayout();
            this.grpRegistration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grpStudent
            // 
            this.grpStudent.Controls.Add(outstandingFeesLabel);
            this.grpStudent.Controls.Add(this.outstandingFeesTextBox);
            this.grpStudent.Controls.Add(this.descriptionTextBox);
            this.grpStudent.Controls.Add(gradePointAverageLabel);
            this.grpStudent.Controls.Add(this.gradePointAverageTextBox);
            this.grpStudent.Controls.Add(dateCreatedLabel);
            this.grpStudent.Controls.Add(this.dateCreatedTextBox);
            this.grpStudent.Controls.Add(fullAddressLabel);
            this.grpStudent.Controls.Add(this.fullAddressTextBox);
            this.grpStudent.Controls.Add(studentNumberLabel);
            this.grpStudent.Controls.Add(this.studentNumberTextBox);
            this.grpStudent.Controls.Add(fullNameLabel);
            this.grpStudent.Controls.Add(this.fullNameTextBox);
            this.grpStudent.Location = new System.Drawing.Point(47, 58);
            this.grpStudent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpStudent.Name = "grpStudent";
            this.grpStudent.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpStudent.Size = new System.Drawing.Size(816, 251);
            this.grpStudent.TabIndex = 0;
            this.grpStudent.TabStop = false;
            this.grpStudent.Text = "Student Data";
            // 
            // grpRegistration
            // 
            this.grpRegistration.Controls.Add(titleLabel);
            this.grpRegistration.Controls.Add(this.titleTextBox);
            this.grpRegistration.Controls.Add(creditHoursLabel);
            this.grpRegistration.Controls.Add(this.creditHoursTextBox);
            this.grpRegistration.Controls.Add(registrationNumberLabel);
            this.grpRegistration.Controls.Add(this.registrationNumberComboBox);
            this.grpRegistration.Controls.Add(courseNumberLabel);
            this.grpRegistration.Controls.Add(this.courseNumberTextBox);
            this.grpRegistration.Location = new System.Drawing.Point(47, 331);
            this.grpRegistration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpRegistration.Name = "grpRegistration";
            this.grpRegistration.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpRegistration.Size = new System.Drawing.Size(816, 190);
            this.grpRegistration.TabIndex = 1;
            this.grpRegistration.TabStop = false;
            this.grpRegistration.Text = "Registration Data";
            // 
            // lnkUpdateGrade
            // 
            this.lnkUpdateGrade.AutoSize = true;
            this.lnkUpdateGrade.Location = new System.Drawing.Point(263, 571);
            this.lnkUpdateGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkUpdateGrade.Name = "lnkUpdateGrade";
            this.lnkUpdateGrade.Size = new System.Drawing.Size(93, 16);
            this.lnkUpdateGrade.TabIndex = 2;
            this.lnkUpdateGrade.TabStop = true;
            this.lnkUpdateGrade.Text = "Update Grade";
            this.lnkUpdateGrade.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdateGrade_LinkClicked);
            // 
            // lnkViewDetails
            // 
            this.lnkViewDetails.AutoSize = true;
            this.lnkViewDetails.Location = new System.Drawing.Point(508, 571);
            this.lnkViewDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkViewDetails.Name = "lnkViewDetails";
            this.lnkViewDetails.Size = new System.Drawing.Size(81, 16);
            this.lnkViewDetails.TabIndex = 3;
            this.lnkViewDetails.TabStop = true;
            this.lnkViewDetails.Text = "View Details";
            this.lnkViewDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkViewDetails_LinkClicked);
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(BITCollege_NF.Models.Student);
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(50, 88);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(71, 16);
            fullNameLabel.TabIndex = 2;
            fullNameLabel.Text = "Full Name:";
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "FullName", true));
            this.fullNameTextBox.Location = new System.Drawing.Point(213, 85);
            this.fullNameTextBox.Multiline = true;
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(540, 31);
            this.fullNameTextBox.TabIndex = 3;
            // 
            // studentNumberLabel
            // 
            studentNumberLabel.AutoSize = true;
            studentNumberLabel.Location = new System.Drawing.Point(50, 38);
            studentNumberLabel.Name = "studentNumberLabel";
            studentNumberLabel.Size = new System.Drawing.Size(106, 16);
            studentNumberLabel.TabIndex = 3;
            studentNumberLabel.Text = "Student Number:";
            // 
            // studentNumberTextBox
            // 
            this.studentNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "StudentNumber", true));
            this.studentNumberTextBox.Location = new System.Drawing.Point(213, 35);
            this.studentNumberTextBox.Multiline = true;
            this.studentNumberTextBox.Name = "studentNumberTextBox";
            this.studentNumberTextBox.Size = new System.Drawing.Size(147, 27);
            this.studentNumberTextBox.TabIndex = 4;
            // 
            // fullAddressLabel
            // 
            fullAddressLabel.AutoSize = true;
            fullAddressLabel.Location = new System.Drawing.Point(50, 125);
            fullAddressLabel.Name = "fullAddressLabel";
            fullAddressLabel.Size = new System.Drawing.Size(85, 16);
            fullAddressLabel.TabIndex = 4;
            fullAddressLabel.Text = "Full Address:";
            // 
            // fullAddressTextBox
            // 
            this.fullAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "FullAddress", true));
            this.fullAddressTextBox.Location = new System.Drawing.Point(213, 122);
            this.fullAddressTextBox.Multiline = true;
            this.fullAddressTextBox.Name = "fullAddressTextBox";
            this.fullAddressTextBox.Size = new System.Drawing.Size(540, 34);
            this.fullAddressTextBox.TabIndex = 5;
            // 
            // dateCreatedLabel
            // 
            dateCreatedLabel.AutoSize = true;
            dateCreatedLabel.Location = new System.Drawing.Point(50, 169);
            dateCreatedLabel.Name = "dateCreatedLabel";
            dateCreatedLabel.Size = new System.Drawing.Size(90, 16);
            dateCreatedLabel.TabIndex = 6;
            dateCreatedLabel.Text = "Date Created:";
            // 
            // dateCreatedTextBox
            // 
            this.dateCreatedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "DateCreated", true));
            this.dateCreatedTextBox.Location = new System.Drawing.Point(213, 166);
            this.dateCreatedTextBox.Name = "dateCreatedTextBox";
            this.dateCreatedTextBox.Size = new System.Drawing.Size(147, 22);
            this.dateCreatedTextBox.TabIndex = 7;
            // 
            // gradePointAverageLabel
            // 
            gradePointAverageLabel.AutoSize = true;
            gradePointAverageLabel.Location = new System.Drawing.Point(50, 201);
            gradePointAverageLabel.Name = "gradePointAverageLabel";
            gradePointAverageLabel.Size = new System.Drawing.Size(136, 16);
            gradePointAverageLabel.TabIndex = 8;
            gradePointAverageLabel.Text = "Grade Point Average:";
            // 
            // gradePointAverageTextBox
            // 
            this.gradePointAverageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "GradePointAverage", true));
            this.gradePointAverageTextBox.Location = new System.Drawing.Point(213, 198);
            this.gradePointAverageTextBox.Name = "gradePointAverageTextBox";
            this.gradePointAverageTextBox.Size = new System.Drawing.Size(147, 22);
            this.gradePointAverageTextBox.TabIndex = 9;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "GradePointState.Description", true));
            this.descriptionTextBox.Location = new System.Drawing.Point(375, 198);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(147, 22);
            this.descriptionTextBox.TabIndex = 11;
            // 
            // outstandingFeesLabel
            // 
            outstandingFeesLabel.AutoSize = true;
            outstandingFeesLabel.Location = new System.Drawing.Point(532, 172);
            outstandingFeesLabel.Name = "outstandingFeesLabel";
            outstandingFeesLabel.Size = new System.Drawing.Size(115, 16);
            outstandingFeesLabel.TabIndex = 11;
            outstandingFeesLabel.Text = "Outstanding Fees:";
            // 
            // outstandingFeesTextBox
            // 
            this.outstandingFeesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "OutstandingFees", true));
            this.outstandingFeesTextBox.Location = new System.Drawing.Point(653, 169);
            this.outstandingFeesTextBox.Name = "outstandingFeesTextBox";
            this.outstandingFeesTextBox.Size = new System.Drawing.Size(100, 22);
            this.outstandingFeesTextBox.TabIndex = 12;
            // 
            // registrationBindingSource
            // 
            this.registrationBindingSource.DataSource = typeof(BITCollege_NF.Models.Registration);
            // 
            // courseNumberLabel
            // 
            courseNumberLabel.AutoSize = true;
            courseNumberLabel.Location = new System.Drawing.Point(50, 81);
            courseNumberLabel.Name = "courseNumberLabel";
            courseNumberLabel.Size = new System.Drawing.Size(104, 16);
            courseNumberLabel.TabIndex = 0;
            courseNumberLabel.Text = "Course Number:";
            // 
            // courseNumberTextBox
            // 
            this.courseNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CourseNumber", true));
            this.courseNumberTextBox.Location = new System.Drawing.Point(192, 78);
            this.courseNumberTextBox.Multiline = true;
            this.courseNumberTextBox.Name = "courseNumberTextBox";
            this.courseNumberTextBox.Size = new System.Drawing.Size(147, 36);
            this.courseNumberTextBox.TabIndex = 1;
            // 
            // registrationNumberLabel
            // 
            registrationNumberLabel.AutoSize = true;
            registrationNumberLabel.Location = new System.Drawing.Point(50, 47);
            registrationNumberLabel.Name = "registrationNumberLabel";
            registrationNumberLabel.Size = new System.Drawing.Size(133, 16);
            registrationNumberLabel.TabIndex = 2;
            registrationNumberLabel.Text = "Registration Number:";
            // 
            // registrationNumberComboBox
            // 
            this.registrationNumberComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "RegistrationNumber", true));
            this.registrationNumberComboBox.FormattingEnabled = true;
            this.registrationNumberComboBox.Location = new System.Drawing.Point(192, 44);
            this.registrationNumberComboBox.Name = "registrationNumberComboBox";
            this.registrationNumberComboBox.Size = new System.Drawing.Size(147, 24);
            this.registrationNumberComboBox.TabIndex = 3;
            // 
            // creditHoursLabel
            // 
            creditHoursLabel.AutoSize = true;
            creditHoursLabel.Location = new System.Drawing.Point(50, 124);
            creditHoursLabel.Name = "creditHoursLabel";
            creditHoursLabel.Size = new System.Drawing.Size(84, 16);
            creditHoursLabel.TabIndex = 4;
            creditHoursLabel.Text = "Credit Hours:";
            // 
            // creditHoursTextBox
            // 
            this.creditHoursTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CreditHours", true));
            this.creditHoursTextBox.Location = new System.Drawing.Point(192, 124);
            this.creditHoursTextBox.Multiline = true;
            this.creditHoursTextBox.Name = "creditHoursTextBox";
            this.creditHoursTextBox.Size = new System.Drawing.Size(147, 36);
            this.creditHoursTextBox.TabIndex = 5;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(403, 69);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(36, 16);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "Title:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.Title", true));
            this.titleTextBox.Location = new System.Drawing.Point(445, 66);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(291, 22);
            this.titleTextBox.TabIndex = 7;
            // 
            // StudentData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 629);
            this.Controls.Add(this.lnkViewDetails);
            this.Controls.Add(this.lnkUpdateGrade);
            this.Controls.Add(this.grpRegistration);
            this.Controls.Add(this.grpStudent);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StudentData";
            this.Text = "StudentData";
            this.Load += new System.EventHandler(this.StudentData_Load);
            this.grpStudent.ResumeLayout(false);
            this.grpStudent.PerformLayout();
            this.grpRegistration.ResumeLayout(false);
            this.grpRegistration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpStudent;
        private System.Windows.Forms.GroupBox grpRegistration;
        private System.Windows.Forms.LinkLabel lnkUpdateGrade;
        private System.Windows.Forms.LinkLabel lnkViewDetails;
        private System.Windows.Forms.TextBox studentNumberTextBox;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox gradePointAverageTextBox;
        private System.Windows.Forms.TextBox dateCreatedTextBox;
        private System.Windows.Forms.TextBox fullAddressTextBox;
        private System.Windows.Forms.TextBox outstandingFeesTextBox;
        private System.Windows.Forms.ComboBox registrationNumberComboBox;
        private System.Windows.Forms.BindingSource registrationBindingSource;
        private System.Windows.Forms.TextBox courseNumberTextBox;
        private System.Windows.Forms.TextBox creditHoursTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
    }
}