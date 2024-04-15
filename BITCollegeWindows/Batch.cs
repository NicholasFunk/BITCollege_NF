using System;
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


        private void ProcessErrors(IEnumerable<XElement> beforeQuery, IEnumerable<XElement> afterQuery, String message)
        {

        }

        private void ProcessHeader()
        {

        }

        private void ProcessDetails()
        {

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
            DateTime date = DateTime.Now;
            
            // a file name with no extension
            string fileName = "";

            if (date.Day >= 10)
            {
                fileName = Convert.ToString(date.Year) + "-0" + Convert.ToString(date.Day) + "-" + programAcronym;
            }
            else 
            {
                fileName = Convert.ToString(date.Year) + "-00" + Convert.ToString(date.Day) + "-" + programAcronym;
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
