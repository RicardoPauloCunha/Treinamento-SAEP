using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.LanHouse.Web.Razor.Dominios
{
    public partial class RegistrosDefeitos
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Informe um data")]
        [Display(Name = "Data do Defeito")]
        public DateTime DataDefeito { get; set; }

        [Required(ErrorMessage = "Informe o id do tipo de equipamento")]
        [Display(Name = "Tipo do Equipamento")]
        public int TipoEquipamentoId { get; set; }

        [Required(ErrorMessage = "Informe o id do tipo de defeito")]
        [Display(Name = "Tipo do Defeito")]
        public int TipoDefeitoId { get; set; }

        [Required(ErrorMessage = "Informe a observação")]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Tipo de Defeito")]
        public TiposDefeitos TipoDefeito { get; set; }

        [Display(Name = "Tipo de Equipamento")]
        public TiposEquipamentos TipoEquipamento { get; set; }
    }
}
