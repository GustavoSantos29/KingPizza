using Microsoft.EntityFrameworkCore;
using kingPizzaApi.Models;
using KingPizza.Models;
using KingPizzaApi.Data;
using kingPizzaApi.DTOs;
using System.Security.Claims;

namespace kingPizzaApi.Services;

public class PedidoService
{
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PedidoService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<Pedido>> ListarTodos()
    {

        var user = _httpContextAccessor.HttpContext?.User;

        var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var isAdmin = user?.IsInRole("Admin") ?? false;

       var query = _context.Pedidos
            .Include(p => p.Cliente)
            .Include(p => p.Itens)
            .ThenInclude(i => i.Ingredientes)
            .AsQueryable();

   
        if (!isAdmin && userIdClaim != null)
        {
            var userId = Guid.Parse(userIdClaim);
            query = query.Where(p => p.ClienteId == userId);
        }

        return await query.ToListAsync();
    }

    public async Task<Pedido> Criar(CreatePedidoDto dto)
    {
        var pedido = new Pedido
        {
            ClienteId = dto.ClienteId,
            EnderecoEntrega = dto.EnderecoEntrega,
            Data = DateTime.UtcNow
        };

        var pizzasDoPedido = new List<Pizza>();
        decimal total = 0;

        foreach (var idPizza in dto.PizzasIds)
        {
            var pizzaMenu = await _context.Pizzas
                .Include(p => p.Ingredientes)
                .FirstOrDefaultAsync(p => p.Id == idPizza && p.Ativo);

            if (pizzaMenu != null)
            {
                // Snapshot
                pizzasDoPedido.Add(new Pizza
                {
                    Nome = pizzaMenu.Nome,
                    Preco = pizzaMenu.Preco,
                    Descricao = pizzaMenu.Descricao,
                    Ingredientes = pizzaMenu.Ingredientes.ToList()
                });
                total += pizzaMenu.Preco;
            }
        }

        pedido.Itens = pizzasDoPedido;
        pedido.ValorTotal = total;

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();

        return pedido;
    }
}