using ProductExportApi.Helpers;
using ProductExportApi.Repositories;

namespace ProductExportApi.Services;

public class ExportService
{
    private readonly ProductRepository _repo;
    private readonly string _templatePath = "Data/plantilla.docx";

    public ExportService(ProductRepository repo)
    {
        _repo = repo;
    }

    public byte[]? GenerateWord(int id)
    {
        var product = _repo.GetById(id);
        if (product == null) return null;

        var values = new Dictionary<string, string>
        {
            { "Nombre", product.Name },
            { "Descripcion", product.Description },
            { "Precio", product.Price.ToString("F2") },
            { "Stock", product.Stock.ToString() }
        };

        return WordHelper.ReplacePlaceholders(_templatePath, values);
    }
}