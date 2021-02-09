using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Funcionarios
{
    public class Desenvolvedor : Funcionario
    {
        public Desenvolvedor(string nome) : base(nome)
        {

        }

        public override void AumentarSalario()
        {
            Salario *= 1.2;
        }

        public override double GetBonificacao()
        {
            return Salario * 0.35;
        }
    }
}
