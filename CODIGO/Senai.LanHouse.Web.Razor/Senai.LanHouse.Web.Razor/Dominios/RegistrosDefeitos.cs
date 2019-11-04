using System;
using System.Collections.Generic;

namespace Senai.LanHouse.Web.Razor.Dominios
{
    public partial class RegistrosDefeitos
    {
        public int Id { get; set; }
        public DateTime DataDefeito { get; set; }
        public int TipoEquipamentoId { get; set; }
        public int TipoDefeitoId { get; set; }
        public string Observacao { get; set; }

        public TiposDefeitos TipoDefeito { get; set; }
        public TiposEquipamentos TipoEquipamento { get; set; }
    }
}
