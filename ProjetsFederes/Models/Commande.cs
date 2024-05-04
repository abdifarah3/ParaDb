using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetsFederes.Models
{
    public class Commande
    {
        [Key]
        public int CommandeId { get; set; }

        [Required(ErrorMessage = "La date de la commande est requise")]
        public DateTime DateCommande { get; set; }

        [Required(ErrorMessage = "Le total de la commande est requis")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le total de la commande doit être supérieur à 0")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Le statut de la commande est requis")]
        public string Status { get; set; }

        // Relation avec le client
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        // Autres propriétés de la commande...
    }
}
