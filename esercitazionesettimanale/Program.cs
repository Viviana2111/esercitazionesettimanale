using System.Globalization;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace esercitazionesettimanale
{
    //Creo la classe contribuente richiesta dalla traccia
    class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string DataDiNascita { get; set; }
        public string CF { get; set; }
        public string Sesso { get; set; }
        public string ComuneDiResidenza { get; set; }
        public decimal RedditoAnnuale { get; set; }

        // creo un Costruttore con
        // richieste di dati indicati dalla traccia

        public Contribuente(string nome, string cognome, string datadinascita, string cf, string sesso, string comunediresidenza, decimal redditoannuale)
        {

            Nome = nome;
            Cognome = cognome;
            DataDiNascita = datadinascita;
            CF = cf;
            Sesso = sesso;
            ComuneDiResidenza = comunediresidenza;
            RedditoAnnuale = redditoannuale;

        }
        // metodo che mi permette di calcolare la giusta aliquota in base al reddito dichiarato
        public decimal Pagare()

        {
            decimal aliquota;


            if (RedditoAnnuale >= 0 && RedditoAnnuale <= 15000)
            {
                aliquota = RedditoAnnuale * 23 / 100;


            }
            else
            if (RedditoAnnuale >= 15001 && RedditoAnnuale <= 28000)
            {
                aliquota = 3450 + (RedditoAnnuale - 15000) * 27 / 100;

            }
            else
            if (RedditoAnnuale >= 28001 && RedditoAnnuale <= 55000)
            {
                aliquota = 6960 + (RedditoAnnuale - 28000) * 38 / 100;
            }
            else
            if (RedditoAnnuale >= 55001 && RedditoAnnuale <= 75000)
            {
                aliquota = 17220 + (RedditoAnnuale - 55000) * 41 / 100;
            }
            else

            {
                aliquota = 25420 + (RedditoAnnuale - 75000) * 42 / 100;

            }

            return aliquota;

        }

    }
    internal class Program
    {
        static void Main(string[] args)

        {   // ho testato il programma anche inserendo altre variabili e al posto di 59000 e i risultati escono corretti

            Contribuente c = new Contribuente("Viviana", "Foschi", "21/11", "cfvf00", "femmina", "Roma", 59000);
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // qui decido di assegnare una variabile anche se non necessaria in quanto sostituendo a Pagare() alla x
            // di riga 92 il programma partina lo stesso

            decimal x = c.Pagare(); // variabile dichiarata ma non strettamente necessaria

            // writeline che mi permettono di visualizzare la schermata 

            Console.WriteLine("==================================================");
            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
            Console.WriteLine();
            Console.WriteLine($"Contribuente: {c.Nome} {c.Cognome},");
            Console.WriteLine($"nato il {c.DataDiNascita} ({c.Sesso}),");
            Console.WriteLine($"residente in {c.ComuneDiResidenza},");
            Console.WriteLine($"codice fiscale: {c.CF}");
            Console.WriteLine();
            Console.WriteLine($"Reddito dichiarato: € {c.RedditoAnnuale}");
            Console.WriteLine();
            Console.WriteLine("IMPOSTA DA VERSARE: € {0}", x);
            Console.WriteLine("==================================================");
                    


        }
    }
}