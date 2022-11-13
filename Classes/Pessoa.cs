using Cadastro_Pessoa.Interfaces;

namespace Cadastro_Pessoa.Classes
{
    //classe pessoa é a superclasse
    public abstract class Pessoa : IPessoa
    {
        //atributos da classe pessoa
       public string? Nome { get; set; }
       public Endereco? Endereco { get; set; }
       public float Rendimento { get; set; }

        public abstract float PagarImposto(float rendimento);
        
    }
}

//metodos acessores
//get : leitura
//set : editar
//por padrao esses metodos acessores vem como publico, mas caso necessite, coloque como privado
