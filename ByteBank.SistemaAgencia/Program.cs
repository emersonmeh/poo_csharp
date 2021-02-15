using ByteBank.Modelos;
using ByteBank.Modelos.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;

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

            var contas = new List<ContaCorrente>() 
            {
                new ContaCorrente(354, 234551),
                new ContaCorrente(354, 22341),
                null,
                new ContaCorrente(352, 265311),
                new ContaCorrente(355, 998761),
                new ContaCorrente(1, 998761)

            };

            //contas.Sort(); //ordenada com base no método IComparable sobrescrito na Classe ContaCorrente;
            //contas.Sort(new ComparadorContaCorrentePorAgencia());
            var listaOrdenada = contas.Where(c => c != null).OrderBy(x => x.Agencia);

            foreach(ContaCorrente c in listaOrdenada)
            {
                Console.WriteLine(c.Numero + ", " + c.Agencia);
            }

            Console.ReadLine();


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
