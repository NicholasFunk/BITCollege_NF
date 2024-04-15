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
            DateTime date = DateTime.Now;

            if (date.Day >= 10)
            {
                inputFileName = Convert.ToString(date.Year) + "-0" + Convert.ToString(date.Day) + "-" + programAcronym + ".xml";
            }
            else 
            {
                inputFileName = Convert.ToString(date.Year) + "-00" + Convert.ToString(date.Day) + "-" + programAcronym + ".xml";
            }
            
        }
    }
}
