using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;


namespace ScheduleMaker
{
    class zDocumentMaker_v01
    {
        object missing;
        Microsoft.Office.Interop.Word.Application winWord;
        List<string> theNames;
        Microsoft.Office.Interop.Word.Document document;
        Microsoft.Office.Interop.Word.Paragraph para1;// = document.Content.Paragraphs.Add(ref missing);
        Microsoft.Office.Interop.Word.Paragraph para2;// = document.Content.Paragraphs.Add(ref missing);
        Table firstTable;// = document.Tables.Add(para1.Range, 1, 1, ref missing, ref missing);
        Table secondTable;// = document.Tables.Add(para2.Range, 5, 7, ref missing, ref missing);
        int YearToUse;
        DateTime theSelectedMonthAndYear;
        int DaysInMonth;
        int dayStartIndex;
        public zDocumentMaker_v01(List<string> namesIn, int month, int year)
        {
            YearToUse=year;
            theSelectedMonthAndYear = new DateTime(year, month, 1);//this is the DateTime
            theNames = namesIn;
            winWord = new Microsoft.Office.Interop.Word.Application();
            winWord.ShowAnimation = false;
            winWord.Visible = false;
            missing = System.Reflection.Missing.Value;
            document = winWord.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            para1 = document.Content.Paragraphs.Add(ref missing);
            para2 = document.Content.Paragraphs.Add(ref missing);
            firstTable = document.Tables.Add(para1.Range, 1, 1, ref missing, ref missing);
            firstTable.Borders.Enable = 1;
            secondTable = document.Tables.Add(para2.Range, 7, 7, ref missing, ref missing);
            secondTable.Borders.Enable = 1;
            secondTable.Range.Paragraphs.SpaceAfter = 0;
            DaysInMonth = DateTime.DaysInMonth(year, month);
           // d = (DayIndex)Enum.Parse(typeof(DayIndex), theSelectedMonthAndYear.DayOfWeek.ToString(),true);
            dayStartIndex = GetDayIndex(theSelectedMonthAndYear.DayOfWeek.ToString());
            
            firstTable.Rows[1].HeadingFormat = -1;
            firstTable.Rows[2].HeadingFormat = -1;
            firstTable.Rows[1].AllowBreakAcrossPages = 0;
            firstTable.Rows[2].AllowBreakAcrossPages = 0;
            //secondTable.Rows[1].HeadingFormat = -1;
            secondTable.Rows[1].AllowBreakAcrossPages = 0;
            //secondTable.Rows[2].HeadingFormat = -1;
            secondTable.Rows[2].AllowBreakAcrossPages = 0;
           // secondTable.Rows[3].HeadingFormat = -1;
            secondTable.Rows[3].AllowBreakAcrossPages = 0;
           // secondTable.Rows[4].HeadingFormat = -1;
            secondTable.Rows[4].AllowBreakAcrossPages = 0;
           // secondTable.Rows[5].HeadingFormat = -1;
            secondTable.Rows[5].AllowBreakAcrossPages = 0;
            //secondTable.Rows[6].HeadingFormat = -1;
            secondTable.Rows[6].AllowBreakAcrossPages = 0;
           // secondTable.Rows[7].HeadingFormat = -1;
            secondTable.Rows[7].AllowBreakAcrossPages = 0;
            
        }

        public void createNewWordDocument()
        {
            int index = 1;
            int cCount = 1;
            //theSelectedMonthAndYear.DayOfWeek.ToString();
            //MessageBox.Show(theSelectedMonthAndYear.DayOfWeek.ToString()+" "+theSelectedMonthAndYear.Year.ToString()+"\n"+DaysInMonth);
           // MessageBox.Show(d.ToString());
           // MessageBox.Show(dayStartIndex.ToString());
            foreach (Row row in firstTable.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    //Header row
                    if (cell.RowIndex == 1)
                    {
                        cell.Range.Text = theSelectedMonthAndYear.ToString("MMMM");// +cell.ColumnIndex.ToString();
                        cell.Range.Font.Bold = 1;
                        cell.Range.Font.Name = "verdana";
                        cell.Range.Font.Size = 8;
                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                    }
                    //Data row
                    else
                    {//3
                     if( cCount<=DaysInMonth)
                      { 
                        if (cell.ColumnIndex >= dayStartIndex && cell.RowIndex > 2 || cell.RowIndex > 3)
                        {
                            //MessageBox.Show(cCount.ToString());
                            cell.Range.Text = cCount.ToString();// (cell.RowIndex - 3 + cell.ColumnIndex).ToString();
                            cCount++;
                        }
                     }
                        
                     }
                }
            }
            
            foreach(Row row in secondTable.Rows)
                {
                    foreach(Cell cell in row.Cells)
                    {
                        if(cell.RowIndex==2&&cell.ColumnIndex==1)
                        {
                            
                            cell.Range.Text = "Sunday";

                        } 
                        if (cell.RowIndex == 2 && cell.ColumnIndex == 2)
                        {
                            cell.Range.Text = "Monday";

                        }
                        if (cell.RowIndex == 2 && cell.ColumnIndex == 3)
                        {
                            cell.Range.Text = "Tuesday";

                        }
                        if (cell.RowIndex == 2 && cell.ColumnIndex == 4)
                        {
                            cell.Range.Text = "Wednesday";

                        }
                        if (cell.RowIndex == 2 && cell.ColumnIndex == 5)
                        {
                            cell.Range.Text = "Thursday";

                        }
                        if (cell.RowIndex == 2 && cell.ColumnIndex == 6)
                        {
                            cell.Range.Text = "Friday";

                        }
                        if (cell.RowIndex == 2 && cell.ColumnIndex == 7)
                        {
                            cell.Range.Text = "Saturday";

                        }
                        if(cell.ColumnIndex==dayStartIndex&&dayStartIndex==1&&cell.RowIndex==2)
                        {
                            index++;
                        }

                        if (cell.ColumnIndex >= dayStartIndex && cell.RowIndex>2&&cell.ColumnIndex>1|| cell.RowIndex > 3 && cell.ColumnIndex > 1)//cell.RowIndex>2 //boom
                        {
                            cell.Range.Font.Size = 8;
                            if (index <=DaysInMonth)
                            {
                                for (int i = 0; i < theNames.Count; i++)
                                {


                                    cell.Range.Text += theNames[i].ToString();


                                }
                                index++;
                            }
                            
                        }
                        if( cell.RowIndex > 3 && cell.ColumnIndex == 1)
                        {
                            index++;
                        }

                    }

                }

                //Save the document
           // OpenFileDialog OFD = new OpenFileDialog();
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Word Document|*.docx";
            SFD.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SFD.FileName = theSelectedMonthAndYear.ToString("MMMM")+"_"+YearToUse.ToString()+"_Calendar";
            //SFD.InitialDirectory;
           // OFD.Filter = "Word Document|*.docx";
           /// OFD.ShowDialog();
                //object filename = @"c:\Users\Chad\Desktop\temp12.docx";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                object filename = SFD.FileName;
                document.SaveAs2(ref filename);
               //(_Application)document.Close(ref missing, ref missing, ref missing);
                ((_Document)document).Close();
                document = null;
                //winWord.Quit(ref missing, ref missing, ref missing);
                ((_Application)winWord).Quit();
                
                winWord = null;
                MessageBox.Show("Document created successfully !");
                
                
            }
          }




        public int GetDayIndex(string DayIn)
        {
            int valueToReturn = 0;
            switch (DayIn)
            {
                case "Sunday":
                    valueToReturn = 1;
                    break;
                case "Monday":
                    valueToReturn = 2;
                    break;
                case "Tuesday":
                    valueToReturn = 3;
                    break;
                case "Wednesday":
                    valueToReturn = 4;
                    break;
                case "Thursday":
                    valueToReturn = 5;
                    break;
                case "Friday":
                    valueToReturn = 6;
                    break;
                case "Saturday":
                    valueToReturn = 7;
                    break;
            }

            return valueToReturn;
        }
     }

}


