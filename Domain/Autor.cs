using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public virtual IList<Livro> Livros { get; set; }
    }
}
