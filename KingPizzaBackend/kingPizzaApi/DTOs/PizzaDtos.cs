using System.ComponentModel.DataAnnotations;

namespace kingPizzaApi.DTOs;

public class CreatePizzaDto
{
    [Required]
    public string Nome { get; set; } = string.Empty;
    
    [Required]
    public decimal Preco { get; set; }
    
    public string Descricao { get; set; } = string.Empty;
    
    public List<Guid> IngredientesIds { get; set; } = new();
}

public class UpdatePizzaDto
{
    [Required]
    public string Nome { get; set; } = string.Empty;
    
    [Required]
    public decimal Preco { get; set; }
    
    public string Descricao { get; set; } = string.Empty;
    
    public List<Guid> IngredientesIds { get; set; } = new();
}