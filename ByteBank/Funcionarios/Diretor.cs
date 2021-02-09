using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Funcionarios
{
    public class Diretor : FuncionarioAutenticavel
    {

        //Passa o parametro recebido no construtor para o construtor base que será chamado primeiro
        public Diretor(double salario, string cpf) : base(salario, cpf)
        {

        }

        //Sobrepõe o comportamento do método dentro de Funcionário
        public override double GetBonificacao()
        {
            // Soma o resultado da chamada do método sobrescrito + o resultado do método
            // dentro da classe Funcionario(base);
            //return Salario + base.GetBonificacao();

            return Salario * 0.5;
        }

        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }

    }
}
