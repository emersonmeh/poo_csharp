using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    public class ContaCorrente
    {
        public int Numero { get; set; }
        public int Agencia { get; set; }
        public double Saldo { get; private set; }
        public Cliente Titular { get; set; }

        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;
        }

        public void Depositar(double valor)
        {
            if(valor <= 0)
            {
                throw new ArgumentException("Valor deve maior que zero", nameof(valor));
            }

            Saldo += valor;
        }
    }
}
