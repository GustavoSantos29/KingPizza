using Microsoft.AspNetCore.Mvc;
using kingPizzaApi.Models;
using kingPizzaApi.Services;
using kingPizzaApi.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace kingPizzaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidosController : ControllerBase
{
    private readonly PedidoService _service;

    public PedidosController(PedidoService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<Pedido>>> Get()
    {
        var lista = await _service.ListarTodos();
        return Ok();
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Pedido>> Post(CreatePedidoDto dto)
    {
        var pedido = await _service.Criar(dto);
        return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
    }
}