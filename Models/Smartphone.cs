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

        public void Ligar()
        {
            Console.WriteLine("Fazendo ligação para: ");
        }

        public void ReceberLigacao()
        {
            Console.WriteLine("Recebendo ligação de: ");
        }

        public abstract void InstalarAplicativo(string nomeApp);
    }
}