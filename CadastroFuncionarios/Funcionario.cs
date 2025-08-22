using System;
using System.Collections.Generic;

namespace CadastroFuncionarios
{
    class Funcionario : Pessoa
    {
        public string Cargo { get; set; }
        public double Salario { get; set; }

        public Funcionario(string nome, int idade, string cargo, double salario) : base(nome, idade)
        {
            Cargo = cargo;
            Salario = salario;
        }

        public void ExibirFuncionario()
        {
            Console.WriteLine($"{Nome} - {Idade} anos - {Cargo} - Salário: {Salario:C}");
        }
    }
}
