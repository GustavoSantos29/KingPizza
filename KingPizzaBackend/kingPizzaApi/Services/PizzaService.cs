using Microsoft.EntityFrameworkCore;
using kingPizzaApi.Models;
using KingPizzaApi.Data;
using KingPizza.Models;
using kingPizzaApi.DTOs;

namespace kingPizzaApi.Services;

public class PizzaService
{
    private readonly AppDbContext _context;

    public PizzaService(AppDbContext context)
    {
        _context = context;
    }

    // Listar todas com os ingredientes 
    public async Task<List<Pizza>> ListarTodas()
    {
        return await _context.Pizzas
            .Include(p => p.Ingredientes)
            .Where(p => p.Ativo == true)
            .ToListAsync();
    }

    // Buscar uma só pelo ID
    public async Task<Pizza?> BuscarPorId(Guid id)
    {
        return await _context.Pizzas
            .Include(p => p.Ingredientes)
            .Where(p => p.Ativo)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    // Criar uma nova pizza
    public async Task<Pizza> Criar(CreatePizzaDto dto)
    {

        var pizzaEntity = new Pizza
        {
            Nome = dto.Nome,
            Preco = dto.Preco,
            Descricao = dto.Descricao,

        };


        foreach (var idIngrediente in dto.IngredientesIds)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(idIngrediente);
            if (ingrediente != null)
            {
                pizzaEntity.Ingredientes.Add(ingrediente);
            }
        }

        _context.Pizzas.Add(pizzaEntity);
        await _context.SaveChangesAsync();

        return pizzaEntity;
    }

    // Deletar
    public async Task<bool> Deletar(Guid id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);
        if (pizza == null) return false;

        pizza.Ativo = false;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Atualizar(Guid id, UpdatePizzaDto dto)
    {
        var pizzaDb = await _context.Pizzas
            .Include(p => p.Ingredientes)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pizzaDb == null) return false;

        // Atualiza campos
        pizzaDb.Nome = dto.Nome;
        pizzaDb.Preco = dto.Preco;
        pizzaDb.Descricao = dto.Descricao;
        pizzaDb.DataModificacao = DateTime.UtcNow;

        // Atualiza Ingredientes
        pizzaDb.Ingredientes.Clear();
        foreach (var idIngrediente in dto.IngredientesIds)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(idIngrediente);
            if (ingrediente != null) pizzaDb.Ingredientes.Add(ingrediente);
        }

        await _context.SaveChangesAsync();
        return true;
    }
}