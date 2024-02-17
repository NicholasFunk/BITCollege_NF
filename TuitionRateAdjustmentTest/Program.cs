using BITCollege_NF.Data;
using BITCollege_NF.Models;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;




namespace BITCollege_NF
{
    class Program
    {
        private static BITCollege_NFContext db;

        static void Main(string[] args) 
        {
            suspendedState_TuitionRateAdjustment_Test();
        }

        static void suspendedState_TuitionRateAdjustment_Test()
        {

            db = new BITCollege_NFContext();

            Student student = db.Students.FirstOrDefault();

            Console.WriteLine(student.FirstName);

            
           
        }
    }
}