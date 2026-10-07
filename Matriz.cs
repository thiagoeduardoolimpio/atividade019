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

    static double[] calcularPercentuaDesmatamento(int[,] matriz)
    {
        double totalCelulas = 36;
        double qtdDesmatada = 0;
        double qtdParcial = 0;
        double qtdPreservada = 0;

        for (int indiceLinha = 0; indiceLinha < 6; indiceLinha++)
        {
            for (int indiceColuna = 0; indiceColuna < 6; indiceColuna++)
            {
                if (matriz[indiceLinha, indiceColuna] == 0)
                {
                    qtdDesmatada++;
                }
                else if (matriz[indiceLinha, indiceColuna] == 1)
                {
                    qtdParcial++;
                }
                else if (matriz[indiceLinha, indiceColuna] == 2)
                {
                    qtdPreservada++;
                }
            }
        }

        double[] percentuais = new double[3];
        percentuais[0] = qtdDesmatada / totalCelulas * 100;
        percentuais[1] = qtdParcial / totalCelulas * 100;
        percentuais[2] = qtdPreservada / totalCelulas * 100;

        return percentuais;
    }

    static void analisarAumento(int[,] matrizAnterior, int[,] matrizAtual)
    {
        double[] percentuaisAnterior = calcularPercentuaDesmatamento(matrizAnterior);
        double[] percentuaisAtual = calcularPercentuaDesmatamento(matrizAtual);

        double percentualDesmatadoAnterior = percentuaisAnterior[0];
        double percentualDesmatadoAtual = percentuaisAtual[0];

        Console.WriteLine("Percentual de ocorrências na matriz 6 meses atrás:");
        Console.WriteLine($"Área Desmatada (Código 0): {percentualDesmatadoAnterior:F2}%");
        Console.WriteLine();

        Console.WriteLine("Percentual de ocorrências na matriz atual:");
        Console.WriteLine($"Área Desmatada (Código 0): {percentualDesmatadoAtual:F2}%");
        Console.WriteLine();

        if (percentualDesmatadoAtual > percentualDesmatadoAnterior)
        {
            Console.WriteLine($"Houve Aumento no Desmatamento – Anterior {percentualDesmatadoAnterior:F2}% -> Atual {percentualDesmatadoAtual:F2}%");
        }
        else if (percentualDesmatadoAtual < percentualDesmatadoAnterior)
        {
            Console.WriteLine($"Houve Redução no Desmatamento – Anterior {percentualDesmatadoAnterior:F2}% -> Atual {percentualDesmatadoAtual:F2}%");
        }
        else
        {
            Console.WriteLine($"Não houve alteração no Desmatamento – Anterior {percentualDesmatadoAnterior:F2}% -> Atual {percentualDesmatadoAtual:F2}%");
        }
    }

    static void Main()
    {
        int[,] matrizAnterior = carregarMatriz("dados_matriz_6meses_atras.csv");
        int[,] matrizAtual = carregarMatriz("dados_matriz_atual.csv");

        Console.WriteLine("=== MONITORAMENTO DE DESMATAMENTO ===");
        Console.WriteLine();

        exibirMatriz("Matriz de 6 meses atrás:", matrizAnterior);
        exibirMatriz("Matriz atual:", matrizAtual);

        analisarAumento(matrizAnterior, matrizAtual);
    }
}