using System;

class Program
{
    static double calcularMedia(int[] roubos)
    {
        double soma = 0;
        double media = 0;
        for (int i = 0; i < roubos.Length; i++)
        {
            soma += roubos[i];
        }
        media = soma / roubos.Length;
        Console.WriteLine($"Média de roubos por bairro: {media} ocorrências");
        return (media);
    }

    static void top3BairrosViolentos(String[] bairros, int[] roubos)
    {
        int[] roubosOrdenados = new int[roubos.Length];
        string[] bairrosOrdenados = new string[bairros.Length];

        for (int i = 0; i < roubos.Length; i++)
        {
            roubosOrdenados[i] = roubos[i];
            bairrosOrdenados[i] = bairros[i];
        }

        for (int i = 0; i < roubosOrdenados.Length - 1; i++)
        {
            for (int j = 0; j < roubosOrdenados.Length - 1 - i; j++)
            {
                if (roubosOrdenados[j] < roubosOrdenados[j + 1])
                {
                    int auxRoubo = roubosOrdenados[j];
                    roubosOrdenados[j] = roubosOrdenados[j + 1];
                    roubosOrdenados[j + 1] = auxRoubo;

                    string auxBairro = bairrosOrdenados[j];
                    bairrosOrdenados[j] = bairrosOrdenados[j + 1];
                    bairrosOrdenados[j + 1] = auxBairro;
                }
            }
        }

        Console.WriteLine("--- TOP 3 BAIRROS MAIS VIOLENTOS ---");

        for (int pos = 0; pos < 3; pos++)
        {
            int indiceOriginal = 0;

            for (int i = 0; i < bairros.Length; i++)
            {
                if (bairros[i] == bairrosOrdenados[pos])
                {
                    indiceOriginal = i;
                    break;
                }
            }

            Console.WriteLine($"{pos + 1}˚ Lugar: {bairrosOrdenados[pos]} (Índice {indiceOriginal}) - {roubosOrdenados[pos]} roubos");
        }
    }

    static void Main()
    {
        string[] bairros = {
            "Centro", "Moema", "Pinheiros", "Itaquera", "Tatuapé",
            "Santo Amaro", "Vila Mariana", "Lapa", "Capão Redondo", "Santana"
        };

        int[] roubos = { 350, 120, 210, 480, 190, 310, 150, 280, 520, 240 };

        Console.WriteLine("=== ANÁLISE DE SEGURANÇA PÚBLICA - BAIRROS DE SP ===");

        calcularMedia(roubos);
        top3BairrosViolentos(bairros, roubos);
    }
}