using System;
using System.ComponentModel.DataAnnotations;

namespace EntityDiscover092022.Models
{
    public class Taches
    {
        public int TachesId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public string Status { get; set; }
    }
}
