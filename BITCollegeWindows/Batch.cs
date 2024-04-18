using System;
using BITCollege_NF.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Runtime.Remoting;
using BITCollege_NF.Models;
using System.Collections.ObjectModel;
using Utility;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BITCollegeWindows
{
    /// <summary>
    /// Batch:  This class provides functionality that will validate
    /// and process incoming xml files.
    /// </summary>
    public class Batch
    {

        // Create an instance of the database context
        BITCollege_NFContext db = new BITCollege_NFContext();

        // Create ainstance of the BITCollege_NFService
        BITCollegeServiceReference.CollegeRegistrationClient registerService = new BITCollegeServiceReference.CollegeRegistrationClient();

        /// <summary>
        /// Represents the name of the file being processed
        /// </summary>
        private String inputFileName;

        /// <summary>
        /// Represent the name of the log file that corresponds with the file being processed
        /// </summary>
        private String logFileName;

        /// <summary>
        /// Represent all data to be written to the log file that corresponds with the file being processed
        /// </summary>
        private String logData;

        /// <summary>
        /// Represents the date
        /// </summary>
        private DateTime todaysDate;


        private void ProcessErrors(IEnumerable<XElement> beforeQuery, IEnumerable<XElement> afterQuery, String message)
        {
            foreach (var record in beforeQuery.Except(afterQuery))
            {
                // compare the records from the beforeQuery to those from the afterQuery. 
                logData += "---------ERROR---------" +
                    Environment.NewLine + "File: " + inputFileName +
                    Environment.NewLine + "Program: " + record.Element("program").ToString() +
                    Environment.NewLine + "Student Number: " + record.Element("student_no").ToString() +
                    Environment.NewLine + "Course Number: " + record.Element("course_no").ToString() +
                    Environment.NewLine + "Registration Number: " + record.Element("registration_no").ToString() +
                    Environment.NewLine + "Type: " + record.Element("type").ToString() +
                    Environment.NewLine + "Grade: " + record.Element("grade").ToString() +
                    Environment.NewLine + "Notes: " + record.Element("notes").ToString() +
                    Environment.NewLine + "Nodes: " + record.Elements().Count() +
                    Environment.NewLine + "Message: " + message +
                    Environment.NewLine;
            }
        }

        private void ProcessHeader()
        {
            int checksum = 0;
            bool acronymFlag = false;

            XDocument xDocument = XDocument.Load(inputFileName);
            XElement xElement = xDocument.Element("student_update");

            IEnumerable<XElement> checkSumElements = xDocument.Descendants().Where(d => d.Name == "student_no");


            // Get all attributes
            XAttribute att_date = xElement.Attribute("date");
            XAttribute att_program = xElement.Attribute("program");
            XAttribute att_checksum = xElement.Attribute("checksum");

            // Fetches a list of all unique program acronyms within the Academic Programs Table.
            IEnumerable<string> uniqueProgramsAcronyms = db.AcademicPrograms.Select(a => a.ProgramAcronym).Distinct();

            // Validate all attributes
            if (xElement.Attributes().Count() < 3)
            {
                throw new Exception("File does not contain at least 3 attirbutes!");
            }

            // Validates the date attribute
            // Convert the attribute value into a date time with days of the year, not month.
            else if (att_date.Value != DateTime.Now.ToString("yyyy-MM-dd"))
            {
                MessageBox.Show(att_date.Value + " " + DateTime.Now.ToString("yyyy-MM-dd"));
                throw new Exception("The date attribute value does not match the current date!");
                
            }

            // Validates the program attribute
            foreach (string acronym in uniqueProgramsAcronyms)
            {
                // If it matches, set the flag to true and escape.
                if (att_program.Value.Equals(acronym))
                {
                    acronymFlag = true;
                }
            }

            if (acronymFlag == false)
            {
                throw new Exception("The program attribute value does not match any known acronyms!");
            }

            // Adding all student no.s together
            foreach (XElement element in checkSumElements)
            {
                checksum += Convert.ToInt32(element.Value);
            }

            // Compare the checksum attirbute to the combined value of student no.s found in the elements
            if (Convert.ToInt32(att_checksum.Value) != checksum)
            {
                throw new Exception("The checksums do not match!");
            }
        }

        /// <summary>
        /// Used to verify the contents of the detail records in the input file.
        /// </summary>
        private void ProcessDetails()
        {
            XDocument xDocument = XDocument.Load(inputFileName);
            IEnumerable<XElement> beforeQuery = xDocument.Descendants().Where(d => d.Name == "transaction");

            // The next query is equal to all transactions that have 7 elements.
            IEnumerable<XElement> afterQuery = beforeQuery.Where(d => d.Nodes().Count() == 7);

            // All transactions program element that equals the root program attribute value
            IEnumerable<XElement> validTransactions_Programs = Enumerable.Empty<XElement>();

            foreach (XElement transaction in afterQuery)
            {
                if (transaction.Element("program").Value == xDocument.Root.Attribute("program").Value)
                {
                    validTransactions_Programs = validTransactions_Programs.Append(transaction);
                }
                else
                {
                    string errorMessage = "Invalid Program Acronym";
                    ProcessErrors(validTransactions_Programs, afterQuery, errorMessage);
                }
            }

            // All transactions that have a numeric type
            IEnumerable<XElement> validTransactions_Type = Enumerable.Empty<XElement>();

            foreach (XElement transaction in validTransactions_Programs)
            {

                if (Utility.Numeric.IsNumeric(transaction.Element("type").Value, System.Globalization.NumberStyles.Number))
                {
                    validTransactions_Type = validTransactions_Type.Append(transaction);
                }
                else
                {
                    string errorMessage = "Invalid Type Is Not Numeric";
                    ProcessErrors(validTransactions_Programs, validTransactions_Type, errorMessage);
                }

            }

            // All transactions that have a numeric grade of have a value of '*'.
            IEnumerable<XElement> validTransactions_Grade = Enumerable.Empty<XElement>();

            foreach (XElement transaction in validTransactions_Type)
            {
                if (Utility.Numeric.IsNumeric(transaction.Element("grade").Value, System.Globalization.NumberStyles.Number) || transaction.Element("grade").Value == "*")
                {
                    validTransactions_Grade = validTransactions_Grade.Append(transaction);
                }
                else
                {
                    string errorMessage = "Invalid Grade Is Not Numeric";
                    ProcessErrors(validTransactions_Type, validTransactions_Grade, errorMessage);
                }
            }

            // All transactions that have a type value of 1 or 2.
            IEnumerable<XElement> validTransactions_TypeValue = Enumerable.Empty<XElement>();

            foreach (XElement transaction in validTransactions_Grade)
            {
                int checkValue = Convert.ToInt32(transaction.Element("type").Value);
                if (checkValue == 1 || checkValue == 2)
                {
                    validTransactions_TypeValue = validTransactions_TypeValue.Append(transaction);
                }
                else
                {
                    string errorMessage = "Invalid Type";
                    ProcessErrors(validTransactions_Grade, validTransactions_TypeValue, errorMessage);
                }
            }

            // All transactions that have a grade within each transaction must have a value of '*'. Within type = 2, the grade must have a value between 0 and 100 inclusive.
            IEnumerable<XElement> validTransactions_GradeValue = Enumerable.Empty<XElement>();

            foreach (XElement transaction in validTransactions_TypeValue)
            {
                if (Convert.ToInt32(transaction.Element("type").Value) == 1 && transaction.Element("grade").Value == "*" || Convert.ToInt32(transaction.Element("type").Value) == 2 && Enumerable.Range(0, 100).Contains(Convert.ToInt32(transaction.Element("grade").Value)))
                {
                    validTransactions_GradeValue = validTransactions_GradeValue.Append(transaction);
                }
                else
                {
                    string errorMessage = "Invalid Grade Value Or Type Value";
                    ProcessErrors(validTransactions_TypeValue, validTransactions_GradeValue, errorMessage);
                }
            }

            // Each student no. must exist in the database
            IEnumerable<XElement> validTransactions_StudentsNo = Enumerable.Empty<XElement>();


            // Retreive a list of all student numbers
            IEnumerable<long> allStudentNo = db.Students.Select(s => s.StudentNumber).ToList();


            foreach (XElement transaction in validTransactions_GradeValue)
            {
                // First convert the string into a double, then cast it as a long.
                long studentNumber = (long)Convert.ToDouble(transaction.Element("student_no").Value);

                if (allStudentNo.Contains(studentNumber))
                {
                    validTransactions_StudentsNo = validTransactions_StudentsNo.Append(transaction);
                }
                else
                {
                    string errorMessage = "Invalid Student Number, No Student Records Found";
                    ProcessErrors(validTransactions_GradeValue, validTransactions_StudentsNo, errorMessage);
                }
            }

            // Course number must exist in the database
            IEnumerable<XElement> validTransactions_CourseNumbers = Enumerable.Empty<XElement>();

            // Retreive a list of all student numbers
            IEnumerable<string> allCourseNo = db.Courses.Select(s => s.CourseNumber).ToList();


            foreach (XElement transaction in validTransactions_StudentsNo)
            {
                string courseNumber = transaction.Element("course_no").Value;
                int type = Convert.ToInt32(transaction.Element("type").Value);

                if (courseNumber == "*" && type == 2 || allCourseNo.Contains(courseNumber) && type == 1)
                {
                    validTransactions_CourseNumbers = validTransactions_CourseNumbers.Append(transaction);
                }
                else
                {
                    string errorMessage = "Invalid Course Number, No Course Records Found";
                    ProcessErrors(validTransactions_StudentsNo, validTransactions_CourseNumbers, errorMessage);
                }
            }

            // Registration Numbers must exist in the database
            // Course number must exist in the database
            IEnumerable<XElement> validTransactions_RegistrationNo = Enumerable.Empty<XElement>();

            // Retreive a list of all student numbers
            IEnumerable<long> allRegistrationNo = db.Registrations.Select(s => s.RegistrationNumber).ToList();


            foreach (XElement transaction in validTransactions_CourseNumbers)
            {

                // First convert the string into a double, then cast it as a long.
                long registrationNumber = (long)Convert.ToDouble(transaction.Element("registration_no").Value);
                int type = Convert.ToInt32(transaction.Element("type").Value);

                if (transaction.Element("registration_no").Value == "*" && type == 1 || allRegistrationNo.Contains(registrationNumber) && type == 2)
                {
                    validTransactions_RegistrationNo = validTransactions_RegistrationNo.Append(transaction);
                }
                else
                {
                    string errorMessage = "Invalid Registration Number, No Course Records Found";
                    ProcessErrors(validTransactions_CourseNumbers, validTransactions_RegistrationNo, errorMessage);
                }
            }

            ProcessTransactions(validTransactions_RegistrationNo);

        }

        private void ProcessTransactions(IEnumerable<XElement> transactionRecords)
        {

            foreach (XElement transaction in transactionRecords)
            {
                int transaction_type = Convert.ToInt32(transaction.Element("type").Value);
                double grade = Convert.ToDouble(transaction.Element("grade").Value) / 100;
                string notes = transaction.Element("notes").Value;

                // Fetch the studentId from the Students table.
                long studentNumber = (long)Convert.ToDouble(transaction.Element("student_no").Value);
                int studentId = db.Students.Where(s => s.StudentNumber == studentNumber).Select(s => s.StudentId).SingleOrDefault();

                // Fetch the courseId from the Courses table.
                string courseNumber = transaction.Element("course_no").Value;
                int courseId = db.Courses.Where(c => c.CourseNumber == courseNumber).Select(c => c.CourseId).SingleOrDefault();

                // Fetch the registrationId from the Registrations table.
                long registrationNumber = (long)Convert.ToDouble(transaction.Element("registration_no").Value);
                int registrationId = db.Registrations.Where(r => r.RegistrationNumber == registrationNumber).Select(r => r.RegstrationId).SingleOrDefault();

                // Use the WCF Service to register the student into the specified course.
                if (transaction_type == 1)
                {
                    int returnCode = registerService.RegisterCourse(studentId, courseId, notes);


                    switch (returnCode)
                    {
                        // Registration was successful
                        case 0:
                            logData += Environment.NewLine + "Student: " + studentNumber.ToString() + " has successfully registered for course: " + courseNumber.ToString() + ".";
                            break;
                        // Registration was unsuccessful
                        default:
                            logData += Environment.NewLine + "REGISTRATION ERROR: " + BusinessRules.RegisterError(returnCode);
                            break;
                    }
                }

                if (transaction_type == 2)
                {
                    try
                    {
                        registerService.UpdateGrade(grade, registrationId, notes);
                        logData += Environment.NewLine + "A grade of: " + (100 * grade).ToString() + "%" + " has been successfully applied to registration: " + registrationId.ToString() + ".";
                    }
                    catch (Exception e )
                    {
                        logData += Environment.NewLine + "UPDATE GRADE ERROR: " + e.Message;
                    }
                }
            }
        }

        // Called upon completion of a file being processed.
        public String WriteLogData()
        {
            StreamWriter streamWriter = new StreamWriter(logFileName, true);
            streamWriter.Write(logData);
            streamWriter.Close();
            string collectedLogData = logData;
            logData = String.Empty;
            logFileName = String.Empty;
            return collectedLogData;
        }

        public void ProcessTransmission(String programAcronym)
        {
            // current date
            DateTime todaysDate = DateTime.Now;

            // a file name with no extension
            string fileName = "";

            if (todaysDate.Day >= 10)
            {
                // 2024-109
                fileName = Convert.ToString(todaysDate.Year) + "-" + Convert.ToString(DateTime.Now.DayOfYear) + "-" + programAcronym;
            }
            else
            {
                // 2024-009
                fileName = Convert.ToString(todaysDate.Year) + "-0" + Convert.ToString(DateTime.Now.DayOfYear) + "-" + programAcronym;
            }

            // inputFileName xml file
            inputFileName = fileName + ".xml";

            // logFileName txt file
            logFileName = "LOG " + fileName + ".txt";

            if (File.Exists(inputFileName))
            {
                try
                {
                    // inputFileName exists, begin processing the file
                    ProcessHeader();
                    ProcessDetails();
                }
                catch (Exception e)
                {
                    // error occured while loading, append error message
                    logData += e.Message + Environment.NewLine;
                }
            }
            else
            {
                // inputFileName doesn't exist, append error message
                logData += ("Warning: " + inputFileName + " does not exist in the current context." + Environment.NewLine);
            }

        }
    }
}
