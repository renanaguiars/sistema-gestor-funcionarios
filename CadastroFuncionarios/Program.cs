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

        Console.WriteLine("\n==== SISTEMA DE GESTÃO DE FUNCIONÁRIOS ====");
        Console.WriteLine("\n[1] - Cadastrar Funcionário");
        Console.WriteLine("[2] - Listar Funcionários");
        Console.WriteLine("[3] - Buscar por Nome");
        Console.WriteLine("[4] - Atualizar Salário");
        Console.WriteLine("[5] - Remover Funcionário");
        Console.WriteLine("[6] - Calcular Folha de Pagamento");
        Console.WriteLine("[0] - Sair");
        Console.WriteLine("\n==========================================");
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
                Console.WriteLine("Sistema encerrado.");
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
        Console.Write("(CADASTRAR_FUNC) - Nome: ");
        string nome = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("[ERRO] - O nome não pode estar vazio!");
            Thread.Sleep(2000);
            ExibirMenu();
        }

        Console.Write("(CADASTRAR_FUNC) - Cargo: ");
        string cargo = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(cargo))
        {
            Console.WriteLine("[ERRO] - O cargo não pode estar vazio!");
            Thread.Sleep(2000);
            ExibirMenu();
        }

        Console.Write("(CADASTRAR_FUNC) - Salário: ");
        double salario = double.Parse(Console.ReadLine()!);
        if(salario <= 0){
            Console.WriteLine("[ERRO] - O salário deve ser maior que zero!");
            Thread.Sleep(2000);
            ExibirMenu();
        }

        Funcionario f = new Funcionario(nome, cargo, salario);
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
        Console.WriteLine("\n=== Quadro de Funcionários ===");
        if(funcionarios.Count == 0)
        {
            Console.WriteLine("[ERRO] - Não existem funcionários cadastrados.");
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
        if (funcionarios.Count > 0) 
        {
            Console.Write("\n(BUSCAR_FUNC) - Nome: ");
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
                Console.WriteLine($"[ERRO] - O/A funcionário(a) {nomeBusca} não consta no banco de dados.");
            }
        }
        else
        {
            Console.WriteLine("[ERRO] - Não existem funcionários cadastrados.");
        }

        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        ExibirMenu();

    }

    static void AtualizarSalario()
    {
        Console.Clear();
        if (funcionarios.Count > 0)
        {
            Console.Write("\n(ATUALIZAR_SAL) - Nome:");
            string nomeBusca = Console.ReadLine()!;
            bool existe = false;

            foreach (var f in funcionarios)
            {
                if (f.Nome.ToLower() == nomeBusca.ToLower())
                {
                    Console.Write("Novo Salário: ");
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
            Console.WriteLine("[ERRO] - Não existem funcionários cadastrados.");
        }

        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        ExibirMenu();
    }

    static void RemoverFuncionario()
    {
        Console.Clear();
        if (funcionarios.Count > 0)
        {
            Console.Write("\n(REMOVER_FUNC) - Nome: ");
            string nomeBusca = Console.ReadLine()!;
            bool existe = false;

            for (int i = 0; i < funcionarios.Count; i++)
            {
                if (funcionarios[i].Nome.ToLower() == nomeBusca.ToLower())
                {
                    funcionarios.RemoveAt(i);
                    Console.WriteLine("[SUCESSO] - Funcionário removido!");
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
            Console.WriteLine("[ERRO] - Não existem funcionários cadastrados.");
        }

        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        ExibirMenu();
    }
    static void CalcularFolhaDePagto()
    {
        Console.Clear();
        double total = 0;

        foreach (var f in funcionarios)
        {
            total += f.Salario;
        }

        Console.WriteLine($"Folha de Pagamento Total: {total:C}");
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        ExibirMenu();
    }

}
