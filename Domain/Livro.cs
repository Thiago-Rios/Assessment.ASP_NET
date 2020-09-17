using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Livro
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Ano { get; set; }
        [JsonIgnore]
        public virtual Autor Autor { get; set; }
    }
}
