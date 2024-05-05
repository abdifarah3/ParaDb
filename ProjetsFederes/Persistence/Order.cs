using System.ComponentModel.DataAnnotations;

namespace ProjetsFederes.Persistence;

public class Order
{
    public int Id { get; set; }

    [Required(ErrorMessage = "La date de la commande est requise")]
    public DateTime Date { get; set; }

    //Should be removed, since it is a calculated attribute
    [Required(ErrorMessage = "Le total de la commande est requis")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Le total de la commande doit être supérieur à 0")]
    public decimal Total { get; set; }

    [Required(ErrorMessage = "Le statut de la commande est requis")]
    public string Status { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; }

    public ICollection<OrderLine> OrderLines { get; set; } = [];
}