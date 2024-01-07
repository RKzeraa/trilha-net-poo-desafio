using System;

namespace DesafioPOO.Models
{
    public abstract class Smartphone
    {
        public string Numero { get; set; }
        private string _modelo;
        private string _IMEI;
        private int _memoria;

        public Smartphone(string numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            _modelo = modelo;
            _IMEI = imei;
            _memoria = memoria;
        }

        public void Ligar(string numeroEscolhido)
        {
            Console.WriteLine($"Fazendo ligação para: {numeroEscolhido}");
        }

        public void ReceberLigacao(string numeroOrigem)
        {
            Console.WriteLine($"Recebendo ligação de: {numeroOrigem}");
        }

        public abstract void InstalarAplicativo(string nomeApp);
    }
}