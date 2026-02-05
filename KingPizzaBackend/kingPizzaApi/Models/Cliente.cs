using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace kingPizzaApi.Models;

public class Cliente
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [EmailAddress] 
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Senha { get; set; } = string.Empty;

    [Required]
    public string Endereco { get; set; } = string.Empty;

    public string? Foto { get; set; } = string.Empty; 

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    [JsonIgnore]
    public List<Pedido> Pedidos { get; set; } = new();

    public bool IsAdmin { get; set; } = false;
}