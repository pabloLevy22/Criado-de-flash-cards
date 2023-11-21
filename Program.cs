using System;
using System.IO;
using System.Text;
internal class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        Console.Clear();
        Console.WriteLine($"Painel de comando" +
        "\n\nopções de funções:" +
        "\n     Cartão simples: Clique S");

        ComandoDoPainelInicial();
    }

    static void ComandoDoPainelInicial()
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        
        string resultado = "";

        switch (tecla.Key)
        {
            case ConsoleKey.S:
                string pergunta = "";
                string resposta = "";
                string padrãoPergunta = "";

                Console.Clear();
                Console.WriteLine("Ensíra os dados da pergunta separador por vírgula");
                EntradaDeDados(out pergunta);
                Console.WriteLine("Ensirá a resposta separador por vírgula");
                EntradaDeDados(out resposta);
                Console.WriteLine("Ensirá o padrão da pergunta");
                EntradaDeDados(out padrãoPergunta);

                resultado = FlashCardSimples(pergunta, resposta, padrãoPergunta);
                break;

            case ConsoleKey.Escape:
                return;

            default:
                ComandoDoPainelInicial();
                return;
        }

        File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(),"tabela.tsv"), resultado);

        Console.WriteLine("Tabela feita\nSalvo em tabela");
    }

    static void EntradaDeDados(out string dado)
    {
        dado = Console.ReadLine() ?? string.Empty;
    }

    static string FlashCardSimples(string palavra, string relaçãoComPalavra, string padrão, string delimitador = ",")
    {
        string[] palavras = palavra.Split(",");
        string[] relaçãoComPalavras = relaçãoComPalavra.Split(",");
        string[] saída = new string[palavras.Length];

        for (int i = 0; i < palavras.Length; i++)
        {
            saída[i] += padrão + " " + palavras[i] + "?" + delimitador + relaçãoComPalavras[i];
        }

        return string.Join("\n", saída);
    }
}