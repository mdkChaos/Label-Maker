using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Data;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;

namespace DataProvider
{
    public static class ExcelProvider
    {
        private static string FileName { get; set; }
        private static ObservableCollection<Label> Labels { get; }

        public static async Task<ObservableCollection<Label>> GetLabelsAsincAsync()
        {
            await StartExcelTaskAsync();

            return Labels;
        }

        private static async Task StartExcelTaskAsync()
        {
            await Task.Run(() => ExtractDataFromExcel());
            Task.WaitAll();
        }

        private static void OpenFile(string filter)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = filter
            };
            if (openFile.ShowDialog() == true)
            {
                FileName = openFile.FileName;
            }
        }

        private static void ExtractDataFromExcel()
        {
            Excel.Application excelApp = null;
            Excel.Workbooks workBooks = null;
            Excel.Workbook workBook = null;
            Excel.Sheets workSheets = null;
            Excel.Worksheet workSheet = null;
            try
            {
                OpenFile("Excel files(*.xls*)|*.xls*");
                excelApp = new Excel.Application
                {
                    Visible = false,
                    ScreenUpdating = false,
                    EnableEvents = false
                };

                workBooks = excelApp.Workbooks;
                workBook = workBooks.Open(FileName);
                workSheets = workBook.Worksheets;
                workSheet = (Excel.Worksheet)workSheets.get_Item(1);

                ReadFromRow(workSheet);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found!", "Error!", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Work is failed.\n{ex.Message}\n", "Error!", MessageBoxButton.OK);
            }
            finally
            {
                workBook.Close();
                excelApp.Quit();
                Marshal.ReleaseComObject(workSheet);
                Marshal.ReleaseComObject(workSheets);
                Marshal.ReleaseComObject(workBook);
                Marshal.ReleaseComObject(workBooks);
                Marshal.ReleaseComObject(excelApp);
            }
        }

        private static void ReadFromRow(Excel.Worksheet workSheet)
        {
            int row = 2;
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            while (workSheet.Cells[row, 1].Text.Trim() != string.Empty)
            {
                Label label = new Label
                {
                    FirstName = workSheet.Cells[row, 1].Text.Trim(),
                    LastName = workSheet.Cells[row, 2].Text.Trim()
                };
                string imgNumber = workSheet.Cells[row, 3].Text.Trim();
                if (string.IsNullOrEmpty(imgNumber))
                {
                    label.ImagePath = imgNumber;
                }
                else
                {
                    label.ImagePath = "0";
                }
                Labels.Add(label);
                row++;
            }
            Thread.CurrentThread.CurrentCulture = temp_culture;
        }
    }
}
