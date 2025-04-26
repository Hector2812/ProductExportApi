using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ProductExportApi.Helpers;

public static class WordHelper
{
    public static byte[] ReplacePlaceholders(string templatePath, Dictionary<string, string> values)
    {
        using var ms = new MemoryStream();
        File.Copy(templatePath, "temp.docx", true);

        using (var doc = WordprocessingDocument.Open("temp.docx", true))
        {
            var body = doc.MainDocumentPart?.Document?.Body;
            if (body == null) throw new Exception("No se pudo acceder al contenido Word.");

            foreach (var text in body.Descendants<Text>())
            {
                foreach (var key in values.Keys)
                {
                    string placeholder = $"{{{{{key}}}}}";
                    if (text.Text.Contains(placeholder))
                    {
                        text.Text = text.Text.Replace(placeholder, values[key]);
                    }
                }
            }

            doc.MainDocumentPart.Document.Save();
        } 

        
        var finalBytes = File.ReadAllBytes("temp.docx");
        File.Delete("temp.docx");

        return finalBytes;

    }
}