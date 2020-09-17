﻿using System.Text.Json.Serialization;

namespace Domain
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Ano { get; set; }
        [JsonIgnore]
        public virtual Autor Autor { get; set; }
    }
}
