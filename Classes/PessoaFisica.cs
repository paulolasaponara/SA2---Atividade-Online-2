using Cadastro_Pessoa.Interfaces;

namespace Cadastro_Pessoa.Classes
{
    //classe pessoa fisica que herda da superclasse Pessoa
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        //atributos da classe pessoa fisica
        public string? Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 1500f)
            {
                return 0;
            }
            else if (rendimento >= 1501 && rendimento <= 3500)
            {
                return rendimento * 0.02f;
            }
            else if (rendimento >= 3501 && rendimento <= 6000)
            {
                return rendimento * 0.035f;
            }
            else
            {
                return rendimento * 0.5f;
            }
        }

        public bool ValidarDataNascimento(DateTime datanascimento)
        {
            //DateTime.Today pega a data
            //DateTime.now pega data e hora
            DateTime dataAtual = DateTime.Today;
            //TotalDays = converte para dias
            double anos = (dataAtual - datanascimento).TotalDays / 365;

            //condicional para verificaçao
            if (anos >= 18)
            {
                return true;
            }
            //nao precisamos do else porque caso seja vdd o primeiro retorno é true
            return false;
        }

        public bool ValidarDataNascimento(string datanascimento)
        {
            DateTime dataConvertida;

            //verificar se a string esta em um formato valido
            //DateTime.TryParse tenta converter a string em DateTime e coloca na saida que é o "out"
            if (DateTime.TryParse(datanascimento, out dataConvertida))
            {
                DateTime dataAtual = DateTime.Today;

                double anos = (dataAtual - dataConvertida).TotalDays / 365;

                if (anos >= 18)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}


//datetime : "19/10/2017" tipo string