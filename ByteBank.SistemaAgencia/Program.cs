using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Extensoes;
using System;
using System.Collections.Generic;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {

            var idades = new List<int>();
            idades.Add(1);
            idades.Add(5);
            idades.Add(10);

            // ListExtensoes.AdicionarVarios(idades, 20, 25, 30);
            idades.AdicionarVarios(2, 7, 30, 22); //Método de extensão

            idades.Sort(); // Ordena crescente
            //idades.Reverse(); // Ordena do ultimo elemento para o primeiro
            idades.Reverse();


           foreach(int idade in idades)
           {
               Console.WriteLine(idade);
           }


            //ContaCorrente conta = new ContaCorrente(846, 234567);

            //string url = "https://bytebank.com.br/cambio?moedaOrigen=Real&moedaDestino=Dolar&valor=1500";
            //string nomeArgumento = "valor";

            //ExtratorValorArgumentosUrl argumento = new ExtratorValorArgumentosUrl(url);

            //Console.WriteLine(argumento.Url);

            //Console.WriteLine("Valor do Argumento: " + argumento.GetValor(nomeArgumento));

            //Console.WriteLine(conta.Numero);

            Console.ReadLine();
        }
    }
}
