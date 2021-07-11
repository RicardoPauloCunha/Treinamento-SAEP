using System.Collections.Generic;

namespace Razor.ToDoCasa.Domains
{
    public partial class TiposSubtarefas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Subtarefas> Subtarefas { get; set; }

        public TiposSubtarefas()
        {
            Subtarefas = new HashSet<Subtarefas>();
        }
    }
}
