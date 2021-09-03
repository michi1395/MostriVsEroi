using MostriVsEroi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MostriVsEroi.Core.Entities;

namespace MostriVsEroi
{
    internal class GiocaView
    {
        internal static void Gioca(Giocatore giocatore)
        {
            Console.WriteLine("Inizia a GIOCARE");
            Console.WriteLine();
            
            // Scelta dell'eroe
            Eroe eroe = ScegliEroe(giocatore);
            // Scelta del mostro
            Mostro mostro = MostroServices.ScegliMostro(eroe);
            Console.WriteLine();
            Console.WriteLine("Il sistema ha scelto per te il MOSTRO:");
            Console.WriteLine();
            Console.WriteLine("{0,20}{1,20}{2,20}{3,10}{4,20}{5,10}", "Nome", "Classe", "Arma", "PDanno", "PVita", "Livello");
            Console.WriteLine("{0,20}{1,20}{2,20}{3,10}{4,20}{5,10}", mostro.Nome,mostro.Categoria.Nome,mostro.Arma.Nome,mostro.Arma.PuntiDanno,mostro.PuntiVita,mostro.Livello);
            // Partita

            int partita=StartPartita(eroe,mostro);

            switch(partita)
            {
                case 0:
                    eroe.PuntiAccumulati = eroe.PuntiAccumulati - (5 * mostro.Livello);
                    break;
                case 1:
                    eroe.PuntiAccumulati = eroe.PuntiAccumulati + (10 * mostro.Livello);
                    break;
                case 2:
                    eroe.PuntiAccumulati = eroe.PuntiAccumulati;
                    break;
            }


            // Calcolare i vari punteggi
            // Verifica nuovo punteggio Eroe
            // nuovo livello eroe
            // nuovo stato utente
        }

        private static int StartPartita(Eroe eroe, Mostro mostro)
        {
            // Chiede all'utente se vuole attaccare o fuggire
            // Dentro un ciclo -> o vita m o vita e <= 0
            // Se attacca
            // Il mostro attacca
            // Se fugge
            // Il mostro attacca

            do
            {
                Console.WriteLine();
                Console.WriteLine("Vuoi attaccare il mostro? \n [1] SI \n [2] NO");
                int num = CheckChoice();
                if(num==1)
                {
                    mostro.PuntiVita = mostro.PuntiVita - eroe.Arma.PuntiDanno;
                    if (mostro.PuntiVita < 0)
                    {
                        mostro.PuntiVita = 0;
                    }
                    Console.WriteLine($"Hai sottratto {eroe.Arma.PuntiDanno} al mostro...ora ha {mostro.PuntiVita} punti");
                    Console.WriteLine();
                    Console.WriteLine("E' il turno del mostro...");
                    Console.WriteLine("Il mostro ti attacca....");
                    eroe.PuntiVita = eroe.PuntiVita - mostro.Arma.PuntiDanno;
                    if (eroe.PuntiVita < 0)
                    {
                        eroe.PuntiVita = 0;
                    }
                    Console.WriteLine($"Hai perso {mostro.Arma.PuntiDanno} Punti Danno...ora hai {eroe.PuntiVita} punti");

                }
                else
                {
                    Random random = new Random();
                    int fuga = random.Next(0, 2);
                    if(fuga==1)
                    {
                        Console.WriteLine(" Sei riuscito a fuggire!");
                        return 0;
                    }
                    else
                    {
                        Console.WriteLine("Il mostro ti attacca....");
                        eroe.PuntiVita = eroe.PuntiVita - mostro.Arma.PuntiDanno;
                        if (eroe.PuntiVita<0)
                        {
                            eroe.PuntiVita = 0;
                        }
                        
                        Console.WriteLine($"Hai perso {mostro.Arma.PuntiDanno} Punti Danno...ora hai {eroe.PuntiVita} punti");
                        Console.WriteLine();
                        Console.WriteLine("Attacca per vincere la partita...");
                        mostro.PuntiVita = mostro.PuntiVita - eroe.Arma.PuntiDanno;
                        if (mostro.PuntiVita < 0)
                        {
                            mostro.PuntiVita = 0;
                        }
                        Console.WriteLine($"Hai sottratto {eroe.Arma.PuntiDanno} al mostro...ora ha {mostro.PuntiVita} punti");
                    }

                }

            } while (eroe.PuntiVita!=0 && mostro.PuntiVita!=0);

            if (eroe.PuntiVita != 0)
            {
                Console.WriteLine("HAI VINTO: sei riuscito a battere il mostro!");
                return 1;
            }
            else
                Console.WriteLine("HAI PERSO... :(");
                return 2;
            // Eroe ha vinto o ha perso o è fuggito
        }

        private static int CheckChoice()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 2)
            {
                Console.WriteLine("Puoi inserire solo inserire 1 o 2! Riprova:");
            }

            return num;
        }

        public static Eroe ScegliEroe(Giocatore giocatore)
        {
            // Visualizza gli eroi del giocatore
            List<Eroe> eroi = EroeServices.GetEroi(giocatore);
            //Stampare gli eroi

            Console.WriteLine("{0,5}{1,20}{2,20}{3,20}{4,10}{5,20}{6,10}{7,10}", "# Eroe", "Nome", "Classe", "Arma", "PDanno", "PAccumulati", "PVita", "Livello");
            int count = 1;
            foreach (Eroe er in eroi)
            {
                Console.WriteLine("{0,5}{1,20}{2,20}{3,20}{4,10}{5,20}{6,10}{7,10}", count, er.Nome, er.Categoria.Nome, er.Arma.Nome, er.Arma.PuntiDanno, er.PuntiAccumulati, er.PuntiVita, er.Livello);
                count++;
            }
            Console.WriteLine();
            Console.Write(" > Scegli il tuo eroe: ");
            int numAr = 0;
            bool isInt1 = false;
            do
            {
                isInt1 = int.TryParse(Console.ReadLine(), out numAr);
            } while (!isInt1 || numAr < 0 || numAr > eroi.Count);

            Eroe eroeScelto = eroi.ElementAt(numAr - 1);


            //Dentro un ciclo che verifica che l'eroe scelto sia compreso nella lista degli eroi
            return eroeScelto;
        }

    }
}