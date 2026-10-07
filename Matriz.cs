using System;
using System.IO;

class Program
{
    static int[,] carregarMatriz(string caminhoArquivo)
    {
        string[] linhasDoArquivo = File.ReadAllLines(caminhoArquivo);
        int[,] matrizCarregada = new int[6, 6];
        int linhaAtualDaMatriz = 0;

        for (int indiceLinhaArquivo = 0; indiceLinhaArquivo < linhasDoArquivo.Length && linhaAtualDaMatriz < 6; indiceLinhaArquivo++)
        {
            if (linhasDoArquivo[indiceLinhaArquivo].Trim() != "")
            {
                string[] valoresDaLinha = linhasDoArquivo[indiceLinhaArquivo].Split(',');

                for (int indiceColuna = 0; indiceColuna < 6; indiceColuna++)
                {
                    matrizCarregada[linhaAtualDaMatriz, indiceColuna] = int.Parse(valoresDaLinha[indiceColuna].Trim());
                }

                linhaAtualDaMatriz++;
            }
        }

        return matrizCarregada;
    }

    static void exibirMatriz(string titulo, int[,] matriz)
    {
        Console.WriteLine(titulo);

        for (int indiceLinha = 0; indiceLinha < 6; indiceLinha++)
        {
            for (int indiceColuna = 0; indiceColuna < 6; indiceColuna++)
            {
                Console.Write($"{matriz[indiceLinha, indiceColuna]} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    static void Main()
    {
        int[,] matrizAnterior = carregarMatriz("dados_matriz_6meses_atras.csv");
        int[,] matrizAtual = carregarMatriz("dados_matriz_atual.csv");

        Console.WriteLine("MONITORAMENTO DE DESMATAMENTO");
        Console.WriteLine();

        exibirMatriz("Matriz de 6 meses atrás:", matrizAnterior);
        exibirMatriz("Matriz atual:", matrizAtual);
    }
}