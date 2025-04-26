using Microsoft.AspNetCore.Mvc;
using ProductExportApi.Services;

namespace ProductExportApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExportController : ControllerBase
{
    private readonly ExportService _service;

    public ExportController(ExportService service)
    {
        _service = service;
    }

    [HttpPost("{id}")]
    public IActionResult Export(int id)
    {
        var file = _service.GenerateWord(id);
        if (file == null) return NotFound();

        return File(file, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", $"Producto_{id}.docx");
    }
}