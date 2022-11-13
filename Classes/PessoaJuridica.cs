using System.Text.RegularExpressions;
using Cadastro_Pessoa.Interfaces;

namespace Cadastro_Pessoa.Classes
{
    //classe pessoa juridica herda da superclasse
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        //atributos da classe pessoa juridica
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }
        public string Caminho { get; private set; } = "dataBase/PessoaJuridica.csv";

        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 3000)
            {
                return rendimento * 0.03f;
            }
            else if (rendimento >= 3001 && rendimento <= 6000)
            {
                return rendimento * 0.05f;
            }
            else if (rendimento >= 6001 && rendimento <= 10000)
            {
                return rendimento * 0.07f;
            }
            else
            {
                return rendimento * 0.09f;
            }
        }

        //22.658.312/0001-77 : 18 caracteres
        //22658312000177 : 14 caracteres
        public bool ValidarCnpj(string cnpj)
        {
            if(Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(^\d{14})$)"))
            {
              if(cnpj.Length == 18)
              {
                if(cnpj.Substring(11, 4) == "0001")
                {
                    return true;
                }
              } 
              else if(cnpj.Length == 14)
              {
                if(cnpj.Substring(8, 4) == "0001")
                {
                    return true;
                }
              } 
            }
            return false;
            
        }

        public void Inserir(PessoaJuridica pj)
        {
            Utils.VerificarPastaArquivo(Caminho);

            string[] pjStrings = {$"{pj.Nome}, {pj.RazaoSocial}, {pj.Cnpj}, {pj.Rendimento}, {pj.Endereco.Logradouro}, {pj.Endereco.Numero}, {pj.Endereco.Complemento}"};

            File.AppendAllLines(Caminho, pjStrings);
        }

        public List<PessoaJuridica> LerArquivo()
        {
            List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(Caminho);

            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaJuridica cadaPJ = new PessoaJuridica();

                cadaPJ.Nome = atributos[0];
                cadaPJ.RazaoSocial = atributos[1];
                cadaPJ.Cnpj = atributos[2];
                cadaPJ.Rendimento = float.Parse(atributos[3]);
                cadaPJ.Endereco.Logradouro = atributos[4];
                cadaPJ.Endereco.Numero = int.Parse(atributos[5]);
                cadaPJ.Endereco.Complemento = atributos[6];

                listaPJ.Add(cadaPJ);
            }
            return listaPJ;
        }
    }
}

