using MostriVsEroi.Core.Entities;
using MostriVsEroi.Services;
using System;

namespace MostriVsEroi
{
    public class RegistratiView
    {
        public static void Registrati()
        {
            Console.Clear();
            Console.WriteLine("==== Menu registrazione ====");
            Console.WriteLine();

            Console.Write("USERNAME: ");
            string nome = Console.ReadLine();

            Console.Write("PASSWORD: ");
            string password = Console.ReadLine();

            Giocatore giocatore = new Giocatore(nome, password);
            giocatore = GiocatoreServices.VerificaRegistrazione(giocatore);
            
            if(giocatore.Nome!=null)
            {
                Console.WriteLine();
                Console.WriteLine("REGISTRAZIONE AVVENUTA CON SUCCESSO! ORA PUOI INIZIARE A GIOCARE..");
                Console.WriteLine();
                Console.WriteLine();
                Menu.MenuNotAdmin(giocatore);
            }
            else
            {
                Menu.Start();
            }
            
        }
    }
}