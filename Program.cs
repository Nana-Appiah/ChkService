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

<<<<<<< HEAD
                var xlpath = string.Format("{0}{1}.{2}",obj.ConfigValue, @"CHEQUE_Book_Data", @"xlsx");
                var localxlpath = string.Format("{0}{1}.{2}", @"C:\Users\ofosu\Music\", @"CHEQUE_Book_Data", @"xlsx");
=======
                var xlpath = string.Format("{0}{1}.{2}",obj.ConfigValue, @"CHEQUE_Book_Data1", @"xlsx");
>>>>>>> 563de044f7765bcd61ad85b9fcbf5da6cb1e7dc8

                if (File.Exists(xlpath))
                {
                    File.Delete(xlpath);
                }

                //call the closedXml module
<<<<<<< HEAD
                bool bln = new ClosedXMLClass() { }.Create(localxlpath, chequeData);
                
                if (bln)
                {
                    Console.WriteLine("Data generated into excel file...now copying to shared drive");

                    //move file to the network folder
                    File.Move(localxlpath, xlpath, true);
                    Console.WriteLine(String.Format("{0} copied successfully to {1}", localxlpath, xlpath));
                }

=======
                new ClosedXMLClass() { }.Create(xlpath, chequeData);
                
>>>>>>> 563de044f7765bcd61ad85b9fcbf5da6cb1e7dc8
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