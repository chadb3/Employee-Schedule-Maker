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
    public partial class Form4 : Form
    {
        EmployeeDB refDBHere;
        List<string> ListofEmployeeNames;
        public Form4(ref EmployeeDB DBin)
        {
            refDBHere = DBin;
            ListofEmployeeNames = refDBHere.getListOfNames();
            InitializeComponent();
            populateList();
        }

        public void populateList()
        {
            foreach(string name in ListofEmployeeNames)
            {
                listBox1.Items.Add(name);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = listBox1.SelectedItem.ToString();
        }

       

        
    }
}
