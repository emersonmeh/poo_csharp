using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Modelos.Funcionarios
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

        internal protected override double GetBonificacao()
        {
            return Salario * 0.35;
        }
    }
}
