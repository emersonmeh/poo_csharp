using System;
using System.IO;

namespace _04_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            CarregarContas();

            Console.ReadLine();

        }

        private static void CarregarContas()
        {
            using(LeitorDeArquivo leitor = new LeitorDeArquivo("Arquivo.txt"))
            {
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }


            // -------- SUBSTITUIDO PELO DIRETIVA USING ------------------------------------

            //LeitorDeArquivo leitor = null;

            //try
            //{
            //    // Proteje o objeto de erros não tratados (bloco catch traz essa garantia);
            //    leitor = new LeitorDeArquivo("contas.txt");

            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //}
            //catch (IOException)
            //{
            //    Console.WriteLine("Exceçao do tipo IOException capturada");
            //}
            //finally
            //{
            //    if(leitor != null)
            //    {
            //        // Sempre executa independente de Sucesso ou Erro;
            //        leitor.Fechar();
            //    }

            //}
        }
    }
}
