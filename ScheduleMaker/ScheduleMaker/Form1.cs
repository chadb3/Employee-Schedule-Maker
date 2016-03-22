using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace ScheduleMaker
{
    public partial class Form1 : Form
    {

        public EmployeeDB theDB;
        List<string> ListOfEmployeeNames;
        string selectedMonth;
        int selectedMonth01;
        int selectedYear;
        zDocumentMaker_v01 newDocument;
        public Form1(ref EmployeeDB DBin)
        {
            theDB = DBin;
            ListOfEmployeeNames = new List<string>();
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "M MMMM";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy";
            dateTimePicker2.ShowUpDown = true;
            ListOfEmployeeNames = DBin.getListOfNames();
            populateList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetMonthData();
            newDocument = new zDocumentMaker_v01(ListOfEmployeeNames, selectedMonth01, selectedYear);
            newDocument.createNewWordDocument();
            //MessageBox.Show(dateTimePicker1.Text+"\n"+dateTimePicker2.Text+"\n"+selectedMonth01);

        }

        private void populateList()
        {
            ListOfEmployeeNames = theDB.getListOfNames();
            listBox2.Items.Clear();
            foreach (string name in ListOfEmployeeNames)
            {
                listBox2.Items.Add(name);
            }
        }

        private void newEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pass the db pointer
            // return the db
            Form2 EnterNewEmployee = new Form2(ref theDB);
            
            EnterNewEmployee.ShowDialog();

            populateList();
        }

        private void GetMonthData()
        {
            Regex regex = new Regex(" ");
            selectedMonth = dateTimePicker1.Text;
            selectedYear = Convert.ToInt32(dateTimePicker2.Text);
           // MessageBox.Show(selectedMonth[0].ToString());
          //  string intMonth = selectedMonth[0].ToString();
            string[] intMonth = regex.Split(selectedMonth);
                selectedMonth01 = Convert.ToInt32(intMonth[0]);
            
        }

        private void removeEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 RemoveEmployee = new Form3(ref theDB);
            RemoveEmployee.ShowDialog();
            populateList();

        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This software was created using Microsoft Visual Studio Express using the C# language.\n Some features in future versions\n-Proper schedule ranking (the people will be in the correct order)\n-Possible theme selection for the calendar.\n-Have a holiday table to look up all applicable holidays\n-Look into the possibility of using a SQL server run on the server computer or        a Raspberry pi2 for a proper DB experience\n-New visuals\n-Possibly more\n\nThank you for using the software.\nSoftware written by Chad Bachman", "V1 info");          
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"If you have encountered a bug/error please write
-What Happened
-What you did to cause the problem
-Call me, and I'll do my best to fix the error
Please be careful to not overwrite a file you have finished or you may lose progress or even the whole schedule", "HELP");
        }

        private void reorderEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pass ref
            Form4 ReOrder = new Form4(ref theDB);
            ReOrder.ShowDialog();
            populateList();
        }
    }
}
