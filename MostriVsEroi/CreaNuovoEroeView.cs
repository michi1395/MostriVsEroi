
using MostriVsEroi.Core.Entities;
using MostriVsEroi.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MostriVsEroi
{
     public class CreaNuovoEroeView
    {
        public static void CreaNuovoEroe(Giocatore giocatore)
        {
            Console.Clear();
            Console.WriteLine("==== SEZIONE CREA NUOVO EROE ====");
            Console.WriteLine();

            Eroe newEroe = new Eroe();
            Console.Write("Inserisci il nome del tuo eroe: ");
            string nome = Console.ReadLine();
            newEroe.Nome = nome;

            List<Categoria> categorie = new List<Categoria>();
            Console.WriteLine("Vuoi un eroe:");
            Console.WriteLine();
            categorie = EroeRepository.MostraCategorie();
            Console.WriteLine("{0,5}{1,20}", "ID", "Categoria");
            foreach (Categoria cat in categorie)
            {
                Console.WriteLine("{0,5}{1,20}", cat.Id, cat.Nome);
            }
            Console.Write("Seleziona il numero eroe: ");
            int numEr = 0;
            bool isInt = false;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out numEr);
            } while (!isInt || numEr < 0 || numEr > categorie.Count);

            Categoria categoriaScelta = categorie.ElementAt(numEr - 1);

            List<Arma> armi = new();
            Console.WriteLine("Inserisci l'arma ");
            Console.WriteLine();
            armi=EroeRepository.MostraArma(categoriaScelta);
            Console.WriteLine("{0,10}{1,20}{2,20}", "# Arma", "Arma", "Punti Danno");
            int count=1;
            foreach (Arma arm in armi)
            {
                Console.WriteLine("{0,10}{1,20}{2,20}", count, arm.Nome, arm.PuntiDanno);
                count++;
            }
            Console.Write("Seleziona il numero arma: ");
            int numAr = 0;
            bool isInt1 = false;
            do
            {
                isInt1 = int.TryParse(Console.ReadLine(), out numAr);
            } while (!isInt1 || numAr < 0 || numAr > armi.Count);

            Arma armaScelta = armi.ElementAt(numAr - 1);

            newEroe.Arma = armaScelta;
            newEroe.Categoria = categoriaScelta;

            EroeRepository.AggiungiEroe(giocatore, newEroe);

            Console.WriteLine();
            Console.WriteLine("EROE AGGIUNTO CORRETTAMENTE!");
            Menu.MenuNotAdmin(giocatore);
        }
    }
}