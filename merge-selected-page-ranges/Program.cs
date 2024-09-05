// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

// Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your license key");

// Create a new PDF document
using PdfDocument finalDocument = new PdfDocument();

// Open and load the first PDF file
using FileStream firstStream = new FileStream("data/file1.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument1 = new PdfLoadedDocument(firstStream);
// Import pages 2 to 5 from the first PDF document
finalDocument.ImportPageRange(loadedDocument1, 1, 5);

// Open and load the second PDF file
using FileStream secondStream = new FileStream("data/file2.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument2 = new PdfLoadedDocument(secondStream);
// Import pages 1 to 2 from the second PDF document
finalDocument.ImportPageRange(loadedDocument2, 0, 1);

// Save the final document
using FileStream outputStream = new FileStream("merge-selected-page-ranges.pdf", FileMode.Create, FileAccess.ReadWrite);
finalDocument.Save(outputStream);