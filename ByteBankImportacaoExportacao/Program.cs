using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var enderecoDoArquivo = "contas.txt";

            // Blocos aninhados de using, no bloco externo não é necessária a abertura das chaves { } e nem a identação
            using(var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDoArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.Read();
                    Console.WriteLine(linha);
                }
            }

            Console.ReadLine();
        }

        
    }
}
