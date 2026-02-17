using System.Buffers;
using System.IO;

Menu();


static void Menu()
{
    Console.Clear();

    string menu = """
                    Menu
            
            1 - Abrir arquivo
            2 - Editar aquivo
            0 - Sair
    """;

    Console.WriteLine(menu);
    short choice = short.Parse(Console.ReadLine());

    switch (choice)
    {
        case 0: 
            Console.WriteLine("Fechando programa.");
            break;

        case 1:
            Abrir();
            break;
        
        case 2:
            Editar();
            break;

        default:
            Console.WriteLine("Digite uma opção válida");
            break;
    }
}


static void Abrir()
{
    Console.Clear();
    
    Console.Write("Digite o caminho do arquivo: ");
    string path = Console.ReadLine();

    using(var file = new StreamReader(path))
    {
        string text = file.ReadToEnd();
        Console.WriteLine("\n" + text);
    }

    Console.WriteLine("\nAperte enter para sair");
    Console.ReadLine();
    Menu();
}


static void Editar()
{
    Console.Clear();

    Console.WriteLine("Digite seu texto abaixo/nESC para sair");
    Console.WriteLine("=-=-=-=-=-=-=-=-=-==-");
    
    string text = "";

    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine;
    } while (Console.ReadKey().Key != ConsoleKey.Escape);

    Salvar(text);    
}


static void Salvar(string text)
{
    Console.Clear();

    Console.Write("Digite o caminho para salvar o arquivo: ");

    var path = Console.ReadLine();

    using (var file = new StreamWriter(path))
    {
        file.Write(text);
    }

    Console.WriteLine($"Arquivo salvo com sucesso!\nCaminho: {path}");
    Thread.Sleep(3000);

    Menu();
}

