namespace Razor.ToDoCasa.Domains
{
    public partial class Subtarefas
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Concluido { get; set; }
        public int TipoSubtarefaId { get; set; }
        public int TarefaId { get; set; }
        public Tarefas Tarefa { get; set; }
        public TiposSubtarefas TipoSubtarefa { get; set; }
    }
}
