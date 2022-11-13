using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_Pessoa.Interfaces
{
    /// <summary>
    /// metodo para calcular imposto
    /// </summary>
    /// <param name="rendimento">rendimento para basear o calculo do imposto
    /// <returns>valor do imposto a ser pago</returns>
    public interface IPessoa
    {
        float PagarImposto(float rendimento);
    }
}

//atributo letra inicial maiuscula
//classe letra inicial minuscula
//interfaces primeira letra I + nome da classe maisucula ex: IPessoa
//metodo inicial maisuscula e parametros(argumentos) em letras minusculas