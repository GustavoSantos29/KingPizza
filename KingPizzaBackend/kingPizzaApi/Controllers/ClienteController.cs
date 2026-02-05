using Microsoft.AspNetCore.Mvc;
using kingPizzaApi.Models;
using kingPizzaApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace kingPizzaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly ClienteService _service;

    public ClientesController(ClienteService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> Get(Guid id)
    {
        var cliente = await _service.BuscarPorId(id);
        if (cliente == null) return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> Post(Cliente cliente)
    {
        var existente = await _service.BuscarPorEmail(cliente.Email);
        if (existente != null)
        {
            return BadRequest("Já existe um cliente com este e-mail.");
        }

        var novo = await _service.Criar(cliente);
        return CreatedAtAction(nameof(Get), new { id = novo.Id }, novo);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Put(Guid id, Cliente cliente)
    {
        if (id != cliente.Id) return BadRequest("IDs não conferem");

        var atualizou = await _service.Atualizar(id, cliente);

        if (!atualizou) return NotFound();

        return NoContent(); 
    }
}