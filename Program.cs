using DesafioPOO.Models;

Smartphone nokia = new Nokia("123456789", modelo: "Modelo 1", imei: "1111111111", memoria: 64);
Smartphone iphone = new Iphone("987654321", modelo: "Modelo 2", imei: "2222222222", memoria: 128);

Console.WriteLine("Smartphone Nokia:");
nokia.Ligar();
Console.WriteLine(iphone.Numero);
nokia.InstalarAplicativo("WhatsApp");
nokia.InstalarAplicativo("Telegram");
nokia.InstalarAplicativo("asdqwe");

Console.WriteLine("\n");

Console.WriteLine("Smartphone Iphone:");
iphone.ReceberLigacao();
Console.WriteLine(nokia.Numero);
iphone.InstalarAplicativo("Telegram");
iphone.InstalarAplicativo("asdqwe");
iphone.InstalarAplicativo("WhatsApp");