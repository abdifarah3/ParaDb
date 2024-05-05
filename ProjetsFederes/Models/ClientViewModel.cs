using System.ComponentModel.DataAnnotations;

namespace ProjetsFederes.Models;

public class ClientViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Le nom du client est requis")]
    [StringLength(100, ErrorMessage = "Le nom du client ne peut pas dépasser 100 caractères")]
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Le type de peau du client est requis")]
    [StringLength(50, ErrorMessage = "Le type de peau du client ne peut pas dépasser 50 caractères")]
    public string SkinType { get; set; } = string.Empty;
}