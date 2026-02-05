using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using kingPizzaApi.Models;

namespace KingPizza.Models;
public class Ingrediente
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Nome { get; set; } = string.Empty;

    [JsonIgnore]
    public List<Pizza> Pizzas { get; set; } = new();
}