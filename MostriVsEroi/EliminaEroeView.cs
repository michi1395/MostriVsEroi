
using MostriVsEroi.Core.Entities;
using MostriVsEroi.DbRepository;
using MostriVsEroi.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MostriVsEroi
{
    internal class EliminaEroeView
    {
        public static void EliminaEroe(Giocatore giocatore)
        {
            List<Eroe> eroi = EroeServices.GetEroi(giocatore);
           
            Console.WriteLine("Quale eroe vuoi eliminare?");
            Console.WriteLine();
            Console.WriteLine("{0,5}{1,20}{2,20}{3,20}{4,10}{5,20}{6,10}{7,10}", "# Eroe", "Nome", "Classe","Arma","PDanno","PAccumulati","PVita","Livello");
            int count = 1;
            foreach(Eroe er in eroi)
            {
                Console.WriteLine("{0,5}{1,20}{2,20}{3,20}{4,10}{5,20}{6,10}{7,10}", count, er.Nome, er.Categoria.Nome, er.Arma.Nome, er.Arma.PuntiDanno, er.PuntiAccumulati, er.PuntiVita, er.Livello);
                count++;
            }
            int numAr = 0;
            bool isInt1 = false;
            do
            {
                isInt1 = int.TryParse(Console.ReadLine(), out numAr);
            } while (!isInt1 || numAr < 0 || numAr > eroi.Count);

            Eroe eroeScelto = eroi.ElementAt(numAr - 1);
            EroeRepository.EliminaEroe(eroeScelto);

            Console.WriteLine("Attendi....");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("EROE ELIMINATO CON SUCCESSO!!");


        }
    }
}