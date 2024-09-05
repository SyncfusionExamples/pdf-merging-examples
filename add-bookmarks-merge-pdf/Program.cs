// See https://aka.ms/new-console-template for more information
  
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Parsing;

// Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your license key");


//Create a PDF document
using (PdfDocument finalDocument = new PdfDocument())
{
    //Load the first PDF document 
    using (FileStream firstStream = new FileStream("data/file1.pdf", FileMode.Open, FileAccess.Read))
    //Load the second PDF document  
    using (FileStream secondStream = new FileStream("data/file2.pdf", FileMode.Open, FileAccess.Read))
    {       

        //Load the stream using PdfLoadedDocument class
        using PdfLoadedDocument loadedDocument1 = new PdfLoadedDocument(firstStream);
        using PdfLoadedDocument loadedDocument2 = new PdfLoadedDocument(secondStream);

        //Merge PDF documents  
        PdfDocumentBase.Merge(finalDocument, [loadedDocument1, loadedDocument2]);

        //Create a bookmark for the first PDF file 
        PdfBookmark bookmark1 = finalDocument.Bookmarks.Add("Chapter 1 - Barcodes");
        //Set the destination page for the first bookmark  
        bookmark1.Destination = new PdfDestination(finalDocument.Pages[0]);
        //Set the destination for the first bookmark  
        bookmark1.Destination.Location = new PointF(20, 20);

        //Create a bookmark for the second PDF file 
        PdfBookmark bookmark2 = finalDocument.Bookmarks.Add("Chapter 2 - HTTP Succinctly");
        //Set the destination page for the second bookmark  
        bookmark2.Destination = new PdfDestination(finalDocument.Pages[loadedDocument1.PageCount]);
        //Set the destination  for the second bookmark 
        bookmark2.Destination.Location = new PointF(20, 20);

        // Save the document into a stream  
        using (FileStream outputFileStream = new FileStream("add-bookmarks.pdf", FileMode.Create, FileAccess.ReadWrite))
        {
            finalDocument.Save(outputFileStream);
        }
    }
}