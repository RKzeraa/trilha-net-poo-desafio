using Newtonsoft.Json.Linq;

namespace DesafioPOO.Models
{
    public class Iphone : Smartphone
    {
        public readonly string Logo = @"
            .:'
      __ :'__
   .'`__`-'__``.
  :__________.-'
  :_________:
   :_________`-;
    `.__.-.__.'
        ";

        public Iphone(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria) { }

        public override void InstalarAplicativo(string nomeApp)
        {
            string infoApp = ObterAplicativoAppleStore(nomeApp);
            Console.WriteLine($"{infoApp} no Iphone...");
        }

        private static string ObterAplicativoAppleStore(string nomeApp)
        {
            string url = $"https://itunes.apple.com/search?term={nomeApp}&entity=software";

            using (HttpClient client = new HttpClient())
            {
                string jsonResult = client.GetStringAsync(url).Result;
                JObject jsonObject = JObject.Parse(jsonResult);

                var results = jsonObject["results"];
                if (results != null && results.HasValues)
                {
                    var resultFromResults =
                        from result in results
                        where result["trackName"].ToString()
                            .Contains(nomeApp, StringComparison.InvariantCultureIgnoreCase)
                        select result;

                    var fromResults = resultFromResults.ToList();
                    if (fromResults.Any())
                    {
                        Console.WriteLine("Resultados encontrados:");

                        int i = 1;
                        foreach (var result in fromResults)
                        {
                            Console.WriteLine($"{i}. {result["trackName"]}");
                            i++;
                        }

                        while (true)
                        {
                            Console.Write("Escolha o número de qual aplicativo deseja instalar (ou 0 para cancelar): ");

                            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 0 && escolha < i)
                            {
                                if (escolha == 0)
                                {
                                    return $"Operação cancelada";
                                }

                                var resultadoEscolhido = fromResults.ElementAt(escolha - 1);

                                string nomeCompleto = resultadoEscolhido["trackName"]?.ToString();

                                if (long.TryParse(resultadoEscolhido["fileSizeBytes"]?.ToString(), out long tamanhoEmBytes))
                                {
                                    double tamanhoEmMegabytes = BytesParaMegabytes(tamanhoEmBytes);
                                    return
                                        $"Instalando aplicativo \"{nomeCompleto}\" - Tamanho: {tamanhoEmMegabytes.ToString("F2")} MB";
                                }

                                return $"Instalando aplicativo \"{nomeCompleto}\"";
                            }

                            Console.WriteLine("Escolha inválida. Tente novamente.");

                        }
                    }

                    return $"O \"{nomeApp}\" não foi encontrado na App Store";
                }
            }
            return $"O \"{nomeApp}\" não foi encontrado na App Store";
        }

        private static double BytesParaMegabytes(long bytes)
        {
            return (double)bytes / (1024 * 1024);
        }
    }
}