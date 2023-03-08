using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MagicVilla_Api.Models
{
    public class VillaUpdateDTO
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int Superficie { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int NbRoom { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public double Rate { get; set; }

    }
}
