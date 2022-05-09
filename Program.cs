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

                var xlpath = string.Format("{0}{1}.{2}",obj.ConfigValue, @"CHEQUE_Book_Data1", @"xlsx");

                if (File.Exists(xlpath))
                {
                    File.Delete(xlpath);
                }

                //call the closedXml module
                new ClosedXMLClass() { }.Create(xlpath, chequeData);
                
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