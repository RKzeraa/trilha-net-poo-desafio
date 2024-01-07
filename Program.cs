using DesafioPOO.Models;

//TODO: Aplicar cores diferentes no console em todos os textos

//TODO: Criar menu de interação para preencher os dados
Nokia nokia = new("123456789", modelo: "Modelo 1", imei: "1111111111", memoria: 64);
Iphone iphone = new("987654321", modelo: "Modelo 2", imei: "2222222222", memoria: 128);

//TODO: Exibir a logo sempre chamar um metodo novo após o Console.Clear()
Console.WriteLine($"Smartphone Nokia: \n {nokia.Logo}");
nokia.Ligar(iphone.Numero);

//TODO: Solicitar ao usuario qual aplicativo deseja instalar
nokia.InstalarAplicativo("WhatsApp");
nokia.InstalarAplicativo("Telegram");
nokia.InstalarAplicativo("asdqwe");
nokia.InstalarAplicativo("Rede Brasil");

Console.WriteLine("\n");

//TODO: Exibir a logo sempre chamar um metodo novo após o Console.Clear()
Console.WriteLine($"Smartphone Iphone: \n{iphone.Logo}");
iphone.ReceberLigacao(nokia.Numero);

//TODO: Solicitar ao usuario qual aplicativo deseja instalar
iphone.InstalarAplicativo("Telegram");
iphone.InstalarAplicativo("asdqwe");
iphone.InstalarAplicativo("WhatsApp");
iphone.InstalarAplicativo("Rede Brasil");