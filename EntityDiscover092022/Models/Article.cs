using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityDiscover092022.Models
{
    public class Article
    {
        //Propriétés de l'articles
        public int ArticleId { get; set; }
        public string Theme { get; set; }
        [MaxLength(30)]
        [Required]
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }

        //Liste des commentaires liés
        public virtual List<Comment> Comments { get; set; }
    }
}
