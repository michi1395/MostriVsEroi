using MostriVsEroi.Core.Entities;
using System;
using MostriVsEroi.DbRepository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Services
{
    public class GiocatoreServices
    {
        static GiocatoreRepository gr = new GiocatoreRepository();
        public static Giocatore VerificaAutenticazione(Giocatore giocatore)
        {
            return gr.GetPlayerByUserPsw(giocatore);
        }
        public static Giocatore VerificaRegistrazione(Giocatore giocatore)
        {
            return gr.AddUserPsw(giocatore);
        }
    }
}
