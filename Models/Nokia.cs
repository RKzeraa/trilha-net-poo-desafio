namespace DesafioPOO.Models
{
    // TODO: Herdar da classe "Smartphone"
    public class Nokia : Smartphone
    {
        string _logo = @"
    _   ______  __ __ _______ 
   / | / / __ \/ //_//  _/   |
  /  |/ / / / / ,<   / // /| |
 / /|  / /_/ / /| |_/ // ___ |
/_/ |_/\____/_/ |_/___/_/  |_|        
            ";

        public Nokia(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria)
        {
            Console.WriteLine(_logo);
        }

        // TODO: Sobrescrever o método "InstalarAplicativo"
        public override void InstalarAplicativo(string nomeApp)
        {
            Console.WriteLine($"Instalando aplicativo \"{nomeApp}\" no Nokia...");
        }
    }
}