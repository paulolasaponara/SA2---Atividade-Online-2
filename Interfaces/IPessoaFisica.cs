using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_Pessoa.Interfaces
{
    public interface IPessoaFisica
    {
        /// <summary>
        /// metodo para validar data de nascimento
        /// </summary>
        /// <param name="datanascimento">data de nascimento</param>
        /// <returns>verdadeiro ou falso</returns>
        bool ValidarDataNascimento(DateTime datanascimento);
    }
}