using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;
using Aspose.Cells;
using System.ComponentModel;
using Aspose.Words;

/// <summary>
/// Summary description for Export
/// </summary>
public class Export
{
    public Export()
    {
        General.SetLicenseForAspose();
    }

    public void ExportExcel(string path, DataTable[] objTable, string nameReportOut)
    {
        Aspose.Cells.WorkbookDesigner designer;
        try
        {
            designer = new WorkbookDesigner();
            designer.Open(path);
            designer.ClearDataSource();
            foreach (DataTable item in objTable)
            {
                designer.SetDataSource(item);
            }
            designer.Process();

            //save workbook lai
            designer.Workbook.Save(General.DateTimeName() + nameReportOut, FileFormatType.Excel2003, Aspose.Cells.SaveType.OpenInExcel, HttpContext.Current.Response);

        }
        catch
        {

        }
    }
    public void ExportWord(string path, DataTable objTable, string nameReportOut)
    {
        try
        {

            Document doc = new Document(path);
            if (objTable != null && objTable.Rows.Count > 0)
            {
                for (int i = 0; i < objTable.Rows.Count; i++)
                {
                    doc.Range.Replace("##" + i.ToString() + "##", objTable.Rows[i]["NEWVALUE"].ToString(), false, false);
                }

            }
            doc.Save(General.DateTimeName() + nameReportOut, SaveFormat.Doc, Aspose.Words.SaveType.OpenInApplication, HttpContext.Current.Response);

        }
        catch
        {

        }
    }

}