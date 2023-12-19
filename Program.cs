using DesafioPOO.Models;

Console.WriteLine("Smartphone Nokia:");
Smartphone nokia = new Nokia("123456789", modelo: "Modelo 1", imei: "1111111111", memoria: 64);
nokia.Ligar();
nokia.InstalarAplicativo("WhatsApp");
// TODO: Realizar os testes com as classes Nokia e Iphone
Console.WriteLine("\n");

Console.WriteLine("Smartphone Iphone:");
Smartphone iphone = new Iphone("987654321", modelo: "Modelo 2", imei: "2222222222", memoria: 128);
iphone.ReceberLigacao();
iphone.InstalarAplicativo("Telegram");