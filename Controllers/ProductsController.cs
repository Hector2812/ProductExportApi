using Microsoft.AspNetCore.Mvc;
using ProductExportApi.Models;
using ProductExportApi.Services;

namespace ProductExportApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;

    public ProductsController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Product>> Get() => _service.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var p = _service.GetById(id);
        return p is null ? NotFound() : Ok(p);
    }

    [HttpPost]
    public IActionResult Post(Product product)
    {
        _service.Create(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Product updated)
    {
        if (!_service.Update(id, updated)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_service.Delete(id)) return NotFound();
        return NoContent();
    }
}