/// <summary>
/// Para leitura de dados a partir de arquivos.
/// </summary>
/// <author>m4rc3lo</author>
/// <created>2025-03-09</created>

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace poker_2025.model;

/// <summary>
///  Classe que define métodos estáticos para carga de cartas representadas em arquivos .csv. 
/// </summary>
public class Load
{//métodos estáticos podem ser utilizados sem a criaçaõ de objeto

    /// <summary>
    /// Método que proporciona a carga para o sistema de uma lista com 07 cartas.
    /// O nome do arquivo específico para ser carregado.
    /// </summary>
    /// <returns>Retorna uma lista de cartas.</returns>
    public static List<Card> load_hand() 
	{
        string[] readText; // array de string
        List<Card> cards = new List<Card>(); // declara e cria uma lista de cartas vazia
        
        // encontra o diretório do projeto (pasta)
        string path_file = Directory.GetCurrentDirectory();
        
        //testa em qual sistema operacional o código está executando
        //linux e windows tem diferença na escrita do caminho
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))            
            path_file += "/04_cards_csv/";
        else
            path_file += "\\04_cards_csv\\"; // precisa ter uma pasta com este nome na raiz do projeto

        Console.WriteLine("\nFile name?"); // digita-se o nome do arquivo
        path_file += Console.ReadLine(); // caminho para o arquivo
        
        try
        { // se algum erro ocorrer neste bloco, o programa não "quebra" (try-catch)
            readText = File.ReadAllLines(path_file); // abre e ler todas as linhas do arquivo 
            foreach(var str_line in readText)
            {
                string[] line = str_line.Split(','); // separa a linha em <str_line> pelas vírgulas
                Card card = new Card (int.Parse(line[0]), Enum.Parse<Suit>(line[1]), bool.Parse(line[2])); //cria uma variável do tipo <struc Card>
                cards.Add(card); // adciona a carta criada na lista <cards>
            }
        }
        catch (System.IO.FileNotFoundException ex) // o erro pode ser tratado nesta parte
        {
            Console.WriteLine("File not found:\n\t" + ex.FileName);
            Console.WriteLine("Closing Aplication !!!");
            Environment.Exit(0);// ecerra o progrma
        }
        return cards; // fim do método <load_hand>, retorna a lista de cartas lidas do arquivo
    }// fim do método <load_hand>
}// fim da classe <Load>
//fim do namespace <structs.controller>