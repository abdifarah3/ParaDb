using Microsoft.AspNetCore.DataProtection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace ProjetsFederes.Models
{
    public class Produit
    {
        [Key]
        public int ProduitId { get; set; }

        [Required(ErrorMessage = "Le nom du produit est requis")]
        [StringLength(100, ErrorMessage = "Le nom du produit ne peut pas dépasser 100 caractères")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "La description du produit est requise")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Le prix du produit est requis")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à 0")]
        public decimal Prix { get; set; }

        [Required(ErrorMessage = "La quantité en stock du produit est requise")]
        [Range(0, int.MaxValue, ErrorMessage = "La quantité en stock doit être positive")]
        public int QuantiteEnStock { get; set; }

        // Relation avec le fournisseur
        [ForeignKey("Fournisseur")]
        [Required(ErrorMessage = "Le fournisseur du produit est requis")]
        public int FournisseurId { get; set; }
        public Fournisseur Fournisseur { get; set; }

        // Relation avec la catégorie
        [ForeignKey("Categorie")]
        [Required(ErrorMessage = "La catégorie du produit est requise")]
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        // Type de peau recommandé
        
        [StringLength(50, ErrorMessage = "Le type de peau recommandé ne peut pas dépasser 50 caractères")]
        public string TypePeauRecommande { get; set; }
    }
}
