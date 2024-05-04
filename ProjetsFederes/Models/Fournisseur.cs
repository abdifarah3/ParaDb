using System.ComponentModel.DataAnnotations;

namespace ProjetsFederes.Models
{
    public class Fournisseur
    {
        public int FournisseurId { get; set; }

        [Required(ErrorMessage = "Le nom du fournisseur est requis")]
        [StringLength(100, ErrorMessage = "Le nom du fournisseur ne peut pas dépasser 100 caractères")]
        public string Nom { get; set; }

        [StringLength(100, ErrorMessage = "Le contact du fournisseur ne peut pas dépasser 100 caractères")]
        public string Contact { get; set; }
    }
}
