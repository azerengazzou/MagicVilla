using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MagicVilla_Api.Models.Dto
{
    public class VillaBookingCreateDTO
    {
        [Required]
        public int BookingNum { get; set; }
        public string SpecialDetails { get; set; }

    }
}
