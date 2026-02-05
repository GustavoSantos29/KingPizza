using Microsoft.EntityFrameworkCore;
using kingPizzaApi.Models;
using KingPizza.Models;
using KingPizzaApi.Data;

namespace kingPizzaApi.Services;

public class IngredienteService
{
    private readonly AppDbContext _context;

    public IngredienteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ingrediente>> ListarTodos()
    {
        return await _context.Ingredientes.ToListAsync();
    }

    public async Task<Ingrediente?> BuscarPorId(Guid id)
    {
        return await _context.Ingredientes.FindAsync(id);
    }

    public async Task<Ingrediente> Criar(Ingrediente ingrediente)
    {
        _context.Ingredientes.Add(ingrediente);
        await _context.SaveChangesAsync();
        return ingrediente;
    }

    public async Task<bool> Deletar(Guid id)
    {
        var ingrediente = await _context.Ingredientes.FindAsync(id);
        if (ingrediente == null) return false;

        _context.Ingredientes.Remove(ingrediente);
        await _context.SaveChangesAsync();
        return true;
    }
}