using Microsoft.AspNetCore.Mvc;
using kingPizzaApi.Models;
using kingPizzaApi.Services;
using KingPizza.Models;
using kingPizzaApi.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace kingPizzaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PizzasController : ControllerBase
{
    private readonly PizzaService _pizzaService;

    public PizzasController(PizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<Pizza>>> Get()
    {
        var pizzas = await _pizzaService.ListarTodas();
        return Ok(pizzas);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<Pizza>> Get(Guid id)
    {
        var pizza = await _pizzaService.BuscarPorId(id);

        if (pizza == null) return NotFound();

        return Ok(pizza);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Pizza>> Post(CreatePizzaDto pizza)
    {
        var novaPizza = await _pizzaService.Criar(pizza);
        return CreatedAtAction(nameof(Get), new { id = novaPizza.Id }, novaPizza);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deletou = await _pizzaService.Deletar(id);

        if (!deletou) return NotFound();

        return NoContent();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid id, UpdatePizzaDto pizza)
    {

        var atualizou = await _pizzaService.Atualizar(id, pizza);

        if (!atualizou) return NotFound();

        return NoContent();
    }
}