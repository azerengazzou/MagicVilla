using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_Api.Models
{
    public class VillaBooking
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingNum { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
