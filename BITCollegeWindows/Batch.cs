using System;
using BITCollege_NF.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

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

        }

        private void ProcessHeader()
        {
            int checksum = 0;

            XDocument xDocument = XDocument.Load(inputFileName);
            XElement xElement = xDocument.Element("student_update");

            IEnumerable<XElement> checkSumElements = xDocument.Descendants().Where(d => d.Name == "student_no");

            // Get all attributes
            XAttribute att_date = xElement.Attribute("date");
            XAttribute att_program = xElement.Attribute("program");
            XAttribute att_checksum = xElement.Attribute("checksum");

            // Fetches a list of all unique program acronyms within the Academic Programs Table.
            var uniqueProgramsAcronyms = db.AcademicPrograms.AsEnumerable().Select(row => row.ProgramAcronym).Distinct().ToList();
         
            // Validate all attributes
            if (xElement.Attributes().Count() < 3)
            {
                throw new Exception("File does not contain at least 3 attirbutes!");
            }

            // Validates the date attribute
            else if (att_date.Value != todaysDate.ToString())
            {
                throw new Exception("The date attribute value does not match the current date!");
            }

            // Validates the program attribute
            foreach (var acronym in uniqueProgramsAcronyms)
            {
                if (att_program.Value != acronym)
                {
                    throw new Exception("The program attribute value does not match any known acronyms!");
                }
            }

            // Adding all student no.s together
            foreach (var element in checkSumElements)
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
            IEnumerable<XElement> previousQuery = xDocument.Descendants().Where(d => d.Name == "transaction");

            // The next query is equal to all transactions that have 7 elements.
            IEnumerable<XElement> nextQuery = previousQuery.Where(d => d.Nodes().Count() == 7);

            // All transactions program element that equals the root program attribute value
            IEnumerable<XElement> programQuery = nextQuery.Where(d => d.Element("program").Value == xDocument.Root.Attribute("program").Value);

            // ProcessErrors(something, something, something);
           
        }

        private void ProcessTransactions(IEnumerable<XElement> transactionRecords)
        {

        }

        public String WriteLogData()
        {
            return logData;
        }

        public void ProcessTransmission(String programAcronym)
        {
            // current date
            DateTime todaysDate = DateTime.Now;
            
            // a file name with no extension
            string fileName = "";

            if (todaysDate.Day >= 10)
            {
                fileName = Convert.ToString(todaysDate.Year) + "-0" + Convert.ToString(todaysDate.Day) + "-" + programAcronym;
            }
            else 
            {
                fileName = Convert.ToString(todaysDate.Year) + "-00" + Convert.ToString(todaysDate.Day) + "-" + programAcronym;
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
                    logData += e.Message;
                    throw;
                }
            }
            else
            {
                // inputFileName doesn't exist, append error message
                logData += ("Warning: " + inputFileName + " does not exist in the current context.");
            }
            
        }
    }
}
