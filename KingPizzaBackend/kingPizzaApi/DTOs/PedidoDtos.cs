using System.ComponentModel.DataAnnotations;

namespace kingPizzaApi.DTOs;

public class CreatePedidoDto
{
    [Required]
    public Guid ClienteId { get; set; }
    
    public string EnderecoEntrega { get; set; } = string.Empty;
    
    public List<Guid> PizzasIds { get; set; } = new();
}