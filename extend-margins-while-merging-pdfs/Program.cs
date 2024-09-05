// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;


// Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your license key");

// Create a new PDF document
using PdfDocument outputDocument = new PdfDocument
{
    // Set the document margins to 50 points on all sides
    PageSettings = { Margins = { All = 50 } }
};

// Load the first and second PDF documents
using FileStream firstPDFStream = new FileStream("data/file1.pdf", FileMode.Open, FileAccess.Read);
using FileStream secondPDFStream = new FileStream("data/file2.pdf", FileMode.Open, FileAccess.Read);

// Create a merge options object
PdfMergeOptions mergeOptions = new PdfMergeOptions
{
    // Enable the extend margin option
    ExtendMargin = true
};

// Merge the PDF documents
PdfDocumentBase.Merge(outputDocument, mergeOptions, new[] { firstPDFStream, secondPDFStream });

// Save the document
using FileStream outputMemoryStream = new FileStream("extend-margins-while-merging-pdfs.pdf", FileMode.Create, FileAccess.ReadWrite);
outputDocument.Save(outputMemoryStream);
