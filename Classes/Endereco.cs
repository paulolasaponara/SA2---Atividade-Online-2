namespace Cadastro_Pessoa.Classes
{
    public class Endereco
    {
        //atributos da classe endereco
        public string? Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public bool Comercial { get; set; }
        public string? Cep { get; set; }
    }
}