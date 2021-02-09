using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _04_ByteBank
{
    public class LeitorDeArquivo : IDisposable
    {
        public string Arquivo { get; set; }

        public LeitorDeArquivo(string arquivo)
        {
            Arquivo = arquivo;

            // força uma exceção de arquivo não encontrado;
            //throw new FileNotFoundException();

            Console.WriteLine("Abrindo Arquivo: " + arquivo);
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha...");

            // força uma exceção;
            //throw new IOException();

            return "Linha do arquivo";
        }

        //public void Fechar()
        //{
        //}

        // Substitui o método Fechar()
        public void Dispose()
        {
            Console.WriteLine("Fechando arquivo.");
        }
    }
}
