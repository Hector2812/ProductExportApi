using ProductExportApi.Models;
using ProductExportApi.Repositories;

namespace ProductExportApi.Services;

public class ProductService
{
    private readonly ProductRepository _repo;

    public ProductService(ProductRepository repo)
    {
        _repo = repo;
    }

    public List<Product> GetAll() => _repo.GetAll();
    public Product? GetById(int id) => _repo.GetById(id);
    public void Create(Product product) => _repo.Add(product);
    public bool Update(int id, Product updated) => _repo.Update(id, updated);
    public bool Delete(int id) => _repo.Delete(id);
}