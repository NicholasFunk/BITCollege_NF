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
            System.Windows.Forms.Label fullAddressLabel;
            System.Windows.Forms.Label courseNumberLabel;
            System.Windows.Forms.Label registrationNumberLabel;
            System.Windows.Forms.Label creditHoursLabel;
            System.Windows.Forms.Label titleLabel;
            System.Windows.Forms.Label studentNumberLabel;
            System.Windows.Forms.Label dateCreatedLabel;
            System.Windows.Forms.Label outstandingFeesLabel;
            System.Windows.Forms.Label gradePointAverageLabel;
            this.grpStudent = new System.Windows.Forms.GroupBox();
            this.grpRegistration = new System.Windows.Forms.GroupBox();
            this.lnkUpdateGrade = new System.Windows.Forms.LinkLabel();
            this.lnkViewDetails = new System.Windows.Forms.LinkLabel();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.fullAddressTextBox = new System.Windows.Forms.TextBox();
            this.registrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courseNumberTextBox = new System.Windows.Forms.TextBox();
            this.registrationNumberComboBox = new System.Windows.Forms.ComboBox();
            this.creditHoursTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.studentNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.dateCreatedLabel1 = new System.Windows.Forms.Label();
            this.outstandingFeesLabel1 = new System.Windows.Forms.Label();
            this.gradePointAverageLabel1 = new System.Windows.Forms.Label();
            this.descriptionLabel1 = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            fullAddressLabel = new System.Windows.Forms.Label();
            courseNumberLabel = new System.Windows.Forms.Label();
            registrationNumberLabel = new System.Windows.Forms.Label();
            creditHoursLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            studentNumberLabel = new System.Windows.Forms.Label();
            dateCreatedLabel = new System.Windows.Forms.Label();
            outstandingFeesLabel = new System.Windows.Forms.Label();
            gradePointAverageLabel = new System.Windows.Forms.Label();
            this.grpStudent.SuspendLayout();
            this.grpRegistration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grpStudent
            // 
            this.grpStudent.Controls.Add(this.descriptionLabel1);
            this.grpStudent.Controls.Add(gradePointAverageLabel);
            this.grpStudent.Controls.Add(this.gradePointAverageLabel1);
            this.grpStudent.Controls.Add(outstandingFeesLabel);
            this.grpStudent.Controls.Add(this.outstandingFeesLabel1);
            this.grpStudent.Controls.Add(dateCreatedLabel);
            this.grpStudent.Controls.Add(this.dateCreatedLabel1);
            this.grpStudent.Controls.Add(studentNumberLabel);
            this.grpStudent.Controls.Add(this.studentNumberMaskedTextBox);
            this.grpStudent.Controls.Add(fullAddressLabel);
            this.grpStudent.Controls.Add(this.fullAddressTextBox);
            this.grpStudent.Controls.Add(fullNameLabel);
            this.grpStudent.Controls.Add(this.fullNameTextBox);
            this.grpStudent.Location = new System.Drawing.Point(47, 58);
            this.grpStudent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpStudent.Name = "grpStudent";
            this.grpStudent.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpStudent.Size = new System.Drawing.Size(816, 255);
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
            // studentNumberLabel
            // 
            studentNumberLabel.AutoSize = true;
            studentNumberLabel.Location = new System.Drawing.Point(48, 46);
            studentNumberLabel.Name = "studentNumberLabel";
            studentNumberLabel.Size = new System.Drawing.Size(106, 16);
            studentNumberLabel.TabIndex = 12;
            studentNumberLabel.Text = "Student Number:";
            // 
            // studentNumberMaskedTextBox
            // 
            this.studentNumberMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "StudentNumber", true));
            this.studentNumberMaskedTextBox.Location = new System.Drawing.Point(213, 43);
            this.studentNumberMaskedTextBox.Mask = "0000-0000";
            this.studentNumberMaskedTextBox.Name = "studentNumberMaskedTextBox";
            this.studentNumberMaskedTextBox.Size = new System.Drawing.Size(147, 22);
            this.studentNumberMaskedTextBox.TabIndex = 13;
            // 
            // dateCreatedLabel
            // 
            dateCreatedLabel.AutoSize = true;
            dateCreatedLabel.Location = new System.Drawing.Point(50, 169);
            dateCreatedLabel.Name = "dateCreatedLabel";
            dateCreatedLabel.Size = new System.Drawing.Size(90, 16);
            dateCreatedLabel.TabIndex = 13;
            dateCreatedLabel.Text = "Date Created:";
            // 
            // dateCreatedLabel1
            // 
            this.dateCreatedLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "DateCreated", true));
            this.dateCreatedLabel1.Location = new System.Drawing.Point(210, 165);
            this.dateCreatedLabel1.Name = "dateCreatedLabel1";
            this.dateCreatedLabel1.Size = new System.Drawing.Size(100, 23);
            this.dateCreatedLabel1.TabIndex = 14;
            this.dateCreatedLabel1.Text = "label1";
            // 
            // outstandingFeesLabel
            // 
            outstandingFeesLabel.AutoSize = true;
            outstandingFeesLabel.Location = new System.Drawing.Point(532, 169);
            outstandingFeesLabel.Name = "outstandingFeesLabel";
            outstandingFeesLabel.Size = new System.Drawing.Size(115, 16);
            outstandingFeesLabel.TabIndex = 14;
            outstandingFeesLabel.Text = "Outstanding Fees:";
            // 
            // outstandingFeesLabel1
            // 
            this.outstandingFeesLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "OutstandingFees", true));
            this.outstandingFeesLabel1.Location = new System.Drawing.Point(653, 169);
            this.outstandingFeesLabel1.Name = "outstandingFeesLabel1";
            this.outstandingFeesLabel1.Size = new System.Drawing.Size(100, 23);
            this.outstandingFeesLabel1.TabIndex = 15;
            this.outstandingFeesLabel1.Text = "label1";
            // 
            // gradePointAverageLabel
            // 
            gradePointAverageLabel.AutoSize = true;
            gradePointAverageLabel.Location = new System.Drawing.Point(50, 207);
            gradePointAverageLabel.Name = "gradePointAverageLabel";
            gradePointAverageLabel.Size = new System.Drawing.Size(136, 16);
            gradePointAverageLabel.TabIndex = 15;
            gradePointAverageLabel.Text = "Grade Point Average:";
            // 
            // gradePointAverageLabel1
            // 
            this.gradePointAverageLabel1.Location = new System.Drawing.Point(210, 207);
            this.gradePointAverageLabel1.Name = "gradePointAverageLabel1";
            this.gradePointAverageLabel1.Size = new System.Drawing.Size(100, 23);
            this.gradePointAverageLabel1.TabIndex = 16;
            this.gradePointAverageLabel1.Text = "label1";
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "GradePointState.Description", true));
            this.descriptionLabel1.Location = new System.Drawing.Point(316, 207);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(100, 23);
            this.descriptionLabel1.TabIndex = 17;
            this.descriptionLabel1.Text = "label1";
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
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.TextBox fullAddressTextBox;
        private System.Windows.Forms.ComboBox registrationNumberComboBox;
        private System.Windows.Forms.BindingSource registrationBindingSource;
        private System.Windows.Forms.TextBox courseNumberTextBox;
        private System.Windows.Forms.TextBox creditHoursTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.MaskedTextBox studentNumberMaskedTextBox;
        private System.Windows.Forms.Label descriptionLabel1;
        private System.Windows.Forms.Label gradePointAverageLabel1;
        private System.Windows.Forms.Label outstandingFeesLabel1;
        private System.Windows.Forms.Label dateCreatedLabel1;
    }
}