using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    [Table("pizza")]
    public class Pizza
    {
        public Pizza() { }

        public Pizza(string name, string description, string imgUrl)
        {
            Name = name;
            Description = description;
            ImgUrl = imgUrl;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio.")]
        [StringLength(25, ErrorMessage = "Il nome della pizza non puo' avere più di 25 caratteri.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descrizione è obbligatoria.")]
        [StringLength(250, ErrorMessage = "La descrizione della pizza non puo' avere più di 250 caratteri.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'immagine è obbligatoria.")]
        public string ImgUrl { get; set; } = string.Empty;
    }
}
