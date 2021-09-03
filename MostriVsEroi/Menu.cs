
using MostriVsEroi.Core.Entities;
using System;

namespace MostriVsEroi
{
    class Menu
    {
        public static void Start()
        {
            bool continuare = true;
            bool isInt = false;
            int scelta;

            Console.WriteLine("------------- MOSTRI VS EROI --------------");
            Console.WriteLine();
            Console.WriteLine("============================================");
            Console.WriteLine();

            do
            {

                Console.WriteLine("[1] ACCEDI");
                Console.WriteLine("[2] REGISTRATI");
                Console.WriteLine("[3] ESCI");
                Console.Write("> ");

                isInt = int.TryParse(Console.ReadLine(), out scelta);

                switch (scelta)
                {
                    case 1:
                        AccediView.Accedi();
                        break;

                    case 2:
                        RegistratiView.Registrati();
                        break;

                    case 3:
                        
                        Console.Clear();
                        Console.WriteLine("Ciao, alla prossima partita!");
                        continuare = false;
                        break;

                    default:
                        Console.WriteLine("Scelta errata! RIPROVA ...");
                        break;

                }

            } while (continuare);

        }

        internal static void MenuNotAdmin(Giocatore giocatore)
        {
            bool vuoiContinuare = true;
            bool isInt = false;
            int scelta;

            do
            {
                
                Console.WriteLine("--------  Menu Utente non ADMIN  --------");
                Console.WriteLine();
                Console.WriteLine("============================================");
                Console.WriteLine();
                Console.WriteLine($"Ciao {giocatore.Nome}");
                Console.WriteLine();
                Console.WriteLine("Cosa vuoi fare?");

                Console.WriteLine("[1] Giocare");
                Console.WriteLine("[2] Creare un nuovo eroe");
                Console.WriteLine("[3] Eliminare un eroe");
                Console.WriteLine("[4] ESCI");

                isInt = int.TryParse(Console.ReadLine(), out scelta);

                switch (scelta)
                {
                    case 1:
                        GiocaView.Gioca(giocatore);
                        break;

                    case 2:
                        CreaNuovoEroeView.CreaNuovoEroe(giocatore);
                        break;

                    case 3:
                        EliminaEroeView.EliminaEroe(giocatore);
                        break;

                    case 4:
                        Console.Clear();
                        Start();
                        vuoiContinuare = false;
                        break;

                    default:
                        Console.WriteLine("Scelta errata! RIPROVA ...");
                        break;
                }

            } while (vuoiContinuare);
        }

        internal static void MenuAdmin(Giocatore giocatore)
        {
            bool vuoiContinuare = true;
            bool isInt = false;
            int scelta;

            do
            {
                
                Console.WriteLine("--------  Menu Utente ADMIN  --------");
                Console.WriteLine();
                Console.WriteLine("============================================");
                Console.WriteLine($"Ciao {giocatore.Nome}");

                Console.WriteLine("Cosa vuoi fare?");

                Console.WriteLine("[1] Giocare");
                Console.WriteLine("[2] Creare un nuovo eroe");
                Console.WriteLine("[3] Eliminare un eroe");
                Console.WriteLine("[4] Creare un nuovo mostro");
                Console.WriteLine("[5] Mostrare la classifica globale");
                Console.WriteLine("[6] ESCI");

                isInt = int.TryParse(Console.ReadLine(), out scelta);

                switch (scelta)
                {
                    case 1:
                        GiocaView.Gioca(giocatore);
                        break;

                    case 2:
                        CreaNuovoEroeView.CreaNuovoEroe(giocatore);
                        break;

                    case 3:
                        EliminaEroeView.EliminaEroe(giocatore);
                        break;

                    case 4:
                        CreaNuovoMostro.NuovoMostro(giocatore);
                        break;
                    case 5:
                        ClassificaView.Classifica();
                        break;

                    case 6:
                        Start();
                        vuoiContinuare = false;
                        break;

                    default:
                        Console.WriteLine("Scelta errata! RIPROVA ...");
                        break;
                }

            } while (vuoiContinuare);
        }




    }

}