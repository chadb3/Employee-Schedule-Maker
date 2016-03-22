using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ScheduleMaker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string path = @"c:\ScheduleMaker2015\EmployeeNames.txt";
            MakeTheFiles();
            string LineOfText;
            StreamReader sr = new StreamReader(path);
            EmployeeDB theMainDB = new EmployeeDB();
            /*
             * Opens the file and populates the DB 
             */
                if(new FileInfo(path).Length !=0)
                {
                    while((LineOfText=sr.ReadLine())!=null)
                    {
                        theMainDB.AddEmployee(new Employee(LineOfText));
                    }
                    sr.Close();
                }
                else
                {
                    MessageBox.Show("Employee Database is empty! \nBe  sure to populate it before continuing.");
                    sr.Close();
                }

            /*
             * end of that DB population
             */ 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(ref theMainDB));
            theMainDB.updateFile();
        }
        /// <summary>
        /// Makes the files if they don't already exist
        /// </summary>
        static void MakeTheFiles()
        {
            string filePath = @"c:\ScheduleMaker2015";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
                MessageBox.Show(filePath + " was created.");
                
            }
            string path = @"c:\ScheduleMaker2015\EmployeeNames.txt";
            if (!File.Exists(path))
            {

                StreamWriter sw = File.CreateText(path);
                MessageBox.Show(path + " was created.");
                sw.Close();
            }
           
        }
    }

}
