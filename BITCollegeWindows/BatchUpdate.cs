using BITCollege_NF.Data;
using BITCollege_NF.Models;
using System;
using System.Collections.Generic;
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
            if (radSelect.Checked)
            {
                // If a single transmission selection has been made.
                batch.ProcessTransmission(programAcronymComboBox.SelectedValue.ToString());

                // Capture the log information and append to the rich text box.
                rtxtLog.Text += batch.WriteLogData();
            }
            else
            {
                // If all transmissions have been selected.
                foreach (var item in programAcronymComboBox.Items)
                {
                    // Pass the ProgramAcronym.
                    batch.ProcessTransmission(item.ToString());

                    // Capture the log information for each item.
                    rtxtLog.Text += batch.WriteLogData();
                }
            }
        }

        /// <summary>
        /// given:  Always open this form in top right of frame.
        /// Further code to be added.
        /// </summary>
        private void BatchUpdate_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            IEnumerable<AcademicProgram> academicPrograms = db.AcademicPrograms.ToList();
            academicProgramBindingSource.DataSource = academicPrograms;
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radAll.Checked)
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
