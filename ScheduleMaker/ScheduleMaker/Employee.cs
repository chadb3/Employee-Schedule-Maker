using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMaker
{
    public class Employee
    {
       protected int rank;
       protected string fName;
     //  protected string Job;

      public Employee(string First_name)
      {
           fName = First_name;
          // lName = Last_Name;

      }

        public string GetFirstName()
      {
          return fName;

      }
        //void for now
     /* public void addJob(string input)
      {
         Job = input;
      }*/
        
    }
}
