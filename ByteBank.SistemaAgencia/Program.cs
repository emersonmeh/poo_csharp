using ByteBank.Modelos;
using System;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(846, 234567);

            string url = "https://bytebank.com.br/cambio?moedaOrigen=Real&moedaDestino=Dolar&valor=1500";
            string nomeArgumento = "valor";

            ExtratorValorArgumentosUrl argumento = new ExtratorValorArgumentosUrl(url);

            Console.WriteLine(argumento.Url);

            Console.WriteLine("Valor do Argumento: " + argumento.GetValor(nomeArgumento));

            //Console.WriteLine(conta.Numero);

            Console.ReadLine();
        }
    }
}
