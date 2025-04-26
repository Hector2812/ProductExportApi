using ProductExportApi.Models;
using ProductExportApi.Helpers;

namespace ProductExportApi.Repositories;

public class ProductRepository
{
    private readonly string _filePath = "Data/productos.json";
    private List<Product> _products;

    public ProductRepository()
    {
        _products = JsonHelper.LoadFromJson<List<Product>>(_filePath) ?? new();
    }

    public List<Product> GetAll() => _products;
    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
    public void Add(Product product)
    {
        product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
        _products.Add(product);
        SaveChanges();
    }

    public bool Update(int id, Product updated)
    {
        var existing = GetById(id);
        if (existing == null) return false;

        existing.Name = updated.Name;
        existing.Description = updated.Description;
        existing.Price = updated.Price;
        existing.Stock = updated.Stock;
        SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var product = GetById(id);
        if (product == null) return false;
        _products.Remove(product);
        SaveChanges();
        return true;
    }

    private void SaveChanges() => JsonHelper.SaveToJson(_products, _filePath);
}