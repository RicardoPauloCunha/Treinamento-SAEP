using System;
using System.Collections.Generic;

namespace Senai.ToDoCada.Web.Razor.Domains
{
    public partial class TiposSubtarefas
    {
        public TiposSubtarefas()
        {
            Subtarefas = new HashSet<Subtarefas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Subtarefas> Subtarefas { get; set; }
    }
}
