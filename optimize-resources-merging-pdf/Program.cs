// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;

// Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your license key");

//Create a new PDF document 
using (PdfDocument outputDocument = new PdfDocument())
{
    //Load the first PDF document
    using (FileStream firstPDFStream = new FileStream("data/file1.pdf", FileMode.Open, FileAccess.Read))
    {
        //Load the second PDF document 
        using (FileStream secondPDFStream = new FileStream("data/file2.pdf", FileMode.Open, FileAccess.Read))
        {
            //Create a list of streams to merge 
            Stream[] streams = { firstPDFStream, secondPDFStream };
            //Create a merge options object 
            PdfMergeOptions mergeOptions = new PdfMergeOptions();
            //Enable the optimize resources option 
            mergeOptions.OptimizeResources = true;
            //Merge the PDF documents  
            PdfDocumentBase.Merge(outputDocument, mergeOptions, streams);
            //Save the document
            using (FileStream outputMemoryStream = new FileStream("optimize-resources-merge-pdf.pdf", FileMode.Create, FileAccess.ReadWrite))
            {
                outputDocument.Save(outputMemoryStream);
            }
        }
    }
}