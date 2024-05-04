using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetsFederes.Models
{
    public class DetailCommande
    {
        [Key]
        public int DetailCommandeId { get; set; }

        [Required(ErrorMessage = "La quantité est requise")]
        [Range(1, int.MaxValue, ErrorMessage = "La quantité doit être supérieure à zéro")]
        public int Quantite { get; set; }

        [Required(ErrorMessage = "Le prix unitaire est requis")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix unitaire doit être supérieur à zéro")]
        public decimal PrixUnitaire { get; set; }

        // Relation avec le produit
        [ForeignKey("Produit")]
        [Required(ErrorMessage = "Le produit est requis")]
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }

        // Relation avec la commande
        [ForeignKey("Commande")]
        [Required(ErrorMessage = "La commande est requise")]
        public int CommandeId { get; set; }
        public Commande Commande { get; set; }
    }
}
