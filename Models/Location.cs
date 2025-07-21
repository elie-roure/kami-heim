using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kami_heim.Models
{
    public class Location
    {
        public int BienId { get; set; }
        public Bien? Bien { get; set; }

        public int LocataireId { get; set; }
        public Locataire? Locataire { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
    }
}
