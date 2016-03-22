using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ScheduleMaker
{
    public partial class Form2 : Form
    {
        EmployeeDB dbToUpdate;
        string name;
        List<string> newEmployeeListToReturn;
        public Form2(ref EmployeeDB DBin)
        {
            dbToUpdate = DBin;
            newEmployeeListToReturn = dbToUpdate.getListOfNames();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddName();
        }

        public void AddName()
        {
            name = textBox1.Text;
            bool NameExists=false;
            if (newEmployeeListToReturn.Count > 0)
            {
                foreach (string nameInList in newEmployeeListToReturn)
                {
                    if (nameInList == name)
                    {
                        NameExists = true;
                        MessageBox.Show(name + " Already exists in list,\n Try changing the name");

                    }

                }
            }
            if (NameExists == false)
            {
                using (StreamWriter file = new StreamWriter(@"c:\ScheduleMaker2015\EmployeeNames.txt", true))
                {
                    file.WriteLine(name);
                    MessageBox.Show(name + " added!");
                    this.Close();
                }
                dbToUpdate.AddEmployee(new Employee(name));

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        
    }
}
