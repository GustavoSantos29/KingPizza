using Microsoft.EntityFrameworkCore;
using kingPizzaApi.Models;
using KingPizzaApi.Data;

namespace kingPizzaApi.Services;

public class ClienteService
{
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente?> BuscarPorId(Guid id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<Cliente?> BuscarPorEmail(string email)
    {
        return await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<Cliente> Criar(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<bool> Atualizar(Guid id, Cliente clienteInput)
{
    var clienteDb = await _context.Clientes.FindAsync(id);
    
    if (clienteDb == null) return false;

    // Atualiza os campos
    clienteDb.Nome = clienteInput.Nome;
    clienteDb.Endereco = clienteInput.Endereco;
    clienteDb.Email = clienteInput.Email;
    clienteDb.Senha = clienteInput.Senha; 

    await _context.SaveChangesAsync();
    return true;
}
}