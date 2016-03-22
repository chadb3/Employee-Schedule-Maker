using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace ScheduleMaker
{
    public class EmployeeDB
    {
       private List<Employee> TheEmployeeList;
       //private int status;
       public List<string> ListOfNames;
       public EmployeeDB()
       {
           TheEmployeeList = new List<Employee>();
           ListOfNames = new List<string>();
       }

       public void AddEmployee(Employee EmployeeIn)
       {
           TheEmployeeList.Add(EmployeeIn);       
       }

        public void RemoveEmployee(int index)
       {
            //TheEmployeeList.Remove()
           TheEmployeeList.RemoveAt(index);
           
               //TheEmployeeList.Remove(new Employee(FirstName));
                //TheEmployeeList.RemoveAt()
       }

        public List<string> getListOfNames()
        {
            ListOfNames.Clear();
            foreach(Employee e in TheEmployeeList)
            {
                ListOfNames.Add(e.GetFirstName());
            }
            return ListOfNames;
        }

        public void updateFile()
        {
            getListOfNames();
            try
            {
                string path = @"c:\ScheduleMaker2015\EmployeeNames.txt";
                StreamWriter file = new StreamWriter(path);
                foreach(string name in ListOfNames)
                {
                    file.WriteLine(name);
                }
                file.Close();
               // MessageBox.Show("File updated");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }


       
    }
}
