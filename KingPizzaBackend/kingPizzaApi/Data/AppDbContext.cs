using Microsoft.EntityFrameworkCore;
using KingPizza.Models;
using kingPizzaApi.Models;
namespace KingPizzaApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Suas tabelas
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Ingrediente> Ingredientes { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
}