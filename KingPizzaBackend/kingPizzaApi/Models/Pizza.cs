using System.ComponentModel.DataAnnotations;
using KingPizza.Models;

namespace kingPizzaApi.Models;

public class Pizza
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required] // VOLTOU A SER OBRIGATÓRIO
    public string Nome { get; set; } = string.Empty;

    [Required]
    public decimal Preco { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public bool Ativo { get; set; } = true;

    // Relacionamentos continuam iguais
    public List<Ingrediente> Ingredientes { get; set; } = new();

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public DateTime DataModificacao { get; set; } = DateTime.UtcNow;
}