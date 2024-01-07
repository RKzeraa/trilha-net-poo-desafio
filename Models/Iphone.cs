using System;
using System.Xml.Linq;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace DesafioPOO.Models
{
    public class Iphone : Smartphone
    {
        public readonly string logo = @"
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
            string url = $"https://itunes.apple.com/search?term={nomeApp}&entity=macSoftware";

            using (HttpClient client = new HttpClient())
            {
                string jsonResult = client.GetStringAsync(url).Result;
                JObject jsonObject = JObject.Parse(jsonResult);

                var results = jsonObject["results"];
                if (results.HasValues)
                {
                    var primeiroResultado = results[0];

                    string nomeCompleto = primeiroResultado["trackName"].ToString();

                    if (long.TryParse(primeiroResultado["fileSizeBytes"].ToString(), out long tamanhoEmBytes))
                    {
                        double tamanhoEmMegabytes = BytesParaMegabytes(tamanhoEmBytes);
                        return $"Instalando aplicativo \"{nomeCompleto}\" - Tamanho: {tamanhoEmMegabytes.ToString("F2")} MB";
                    }
                    else
                    {
                        return $"Instalando aplicativo \"{nomeCompleto}\"";
                    }
                    
                }
                else
                {
                    return $"O \"{nomeApp}\" não foi encontrado na App Store";
                }
            }
        }

        private static double BytesParaMegabytes(long bytes)
        {
            return (double)bytes / (1024 * 1024);
        }
    }
}