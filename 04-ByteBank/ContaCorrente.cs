using _04_ByteBank;
using System;

namespace _04_ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        //Membro estático - pertence à Classe
        public static int TotalDeContasCriadas { get; private set; }
        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }
        public static double TaxaOperacao { get; private set; }
        public int Agencia { get; } //propriedade readonly
        public int Numero { get; }

        private double saldo = 100;

        public double Saldo
        {
            get
            {
                return saldo;
            }
            set
            {
                if(value < 0)
                {
                    return;
                }
                saldo = value;
            }
        }

        //Construtor
        public ContaCorrente(int agencia, int numero)
        {
            if(agencia <= 0)
            {
                //Exceção
                ArgumentException excecao = new ArgumentException("A agência e o número devem ser maior que zero(0)!", nameof(agencia));
                throw excecao;
            }

            if (numero <= 0)
            {
                //Exceção
                throw new ArgumentException("A agência e o número devem ser maior que zero(0)!", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;

            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (this.saldo < valor)
            {
                //throw new SaldoInsuficienteException("Saldo insuficiente para o saque no valor de " +  valor);
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }
            else
            {
                this.saldo -= valor;
            }
        }

        public void Depositar(double valor)
        {
            this.saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {

            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Saldo insuficiente", ex);
            }

            this.saldo -= valor;
            contaDestino.Depositar(valor);
        }



    }
}
