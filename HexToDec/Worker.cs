using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace HexToDec
{
    public class Worker
    {
        public void start()
        {
            GetExcelFile();
        }

        private string reverseBitOrder(string a)
        {
            string result = "";
            for (int i = a.Length-1; i >= 0; i--)
            {
                result = result + a[i];
            }
            return result;
        }

        private string reverseByteOrder(string a)
        {
            string result = "";
            double number = 1.00;

            for (int i = a.Length-1; i >= 0; i--)
            {
                //Console.WriteLine(Math.Abs(i/8+number));
                double calc = Math.Abs((double)i / 8.00 + number);
                if (Math.Abs(calc - 5.00) < 0.01)
                {
                    number++;
                    for (int j = 0; j < 8; j++)
                    {
                        result = result + a[i + j];
                    }
                }
            }

            return result;
        }

        private string BinaryStringToHexString(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                return binary;

            StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

            // TODO: check all 1's or 0's... throw otherwise

            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                // pad to length multiple of 8
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }

        private string HexLast8Dig(string a)
        {
            string result ="";

            for (int i = 2; i < a.Length; i++)
            {
                result = result + a[i];
            }

            return result;
        }

        public void GetExcelFile()
        {

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\test\Hexliste.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1] as Excel._Worksheet;
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            
            Console.WriteLine(rowCount);
            Console.WriteLine(colCount);
            //Console.WriteLine(xlRange.Cells[1,1].Value);

            string hex;
            string dec;
            for (int i = 1; i <= rowCount; i++)
            {
                if (xlRange.Cells[i,1].value != null)
                {
                    Console.WriteLine("row " + i);
                    hex = xlRange.Cells[i, 1].Value;
                    dec = ConvertionOfSingleHex(hex);
                    xlWorksheet.Cells[i, 5].Value = dec;
                }
                
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }

        private string ConvertionOfSingleHex(string a)
        {
            string result;
            //Console.WriteLine("HexString");
            Console.WriteLine(a);

            //Console.WriteLine("Convert to bit string");
            result = String.Join(String.Empty,
                a.Select(
                    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                )
            );
            //Console.WriteLine(result);

            //Console.WriteLine("reverse bit order");
            result = reverseBitOrder(result);
            //Console.WriteLine(result);

            //Console.WriteLine("reverse byte order");
            result = reverseByteOrder(result);
            //Console.WriteLine(result);

            //Console.WriteLine("New hex string");
            result = BinaryStringToHexString(result);
            //Console.WriteLine(result);

            //Console.WriteLine("Last 8 digs");
            result = HexLast8Dig(result);
            //Console.WriteLine(result);

            //Console.WriteLine("Convert to Decimal");
            long decimalNumber = long.Parse(result, System.Globalization.NumberStyles.HexNumber);
            //Console.WriteLine(decimalNumber);

            //Console.WriteLine("Add s");
            result = "s" + decimalNumber;
            Console.WriteLine(result);

            return result;
        }
    }
}
