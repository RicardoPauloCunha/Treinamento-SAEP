using System;
using System.Collections.Generic;

namespace Senai.ToDoCada.Web.Razor.Domains
{
    public partial class Tarefas
    {
        public Tarefas()
        {
            Subtarefas = new HashSet<Subtarefas>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataCriacao { get; set; }

        public ICollection<Subtarefas> Subtarefas { get; set; }
    }
}
