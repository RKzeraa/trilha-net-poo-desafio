using DesafioPOO.Models;
using System.Reflection;
using System;

//TODO: Aplicar cores diferentes no console em todos os textos


string opcao;
bool exibirMenu = true;

while (exibirMenu)
{
    //textCustom.ShowLogo();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar Iphone");
    Console.WriteLine("2 - Cadastrar Nokia");
    Console.WriteLine("3 - Encerrar");
    Console.Write("\r\nSelecione uma opção: ");
    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            ExecutarSmartphone(PreencherDados(opcao));
            break;

        case "2":
            ExecutarSmartphone(PreencherDados(opcao));
            break;

        case "3":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção Inválida!!!");
            break;
    }

    Console.Clear();
    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadKey();
}

#region Métodos
static Smartphone PreencherDados(string op)
{
    string numero, modelo, imei;
    int memoria;
    if (op != "1")
    {
        Console.WriteLine("Digite o numero do Nokia: ");
        numero = Console.ReadLine();

        Console.WriteLine("Digite o modelo do Nokia: ");
        modelo = Console.ReadLine();

        Console.WriteLine($"Digite o IMEI do Nokia {modelo}: ");
        imei = Console.ReadLine();

        Console.WriteLine($"Digite o tamanho de armazenamento do Nokia {modelo}: ");
        memoria = int.Parse(Console.ReadLine() ?? string.Empty);

        return new Nokia(numero, modelo: modelo, imei: imei, memoria: memoria);
    }

    Console.WriteLine("Digite o numero do Iphone: ");
    numero = Console.ReadLine();

    Console.WriteLine("Digite o modelo do Iphone: ");
    modelo = Console.ReadLine();

    Console.WriteLine($"Digite o IMEI do Iphone {modelo}: ");
    imei = Console.ReadLine();

    Console.WriteLine($"Digite o tamanho de armazenamento do Iphone {modelo}: ");
    memoria = int.Parse(Console.ReadLine() ?? string.Empty);

    return new Iphone(numero, modelo: modelo, imei: imei, memoria: memoria);
}

static void ExecutarSmartphone(Smartphone smartphone)
{
    

    if (smartphone is Iphone iphone)
    {
        MenuIphone(iphone);

    }
    else if (smartphone is Nokia nokia)
    {
        MenuNokia(nokia);
    }
}

static void MenuIphone(Iphone iphone)
{
    string opcao;
    bool exibirMenu = true;

    while (exibirMenu)
    {

        Console.Clear();
        Console.WriteLine($"Smartphone {iphone.GetType()}: \n {iphone.Logo}");
        Console.WriteLine("\nDigite a sua opção:");
        Console.WriteLine("1 - Fazer Ligação");
        Console.WriteLine("2 - Instalar Aplicativo");
        Console.WriteLine("3 - Encerrar");
        Console.Write("\r\nSelecione uma opção: ");
        opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Console.Clear();
                Console.WriteLine(iphone.Logo);
                Console.WriteLine("\nDigite para qual numero deseja ligar: ");
                string numeroLigacao = Console.ReadLine();
                iphone.Ligar(numeroLigacao);
                //nokia.ReceberLigacao(iphone.Numero);
                break;

            case "2":
                Console.Clear();
                Console.WriteLine(iphone.Logo);
                Console.WriteLine("\nDigite qual o nome do aplicativo que deseja instalar: ");
                string nomeDoAplicativo = Console.ReadLine();
                iphone.InstalarAplicativo(nomeDoAplicativo);
                break;

            case "3":
                exibirMenu = false;
                break;

            default:
                Console.Clear();
                Console.WriteLine(iphone.Logo);
                Console.WriteLine("\nOpção Inválida!!!");
                break;
        }

        Console.WriteLine("Pressione uma tecla para continuar");
        Console.ReadKey();
    }
}

static void MenuNokia(Nokia nokia)
{
    string opcao;
    bool exibirMenu = true;

    while (exibirMenu)
    {

        Console.Clear();
        Console.WriteLine($"Smartphone {nokia.GetType()}: \n {nokia.Logo}");
        Console.WriteLine("\nDigite a sua opção:");
        Console.WriteLine("1 - Fazer Ligação");
        Console.WriteLine("2 - Instalar Aplicativo");
        Console.WriteLine("3 - Encerrar");
        Console.Write("\r\nSelecione uma opção: ");
        opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Console.Clear();
                Console.WriteLine(nokia.Logo);
                Console.WriteLine("\nDigite para qual numero deseja ligar: ");
                string numeroLigacao = Console.ReadLine();
                nokia.Ligar(numeroLigacao);
                //iphone.ReceberLigacao(nokia.Numero);
                break;

            case "2":
                Console.Clear();
                Console.WriteLine(nokia.Logo);
                Console.WriteLine("\nDigite qual o nome do aplicativo que deseja instalar: ");
                string nomeDoAplicativo = Console.ReadLine();
                nokia.InstalarAplicativo(nomeDoAplicativo);
                break;

            case "3":
                exibirMenu = false;
                break;

            default:
                Console.Clear();
                Console.WriteLine(nokia.Logo);
                Console.WriteLine("\nOpção Inválida!!!");
                break;
        }

        Console.WriteLine("Pressione uma tecla para continuar");
        Console.ReadKey();
    }
}

#endregion