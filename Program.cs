using DesafioPOO.Models;

Nokia nokia = new("123456789", modelo: "Modelo 1", imei: "1111111111", memoria: 64);
Iphone iphone = new("987654321", modelo: "Modelo 2", imei: "2222222222", memoria: 128);

Console.WriteLine($"Smartphone Nokia: \n {nokia.logo}");
nokia.Ligar(iphone.Numero);
nokia.InstalarAplicativo("WhatsApp");
nokia.InstalarAplicativo("Telegram");
nokia.InstalarAplicativo("asdqwe");

Console.WriteLine("\n");

Console.WriteLine($"Smartphone Iphone: \n{iphone.logo}");
iphone.ReceberLigacao(nokia.Numero);
iphone.InstalarAplicativo("Telegram");
iphone.InstalarAplicativo("asdqwe");
iphone.InstalarAplicativo("WhatsApp");