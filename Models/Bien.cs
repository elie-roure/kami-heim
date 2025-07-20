using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kami_heim.Models
{
    public class Bien
    {
        public int Id { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Type { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}
