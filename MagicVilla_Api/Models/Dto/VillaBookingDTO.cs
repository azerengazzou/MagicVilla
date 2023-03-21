using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Api.Models.Dto
{
    public class VillaBookingDTO
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingNum { get; set; }
        public string SpecialDetails { get; set; }
    }
}
