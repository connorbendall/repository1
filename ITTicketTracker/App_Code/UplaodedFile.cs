using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.IO;
using System.Drawing;
/// <summary>
/// Summary description for UplaodedFile
/// </summary>
public class UploadedFile
{
    private static int maxUploads = 10;
    public readonly static string filePath = FileLocation.FilePath + @"ITRepository\";

    
    /// <summary>
    /// Takes a filename and returns the extension of the file 
    /// </summary>
    /// <param name="fileName">The file name</param>
    /// <returns>The extension of the file</returns>
    public static string GetFileExtention(string fileName)
    {
        string[] file = fileName.Split('.');
        string fileExt = file[file.Length -1];

        return fileExt;
    }
    public static int MaxUploads()
    {
        return maxUploads;
    }

    /// <summary>
    /// Deletes any files that have been saved for the specified ticket no matter what the extension
    /// </summary>
    /// <param name="ticketID">The Ticket ID</param>
    public static void DeleteExistingFiles( string ticketID)
    {
        // The user had uploaded a second file see if one with the id and any extension exists and delete it to make room for the new one
        foreach (string files in Directory.GetFiles(filePath, ticketID + ".*"))
        {
            File.Delete(files);
        }

    }

    public static bool FileExtentionAllowed(string fileExtention)
    {
        string[] allowedExtentions = { "jpg", "png", "pdf", "docx", "xlsx", "msg", "doc", "xls", "txt", "ppt", "pptx", "csv" };
        bool returnValue;

        if (allowedExtentions.Contains(fileExtention))
            returnValue = true;
        else
            returnValue = false;

        return returnValue;

    }
}