using System.Collections.Generic;

namespace Razor.LanHouse.Dominios
{
    public partial class TiposEquipamentos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<RegistrosDefeitos> RegistrosDefeitos { get; set; }

        public TiposEquipamentos()
        {
            RegistrosDefeitos = new HashSet<RegistrosDefeitos>();
        }
    }
}
