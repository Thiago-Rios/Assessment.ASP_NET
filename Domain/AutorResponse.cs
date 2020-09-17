using System;
using System.Collections.Generic;

namespace Domain
{
    public class AutorResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public virtual IList<Livro> Livros { get; set; }
    }
}
