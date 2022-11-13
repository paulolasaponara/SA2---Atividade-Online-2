using System.Globalization;
using Cadastro_Pessoa.Classes;

Console.Clear();
Console.BackgroundColor = ConsoleColor.DarkGreen;
Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine(@$"
=======================================
| Bem Vindo ao sistema de cadastro de |
|     Pessoas Fisicas e Juridicas     |
=======================================
");

Utils.BarraCarregamento("Iniciando", 300, 10);

Console.ResetColor();

//lista para armazenar as pessoas fisicas cadastradas
List<PessoaFisica> listaPF = new List<PessoaFisica>();
List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();


string? opcao;

do
{
    Console.Clear();
    Console.BackgroundColor = ConsoleColor.DarkGreen;
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine(@$"
=======================================
|   Escolha uma das opções abaixo     |
|-------------------------------------|
|   1- Pessoa Fisica                  |
|   2- Pessoa Juridica                |
|                                     |
|   0- Sair                           |
=======================================
");

    Console.ResetColor();

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

            string? opcaoPF;

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(@$"
=======================================
|   Escolha uma das opções abaixo     |
|-------------------------------------|
|   1- Cadastrar Pessoa Fisica        |
|   2- Listar Pessoa Fisica           |
|                                     |
|   0- Voltar ao menu anterior        |
=======================================
");
                Console.ResetColor();

                opcaoPF = Console.ReadLine();

                PessoaFisica MetodosPf = new PessoaFisica();

                switch (opcaoPF)
                {
                    case "1":
                        //criaçao dos objetos
                        PessoaFisica novaPessoaFisica = new PessoaFisica();
                        Endereco novoEnderecopf = new Endereco();

                        //entrada e armazenamento do nome
                        Console.WriteLine(@$"Digite o nome");
                        novaPessoaFisica.Nome = Console.ReadLine();

                        //entrada e armazenamento do cpf
                        Console.WriteLine(@$"Digite o CPF");
                        novaPessoaFisica.Cpf = Console.ReadLine();


                        //validaçao da data de nascimento

                        bool dataValida; //variavel que guarda a info se a data de nascimento é valida

                        do // laço de repetiçao
                        {
                            //entrada e armazenamento da data de nascimento digitado
                            Console.WriteLine(@$"Digite a data de nascimento");
                            string? dataNascimento = Console.ReadLine();

                            //variavel recebe a validaçao da data de nascimento digitada
                            dataValida = MetodosPf.ValidarDataNascimento(dataNascimento);

                            //se a data for valida
                            if (dataValida)
                            {
                                //variavel para armazenar a data convertida de string para datetime
                                DateTime dataConvertida;

                                //fazendo a conversão e colocando a saída dentro da variável dataConvertida
                                DateTime.TryParse(dataNascimento, out dataConvertida);

                                //atribui a data digitada para a DataNascimento do objeto
                                novaPessoaFisica.DataNascimento = dataConvertida;
                            }
                            else
                            {
                                //senão, mostra uma mensagem no console que a data não é válida
                                Console.WriteLine($"Data invalida, por favor digite uma data valida");
                            }
                        } while (dataValida == false);

                        //entrada e armazenamento do rendimento
                        Console.WriteLine($"Digite o rendimento mensal, apenas numeros");
                        novaPessoaFisica.Rendimento = float.Parse(Console.ReadLine());

                        //entrada e armazenamento do logradouro
                        Console.WriteLine($"Digite o endereço: ");
                        novoEnderecopf.Logradouro = Console.ReadLine();

                        //entrada e armazenamento do numero
                        Console.WriteLine($"Digite o numero");
                        novoEnderecopf.Numero = int.Parse(Console.ReadLine());

                        //entrada e armazenamento do complemento
                        Console.WriteLine($"Complemento");
                        novoEnderecopf.Complemento = Console.ReadLine();

                        //entrada e armazenamento do endereço comercial
                        Console.WriteLine($"Endereço comercial? S para sim ou N para não");

                        string endCom = Console.ReadLine().ToUpper();

                        //se o endereço digitado for comercial "S"
                        if (endCom == "S")
                        {
                            //atribui true para o endereço comercial
                            novoEnderecopf.Comercial = true;
                        }
                        else
                        {
                            //senao, atribui false
                            novoEnderecopf.Comercial = false;
                        }

                        //então armazena todos os dados do objeto novoEndPf dentro do endereço do objeto novaPessoaFisica
                        novaPessoaFisica.Endereco = novoEnderecopf;

                        //adicionamos a pessoa cadastrada dentro da lista
                        listaPF.Add(novaPessoaFisica);

                        // StreamWriter sw = new StreamWriter($"{novaPessoaFisica.Nome}.txt");
                        // sw.WriteLine(novaPessoaFisica.Nome);
                        // sw.Close();

                        using (StreamWriter sw = new StreamWriter($"{novaPessoaFisica.Nome}.txt"))
                        {
                            sw.WriteLine(novaPessoaFisica.Nome);
                        }

                        //finalizando com uma mensagem
                        Console.WriteLine($"Cadastro realizado com sucesso");
                        Thread.Sleep(2000);
                        break;

                    case "2":

                        using (StreamReader sr = new StreamReader("Paulo.txt"))
                        {
                            string? linha;

                            while ((linha = sr.ReadLine()) != null)
                            {
                                Console.WriteLine($"{linha}");

                            }
                        }
                        Console.WriteLine($"Aperte ENTER para continuar");
                        Console.ReadLine();

                        break;

                    case "0":
                        //voltar ao menu anterior
                        break;

                    default:
                        //mensagem generica
                        Console.WriteLine($"Opção invalida, digite outra opção");
                        break;
                }


            } while (opcaoPF != "0");

            Console.WriteLine("Aperte ENTER para continuar");
            Console.ReadLine();
            break;


        case "2":

            PessoaJuridica metodosPJ = new PessoaJuridica();

            string? opcaoPJ;

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(@$"
                =============================================
                |           Escolha uma das opções          |
                |-------------------------------------------|
                |      1- Cadastrar Pessoa Juridica         |
                |      2- Listar Pessoa Juridica            |
                |                                           |
                |      0- Voltar ao menu anterior           |
                =============================================
                ");

                Console.WriteLine($"Escolha uma opção");
                Console.ResetColor();
                opcaoPJ = Console.ReadLine();


                switch (opcaoPJ)

                {
                    case "1":

                        PessoaJuridica novaPessoaJuridica = new PessoaJuridica();
                        Endereco novoEndereco = new Endereco();

                        Console.WriteLine($"Digite o nome");
                        novaPessoaJuridica.Nome = Console.ReadLine();

                        Console.WriteLine($"Digite a razão social");
                        novaPessoaJuridica.RazaoSocial = Console.ReadLine();

                        bool cnpjValido;
                        do
                        {
                            Console.WriteLine($"Digite o CNPJ");
                            string CNPJ = Console.ReadLine();

                            cnpjValido = metodosPJ.ValidarCnpj(CNPJ);

                            if (cnpjValido == true)
                            {
                                Console.WriteLine($"CNPJ valido");
                                novaPessoaJuridica.Cnpj = CNPJ;
                            }
                            else
                            {
                                Console.WriteLine($"CNPJ invalido");
                            }

                        } while (cnpjValido == false);

                        Console.WriteLine($"Digite o rendimento");
                        novaPessoaJuridica.Rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro");
                        novoEndereco.Logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o numero");
                        novoEndereco.Numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Complemento");
                        novoEndereco.Complemento = Console.ReadLine();

                        Console.WriteLine($"Endereço comercial ? S para sim ou N para não");

                        string endCom = Console.ReadLine().ToUpper();


                        if (endCom == "S")
                        {
                            novoEndereco.Comercial = true;
                        }
                        else
                        {
                            novoEndereco.Comercial = false;
                        }

                        novaPessoaJuridica.Endereco = novoEndereco;



                        listaPJ.Add(novaPessoaJuridica);

                        metodosPJ.Inserir(novaPessoaJuridica);

                        foreach (PessoaJuridica cadaItem in listaPJ)
                        {
                            Console.WriteLine(@$"
                            Nome: {cadaItem.Nome}
                            Razão Social: {cadaItem.RazaoSocial}
                            CNPJ: {cadaItem.Cnpj}
                            Rendimento: {cadaItem.Rendimento}
                            Logradouro: {cadaItem.Endereco.Logradouro}
                            Numero: {cadaItem.Endereco.Numero}
                            Complemento: {cadaItem.Endereco.Complemento}
                            ");

                            Console.WriteLine($"Aperte ENTER para continuar");
                            Console.ReadLine();

                        }

                        Console.WriteLine($"Cadastro realizado com sucesso");
                        Thread.Sleep(2000);

                        break;


                    case "2":

                        if (listaPJ.Count != 0)
                        {
                            foreach (PessoaJuridica PJ in listaPJ)
                            {
                                Console.WriteLine(@$"
                                Nome da empresa: {PJ.Nome}
                                Razão social: {PJ.RazaoSocial}
                                CNPJ: {PJ.Cnpj}
                                CNPJ Valido: {(metodosPJ.ValidarCnpj(PJ.Cnpj) ? "CNPJ valido." : "CNPJ invalido.")}
                                Endereço: {PJ.Endereco.Logradouro}
                                Numero: {PJ.Endereco.Numero}
                                Complemento: {PJ.Endereco.Complemento}
                                Endereço Comercial: {PJ.Endereco.Comercial}
                                Rendimento: R${PJ.Rendimento}
                                Imposto a pagar: R${metodosPJ.PagarImposto(PJ.Rendimento).ToString("C", new CultureInfo("PT-BR"))}
                                ");

                            }
                            Console.WriteLine("Aperte ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Lista Vazia");
                            Thread.Sleep(2000);
                        }
                        break;


                    case "0":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção invalida, digite uma opção valida");
                        Thread.Sleep(2000);
                        break;
                }
            } while (opcaoPJ != "0");

            Console.WriteLine($"Aperte ENTER para continuar");
            Console.ReadLine();
            break;

        case "0":
            Console.Clear();
            Console.WriteLine("Agradecemos por usar o nosso sistema!");
            Thread.Sleep(2000);
            break;

        default:
            Console.Clear();
            Console.WriteLine($"Digite um número valido.");
            Thread.Sleep(2000);
            break;
    }
} while (opcao != "0");


Utils.BarraCarregamento("Finalizando", 500, 20);


//ToString transforma o numero (float) para texto (string)


// exemplo de expressao regular para validar um formato de data
// string data = "26/09/2022";
// bool valido = Regex.IsMatch(data, @"^\d{2}/\d{2}/\d{4}$");
// Console.WriteLine(valido ? "dentro do padrao" : "fora do padrao, insira nova data");

// exemplo de substring com dois argumentos
// start~Index : da onde vai partir
// Lenght : quantos objetos vamos obter
// string nome = "Pindamonhangaba";
// string substring = nome.Substring(3);
// Console.WriteLine(substring);
