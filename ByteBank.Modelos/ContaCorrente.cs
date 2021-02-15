using ByteBank.Modelos;
using System;

namespace ByteBank.Modelos
{
    /// <summary>
    /// Define uma conta corrente do banco ByteBank
    /// </summary>
    public class ContaCorrente : IComparable
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

        /// <summary>
        /// Cria uma instância de Conta Corrente com os argumentos utilizados.
        /// </summary>
        /// <param name="agencia"> Representa o valor da propriedade <see cref="Agencia"/> e deve possuir um valor maior que zero. </param>
        /// <param name="numero"> Representa o valor da propriedade <see cref="Numero"/> e deve possuir um valor maior que zero. </param>
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

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>
        /// </summary>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/></exception>
        /// <param name="valor">Representa o valor do saque. Deve ser maior que 0 e menor que o <see cref="Saldo"/></param>
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

        public int CompareTo(object obj)
        {
            // Retorna negativo quando a instânca precede o obj;
            // Retorna zero quando nossa instância e obj forem equivalentes;
            // Retorna positivo diferente de zero quando a precedencia for de obj;

            var outraConta = obj as ContaCorrente;

            if(outraConta == null)
            {
                return -1;
            }

            if(Numero < outraConta.Numero)
            {
                return -1;
            }

            if(Numero == outraConta.Numero)
            {
                return 0;
            }

            return 1;
        }
    }
}
