namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DocumentCreator
    {
        public static ITextDocument CreateTextDocument(string name, IList<KeyValuePair<string, object>> parameters)
        {
            var txtDoc = new TextDocument(name);
            LoadParameters(parameters, txtDoc);

            return txtDoc;
        }

        public static IPdfDocument CreatePdfDocument(string name, IList<KeyValuePair<string, object>> parameters)
        {
            var pdfDoc = new PDFDocument(name);
            LoadParameters(parameters, pdfDoc);

            return pdfDoc;
        }

        private static void LoadParameters(IList<KeyValuePair<string, object>> parameters, IDocument document)
        {
            foreach (var pair in parameters)
            {
                document.LoadProperty(pair.Key, pair.Value.ToString());
            }
        }
    }
}
