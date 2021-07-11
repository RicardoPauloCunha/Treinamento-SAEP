using System;
using System.Collections.Generic;

namespace Razor.ToDoCasa.Domains
{
    public partial class Tarefas
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataCriacao { get; set; }
        public ICollection<Subtarefas> Subtarefas { get; set; }

        public Tarefas()
        {
            Subtarefas = new HashSet<Subtarefas>();
        }
    }
}
