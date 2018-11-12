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
        public static ObservableCollection<Label> Labels { get; } = new ObservableCollection<Label>();

        public static async Task GetLabelsAsync()
        {
            await Task.Run(() => ExtractDataFromExcel());
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
                if (!string.IsNullOrWhiteSpace(FileName))
                {
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
                    MessageBox.Show("Extract successful!", "Congratulation!", MessageBoxButton.OK);
                }
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
                if (FileName != null)
                {
                    workBook.Close();
                    excelApp.Quit();
                    FileName = null;
                    Marshal.ReleaseComObject(workSheet);
                    Marshal.ReleaseComObject(workSheets);
                    Marshal.ReleaseComObject(workBook);
                    Marshal.ReleaseComObject(workBooks);
                    Marshal.ReleaseComObject(excelApp);
                }
            }
        }

        private static void ReadFromRow(Excel.Worksheet workSheet)
        {
            int row = 2;
            dynamic range;
            string text;
            Label label;
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            range = workSheet.Cells[row, 1];
            text = range.Text;

            while (!string.IsNullOrWhiteSpace(text.Trim()))
            {
                label = new Label();
                label.FirstName = text.Trim();
                range = workSheet.Cells[row, 2];
                text = range.Text;
                label.LastName = text.Trim();

                range = workSheet.Cells[row, 3];
                text = range.Text;
                if (int.TryParse(text.Trim(), out int result))
                {
                    label.ImagePath = result.ToString();
                }
                else
                {
                    label.ImagePath = "0";
                }
                Labels.Add(label);
                row++;
                range = workSheet.Cells[row, 1];
                text = range.Text;
            }

            Thread.CurrentThread.CurrentCulture = temp_culture;
            Marshal.ReleaseComObject(workSheet);
            Marshal.ReleaseComObject(range);
            range = null;
            workSheet = null;
        }
    }
}
