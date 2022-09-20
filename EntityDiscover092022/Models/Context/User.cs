using System;
using System.ComponentModel.DataAnnotations;

namespace EntityDiscover092022.Models.Context
{
    public class User
    {
        public int ID { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}