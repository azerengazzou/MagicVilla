using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MagicVilla_Api.Models.Dto
{
    public class VillaUpdateDTO
    {

        [Required]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public int Superficie { get; set; }

        public string Description { get; set; }
        public int NbRoom { get; set; }
        public string ImageUrl { get; set; }
        public double Rate { get; set; }

    }
}
