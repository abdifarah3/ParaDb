using System.ComponentModel.DataAnnotations;

namespace ProjetsFederes.Persistence;

public class Category
{
    public int Id { get; set; }

    [StringLength(100, ErrorMessage = "Le nom de la catégorie ne peut pas dépasser 100 caractères")]
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}