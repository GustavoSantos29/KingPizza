using Microsoft.AspNetCore.Mvc;
using kingPizzaApi.Services;
using KingPizza.Models;
using Microsoft.AspNetCore.Authorization;

namespace kingPizzaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientesController : ControllerBase
{
    private readonly IngredienteService _service;

    public IngredientesController(IngredienteService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<Ingrediente>>> Get()
    {
        return Ok(await _service.ListarTodos());
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Ingrediente>> Post(Ingrediente ingrediente)
    {
        var novo = await _service.Criar(ingrediente);
        return CreatedAtAction(nameof(Get), new { id = novo.Id }, novo);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deletou = await _service.Deletar(id);
        if (!deletou) return NotFound();
        return NoContent();
    }
}