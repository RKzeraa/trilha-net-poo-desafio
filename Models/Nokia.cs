using System;
using HtmlAgilityPack;

namespace DesafioPOO.Models
{
    public class Nokia : Smartphone
    {
        public readonly string logo = @"
    _   ______  __ __ _______ 
   / | / / __ \/ //_//  _/   |
  /  |/ / / / / ,<   / // /| |
 / /|  / /_/ / /| |_/ // ___ |
/_/ |_/\____/_/ |_/___/_/  |_|        
            ";

        public Nokia(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria) { }

        public override void InstalarAplicativo(string nomeApp)
        {
            string infoApp = ObterAplicativoGooglePlay(nomeApp);
            Console.WriteLine($"{infoApp} no Nokia...");
        }

        private static string ObterAplicativoGooglePlay(string nomeApp)
        {
            string url = $"https://play.google.com/store/search?q={nomeApp}&c=apps";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            var linkApp = doc.DocumentNode.SelectSingleNode("//a[@href and contains(@class, 'Qfxief')]");

            if (linkApp != null)
            {
                string hrefValue = linkApp.GetAttributeValue("href", "");

                string appUrl = "https://play.google.com" + hrefValue;

                HtmlDocument appDoc = web.Load(appUrl);

                var h1Element = appDoc.DocumentNode.SelectSingleNode("//h1[@itemprop='name']");

                if (h1Element != null)
                {
                    string nomeCompleto = h1Element.InnerText.Trim();
                    return $"Instalando aplicativo \"{nomeCompleto}\"";
                }
                else
                {
                   return $"Houve um problema ao tentar instalar o \"{nomeApp}\" na Google Play Store";
                }
            }
            else
            {
                return $"O \"{nomeApp}\" não foi encontrado na Google Play Store";
            }
        }
    }
}