using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleMaker
{
    /// <summary>
    /// has to do with the gui that removes an employee from the file
    ///this will remove the employee
    /// </summary>
    public partial class Form3 : Form
    {
        EmployeeDB theDBForForm3;
        List<string> listOfNames;
        public Form3(ref EmployeeDB DBin)
        {
            theDBForForm3 = DBin;
            listOfNames = theDBForForm3.getListOfNames();
            



            InitializeComponent();
            PopulateList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==comboBox1.Text)
            {
                theDBForForm3.RemoveEmployee(listOfNames.IndexOf(textBox1.Text));
               //MessageBox.Show( listOfNames.IndexOf(textBox1.Text).ToString());
                //theDBForForm3.RemoveEmployee(textBox1.Text);
                this.Close();
            }
            PopulateList();
        }

        private void PopulateList()
        {
            foreach(string name in listOfNames)
            {
                comboBox1.Items.Add(name);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
