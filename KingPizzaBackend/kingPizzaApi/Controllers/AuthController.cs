using kingPizzaApi.DTOs;
using kingPizzaApi.Services;
using KingPizzaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace kingPizzaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ClienteService _clienteService; 
    private readonly TokenService _tokenService;     

    public AuthController(ClienteService clienteService, TokenService tokenService)
    {
        _clienteService = clienteService;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        var cliente = await _clienteService.BuscarPorEmail(login.Email);

        if (cliente == null || cliente.Senha != login.Senha)
            return Unauthorized("Email ou senha inválidos");

        var token = _tokenService.GenerateToken(cliente);

        return Ok(new 
        { 
            token = token,
            user = new { cliente.Nome, cliente.Email, cliente.IsAdmin } 
        });
    }
}