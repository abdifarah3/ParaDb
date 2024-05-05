using System.ComponentModel.DataAnnotations;

namespace ProjetsFederes.Persistence;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom du produit est requis")]
    [StringLength(100, ErrorMessage = "Le nom du produit ne peut pas dépasser 100 caractères")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "La description du produit est requise")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Le prix du produit est requis")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à 0")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "La quantité en stock du produit est requise")]
    [Range(0, int.MaxValue, ErrorMessage = "La quantité en stock doit être positive")]
    public int StockQuantity { get; set; }

    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    [StringLength(50, ErrorMessage = "Le type de peau recommandé ne peut pas dépasser 50 caractères")]
    public string RecommendedSkinType { get; set; } = string.Empty;
}