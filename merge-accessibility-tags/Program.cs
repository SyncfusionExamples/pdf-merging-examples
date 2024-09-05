using Syncfusion.Pdf;


// Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your license key");

// Create a PDF document.
using (PdfDocument finalDoc = new PdfDocument())
{
    // Load the PDF documents.
    using (FileStream stream1 = new FileStream("data/file1.pdf", FileMode.Open, FileAccess.Read))
    using (FileStream stream2 = new FileStream("data/file2.pdf", FileMode.Open, FileAccess.Read))
    {
        // Create merge options
        PdfMergeOptions mergeOptions = new PdfMergeOptions
        {
            // Enable the Merge Accessibility Tags.
            MergeAccessibilityTags = true
        };

        // Merge PDFDocument.
        PdfDocumentBase.Merge(finalDoc, mergeOptions, [stream1, stream2]);

        // Save the document into stream.
        using (FileStream outputFileStream = new FileStream("merge-tags.pdf", FileMode.Create, FileAccess.ReadWrite))
        {
            finalDoc.Save(outputFileStream);
        }
    }
}
