using System;
using System.Collections.Generic;

namespace CadastroFuncionarios
{
    class Funcionario : Pessoa
    {
        public string Cargo { get; set; }
        public double Salario { get; set; }

        public Funcionario(string nome, string cargo, double salario) : base(nome)
        {
            Cargo = cargo;
            Salario = salario;
        }

        public void ExibirFuncionario()
        {
            Console.WriteLine($"Nome: {Nome} - Cargo: {Cargo} - Salário: {Salario:C}");
        }
    }
}
