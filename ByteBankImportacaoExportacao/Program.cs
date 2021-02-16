using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //CriarArquivo();
            CriarArquivoComStreamWriter();

            Console.ReadLine();
        }


        static void LidandoComStreamReader()
        {
            var enderecoDoArquivo = "contas.txt";

            // Blocos aninhados de using, no bloco externo não é necessária a abertura das chaves { } e nem a identação
            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDoArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    var contaCorrente = ConverteStringParaCC(linha);

                    var msg = $"Titular {contaCorrente.Titular.Nome} Conta número {contaCorrente.Numero}, Ag. {contaCorrente.Agencia}. Saldo de {contaCorrente.Saldo}";

                    Console.WriteLine(msg);
                }
            }
        }

        static ContaCorrente ConverteStringParaCC(string linha)
        {
            string[] campos = linha.Split(',');

            var agencia = Convert.ToInt32(campos[0]);
            var numero = int.Parse(campos[1].ToString());
            var saldo = Convert.ToDouble(campos[2].Replace('.', ','));
            var nome = campos[3];

            var titular = new Cliente();
            titular.Nome = nome;

            var resultado = new ContaCorrente(agencia, numero);
            resultado.Depositar(saldo);
            resultado.Titular = titular;

            return resultado;
        }

        
    }
}
