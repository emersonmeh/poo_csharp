using ByteBank.Modelos.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.SistemaAgencia
{
    public class Estagiario : Funcionario
    {
        public Estagiario(double salario, string cpf) : base(salario, cpf)
        {

        }

        public override void AumentarSalario()
        {
            throw new NotImplementedException();
        }

        // Não é necessário o modificador internal na definição do método pois o internal neste caso diz respeito somente
        // à Classe e o projeto do qual foi definido;
        protected override double GetBonificacao()
        {
            throw new NotImplementedException();
        }
    }
}
