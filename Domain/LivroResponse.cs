using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class LivroResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Ano { get; set; }
        public virtual Autor Autor { get; set; }
    }
}
