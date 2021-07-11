using System.Collections.Generic;

namespace Razor.LanHouse.Dominios
{
    public partial class TiposDefeitos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<RegistrosDefeitos> RegistrosDefeitos { get; set; }

        public TiposDefeitos()
        {
            RegistrosDefeitos = new HashSet<RegistrosDefeitos>();
        }
    }
}
