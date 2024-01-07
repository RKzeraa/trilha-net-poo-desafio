using HtmlAgilityPack;

namespace DesafioPOO.Models
{
    public class Nokia : Smartphone
    {
        public readonly string Logo = @"
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
            string[] classesParaBuscar = { "Qfxief", "Si6A0c Gy4nib" };
            var (linkApp,classeBuscada) = SelecionarLinkApp(doc, classesParaBuscar);

            if (linkApp == null)
            {
                return $"O \"{nomeApp}\" não foi encontrado na Google Play Store";
            }

            if (classeBuscada == "Si6A0c Gy4nib")
            {

                var spanElements = doc.DocumentNode.SelectNodes("//span[@class='DdYX5']");
                var filteredSpanElements = spanElements
                                               ?.Where(spanNode => spanNode.InnerText.Contains(nomeApp, StringComparison.InvariantCultureIgnoreCase))
                                           ?? Enumerable.Empty<HtmlNode>();

                var htmlNodes = filteredSpanElements.ToList();
                if (htmlNodes.Any())
                {
                    Console.WriteLine("Resultados encontrados:");

                    int i = 1;
                    foreach (var result in htmlNodes)
                    {
                        Console.WriteLine($"{i}. {result.InnerText.Trim()}");
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

                            var resultadoEscolhido = htmlNodes.ElementAt(escolha - 1);

                            string nomeCompleto = resultadoEscolhido.InnerText.Trim();

                            return $"Instalando aplicativo \"{nomeCompleto}\"";
                        }

                        Console.WriteLine("Escolha inválida. Tente novamente.");

                    }

                }

                return $"O \"{nomeApp}\" não foi encontrado na Google Play Store";
            }

            string href2Value = linkApp.GetAttributeValue("href", "");

            string app2Url = "https://play.google.com" + href2Value;

            HtmlDocument app2Doc = web.Load(app2Url);

            var h1Element = app2Doc.DocumentNode.SelectSingleNode("//h1[@itemprop='name']");

            string nome2Completo = h1Element.InnerText.Trim();

            return nome2Completo.Contains(nomeApp)
                ? $"Instalando aplicativo \"{nome2Completo}\""
                : $"Houve um problema ao tentar instalar o \"{nomeApp}\" na Google Play Store";

        }

        private static (HtmlNode, string) SelecionarLinkApp(HtmlDocument doc, string[] classes)
        {
            foreach (var classValue in classes)
            {
                var selector = $"//a[@href and contains(@class, '{classValue}')]";
                var linkApp = doc.DocumentNode.SelectSingleNode(selector);

                if (linkApp != null)
                {
                    return (linkApp, classValue);
                }
            }

            return (null, null);
        }
    }
}