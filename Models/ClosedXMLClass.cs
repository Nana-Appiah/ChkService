﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClosedXML.Excel;


namespace ChequeBookService.Models
{
    public class ClosedXMLClass
    {
        public void Create(string filePath, IEnumerable<ChequeBook> dt)
        {
            IXLWorkbook workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add(@"CHEQUE");

            //Adding cell headers
            worksheet.Cell("A1").Value = @"CHQ_ORDER_DATE";
            worksheet.Cell("B1").Value = @"ACCOUNT_NO";
            worksheet.Cell("C1").Value = @"ACCOUNT_NAME";
            worksheet.Cell("D1").Value = @"ACCOUNT_CLASS";
            worksheet.Cell("E1").Value = @"CHEQUE_TYPE";
            worksheet.Cell("F1").Value = @"NOTES";
            worksheet.Cell("G1").Value = @"LEAVES";
            worksheet.Cell("H1").Value = @"CHECK_NO";
            worksheet.Cell("I1").Value = @"REFERENCE_ID";
            worksheet.Cell("J1").Value = @"REFERENCE_NO";
            worksheet.Cell("K1").Value = @"BRANCH_CODE";
            worksheet.Cell("L1").Value = @"TEL_NO";

            //iterating through the data
            int rowId = 2;
            foreach(var d in dt)
            {
                worksheet.Cell(rowId, 1).Value = d.ChqOrderDate;
                worksheet.Cell(rowId, 2).Value = d.AccountNumber;
                worksheet.Cell(rowId, 3).Value = d.AccountName;
                worksheet.Cell(rowId, 4).Value = d.AccountClass;
                worksheet.Cell(rowId, 5).Value = d.ChequeType;
                worksheet.Cell(rowId, 6).Value = d.Notes;
                worksheet.Cell(rowId, 7).Value = d.Leaves;
                worksheet.Cell(rowId, 8).Value = d.ChequeNumber;
                worksheet.Cell(rowId, 9).Value = d.ReferenceId;
                worksheet.Cell(rowId, 10).Value = d.ReferenceNo;
                worksheet.Cell(rowId, 11).Value = d.BranchCode;
                worksheet.Cell(rowId, 12).Value = d.TelephoneNumber;

                rowId += 1;
            }

            //saving file to file path
            workbook.SaveAs(filePath);
        }
    }
}