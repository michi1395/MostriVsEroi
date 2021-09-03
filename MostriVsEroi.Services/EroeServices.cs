using MostriVsEroi.Core.Entities;
using MostriVsEroi.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Services
{
    public class EroeServices
    {
        static EroeRepository er = new EroeRepository();
        public static List<Eroe> GetEroi(Giocatore giocatore)
        {
            List<Eroe> myList = er.FetchByID(giocatore);

            return myList;

        }

    }
}
