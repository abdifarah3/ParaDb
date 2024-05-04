using System.ComponentModel.DataAnnotations;

namespace ProjetsFederes.Models
{
    public class Categorie
    {
        [Key]
        [Required]
        public int CategorieId { get; set; }

        [Required(ErrorMessage = "Le nom de la catégorie est requis")]
        [StringLength(100, ErrorMessage = "Le nom de la catégorie ne peut pas dépasser 100 caractères")]
        public string Nom { get; set; }

        // Autres propriétés...

        // Relation avec les produits
        public ICollection<Produit> Produits { get; set; }
    }
}
