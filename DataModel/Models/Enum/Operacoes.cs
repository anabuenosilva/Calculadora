using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.Models.Enum
{
    public enum Operacoes
    {
        [Description("Adição")]
        Adicao = 0,
        [Description("Subtração")]
        Subtracao = 1,
        [Description("Multiplicação")]
        Multiplicacao = 2,
        [Description("Divisão")]
        Divisao = 3
    }
}
