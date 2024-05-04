using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetsFederes.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Le nom du client est requis")]
        [StringLength(100, ErrorMessage = "Le nom du client ne peut pas dépasser 100 caractères")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le type de peau du client est requis")]
        [StringLength(50, ErrorMessage = "Le type de peau du client ne peut pas dépasser 50 caractères")]
        public string Adresse { get; set; }

        public string Email { get; set; }
        public string TypePeau { get; set; }

        // Autres propriétés du client...

        // Relations avec les produits achetés
        public ICollection<DetailCommande> Achats { get; set; }
    }
}
