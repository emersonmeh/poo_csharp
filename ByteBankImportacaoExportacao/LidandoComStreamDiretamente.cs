using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void LidandoComFileStreamDiretamente()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                // Espaço para armazenamento dos bytes do arquivo que vai ser lido;
                var buffer = new byte[1024]; // 1 kb
                var numeroBytesLidos = -1;

                while (numeroBytesLidos != 0)
                {
                    numeroBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, numeroBytesLidos);
                }
            }
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {

            // Decoding dos bytes em texto
            //var a = new UTF8Encoding(); //codificação explícita
            var a = Encoding.Default; //codificação da máquina que esta rodando o programa
            var texto = a.GetString(buffer, 0, bytesLidos);

            Console.Write(texto);

            // Escreve os bytes do arquivo carregado no buffer
            //foreach(var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }
    }
}
