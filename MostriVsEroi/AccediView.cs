
using MostriVsEroi.Core.Entities;
using MostriVsEroi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi
{
    public class AccediView
    {
        public static void Accedi()
        {
            Console.Clear();
            Console.WriteLine("==== Menu accesso ====");
            Console.WriteLine();

            Console.Write("USERNAME: ");
            string nome = Console.ReadLine();

            Console.Write("PASSWORD: ");
            string password = Console.ReadLine();

            Giocatore giocatore = new Giocatore(nome, password);

            giocatore = GiocatoreServices.VerificaAutenticazione(giocatore);
            if (giocatore.IsAuthenticated && giocatore.IsAdmin)
            {
                Menu.MenuAdmin(giocatore);
            }
            else if (giocatore.IsAuthenticated && !giocatore.IsAdmin)
            {
                Menu.MenuNotAdmin(giocatore);
            }
            else
            {
                Console.WriteLine("Non sei registrato. Registrati");
                Console.Clear();
                Menu.Start();
            }
        }
    }
}