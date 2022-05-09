//get cheque data
using ChequeBookService.Utils;
using ChequeBookService.Models;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Text;
using System;
using ChequeBookService.Bridge;

#region OpenXML namespaces

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

#endregion

try
{

    var obj = await new Helper { }.getConfigObject(@"ChequeBookFilePath");

    var chequeData = await new Helper { }.GetChequeBooksAsync(DateTime.Now);

    if (chequeData != null)
    {
        if (obj != null)
        {
            try
            {
                Console.WriteLine(String.Format("Generating cheque book data to the path {0}", obj.ConfigValue));

                var xlpath = string.Format("{0}{1}.{2}",obj.ConfigValue, @"CHEQUE_Book_Data", @"xlsx");
                var localxlpath = string.Format("{0}{1}.{2}", @"C:\Users\ofosu\Music\", @"CHEQUE_Book_Data", @"xlsx");

                if (File.Exists(xlpath))
                {
                    File.Delete(xlpath);
                }

                //call the closedXml module
                bool bln = new ClosedXMLClass() { }.Create(localxlpath, chequeData);
                
                if (bln)
                {
                    Console.WriteLine("Data generated into excel file...now copying to shared drive");

                    //move file to the network folder
                    File.Move(localxlpath, xlpath, true);
                    Console.WriteLine(String.Format("{0} copied successfully to {1}", localxlpath, xlpath));
                }

                Console.WriteLine("Cheque book generation finished");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }   
        }

        Console.ReadKey();
    }

}
catch(Exception x)
{
    Console.WriteLine($"Error: {x.Message}");
}