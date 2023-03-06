using MagicVilla_Api.Models;

namespace MagicVilla_Api.Data
{
    public class VillaStore 
    {
        public static List<VillaDTO> VillaList = new List<VillaDTO>
            {
                new VillaDTO
                {
                    Id = 1,
                    Name = "Pool View",
                    Superficie=400,
                    NbRoom=5
                },
                new VillaDTO{
                    Id= 2,
                    Name="Ocean View",
                    Superficie=300,
                    NbRoom=4
                }
            };
    }
}
