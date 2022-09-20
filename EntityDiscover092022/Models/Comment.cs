using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EntityDiscover092022.Models
{
    public class Comment
    {
        //Propriétés du commentaire
        public int CommentId { get; set; }
        [MaxLength(30)]
        [Required]
        public string Author { get; set; }
        public string Content { get; set; }


        //Référence à l'article lié
        public int ArticleId { get; set; }
        //Contenu de l'article lié
        [JsonIgnore]
        public virtual Article Article { get; set; }
    }
}
