using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_Api.Models
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Superficie { get; set; }
        public int NbRoom { get; set; }
        public string ImageUrl { get; set; }
        public double Rate { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Updated_date { get; set; }
        
    }
}
