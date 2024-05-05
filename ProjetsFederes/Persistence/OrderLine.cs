using System.ComponentModel.DataAnnotations;

namespace ProjetsFederes.Persistence;

public class OrderLine
{
    public int Id { get; set; }

    [Required(ErrorMessage = "La quantité est requise")]
    [Range(1, int.MaxValue, ErrorMessage = "La quantité doit être supérieure à zéro")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Le prix unitaire est requis")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Le prix unitaire doit être supérieur à zéro")]
    public decimal UnitPrice { get; set; }


    [Required(ErrorMessage = "Le produit est requis")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Required(ErrorMessage = "La commande est requise")]
    public int OrderId { get; set; }
    public Order Order { get; set; }
}