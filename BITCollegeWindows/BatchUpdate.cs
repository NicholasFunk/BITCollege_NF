using BITCollege_NF.Data;
using BITCollege_NF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BITCollegeWindows
{
    public partial class BatchUpdate : Form
    {

        private BITCollege_NFContext db = new BITCollege_NFContext();
        

        public BatchUpdate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Batch processing
        /// Further code to be added.
        /// </summary>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Batch batch = new Batch();

            if (radSelect.Checked.Equals(true))
            {
                // If a single transmission selection has been made.
                batch.ProcessTransmission(programAcronymComboBox.SelectedValue.ToString());

                // Capture the log information and append to the rich text box.
            }
            else
            {

                foreach (AcademicProgram item in programAcronymComboBox.Items)
                {
                    batch.ProcessTransmission(item.ProgramAcronym);
                }
            }

            rtxtLog.Text += batch.WriteLogData();
        }

        /// <summary>
        /// given:  Always open this form in top right of frame.
        /// Further code to be added.
        /// </summary>
        private void BatchUpdate_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            
            IQueryable<AcademicProgram> academicPrograms = db.AcademicPrograms;
            academicProgramBindingSource.DataSource = academicPrograms.ToList();
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radAll.Checked.Equals(true))
            {
                programAcronymComboBox.Enabled = false;
            }
            else
            {
                programAcronymComboBox.Enabled = true;
            }
        }

        
    }
}
