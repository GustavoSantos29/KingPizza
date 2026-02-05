using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KingPizza.Models; 

namespace kingPizzaApi.Models;

public class Pedido
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime Data { get; set; } = DateTime.UtcNow;

    public decimal ValorTotal { get; set; }

    [Required]
    public string EnderecoEntrega { get; set; } = string.Empty;

    [Required]
    public Guid ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public Cliente? Cliente { get; set; }

    public List<Pizza> Itens { get; set; } = new();
}