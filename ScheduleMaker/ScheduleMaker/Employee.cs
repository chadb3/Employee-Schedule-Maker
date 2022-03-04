using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMaker
{
    /// <summary>
    /// Defines an Employee and what to do with them
    /// </summary>
    public class Employee
    {
        protected int rank;
        protected string fName;
        protected string lName;
        protected string jobTitle;
     //  protected string Job;

       public Employee(string First_name, string lName)
       {
            fName = First_name;
            this.lName = lName;


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
