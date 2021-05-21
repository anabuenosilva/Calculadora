using DataModel.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class CalculoHistoricoModel : BaseModel
    {
        public decimal? ValorPrimario { get; set; }
        public Operacoes? Operacao { get; set; }
        public decimal? ValorSecundario { get; set; }
        public decimal? Resultado { get; set; }
        public string Usuario { get; set; }
        public string Calculo { get; set; }

    }
}
