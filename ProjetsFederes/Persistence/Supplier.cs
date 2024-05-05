using System.ComponentModel.DataAnnotations;

namespace ProjetsFederes.Persistence;

public class Supplier
{
    public int Id { get; set; }

    [StringLength(100, ErrorMessage = "Le nom du fournisseur ne peut pas dépasser 100 caractères")]
    public string Name { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Le contact du fournisseur ne peut pas dépasser 100 caractères")]
    public string Contact { get; set; } = string.Empty;
}