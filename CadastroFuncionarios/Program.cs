using CadastroFuncionarios;
using System;

class Program
{
    static List<Funcionario> funcionarios = new List<Funcionario>();

    static void Main()
    {
        ExibirMenu();
    }

    static void ExibirMenu()
    {
        Console.Clear();
        int opcao;

        Console.WriteLine("==== GESTOR DE FUNCIONÁRIOS 2.0 ====\n");
        Console.WriteLine("[1] - Cadastrar funcionário");
        Console.WriteLine("[2] - Listar todos os funcionários");
        Console.WriteLine("[3] - Buscar funcionário");
        Console.WriteLine("[4] - Atualizar salário");
        Console.WriteLine("[5] - Demitir/Remover funcionário");
        Console.WriteLine("[6] - Calcular folha de pagamento");
        Console.WriteLine("[0] - Sair");
        Console.WriteLine("\n======================================");
        Console.Write("\nDigite a opção que deseja: ");
        
        opcao = int.Parse(Console.ReadLine()!);

        switch (opcao)
        {
            case 1:
                CadastrarFuncionario();
                break;
            case 2:
                ListarFuncionarios();
                break;
            case 3:
                BuscarFuncionario();
                break;
            case 4:
                AtualizarSalario();
                break;
            case 5:
                RemoverFuncionario();
                break;
            case 6:
                CalcularFolhaDePagto();
                break;
            case 0:
                Console.WriteLine("\nSistema encerrado.");
                break;
            default:
                Console.WriteLine("[ERRO] - Opção inválida!");
                Thread.Sleep(2000);
                Console.Clear();
                ExibirMenu();
                break;
        }
    }

    static void CadastrarFuncionario()
    {
        Console.Clear();
        Console.WriteLine("==== CADASTRO DE FUNCIONÁRIO ====\n");
        Thread.Sleep(2000);
        Console.Write("Nome: ");
        string nome = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("\n[ERRO] - O nome do funcionário não pode estar vazio!");
            Thread.Sleep(2000);
            ExibirMenu();
        }

        Console.Write("Idade: ");
        int idade = int.Parse(Console.ReadLine()!);
        if (idade < 18)
        {
            Console.WriteLine("\n[ERRO] - A idade do funcionário deve ser maior ou igual a 18 anos.");
            Thread.Sleep(2000);
            ExibirMenu();
        }

        Console.Write("Cargo: ");
        string cargo = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(cargo))
        {
            Console.WriteLine("\n[ERRO] - O cargo do funcionário não pode estar vazio!");
            Thread.Sleep(2000);
            ExibirMenu();
        }

        Console.Write("Salário: ");
        double salario = double.Parse(Console.ReadLine()!);
        if(salario <= 0){
            Console.WriteLine("\n[ERRO] - O salário do funcionário deve ser maior que zero!");
            Thread.Sleep(2000);
            ExibirMenu();
        }

        Funcionario f = new Funcionario(nome, idade, cargo, salario);
        funcionarios.Add(f);

        Console.WriteLine("\n[SUCESSO] - Funcionário cadastrado!");
        Thread.Sleep(2000);
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        ExibirMenu();
    }

    static void ListarFuncionarios()
    {
        Console.Clear();
        Console.WriteLine("==== QUADRO DE FUNCIONÁRIOS ====\n");
        Thread.Sleep(2000);
        if(funcionarios.Count == 0)
        {
            Console.WriteLine("Não existem funcionários cadastrados.");
        } else
        {
            foreach (var f in funcionarios)
            {
                f.ExibirFuncionario();
            }
        }

        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        ExibirMenu();
    }

    static void BuscarFuncionario()
    {
        Console.Clear();
        Console.WriteLine("==== BUSCAR UM FUNCIONÁRIO ====\n");
        Thread.Sleep(2000);
        if (funcionarios.Count > 0) 
        {
            Console.Write("Nome do funcionário: ");
            string nomeBusca = Console.ReadLine()!;
            bool existe = false;

            foreach (var f in funcionarios)
            {
                if (f.Nome.ToLower() == nomeBusca.ToLower())
                {
                    f.ExibirFuncionario();
                    existe = true;
                }
            }
            
            if (!existe)
            {
                Console.WriteLine($"\n[ERRO] - O/A funcionário(a) {nomeBusca} não consta no banco de dados.");
            }
        }
        else
        {
            Console.WriteLine("Não existem funcionários cadastrados.");
        }

        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        ExibirMenu();

    }

    static void AtualizarSalario()
    {
        Console.Clear();
        Console.WriteLine("==== REAJUSTE SALARIAL ====\n");
        Thread.Sleep(2000);
        if (funcionarios.Count > 0)
        {
            Console.Write("Nome do funcionário: ");
            string nomeBusca = Console.ReadLine()!;
            bool existe = false;

            foreach (var f in funcionarios)
            {
                if (f.Nome.ToLower() == nomeBusca.ToLower())
                {
                    Console.Write("Novo salário: ");
                    f.Salario = double.Parse(Console.ReadLine()!);
                    Console.WriteLine("[SUCESSO] - Salário atualizado!");
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                Console.WriteLine("[ERRO] - Funcionário não encontrado!");
            }
        }
        else
        {
            Console.WriteLine("Não existem funcionários cadastrados.");
        }

        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        ExibirMenu();
    }

    static void RemoverFuncionario()
    {
        Console.Clear();
        Console.WriteLine("==== RECURSOS HUMANOS ====\n");
        Thread.Sleep(2000);
        if (funcionarios.Count > 0)
        {
            Console.Write("Nome do funcionário que deseja remover: ");
            string nomeBusca = Console.ReadLine()!;
            bool existe = false;

            for (int i = 0; i < funcionarios.Count; i++)
            {
                if (funcionarios[i].Nome.ToLower() == nomeBusca.ToLower())
                {
                    Console.Write($"\nTem certeza que deseja demitir o funcionário {nomeBusca} ? ");
                    string resp = Console.ReadLine()!;
                    if(resp == "Sim" || resp == "sim")
                    {
                        funcionarios.RemoveAt(i);
                        Console.WriteLine("\n[SUCESSO] - Funcionário removido!");
                        existe = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nOperação cancelada.");
                        break;
                    }
                }
            }

            if (!existe)
            {
                Console.WriteLine($"\n[ERRO] - Funcionário {nomeBusca} não foi encontrado na base de dados.");
            }
        }
        else
        {
            Console.WriteLine("Não existem funcionários cadastrados.");
        }

        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        ExibirMenu();
    }
    static void CalcularFolhaDePagto()
    {
        Console.Clear();
        Console.WriteLine("==== FOLHA DE PAGAMENTO ====\n");
        Thread.Sleep(2000);
        double total = 0;

        foreach (var f in funcionarios)
        {
            total += f.Salario;
        }

        Console.WriteLine($"Folha de pagamento total: {total:C}");
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        ExibirMenu();
    }

}
