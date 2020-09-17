using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class AutorResponse
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DataDeNascimento { get; set; }
        public virtual IList<Livro> Livros { get; set; }
    }
}
