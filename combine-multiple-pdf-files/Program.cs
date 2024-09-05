// See https://aka.ms/new-console-template for more information


using Syncfusion.Pdf;


// Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your license key");

//Create a PDF document 
using (PdfDocument finalDocument = new PdfDocument())
{
    //Get the stream from an existing PDF document 
    using (FileStream firstStream = new FileStream("data/file1.pdf", FileMode.Open, FileAccess.Read))
    using (FileStream secondStream = new FileStream("data/file2.pdf", FileMode.Open, FileAccess.Read))
    {
        //Create a stream array for merging 
        Stream[] streams = { firstStream, secondStream };
        //Merge PDF documents 
        PdfDocumentBase.Merge(finalDocument, streams);
        //Save the document 
        using (FileStream outputStream = new FileStream("combine-multiple-pdf-files.pdf", FileMode.Create, FileAccess.ReadWrite))
        {
            finalDocument.Save(outputStream);
        }
    }
}